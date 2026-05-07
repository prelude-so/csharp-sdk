using System;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using VerificationManagement = PreludeSdk.Models.VerificationManagement;

namespace PreludeSdk.Tests.Models.VerificationManagement;

public class VerificationManagementDeletePhoneNumberParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VerificationManagement::VerificationManagementDeletePhoneNumberParams
        {
            Action = VerificationManagement::Action.Allow,
            PhoneNumber = "+30123456789",
        };

        ApiEnum<string, VerificationManagement::Action> expectedAction =
            VerificationManagement::Action.Allow;
        string expectedPhoneNumber = "+30123456789";

        Assert.Equal(expectedAction, parameters.Action);
        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
    }

    [Fact]
    public void Url_Works()
    {
        VerificationManagement::VerificationManagementDeletePhoneNumberParams parameters = new()
        {
            Action = VerificationManagement::Action.Allow,
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
        var parameters = new VerificationManagement::VerificationManagementDeletePhoneNumberParams
        {
            Action = VerificationManagement::Action.Allow,
            PhoneNumber = "+30123456789",
        };

        VerificationManagement::VerificationManagementDeletePhoneNumberParams copied = new(
            parameters
        );

        Assert.Equal(parameters, copied);
    }
}

public class ActionTest : TestBase
{
    [Theory]
    [InlineData(VerificationManagement::Action.Allow)]
    [InlineData(VerificationManagement::Action.Block)]
    public void Validation_Works(VerificationManagement::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationManagement::Action> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerificationManagement::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerificationManagement::Action.Allow)]
    [InlineData(VerificationManagement::Action.Block)]
    public void SerializationRoundtrip_Works(VerificationManagement::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationManagement::Action> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationManagement::Action>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerificationManagement::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationManagement::Action>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
