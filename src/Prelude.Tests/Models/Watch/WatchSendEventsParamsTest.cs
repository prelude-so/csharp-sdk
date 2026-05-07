using System;
using System.Collections.Generic;
using System.Text.Json;
using Prelude.Core;
using Prelude.Exceptions;
using Prelude.Models.Watch;

namespace Prelude.Tests.Models.Watch;

public class WatchSendEventsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WatchSendEventsParams
        {
            Events =
            [
                new()
                {
                    Confidence = Confidence.Maximum,
                    Label = "onboarding.start",
                    Target = new() { Type = EventTargetType.PhoneNumber, Value = "+30123456789" },
                },
            ],
        };

        List<Event> expectedEvents =
        [
            new()
            {
                Confidence = Confidence.Maximum,
                Label = "onboarding.start",
                Target = new() { Type = EventTargetType.PhoneNumber, Value = "+30123456789" },
            },
        ];

        Assert.Equal(expectedEvents.Count, parameters.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], parameters.Events[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        WatchSendEventsParams parameters = new()
        {
            Events =
            [
                new()
                {
                    Confidence = Confidence.Maximum,
                    Label = "onboarding.start",
                    Target = new() { Type = EventTargetType.PhoneNumber, Value = "+30123456789" },
                },
            ],
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.prelude.dev/v2/watch/event"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WatchSendEventsParams
        {
            Events =
            [
                new()
                {
                    Confidence = Confidence.Maximum,
                    Label = "onboarding.start",
                    Target = new() { Type = EventTargetType.PhoneNumber, Value = "+30123456789" },
                },
            ],
        };

        WatchSendEventsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Event
        {
            Confidence = Confidence.Maximum,
            Label = "onboarding.start",
            Target = new() { Type = EventTargetType.PhoneNumber, Value = "+30123456789" },
        };

        ApiEnum<string, Confidence> expectedConfidence = Confidence.Maximum;
        string expectedLabel = "onboarding.start";
        EventTarget expectedTarget = new()
        {
            Type = EventTargetType.PhoneNumber,
            Value = "+30123456789",
        };

        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedLabel, model.Label);
        Assert.Equal(expectedTarget, model.Target);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Event
        {
            Confidence = Confidence.Maximum,
            Label = "onboarding.start",
            Target = new() { Type = EventTargetType.PhoneNumber, Value = "+30123456789" },
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
            Confidence = Confidence.Maximum,
            Label = "onboarding.start",
            Target = new() { Type = EventTargetType.PhoneNumber, Value = "+30123456789" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, Confidence> expectedConfidence = Confidence.Maximum;
        string expectedLabel = "onboarding.start";
        EventTarget expectedTarget = new()
        {
            Type = EventTargetType.PhoneNumber,
            Value = "+30123456789",
        };

        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedLabel, deserialized.Label);
        Assert.Equal(expectedTarget, deserialized.Target);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Event
        {
            Confidence = Confidence.Maximum,
            Label = "onboarding.start",
            Target = new() { Type = EventTargetType.PhoneNumber, Value = "+30123456789" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Event
        {
            Confidence = Confidence.Maximum,
            Label = "onboarding.start",
            Target = new() { Type = EventTargetType.PhoneNumber, Value = "+30123456789" },
        };

        Event copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConfidenceTest : TestBase
{
    [Theory]
    [InlineData(Confidence.Maximum)]
    [InlineData(Confidence.High)]
    [InlineData(Confidence.Neutral)]
    [InlineData(Confidence.Low)]
    [InlineData(Confidence.Minimum)]
    public void Validation_Works(Confidence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Confidence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Confidence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Confidence.Maximum)]
    [InlineData(Confidence.High)]
    [InlineData(Confidence.Neutral)]
    [InlineData(Confidence.Low)]
    [InlineData(Confidence.Minimum)]
    public void SerializationRoundtrip_Works(Confidence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Confidence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Confidence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Confidence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Confidence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EventTargetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventTarget { Type = EventTargetType.PhoneNumber, Value = "+30123456789" };

        ApiEnum<string, EventTargetType> expectedType = EventTargetType.PhoneNumber;
        string expectedValue = "+30123456789";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventTarget { Type = EventTargetType.PhoneNumber, Value = "+30123456789" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventTarget>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventTarget { Type = EventTargetType.PhoneNumber, Value = "+30123456789" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventTarget>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, EventTargetType> expectedType = EventTargetType.PhoneNumber;
        string expectedValue = "+30123456789";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventTarget { Type = EventTargetType.PhoneNumber, Value = "+30123456789" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventTarget { Type = EventTargetType.PhoneNumber, Value = "+30123456789" };

        EventTarget copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventTargetTypeTest : TestBase
{
    [Theory]
    [InlineData(EventTargetType.PhoneNumber)]
    [InlineData(EventTargetType.EmailAddress)]
    public void Validation_Works(EventTargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventTargetType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventTargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventTargetType.PhoneNumber)]
    [InlineData(EventTargetType.EmailAddress)]
    public void SerializationRoundtrip_Works(EventTargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventTargetType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventTargetType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventTargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventTargetType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
