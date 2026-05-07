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
        NotifyListSubscriptionPhoneNumbersResponse,
        NotifyListSubscriptionPhoneNumbersResponseFromRaw
    >)
)]
public sealed record class NotifyListSubscriptionPhoneNumbersResponse : JsonModel
{
    /// <summary>
    /// A list of phone numbers and their subscription statuses.
    /// </summary>
    public required IReadOnlyList<PhoneNumber> PhoneNumbers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PhoneNumber>>("phone_numbers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PhoneNumber>>(
                "phone_numbers",
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
        foreach (var item in this.PhoneNumbers)
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public NotifyListSubscriptionPhoneNumbersResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotifyListSubscriptionPhoneNumbersResponse(
        NotifyListSubscriptionPhoneNumbersResponse notifyListSubscriptionPhoneNumbersResponse
    )
        : base(notifyListSubscriptionPhoneNumbersResponse) { }
#pragma warning restore CS8618

    public NotifyListSubscriptionPhoneNumbersResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotifyListSubscriptionPhoneNumbersResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotifyListSubscriptionPhoneNumbersResponseFromRaw.FromRawUnchecked"/>
    public static NotifyListSubscriptionPhoneNumbersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NotifyListSubscriptionPhoneNumbersResponse(IReadOnlyList<PhoneNumber> phoneNumbers)
        : this()
    {
        this.PhoneNumbers = phoneNumbers;
    }
}

class NotifyListSubscriptionPhoneNumbersResponseFromRaw
    : IFromRawJson<NotifyListSubscriptionPhoneNumbersResponse>
{
    /// <inheritdoc/>
    public NotifyListSubscriptionPhoneNumbersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotifyListSubscriptionPhoneNumbersResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PhoneNumber, PhoneNumberFromRaw>))]
public sealed record class PhoneNumber : JsonModel
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
    public required string PhoneNumberValue
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
    public required ApiEnum<string, PhoneNumberSource> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PhoneNumberSource>>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// The subscription state:   * `SUB` - Subscribed (user can receive marketing
    /// messages)   * `UNSUB` - Unsubscribed (user has opted out)
    /// </summary>
    public required ApiEnum<string, PhoneNumberState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PhoneNumberState>>("state");
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
        _ = this.PhoneNumberValue;
        this.Source.Validate();
        this.State.Validate();
        _ = this.UpdatedAt;
        _ = this.Reason;
    }

    public PhoneNumber() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumber(PhoneNumber phoneNumber)
        : base(phoneNumber) { }
#pragma warning restore CS8618

    public PhoneNumber(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumber(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberFromRaw.FromRawUnchecked"/>
    public static PhoneNumber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhoneNumberFromRaw : IFromRawJson<PhoneNumber>
{
    /// <inheritdoc/>
    public PhoneNumber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PhoneNumber.FromRawUnchecked(rawData);
}

/// <summary>
/// How the subscription state was changed:   * `MO_KEYWORD` - User sent a keyword
/// (STOP/START)   * `API` - Changed via API   * `CSV_IMPORT` - Imported from CSV
///   * `CARRIER_DISCONNECT` - Automatically unsubscribed due to carrier disconnect
/// </summary>
[JsonConverter(typeof(PhoneNumberSourceConverter))]
public enum PhoneNumberSource
{
    MoKeyword,
    Api,
    CsvImport,
    CarrierDisconnect,
}

sealed class PhoneNumberSourceConverter : JsonConverter<PhoneNumberSource>
{
    public override PhoneNumberSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MO_KEYWORD" => PhoneNumberSource.MoKeyword,
            "API" => PhoneNumberSource.Api,
            "CSV_IMPORT" => PhoneNumberSource.CsvImport,
            "CARRIER_DISCONNECT" => PhoneNumberSource.CarrierDisconnect,
            _ => (PhoneNumberSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PhoneNumberSource.MoKeyword => "MO_KEYWORD",
                PhoneNumberSource.Api => "API",
                PhoneNumberSource.CsvImport => "CSV_IMPORT",
                PhoneNumberSource.CarrierDisconnect => "CARRIER_DISCONNECT",
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
[JsonConverter(typeof(PhoneNumberStateConverter))]
public enum PhoneNumberState
{
    Sub,
    Unsub,
}

sealed class PhoneNumberStateConverter : JsonConverter<PhoneNumberState>
{
    public override PhoneNumberState Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SUB" => PhoneNumberState.Sub,
            "UNSUB" => PhoneNumberState.Unsub,
            _ => (PhoneNumberState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PhoneNumberState.Sub => "SUB",
                PhoneNumberState.Unsub => "UNSUB",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
