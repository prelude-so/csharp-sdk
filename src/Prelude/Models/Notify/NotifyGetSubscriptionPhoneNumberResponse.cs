using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Prelude.Core;
using Prelude.Exceptions;

namespace Prelude.Models.Notify;

[JsonConverter(
    typeof(JsonModelConverter<
        NotifyGetSubscriptionPhoneNumberResponse,
        NotifyGetSubscriptionPhoneNumberResponseFromRaw
    >)
)]
public sealed record class NotifyGetSubscriptionPhoneNumberResponse : JsonModel
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
    public required ApiEnum<string, Source> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Source>>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// The subscription state:   * `SUB` - Subscribed (user can receive marketing
    /// messages)   * `UNSUB` - Unsubscribed (user has opted out)
    /// </summary>
    public required ApiEnum<string, NotifyGetSubscriptionPhoneNumberResponseState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NotifyGetSubscriptionPhoneNumberResponseState>
            >("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The date and time when the subscription status was last updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
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
        _ = this.UpdatedAt;
        _ = this.Reason;
    }

    public NotifyGetSubscriptionPhoneNumberResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotifyGetSubscriptionPhoneNumberResponse(
        NotifyGetSubscriptionPhoneNumberResponse notifyGetSubscriptionPhoneNumberResponse
    )
        : base(notifyGetSubscriptionPhoneNumberResponse) { }
#pragma warning restore CS8618

    public NotifyGetSubscriptionPhoneNumberResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotifyGetSubscriptionPhoneNumberResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotifyGetSubscriptionPhoneNumberResponseFromRaw.FromRawUnchecked"/>
    public static NotifyGetSubscriptionPhoneNumberResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotifyGetSubscriptionPhoneNumberResponseFromRaw
    : IFromRawJson<NotifyGetSubscriptionPhoneNumberResponse>
{
    /// <inheritdoc/>
    public NotifyGetSubscriptionPhoneNumberResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotifyGetSubscriptionPhoneNumberResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// How the subscription state was changed:   * `MO_KEYWORD` - User sent a keyword
/// (STOP/START)   * `API` - Changed via API   * `CSV_IMPORT` - Imported from CSV
///   * `CARRIER_DISCONNECT` - Automatically unsubscribed due to carrier disconnect
/// </summary>
[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    MoKeyword,
    Api,
    CsvImport,
    CarrierDisconnect,
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MO_KEYWORD" => Source.MoKeyword,
            "API" => Source.Api,
            "CSV_IMPORT" => Source.CsvImport,
            "CARRIER_DISCONNECT" => Source.CarrierDisconnect,
            _ => (Source)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Source.MoKeyword => "MO_KEYWORD",
                Source.Api => "API",
                Source.CsvImport => "CSV_IMPORT",
                Source.CarrierDisconnect => "CARRIER_DISCONNECT",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The subscription state:   * `SUB` - Subscribed (user can receive marketing messages)
///   * `UNSUB` - Unsubscribed (user has opted out)
/// </summary>
[JsonConverter(typeof(NotifyGetSubscriptionPhoneNumberResponseStateConverter))]
public enum NotifyGetSubscriptionPhoneNumberResponseState
{
    Sub,
    Unsub,
}

sealed class NotifyGetSubscriptionPhoneNumberResponseStateConverter
    : JsonConverter<NotifyGetSubscriptionPhoneNumberResponseState>
{
    public override NotifyGetSubscriptionPhoneNumberResponseState Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SUB" => NotifyGetSubscriptionPhoneNumberResponseState.Sub,
            "UNSUB" => NotifyGetSubscriptionPhoneNumberResponseState.Unsub,
            _ => (NotifyGetSubscriptionPhoneNumberResponseState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NotifyGetSubscriptionPhoneNumberResponseState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NotifyGetSubscriptionPhoneNumberResponseState.Sub => "SUB",
                NotifyGetSubscriptionPhoneNumberResponseState.Unsub => "UNSUB",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
