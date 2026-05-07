using System;
using System.Collections.Generic;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.Watch;

namespace PreludeSdk.Tests.Models.Watch;

public class WatchSendFeedbacksParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WatchSendFeedbacksParams
        {
            Feedbacks =
            [
                new()
                {
                    Target = new()
                    {
                        Type = FeedbackTargetType.PhoneNumber,
                        Value = "+30123456789",
                    },
                    Type = FeedbackType.VerificationStarted,
                    Metadata = new() { CorrelationID = "correlation_id" },
                },
            ],
        };

        List<Feedback> expectedFeedbacks =
        [
            new()
            {
                Target = new() { Type = FeedbackTargetType.PhoneNumber, Value = "+30123456789" },
                Type = FeedbackType.VerificationStarted,
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
        WatchSendFeedbacksParams parameters = new()
        {
            Feedbacks =
            [
                new()
                {
                    Target = new()
                    {
                        Type = FeedbackTargetType.PhoneNumber,
                        Value = "+30123456789",
                    },
                    Type = FeedbackType.VerificationStarted,
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
        var parameters = new WatchSendFeedbacksParams
        {
            Feedbacks =
            [
                new()
                {
                    Target = new()
                    {
                        Type = FeedbackTargetType.PhoneNumber,
                        Value = "+30123456789",
                    },
                    Type = FeedbackType.VerificationStarted,
                    Metadata = new() { CorrelationID = "correlation_id" },
                },
            ],
        };

        WatchSendFeedbacksParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FeedbackTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Feedback
        {
            Target = new() { Type = FeedbackTargetType.PhoneNumber, Value = "+30123456789" },
            Type = FeedbackType.VerificationStarted,
            Metadata = new() { CorrelationID = "correlation_id" },
        };

        FeedbackTarget expectedTarget = new()
        {
            Type = FeedbackTargetType.PhoneNumber,
            Value = "+30123456789",
        };
        ApiEnum<string, FeedbackType> expectedType = FeedbackType.VerificationStarted;
        FeedbackMetadata expectedMetadata = new() { CorrelationID = "correlation_id" };

        Assert.Equal(expectedTarget, model.Target);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedMetadata, model.Metadata);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Feedback
        {
            Target = new() { Type = FeedbackTargetType.PhoneNumber, Value = "+30123456789" },
            Type = FeedbackType.VerificationStarted,
            Metadata = new() { CorrelationID = "correlation_id" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Feedback>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Feedback
        {
            Target = new() { Type = FeedbackTargetType.PhoneNumber, Value = "+30123456789" },
            Type = FeedbackType.VerificationStarted,
            Metadata = new() { CorrelationID = "correlation_id" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Feedback>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FeedbackTarget expectedTarget = new()
        {
            Type = FeedbackTargetType.PhoneNumber,
            Value = "+30123456789",
        };
        ApiEnum<string, FeedbackType> expectedType = FeedbackType.VerificationStarted;
        FeedbackMetadata expectedMetadata = new() { CorrelationID = "correlation_id" };

        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Feedback
        {
            Target = new() { Type = FeedbackTargetType.PhoneNumber, Value = "+30123456789" },
            Type = FeedbackType.VerificationStarted,
            Metadata = new() { CorrelationID = "correlation_id" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Feedback
        {
            Target = new() { Type = FeedbackTargetType.PhoneNumber, Value = "+30123456789" },
            Type = FeedbackType.VerificationStarted,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Feedback
        {
            Target = new() { Type = FeedbackTargetType.PhoneNumber, Value = "+30123456789" },
            Type = FeedbackType.VerificationStarted,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Feedback
        {
            Target = new() { Type = FeedbackTargetType.PhoneNumber, Value = "+30123456789" },
            Type = FeedbackType.VerificationStarted,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Feedback
        {
            Target = new() { Type = FeedbackTargetType.PhoneNumber, Value = "+30123456789" },
            Type = FeedbackType.VerificationStarted,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Feedback
        {
            Target = new() { Type = FeedbackTargetType.PhoneNumber, Value = "+30123456789" },
            Type = FeedbackType.VerificationStarted,
            Metadata = new() { CorrelationID = "correlation_id" },
        };

        Feedback copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeedbackTargetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeedbackTarget
        {
            Type = FeedbackTargetType.PhoneNumber,
            Value = "+30123456789",
        };

        ApiEnum<string, FeedbackTargetType> expectedType = FeedbackTargetType.PhoneNumber;
        string expectedValue = "+30123456789";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeedbackTarget
        {
            Type = FeedbackTargetType.PhoneNumber,
            Value = "+30123456789",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeedbackTarget>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeedbackTarget
        {
            Type = FeedbackTargetType.PhoneNumber,
            Value = "+30123456789",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeedbackTarget>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, FeedbackTargetType> expectedType = FeedbackTargetType.PhoneNumber;
        string expectedValue = "+30123456789";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeedbackTarget
        {
            Type = FeedbackTargetType.PhoneNumber,
            Value = "+30123456789",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeedbackTarget
        {
            Type = FeedbackTargetType.PhoneNumber,
            Value = "+30123456789",
        };

        FeedbackTarget copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeedbackTargetTypeTest : TestBase
{
    [Theory]
    [InlineData(FeedbackTargetType.PhoneNumber)]
    [InlineData(FeedbackTargetType.EmailAddress)]
    public void Validation_Works(FeedbackTargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeedbackTargetType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeedbackTargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeedbackTargetType.PhoneNumber)]
    [InlineData(FeedbackTargetType.EmailAddress)]
    public void SerializationRoundtrip_Works(FeedbackTargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeedbackTargetType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeedbackTargetType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeedbackTargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeedbackTargetType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FeedbackTypeTest : TestBase
{
    [Theory]
    [InlineData(FeedbackType.VerificationStarted)]
    [InlineData(FeedbackType.VerificationCompleted)]
    public void Validation_Works(FeedbackType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeedbackType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeedbackType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeedbackType.VerificationStarted)]
    [InlineData(FeedbackType.VerificationCompleted)]
    public void SerializationRoundtrip_Works(FeedbackType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeedbackType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeedbackType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeedbackType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeedbackType>>(
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
        var model = new FeedbackMetadata { CorrelationID = "correlation_id" };

        string expectedCorrelationID = "correlation_id";

        Assert.Equal(expectedCorrelationID, model.CorrelationID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeedbackMetadata { CorrelationID = "correlation_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeedbackMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeedbackMetadata { CorrelationID = "correlation_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeedbackMetadata>(
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
        var model = new FeedbackMetadata { CorrelationID = "correlation_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FeedbackMetadata { };

        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FeedbackMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FeedbackMetadata
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
        var model = new FeedbackMetadata
        {
            // Null should be interpreted as omitted for these properties
            CorrelationID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeedbackMetadata { CorrelationID = "correlation_id" };

        FeedbackMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
