using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Models.Verification.Phone.History;

namespace PreludeSdk.Tests.Models.Verification.Phone.History;

public class PhoneVerificationMoneyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhoneVerificationMoney { Amount = "0.042", Currency = "EUR" };

        string expectedAmount = "0.042";
        string expectedCurrency = "EUR";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhoneVerificationMoney { Amount = "0.042", Currency = "EUR" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneVerificationMoney>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhoneVerificationMoney { Amount = "0.042", Currency = "EUR" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneVerificationMoney>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAmount = "0.042";
        string expectedCurrency = "EUR";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhoneVerificationMoney { Amount = "0.042", Currency = "EUR" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhoneVerificationMoney { Amount = "0.042", Currency = "EUR" };

        PhoneVerificationMoney copied = new(model);

        Assert.Equal(model, copied);
    }
}
