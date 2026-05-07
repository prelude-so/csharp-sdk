using System;
using System.Collections.Generic;
using System.Text.Json;
using Prelude.Core;
using Prelude.Exceptions;
using Prelude.Models.Notify;

namespace Prelude.Tests.Models.Notify;

public class NotifyListSubscriptionPhoneNumberEventsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumberEventsResponse
        {
            Events =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumber = "+33612345678",
                    Source = EventSource.MoKeyword,
                    State = EventState.Sub,
                    Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],
            NextCursor = "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==",
        };

        List<Event> expectedEvents =
        [
            new()
            {
                ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                PhoneNumber = "+33612345678",
                Source = EventSource.MoKeyword,
                State = EventState.Sub,
                Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                Reason = "STOP",
            },
        ];
        string expectedNextCursor =
            "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==";

        Assert.Equal(expectedEvents.Count, model.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], model.Events[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumberEventsResponse
        {
            Events =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumber = "+33612345678",
                    Source = EventSource.MoKeyword,
                    State = EventState.Sub,
                    Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],
            NextCursor = "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<NotifyListSubscriptionPhoneNumberEventsResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumberEventsResponse
        {
            Events =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumber = "+33612345678",
                    Source = EventSource.MoKeyword,
                    State = EventState.Sub,
                    Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],
            NextCursor = "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<NotifyListSubscriptionPhoneNumberEventsResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<Event> expectedEvents =
        [
            new()
            {
                ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                PhoneNumber = "+33612345678",
                Source = EventSource.MoKeyword,
                State = EventState.Sub,
                Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                Reason = "STOP",
            },
        ];
        string expectedNextCursor =
            "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==";

        Assert.Equal(expectedEvents.Count, deserialized.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], deserialized.Events[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumberEventsResponse
        {
            Events =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumber = "+33612345678",
                    Source = EventSource.MoKeyword,
                    State = EventState.Sub,
                    Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],
            NextCursor = "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumberEventsResponse
        {
            Events =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumber = "+33612345678",
                    Source = EventSource.MoKeyword,
                    State = EventState.Sub,
                    Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("next_cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumberEventsResponse
        {
            Events =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumber = "+33612345678",
                    Source = EventSource.MoKeyword,
                    State = EventState.Sub,
                    Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumberEventsResponse
        {
            Events =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumber = "+33612345678",
                    Source = EventSource.MoKeyword,
                    State = EventState.Sub,
                    Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("next_cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumberEventsResponse
        {
            Events =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumber = "+33612345678",
                    Source = EventSource.MoKeyword,
                    State = EventState.Sub,
                    Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumberEventsResponse
        {
            Events =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumber = "+33612345678",
                    Source = EventSource.MoKeyword,
                    State = EventState.Sub,
                    Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],
            NextCursor = "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==",
        };

        NotifyListSubscriptionPhoneNumberEventsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Event
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = EventSource.MoKeyword,
            State = EventState.Sub,
            Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Reason = "STOP",
        };

        string expectedConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9";
        string expectedPhoneNumber = "+33612345678";
        ApiEnum<string, EventSource> expectedSource = EventSource.MoKeyword;
        ApiEnum<string, EventState> expectedState = EventState.Sub;
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z");
        string expectedReason = "STOP";

        Assert.Equal(expectedConfigID, model.ConfigID);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Event
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = EventSource.MoKeyword,
            State = EventState.Sub,
            Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Reason = "STOP",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Event
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = EventSource.MoKeyword,
            State = EventState.Sub,
            Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Reason = "STOP",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9";
        string expectedPhoneNumber = "+33612345678";
        ApiEnum<string, EventSource> expectedSource = EventSource.MoKeyword;
        ApiEnum<string, EventState> expectedState = EventState.Sub;
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z");
        string expectedReason = "STOP";

        Assert.Equal(expectedConfigID, deserialized.ConfigID);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Event
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = EventSource.MoKeyword,
            State = EventState.Sub,
            Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Reason = "STOP",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Event
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = EventSource.MoKeyword,
            State = EventState.Sub,
            Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Event
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = EventSource.MoKeyword,
            State = EventState.Sub,
            Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Event
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = EventSource.MoKeyword,
            State = EventState.Sub,
            Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),

            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Event
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = EventSource.MoKeyword,
            State = EventState.Sub,
            Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),

            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Event
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = EventSource.MoKeyword,
            State = EventState.Sub,
            Timestamp = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Reason = "STOP",
        };

        Event copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventSourceTest : TestBase
{
    [Theory]
    [InlineData(EventSource.MoKeyword)]
    [InlineData(EventSource.Api)]
    [InlineData(EventSource.CsvImport)]
    [InlineData(EventSource.CarrierDisconnect)]
    public void Validation_Works(EventSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventSource.MoKeyword)]
    [InlineData(EventSource.Api)]
    [InlineData(EventSource.CsvImport)]
    [InlineData(EventSource.CarrierDisconnect)]
    public void SerializationRoundtrip_Works(EventSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EventStateTest : TestBase
{
    [Theory]
    [InlineData(EventState.Sub)]
    [InlineData(EventState.Unsub)]
    public void Validation_Works(EventState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventState.Sub)]
    [InlineData(EventState.Unsub)]
    public void SerializationRoundtrip_Works(EventState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
