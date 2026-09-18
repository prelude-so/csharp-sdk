using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Models.VerificationManagement.Sandbox;

namespace PreludeSdk.Tests.Models.VerificationManagement.Sandbox;

public class SandboxDeletePhoneNumberResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SandboxDeletePhoneNumberResponse { PhoneNumber = "+30123456789" };

        string expectedPhoneNumber = "+30123456789";

        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SandboxDeletePhoneNumberResponse { PhoneNumber = "+30123456789" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SandboxDeletePhoneNumberResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SandboxDeletePhoneNumberResponse { PhoneNumber = "+30123456789" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SandboxDeletePhoneNumberResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPhoneNumber = "+30123456789";

        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SandboxDeletePhoneNumberResponse { PhoneNumber = "+30123456789" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SandboxDeletePhoneNumberResponse { PhoneNumber = "+30123456789" };

        SandboxDeletePhoneNumberResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
