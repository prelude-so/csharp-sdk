using System;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.VerificationManagement;

namespace PreludeSdk.Tests.Models.VerificationManagement;

public class VerificationManagementListPhoneNumbersParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VerificationManagementListPhoneNumbersParams
        {
            Action = VerificationManagementListPhoneNumbersParamsAction.Allow,
        };

        ApiEnum<string, VerificationManagementListPhoneNumbersParamsAction> expectedAction =
            VerificationManagementListPhoneNumbersParamsAction.Allow;

        Assert.Equal(expectedAction, parameters.Action);
    }

    [Fact]
    public void Url_Works()
    {
        VerificationManagementListPhoneNumbersParams parameters = new()
        {
            Action = VerificationManagementListPhoneNumbersParamsAction.Allow,
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
        var parameters = new VerificationManagementListPhoneNumbersParams
        {
            Action = VerificationManagementListPhoneNumbersParamsAction.Allow,
        };

        VerificationManagementListPhoneNumbersParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class VerificationManagementListPhoneNumbersParamsActionTest : TestBase
{
    [Theory]
    [InlineData(VerificationManagementListPhoneNumbersParamsAction.Allow)]
    [InlineData(VerificationManagementListPhoneNumbersParamsAction.Block)]
    public void Validation_Works(VerificationManagementListPhoneNumbersParamsAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationManagementListPhoneNumbersParamsAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationManagementListPhoneNumbersParamsAction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerificationManagementListPhoneNumbersParamsAction.Allow)]
    [InlineData(VerificationManagementListPhoneNumbersParamsAction.Block)]
    public void SerializationRoundtrip_Works(
        VerificationManagementListPhoneNumbersParamsAction rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationManagementListPhoneNumbersParamsAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationManagementListPhoneNumbersParamsAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationManagementListPhoneNumbersParamsAction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationManagementListPhoneNumbersParamsAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
