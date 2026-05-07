using System;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.VerificationManagement;

namespace PreludeSdk.Tests.Models.VerificationManagement;

public class VerificationManagementSetPhoneNumberParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VerificationManagementSetPhoneNumberParams
        {
            Action = VerificationManagementSetPhoneNumberParamsAction.Allow,
            PhoneNumber = "+30123456789",
        };

        ApiEnum<string, VerificationManagementSetPhoneNumberParamsAction> expectedAction =
            VerificationManagementSetPhoneNumberParamsAction.Allow;
        string expectedPhoneNumber = "+30123456789";

        Assert.Equal(expectedAction, parameters.Action);
        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
    }

    [Fact]
    public void Url_Works()
    {
        VerificationManagementSetPhoneNumberParams parameters = new()
        {
            Action = VerificationManagementSetPhoneNumberParamsAction.Allow,
            PhoneNumber = "+30123456789",
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.prelude.dev/v2/verification/management/phone-numbers/allow"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VerificationManagementSetPhoneNumberParams
        {
            Action = VerificationManagementSetPhoneNumberParamsAction.Allow,
            PhoneNumber = "+30123456789",
        };

        VerificationManagementSetPhoneNumberParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class VerificationManagementSetPhoneNumberParamsActionTest : TestBase
{
    [Theory]
    [InlineData(VerificationManagementSetPhoneNumberParamsAction.Allow)]
    [InlineData(VerificationManagementSetPhoneNumberParamsAction.Block)]
    public void Validation_Works(VerificationManagementSetPhoneNumberParamsAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationManagementSetPhoneNumberParamsAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationManagementSetPhoneNumberParamsAction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerificationManagementSetPhoneNumberParamsAction.Allow)]
    [InlineData(VerificationManagementSetPhoneNumberParamsAction.Block)]
    public void SerializationRoundtrip_Works(
        VerificationManagementSetPhoneNumberParamsAction rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationManagementSetPhoneNumberParamsAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationManagementSetPhoneNumberParamsAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationManagementSetPhoneNumberParamsAction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationManagementSetPhoneNumberParamsAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
