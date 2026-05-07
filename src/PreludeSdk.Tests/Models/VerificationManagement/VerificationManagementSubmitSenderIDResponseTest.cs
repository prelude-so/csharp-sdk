using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.VerificationManagement;

namespace PreludeSdk.Tests.Models.VerificationManagement;

public class VerificationManagementSubmitSenderIDResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerificationManagementSubmitSenderIDResponse
        {
            SenderID = "sender_id",
            Status = VerificationManagementSubmitSenderIDResponseStatus.Approved,
            Reason = "reason",
        };

        string expectedSenderID = "sender_id";
        ApiEnum<string, VerificationManagementSubmitSenderIDResponseStatus> expectedStatus =
            VerificationManagementSubmitSenderIDResponseStatus.Approved;
        string expectedReason = "reason";

        Assert.Equal(expectedSenderID, model.SenderID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerificationManagementSubmitSenderIDResponse
        {
            SenderID = "sender_id",
            Status = VerificationManagementSubmitSenderIDResponseStatus.Approved,
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerificationManagementSubmitSenderIDResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerificationManagementSubmitSenderIDResponse
        {
            SenderID = "sender_id",
            Status = VerificationManagementSubmitSenderIDResponseStatus.Approved,
            Reason = "reason",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerificationManagementSubmitSenderIDResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSenderID = "sender_id";
        ApiEnum<string, VerificationManagementSubmitSenderIDResponseStatus> expectedStatus =
            VerificationManagementSubmitSenderIDResponseStatus.Approved;
        string expectedReason = "reason";

        Assert.Equal(expectedSenderID, deserialized.SenderID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerificationManagementSubmitSenderIDResponse
        {
            SenderID = "sender_id",
            Status = VerificationManagementSubmitSenderIDResponseStatus.Approved,
            Reason = "reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerificationManagementSubmitSenderIDResponse
        {
            SenderID = "sender_id",
            Status = VerificationManagementSubmitSenderIDResponseStatus.Approved,
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerificationManagementSubmitSenderIDResponse
        {
            SenderID = "sender_id",
            Status = VerificationManagementSubmitSenderIDResponseStatus.Approved,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerificationManagementSubmitSenderIDResponse
        {
            SenderID = "sender_id",
            Status = VerificationManagementSubmitSenderIDResponseStatus.Approved,

            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerificationManagementSubmitSenderIDResponse
        {
            SenderID = "sender_id",
            Status = VerificationManagementSubmitSenderIDResponseStatus.Approved,

            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerificationManagementSubmitSenderIDResponse
        {
            SenderID = "sender_id",
            Status = VerificationManagementSubmitSenderIDResponseStatus.Approved,
            Reason = "reason",
        };

        VerificationManagementSubmitSenderIDResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerificationManagementSubmitSenderIDResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(VerificationManagementSubmitSenderIDResponseStatus.Approved)]
    [InlineData(VerificationManagementSubmitSenderIDResponseStatus.Pending)]
    [InlineData(VerificationManagementSubmitSenderIDResponseStatus.Rejected)]
    public void Validation_Works(VerificationManagementSubmitSenderIDResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationManagementSubmitSenderIDResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationManagementSubmitSenderIDResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerificationManagementSubmitSenderIDResponseStatus.Approved)]
    [InlineData(VerificationManagementSubmitSenderIDResponseStatus.Pending)]
    [InlineData(VerificationManagementSubmitSenderIDResponseStatus.Rejected)]
    public void SerializationRoundtrip_Works(
        VerificationManagementSubmitSenderIDResponseStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationManagementSubmitSenderIDResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationManagementSubmitSenderIDResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationManagementSubmitSenderIDResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationManagementSubmitSenderIDResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
