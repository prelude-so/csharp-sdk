using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using System = System;

namespace PreludeSdk.Models.Watch;

/// <summary>
/// Send custom fraud signals from your application (labels and confidence levels).
/// Events capture product-specific risk patterns and are weighted when scoring traffic.
/// Use without Predict or Feedback if you only need to report product-side abuse
/// (for example account.banned). Feedback is a separate, optional endpoint for self-hosted
/// phone verification funnels.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WatchSendEventsParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// A list of events to dispatch. A maximum of 100 events can be sent in a single request.
    /// </summary>
    public required IReadOnlyList<Event> Events
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Event>>("events");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Event>>(
                "events",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public WatchSendEventsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WatchSendEventsParams(WatchSendEventsParams watchSendEventsParams)
        : base(watchSendEventsParams)
    {
        this._rawBodyData = new(watchSendEventsParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WatchSendEventsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WatchSendEventsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WatchSendEventsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(WatchSendEventsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v2/watch/event")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(JsonModelConverter<Event, EventFromRaw>))]
public sealed record class Event : JsonModel
{
    /// <summary>
    /// The level of trust you place in this event, in increasing order of trust:
    /// `minimum`, `low`, `neutral`, `high`, `maximum`. Prelude uses this value to
    /// weight your signals when scoring traffic — events flagged with `minimum` confidence
    /// indicate end-users you trust the least to be legitimate, and the pipeline
    /// will use these signals to filter them out.
    /// </summary>
    public required ApiEnum<string, Confidence> Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Confidence>>("confidence");
        }
        init { this._rawData.Set("confidence", value); }
    }

    /// <summary>
    /// A label to describe what the event refers to.
    /// </summary>
    public required string Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("label");
        }
        init { this._rawData.Set("label", value); }
    }

    /// <summary>
    /// The event target. Only supports phone numbers for now.
    /// </summary>
    public required EventTarget Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EventTarget>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Confidence.Validate();
        _ = this.Label;
        this.Target.Validate();
    }

    public Event() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Event(Event event_)
        : base(event_) { }
#pragma warning restore CS8618

    public Event(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Event(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventFromRaw.FromRawUnchecked"/>
    public static Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventFromRaw : IFromRawJson<Event>
{
    /// <inheritdoc/>
    public Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Event.FromRawUnchecked(rawData);
}

/// <summary>
/// The level of trust you place in this event, in increasing order of trust: `minimum`,
/// `low`, `neutral`, `high`, `maximum`. Prelude uses this value to weight your signals
/// when scoring traffic — events flagged with `minimum` confidence indicate end-users
/// you trust the least to be legitimate, and the pipeline will use these signals
/// to filter them out.
/// </summary>
[JsonConverter(typeof(ConfidenceConverter))]
public enum Confidence
{
    Maximum,
    High,
    Neutral,
    Low,
    Minimum,
}

sealed class ConfidenceConverter : JsonConverter<Confidence>
{
    public override Confidence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "maximum" => Confidence.Maximum,
            "high" => Confidence.High,
            "neutral" => Confidence.Neutral,
            "low" => Confidence.Low,
            "minimum" => Confidence.Minimum,
            _ => (Confidence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Confidence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Confidence.Maximum => "maximum",
                Confidence.High => "high",
                Confidence.Neutral => "neutral",
                Confidence.Low => "low",
                Confidence.Minimum => "minimum",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The event target. Only supports phone numbers for now.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EventTarget, EventTargetFromRaw>))]
public sealed record class EventTarget : JsonModel
{
    /// <summary>
    /// The type of the target. Either "phone_number" or "email_address".
    /// </summary>
    public required ApiEnum<string, EventTargetType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventTargetType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// An E.164 formatted phone number or an email address.
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Value;
    }

    public EventTarget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventTarget(EventTarget eventTarget)
        : base(eventTarget) { }
#pragma warning restore CS8618

    public EventTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventTargetFromRaw.FromRawUnchecked"/>
    public static EventTarget FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventTargetFromRaw : IFromRawJson<EventTarget>
{
    /// <inheritdoc/>
    public EventTarget FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EventTarget.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the target. Either "phone_number" or "email_address".
/// </summary>
[JsonConverter(typeof(EventTargetTypeConverter))]
public enum EventTargetType
{
    PhoneNumber,
    EmailAddress,
}

sealed class EventTargetTypeConverter : JsonConverter<EventTargetType>
{
    public override EventTargetType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "phone_number" => EventTargetType.PhoneNumber,
            "email_address" => EventTargetType.EmailAddress,
            _ => (EventTargetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventTargetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventTargetType.PhoneNumber => "phone_number",
                EventTargetType.EmailAddress => "email_address",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
