using System;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.Verification;

namespace PreludeSdk.Tests.Models.Verification;

public class VerificationCheckParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VerificationCheckParams
        {
            Code = "12345",
            Target = new()
            {
                Type = VerificationCheckParamsTargetType.PhoneNumber,
                Value = "+30123456789",
            },
            Psd2 = new()
            {
                Amount = "99999.99",
                Currency = "EUR",
                Recipient = "Rainbow LLC",
            },
        };

        string expectedCode = "12345";
        VerificationCheckParamsTarget expectedTarget = new()
        {
            Type = VerificationCheckParamsTargetType.PhoneNumber,
            Value = "+30123456789",
        };
        Psd2 expectedPsd2 = new()
        {
            Amount = "99999.99",
            Currency = "EUR",
            Recipient = "Rainbow LLC",
        };

        Assert.Equal(expectedCode, parameters.Code);
        Assert.Equal(expectedTarget, parameters.Target);
        Assert.Equal(expectedPsd2, parameters.Psd2);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VerificationCheckParams
        {
            Code = "12345",
            Target = new()
            {
                Type = VerificationCheckParamsTargetType.PhoneNumber,
                Value = "+30123456789",
            },
        };

        Assert.Null(parameters.Psd2);
        Assert.False(parameters.RawBodyData.ContainsKey("psd2"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VerificationCheckParams
        {
            Code = "12345",
            Target = new()
            {
                Type = VerificationCheckParamsTargetType.PhoneNumber,
                Value = "+30123456789",
            },

            // Null should be interpreted as omitted for these properties
            Psd2 = null,
        };

        Assert.Null(parameters.Psd2);
        Assert.False(parameters.RawBodyData.ContainsKey("psd2"));
    }

    [Fact]
    public void Url_Works()
    {
        VerificationCheckParams parameters = new()
        {
            Code = "12345",
            Target = new()
            {
                Type = VerificationCheckParamsTargetType.PhoneNumber,
                Value = "+30123456789",
            },
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.prelude.dev/v2/verification/check"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VerificationCheckParams
        {
            Code = "12345",
            Target = new()
            {
                Type = VerificationCheckParamsTargetType.PhoneNumber,
                Value = "+30123456789",
            },
            Psd2 = new()
            {
                Amount = "99999.99",
                Currency = "EUR",
                Recipient = "Rainbow LLC",
            },
        };

        VerificationCheckParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class VerificationCheckParamsTargetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerificationCheckParamsTarget
        {
            Type = VerificationCheckParamsTargetType.PhoneNumber,
            Value = "+30123456789",
        };

        ApiEnum<string, VerificationCheckParamsTargetType> expectedType =
            VerificationCheckParamsTargetType.PhoneNumber;
        string expectedValue = "+30123456789";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerificationCheckParamsTarget
        {
            Type = VerificationCheckParamsTargetType.PhoneNumber,
            Value = "+30123456789",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerificationCheckParamsTarget>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerificationCheckParamsTarget
        {
            Type = VerificationCheckParamsTargetType.PhoneNumber,
            Value = "+30123456789",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerificationCheckParamsTarget>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, VerificationCheckParamsTargetType> expectedType =
            VerificationCheckParamsTargetType.PhoneNumber;
        string expectedValue = "+30123456789";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerificationCheckParamsTarget
        {
            Type = VerificationCheckParamsTargetType.PhoneNumber,
            Value = "+30123456789",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerificationCheckParamsTarget
        {
            Type = VerificationCheckParamsTargetType.PhoneNumber,
            Value = "+30123456789",
        };

        VerificationCheckParamsTarget copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerificationCheckParamsTargetTypeTest : TestBase
{
    [Theory]
    [InlineData(VerificationCheckParamsTargetType.PhoneNumber)]
    [InlineData(VerificationCheckParamsTargetType.EmailAddress)]
    public void Validation_Works(VerificationCheckParamsTargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationCheckParamsTargetType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerificationCheckParamsTargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerificationCheckParamsTargetType.PhoneNumber)]
    [InlineData(VerificationCheckParamsTargetType.EmailAddress)]
    public void SerializationRoundtrip_Works(VerificationCheckParamsTargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationCheckParamsTargetType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationCheckParamsTargetType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerificationCheckParamsTargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationCheckParamsTargetType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class Psd2Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Psd2
        {
            Amount = "99999.99",
            Currency = "EUR",
            Recipient = "Rainbow LLC",
        };

        string expectedAmount = "99999.99";
        string expectedCurrency = "EUR";
        string expectedRecipient = "Rainbow LLC";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedRecipient, model.Recipient);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Psd2
        {
            Amount = "99999.99",
            Currency = "EUR",
            Recipient = "Rainbow LLC",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Psd2>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Psd2
        {
            Amount = "99999.99",
            Currency = "EUR",
            Recipient = "Rainbow LLC",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Psd2>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedAmount = "99999.99";
        string expectedCurrency = "EUR";
        string expectedRecipient = "Rainbow LLC";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedRecipient, deserialized.Recipient);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Psd2
        {
            Amount = "99999.99",
            Currency = "EUR",
            Recipient = "Rainbow LLC",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Psd2
        {
            Amount = "99999.99",
            Currency = "EUR",
            Recipient = "Rainbow LLC",
        };

        Psd2 copied = new(model);

        Assert.Equal(model, copied);
    }
}
