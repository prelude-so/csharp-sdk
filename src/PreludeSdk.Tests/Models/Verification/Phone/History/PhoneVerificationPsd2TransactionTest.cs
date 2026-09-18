using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Models.Verification.Phone.History;

namespace PreludeSdk.Tests.Models.Verification.Phone.History;

public class PhoneVerificationPsd2TransactionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhoneVerificationPsd2Transaction
        {
            Amount = new() { Amount = "0.042", Currency = "EUR" },
            Recipient = "recipient",
        };

        PhoneVerificationMoney expectedAmount = new() { Amount = "0.042", Currency = "EUR" };
        string expectedRecipient = "recipient";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedRecipient, model.Recipient);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhoneVerificationPsd2Transaction
        {
            Amount = new() { Amount = "0.042", Currency = "EUR" },
            Recipient = "recipient",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneVerificationPsd2Transaction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhoneVerificationPsd2Transaction
        {
            Amount = new() { Amount = "0.042", Currency = "EUR" },
            Recipient = "recipient",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneVerificationPsd2Transaction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PhoneVerificationMoney expectedAmount = new() { Amount = "0.042", Currency = "EUR" };
        string expectedRecipient = "recipient";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedRecipient, deserialized.Recipient);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhoneVerificationPsd2Transaction
        {
            Amount = new() { Amount = "0.042", Currency = "EUR" },
            Recipient = "recipient",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PhoneVerificationPsd2Transaction { };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Recipient);
        Assert.False(model.RawData.ContainsKey("recipient"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PhoneVerificationPsd2Transaction { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PhoneVerificationPsd2Transaction
        {
            // Null should be interpreted as omitted for these properties
            Amount = null,
            Recipient = null,
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Recipient);
        Assert.False(model.RawData.ContainsKey("recipient"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PhoneVerificationPsd2Transaction
        {
            // Null should be interpreted as omitted for these properties
            Amount = null,
            Recipient = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhoneVerificationPsd2Transaction
        {
            Amount = new() { Amount = "0.042", Currency = "EUR" },
            Recipient = "recipient",
        };

        PhoneVerificationPsd2Transaction copied = new(model);

        Assert.Equal(model, copied);
    }
}
