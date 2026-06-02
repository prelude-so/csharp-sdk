using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.Verification;

namespace PreludeSdk.Tests.Models.Verification;

public class VerificationCheckResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerificationCheckResponse
        {
            Status = VerificationCheckResponseStatus.Success,
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Metadata = new() { CorrelationID = "correlation_id" },
            RequestID = "request_id",
        };

        ApiEnum<string, VerificationCheckResponseStatus> expectedStatus =
            VerificationCheckResponseStatus.Success;
        string expectedID = "vrf_01jc0t6fwwfgfsq1md24mhyztj";
        VerificationCheckResponseMetadata expectedMetadata = new()
        {
            CorrelationID = "correlation_id",
        };
        string expectedRequestID = "request_id";

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedRequestID, model.RequestID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerificationCheckResponse
        {
            Status = VerificationCheckResponseStatus.Success,
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Metadata = new() { CorrelationID = "correlation_id" },
            RequestID = "request_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerificationCheckResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerificationCheckResponse
        {
            Status = VerificationCheckResponseStatus.Success,
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Metadata = new() { CorrelationID = "correlation_id" },
            RequestID = "request_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerificationCheckResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, VerificationCheckResponseStatus> expectedStatus =
            VerificationCheckResponseStatus.Success;
        string expectedID = "vrf_01jc0t6fwwfgfsq1md24mhyztj";
        VerificationCheckResponseMetadata expectedMetadata = new()
        {
            CorrelationID = "correlation_id",
        };
        string expectedRequestID = "request_id";

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedRequestID, deserialized.RequestID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerificationCheckResponse
        {
            Status = VerificationCheckResponseStatus.Success,
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Metadata = new() { CorrelationID = "correlation_id" },
            RequestID = "request_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerificationCheckResponse
        {
            Status = VerificationCheckResponseStatus.Success,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerificationCheckResponse
        {
            Status = VerificationCheckResponseStatus.Success,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerificationCheckResponse
        {
            Status = VerificationCheckResponseStatus.Success,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Metadata = null,
            RequestID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerificationCheckResponse
        {
            Status = VerificationCheckResponseStatus.Success,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Metadata = null,
            RequestID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerificationCheckResponse
        {
            Status = VerificationCheckResponseStatus.Success,
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Metadata = new() { CorrelationID = "correlation_id" },
            RequestID = "request_id",
        };

        VerificationCheckResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerificationCheckResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(VerificationCheckResponseStatus.Success)]
    [InlineData(VerificationCheckResponseStatus.Failure)]
    [InlineData(VerificationCheckResponseStatus.ExpiredOrNotFound)]
    [InlineData(VerificationCheckResponseStatus.TransactionMissing)]
    [InlineData(VerificationCheckResponseStatus.TransactionMismatch)]
    public void Validation_Works(VerificationCheckResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationCheckResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerificationCheckResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerificationCheckResponseStatus.Success)]
    [InlineData(VerificationCheckResponseStatus.Failure)]
    [InlineData(VerificationCheckResponseStatus.ExpiredOrNotFound)]
    [InlineData(VerificationCheckResponseStatus.TransactionMissing)]
    [InlineData(VerificationCheckResponseStatus.TransactionMismatch)]
    public void SerializationRoundtrip_Works(VerificationCheckResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationCheckResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationCheckResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerificationCheckResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationCheckResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VerificationCheckResponseMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerificationCheckResponseMetadata { CorrelationID = "correlation_id" };

        string expectedCorrelationID = "correlation_id";

        Assert.Equal(expectedCorrelationID, model.CorrelationID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerificationCheckResponseMetadata { CorrelationID = "correlation_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerificationCheckResponseMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerificationCheckResponseMetadata { CorrelationID = "correlation_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerificationCheckResponseMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCorrelationID = "correlation_id";

        Assert.Equal(expectedCorrelationID, deserialized.CorrelationID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerificationCheckResponseMetadata { CorrelationID = "correlation_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerificationCheckResponseMetadata { };

        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerificationCheckResponseMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerificationCheckResponseMetadata
        {
            // Null should be interpreted as omitted for these properties
            CorrelationID = null,
        };

        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerificationCheckResponseMetadata
        {
            // Null should be interpreted as omitted for these properties
            CorrelationID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerificationCheckResponseMetadata { CorrelationID = "correlation_id" };

        VerificationCheckResponseMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
