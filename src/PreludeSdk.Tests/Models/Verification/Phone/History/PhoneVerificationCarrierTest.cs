using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Models.Verification.Phone.History;

namespace PreludeSdk.Tests.Models.Verification.Phone.History;

public class PhoneVerificationCarrierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhoneVerificationCarrier { Mccmnc = "208-01", Name = "Orange" };

        string expectedMccmnc = "208-01";
        string expectedName = "Orange";

        Assert.Equal(expectedMccmnc, model.Mccmnc);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhoneVerificationCarrier { Mccmnc = "208-01", Name = "Orange" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneVerificationCarrier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhoneVerificationCarrier { Mccmnc = "208-01", Name = "Orange" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneVerificationCarrier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMccmnc = "208-01";
        string expectedName = "Orange";

        Assert.Equal(expectedMccmnc, deserialized.Mccmnc);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhoneVerificationCarrier { Mccmnc = "208-01", Name = "Orange" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PhoneVerificationCarrier { Mccmnc = "208-01" };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PhoneVerificationCarrier { Mccmnc = "208-01" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PhoneVerificationCarrier
        {
            Mccmnc = "208-01",

            // Null should be interpreted as omitted for these properties
            Name = null,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PhoneVerificationCarrier
        {
            Mccmnc = "208-01",

            // Null should be interpreted as omitted for these properties
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhoneVerificationCarrier { Mccmnc = "208-01", Name = "Orange" };

        PhoneVerificationCarrier copied = new(model);

        Assert.Equal(model, copied);
    }
}
