using System.Text.Json;
using Prelude.Core;
using Prelude.Exceptions;
using Prelude.Models.Watch;

namespace Prelude.Tests.Models.Watch;

public class WatchSendFeedbacksResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WatchSendFeedbacksResponse
        {
            RequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a",
            Status = WatchSendFeedbacksResponseStatus.Success,
        };

        string expectedRequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a";
        ApiEnum<string, WatchSendFeedbacksResponseStatus> expectedStatus =
            WatchSendFeedbacksResponseStatus.Success;

        Assert.Equal(expectedRequestID, model.RequestID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WatchSendFeedbacksResponse
        {
            RequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a",
            Status = WatchSendFeedbacksResponseStatus.Success,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WatchSendFeedbacksResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WatchSendFeedbacksResponse
        {
            RequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a",
            Status = WatchSendFeedbacksResponseStatus.Success,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WatchSendFeedbacksResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a";
        ApiEnum<string, WatchSendFeedbacksResponseStatus> expectedStatus =
            WatchSendFeedbacksResponseStatus.Success;

        Assert.Equal(expectedRequestID, deserialized.RequestID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WatchSendFeedbacksResponse
        {
            RequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a",
            Status = WatchSendFeedbacksResponseStatus.Success,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WatchSendFeedbacksResponse
        {
            RequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a",
            Status = WatchSendFeedbacksResponseStatus.Success,
        };

        WatchSendFeedbacksResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WatchSendFeedbacksResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(WatchSendFeedbacksResponseStatus.Success)]
    public void Validation_Works(WatchSendFeedbacksResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WatchSendFeedbacksResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WatchSendFeedbacksResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WatchSendFeedbacksResponseStatus.Success)]
    public void SerializationRoundtrip_Works(WatchSendFeedbacksResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WatchSendFeedbacksResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WatchSendFeedbacksResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WatchSendFeedbacksResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WatchSendFeedbacksResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
