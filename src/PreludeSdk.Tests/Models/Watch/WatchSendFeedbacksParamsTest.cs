using System;
using System.Collections.Generic;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using Models = PreludeSdk.Models;
using Watch = PreludeSdk.Models.Watch;

namespace PreludeSdk.Tests.Models.Watch;

public class WatchSendFeedbacksParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Watch::WatchSendFeedbacksParams
        {
            Feedbacks =
            [
                new()
                {
                    Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
                    Type = Watch::Type.VerificationStarted,
                    Metadata = new() { CorrelationID = "correlation_id" },
                },
            ],
        };

        List<Watch::Feedback> expectedFeedbacks =
        [
            new()
            {
                Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
                Type = Watch::Type.VerificationStarted,
                Metadata = new() { CorrelationID = "correlation_id" },
            },
        ];

        Assert.Equal(expectedFeedbacks.Count, parameters.Feedbacks.Count);
        for (int i = 0; i < expectedFeedbacks.Count; i++)
        {
            Assert.Equal(expectedFeedbacks[i], parameters.Feedbacks[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        Watch::WatchSendFeedbacksParams parameters = new()
        {
            Feedbacks =
            [
                new()
                {
                    Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
                    Type = Watch::Type.VerificationStarted,
                    Metadata = new() { CorrelationID = "correlation_id" },
                },
            ],
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.prelude.dev/v2/watch/feedback"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Watch::WatchSendFeedbacksParams
        {
            Feedbacks =
            [
                new()
                {
                    Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
                    Type = Watch::Type.VerificationStarted,
                    Metadata = new() { CorrelationID = "correlation_id" },
                },
            ],
        };

        Watch::WatchSendFeedbacksParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FeedbackTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Watch::Feedback
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
            Type = Watch::Type.VerificationStarted,
            Metadata = new() { CorrelationID = "correlation_id" },
        };

        Models::Target expectedTarget = new()
        {
            Type = Models::Type.PhoneNumber,
            Value = "+30123456789",
        };
        ApiEnum<string, Watch::Type> expectedType = Watch::Type.VerificationStarted;
        Watch::FeedbackMetadata expectedMetadata = new() { CorrelationID = "correlation_id" };

        Assert.Equal(expectedTarget, model.Target);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedMetadata, model.Metadata);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Watch::Feedback
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
            Type = Watch::Type.VerificationStarted,
            Metadata = new() { CorrelationID = "correlation_id" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Watch::Feedback>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Watch::Feedback
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
            Type = Watch::Type.VerificationStarted,
            Metadata = new() { CorrelationID = "correlation_id" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Watch::Feedback>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Models::Target expectedTarget = new()
        {
            Type = Models::Type.PhoneNumber,
            Value = "+30123456789",
        };
        ApiEnum<string, Watch::Type> expectedType = Watch::Type.VerificationStarted;
        Watch::FeedbackMetadata expectedMetadata = new() { CorrelationID = "correlation_id" };

        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Watch::Feedback
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
            Type = Watch::Type.VerificationStarted,
            Metadata = new() { CorrelationID = "correlation_id" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Watch::Feedback
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
            Type = Watch::Type.VerificationStarted,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Watch::Feedback
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
            Type = Watch::Type.VerificationStarted,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Watch::Feedback
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
            Type = Watch::Type.VerificationStarted,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Watch::Feedback
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
            Type = Watch::Type.VerificationStarted,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Watch::Feedback
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
            Type = Watch::Type.VerificationStarted,
            Metadata = new() { CorrelationID = "correlation_id" },
        };

        Watch::Feedback copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Watch::Type.VerificationStarted)]
    [InlineData(Watch::Type.VerificationCompleted)]
    public void Validation_Works(Watch::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Watch::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Watch::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Watch::Type.VerificationStarted)]
    [InlineData(Watch::Type.VerificationCompleted)]
    public void SerializationRoundtrip_Works(Watch::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Watch::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Watch::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Watch::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Watch::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FeedbackMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Watch::FeedbackMetadata { CorrelationID = "correlation_id" };

        string expectedCorrelationID = "correlation_id";

        Assert.Equal(expectedCorrelationID, model.CorrelationID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Watch::FeedbackMetadata { CorrelationID = "correlation_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Watch::FeedbackMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Watch::FeedbackMetadata { CorrelationID = "correlation_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Watch::FeedbackMetadata>(
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
        var model = new Watch::FeedbackMetadata { CorrelationID = "correlation_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Watch::FeedbackMetadata { };

        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Watch::FeedbackMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Watch::FeedbackMetadata
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
        var model = new Watch::FeedbackMetadata
        {
            // Null should be interpreted as omitted for these properties
            CorrelationID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Watch::FeedbackMetadata { CorrelationID = "correlation_id" };

        Watch::FeedbackMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
