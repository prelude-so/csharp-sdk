using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Prelude.Core;
using Prelude.Exceptions;

namespace Prelude.Models.Notify;

[JsonConverter(
    typeof(JsonModelConverter<
        NotifyListSubscriptionPhoneNumberEventsResponse,
        NotifyListSubscriptionPhoneNumberEventsResponseFromRaw
    >)
)]
public sealed record class NotifyListSubscriptionPhoneNumberEventsResponse : JsonModel
{
    /// <summary>
    /// A list of subscription events (status changes) ordered by timestamp descending.
    /// </summary>
    public required IReadOnlyList<Event> Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Event>>("events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Event>>(
                "events",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination cursor for the next page of results. Omitted if there are no more pages.
    /// </summary>
    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("next_cursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Events)
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public NotifyListSubscriptionPhoneNumberEventsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotifyListSubscriptionPhoneNumberEventsResponse(
        NotifyListSubscriptionPhoneNumberEventsResponse notifyListSubscriptionPhoneNumberEventsResponse
    )
        : base(notifyListSubscriptionPhoneNumberEventsResponse) { }
#pragma warning restore CS8618

    public NotifyListSubscriptionPhoneNumberEventsResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotifyListSubscriptionPhoneNumberEventsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotifyListSubscriptionPhoneNumberEventsResponseFromRaw.FromRawUnchecked"/>
    public static NotifyListSubscriptionPhoneNumberEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NotifyListSubscriptionPhoneNumberEventsResponse(IReadOnlyList<Event> events)
        : this()
    {
        this.Events = events;
    }
}

class NotifyListSubscriptionPhoneNumberEventsResponseFromRaw
    : IFromRawJson<NotifyListSubscriptionPhoneNumberEventsResponse>
{
    /// <inheritdoc/>
    public NotifyListSubscriptionPhoneNumberEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotifyListSubscriptionPhoneNumberEventsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Event, EventFromRaw>))]
public sealed record class Event : JsonModel
{
    /// <summary>
    /// The subscription configuration ID.
    /// </summary>
    public required string ConfigID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("config_id");
        }
        init { this._rawData.Set("config_id", value); }
    }

    /// <summary>
    /// The phone number in E.164 format.
    /// </summary>
    public required string PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("phone_number");
        }
        init { this._rawData.Set("phone_number", value); }
    }

    /// <summary>
    /// How the subscription state was changed:   * `MO_KEYWORD` - User sent a keyword
    /// (STOP/START)   * `API` - Changed via API   * `CSV_IMPORT` - Imported from
    /// CSV   * `CARRIER_DISCONNECT` - Automatically unsubscribed due to carrier
    /// disconnect
    /// </summary>
    public required ApiEnum<string, EventSource> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventSource>>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// The subscription state after this event:   * `SUB` - Subscribed (user can
    /// receive marketing messages)   * `UNSUB` - Unsubscribed (user has opted out)
    /// </summary>
    public required ApiEnum<string, EventState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventState>>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The date and time when the event occurred.
    /// </summary>
    public required DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// Additional context about the state change (e.g., the keyword that was sent).
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConfigID;
        _ = this.PhoneNumber;
        this.Source.Validate();
        this.State.Validate();
        _ = this.Timestamp;
        _ = this.Reason;
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
/// How the subscription state was changed:   * `MO_KEYWORD` - User sent a keyword
/// (STOP/START)   * `API` - Changed via API   * `CSV_IMPORT` - Imported from CSV
///   * `CARRIER_DISCONNECT` - Automatically unsubscribed due to carrier disconnect
/// </summary>
[JsonConverter(typeof(EventSourceConverter))]
public enum EventSource
{
    MoKeyword,
    Api,
    CsvImport,
    CarrierDisconnect,
}

sealed class EventSourceConverter : JsonConverter<EventSource>
{
    public override EventSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MO_KEYWORD" => EventSource.MoKeyword,
            "API" => EventSource.Api,
            "CSV_IMPORT" => EventSource.CsvImport,
            "CARRIER_DISCONNECT" => EventSource.CarrierDisconnect,
            _ => (EventSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventSource.MoKeyword => "MO_KEYWORD",
                EventSource.Api => "API",
                EventSource.CsvImport => "CSV_IMPORT",
                EventSource.CarrierDisconnect => "CARRIER_DISCONNECT",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The subscription state after this event:   * `SUB` - Subscribed (user can receive
/// marketing messages)   * `UNSUB` - Unsubscribed (user has opted out)
/// </summary>
[JsonConverter(typeof(EventStateConverter))]
public enum EventState
{
    Sub,
    Unsub,
}

sealed class EventStateConverter : JsonConverter<EventState>
{
    public override EventState Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SUB" => EventState.Sub,
            "UNSUB" => EventState.Unsub,
            _ => (EventState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventState.Sub => "SUB",
                EventState.Unsub => "UNSUB",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
