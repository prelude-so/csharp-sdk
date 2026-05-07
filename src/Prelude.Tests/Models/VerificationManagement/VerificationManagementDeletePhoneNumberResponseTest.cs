using System.Text.Json;
using Prelude.Core;
using Prelude.Models.VerificationManagement;

namespace Prelude.Tests.Models.VerificationManagement;

public class VerificationManagementDeletePhoneNumberResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerificationManagementDeletePhoneNumberResponse
        {
            PhoneNumber = "+30123456789",
        };

        string expectedPhoneNumber = "+30123456789";

        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerificationManagementDeletePhoneNumberResponse
        {
            PhoneNumber = "+30123456789",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerificationManagementDeletePhoneNumberResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerificationManagementDeletePhoneNumberResponse
        {
            PhoneNumber = "+30123456789",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerificationManagementDeletePhoneNumberResponse>(
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
        var model = new VerificationManagementDeletePhoneNumberResponse
        {
            PhoneNumber = "+30123456789",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerificationManagementDeletePhoneNumberResponse
        {
            PhoneNumber = "+30123456789",
        };

        VerificationManagementDeletePhoneNumberResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
