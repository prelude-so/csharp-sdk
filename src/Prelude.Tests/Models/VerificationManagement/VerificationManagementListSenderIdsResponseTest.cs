using System.Collections.Generic;
using System.Text.Json;
using Prelude.Core;
using Prelude.Exceptions;
using Prelude.Models.VerificationManagement;

namespace Prelude.Tests.Models.VerificationManagement;

public class VerificationManagementListSenderIdsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerificationManagementListSenderIdsResponse
        {
            SenderIds = [new() { SenderIDValue = "sender_id", Status = Status.Approved }],
        };

        List<SenderID> expectedSenderIds =
        [
            new() { SenderIDValue = "sender_id", Status = Status.Approved },
        ];

        Assert.NotNull(model.SenderIds);
        Assert.Equal(expectedSenderIds.Count, model.SenderIds.Count);
        for (int i = 0; i < expectedSenderIds.Count; i++)
        {
            Assert.Equal(expectedSenderIds[i], model.SenderIds[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerificationManagementListSenderIdsResponse
        {
            SenderIds = [new() { SenderIDValue = "sender_id", Status = Status.Approved }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerificationManagementListSenderIdsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerificationManagementListSenderIdsResponse
        {
            SenderIds = [new() { SenderIDValue = "sender_id", Status = Status.Approved }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerificationManagementListSenderIdsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<SenderID> expectedSenderIds =
        [
            new() { SenderIDValue = "sender_id", Status = Status.Approved },
        ];

        Assert.NotNull(deserialized.SenderIds);
        Assert.Equal(expectedSenderIds.Count, deserialized.SenderIds.Count);
        for (int i = 0; i < expectedSenderIds.Count; i++)
        {
            Assert.Equal(expectedSenderIds[i], deserialized.SenderIds[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerificationManagementListSenderIdsResponse
        {
            SenderIds = [new() { SenderIDValue = "sender_id", Status = Status.Approved }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerificationManagementListSenderIdsResponse { };

        Assert.Null(model.SenderIds);
        Assert.False(model.RawData.ContainsKey("sender_ids"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerificationManagementListSenderIdsResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerificationManagementListSenderIdsResponse
        {
            // Null should be interpreted as omitted for these properties
            SenderIds = null,
        };

        Assert.Null(model.SenderIds);
        Assert.False(model.RawData.ContainsKey("sender_ids"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerificationManagementListSenderIdsResponse
        {
            // Null should be interpreted as omitted for these properties
            SenderIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerificationManagementListSenderIdsResponse
        {
            SenderIds = [new() { SenderIDValue = "sender_id", Status = Status.Approved }],
        };

        VerificationManagementListSenderIdsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SenderIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SenderID { SenderIDValue = "sender_id", Status = Status.Approved };

        string expectedSenderIDValue = "sender_id";
        ApiEnum<string, Status> expectedStatus = Status.Approved;

        Assert.Equal(expectedSenderIDValue, model.SenderIDValue);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SenderID { SenderIDValue = "sender_id", Status = Status.Approved };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderID>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SenderID { SenderIDValue = "sender_id", Status = Status.Approved };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderID>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSenderIDValue = "sender_id";
        ApiEnum<string, Status> expectedStatus = Status.Approved;

        Assert.Equal(expectedSenderIDValue, deserialized.SenderIDValue);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SenderID { SenderIDValue = "sender_id", Status = Status.Approved };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SenderID { };

        Assert.Null(model.SenderIDValue);
        Assert.False(model.RawData.ContainsKey("sender_id"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SenderID { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SenderID
        {
            // Null should be interpreted as omitted for these properties
            SenderIDValue = null,
            Status = null,
        };

        Assert.Null(model.SenderIDValue);
        Assert.False(model.RawData.ContainsKey("sender_id"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SenderID
        {
            // Null should be interpreted as omitted for these properties
            SenderIDValue = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SenderID { SenderIDValue = "sender_id", Status = Status.Approved };

        SenderID copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Approved)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Rejected)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Approved)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Rejected)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
