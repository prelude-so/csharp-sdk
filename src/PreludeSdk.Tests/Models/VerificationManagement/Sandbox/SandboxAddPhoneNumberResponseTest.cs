using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Models.VerificationManagement.Sandbox;

namespace PreludeSdk.Tests.Models.VerificationManagement.Sandbox;

public class SandboxAddPhoneNumberResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SandboxAddPhoneNumberResponse
        {
            AttemptCode = "123456",
            PhoneNumber = "+30123456789",
        };

        string expectedAttemptCode = "123456";
        string expectedPhoneNumber = "+30123456789";

        Assert.Equal(expectedAttemptCode, model.AttemptCode);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SandboxAddPhoneNumberResponse
        {
            AttemptCode = "123456",
            PhoneNumber = "+30123456789",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SandboxAddPhoneNumberResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SandboxAddPhoneNumberResponse
        {
            AttemptCode = "123456",
            PhoneNumber = "+30123456789",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SandboxAddPhoneNumberResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAttemptCode = "123456";
        string expectedPhoneNumber = "+30123456789";

        Assert.Equal(expectedAttemptCode, deserialized.AttemptCode);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SandboxAddPhoneNumberResponse
        {
            AttemptCode = "123456",
            PhoneNumber = "+30123456789",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SandboxAddPhoneNumberResponse
        {
            AttemptCode = "123456",
            PhoneNumber = "+30123456789",
        };

        SandboxAddPhoneNumberResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
