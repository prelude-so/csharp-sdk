using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using System = System;

namespace PreludeSdk.Models.Verification.Phone.History;

[JsonConverter(typeof(JsonModelConverter<HistoryListResponse, HistoryListResponseFromRaw>))]
public sealed record class HistoryListResponse : JsonModel
{
    /// <summary>
    /// The page of verifications, most recent first.
    /// </summary>
    public required IReadOnlyList<HistoryListResponseVerification> Verifications
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<HistoryListResponseVerification>>(
                "verifications"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<HistoryListResponseVerification>>(
                "verifications",
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
        foreach (var item in this.Verifications)
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public HistoryListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HistoryListResponse(HistoryListResponse historyListResponse)
        : base(historyListResponse) { }
#pragma warning restore CS8618

    public HistoryListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HistoryListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HistoryListResponseFromRaw.FromRawUnchecked"/>
    public static HistoryListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public HistoryListResponse(IReadOnlyList<HistoryListResponseVerification> verifications)
        : this()
    {
        this.Verifications = verifications;
    }
}

class HistoryListResponseFromRaw : IFromRawJson<HistoryListResponse>
{
    /// <inheritdoc/>
    public HistoryListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        HistoryListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// One entry of the verification history. [Get a phone verification](/verify/v2/api-reference/history/get-a-phone-verification)
/// returns the full record.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        HistoryListResponseVerification,
        HistoryListResponseVerificationFromRaw
    >)
)]
public sealed record class HistoryListResponseVerification : JsonModel
{
    /// <summary>
    /// The verification identifier.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The channels the verification could use, and which one the end user converted
    /// through. Empty when the verification used only channels this API does not list.
    /// </summary>
    public required IReadOnlyList<HistoryListResponseVerificationChannel> Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<HistoryListResponseVerificationChannel>
            >("channels");
        }
        init
        {
            this._rawData.Set<ImmutableArray<HistoryListResponseVerificationChannel>>(
                "channels",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Whether at least one message was reported delivered.
    /// </summary>
    public required bool Delivered
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("delivered");
        }
        init { this._rawData.Set("delivered", value); }
    }

    /// <summary>
    /// The E.164 phone number the verification targeted.
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
    /// The outcome of the verification.  * `converted` - The end user submitted
    /// a valid code.  * `not_converted` - The verification expired without a valid
    /// code.  * `pending_check` - A code was delivered and Prelude is still waiting
    /// for a check.  * `sent` - A code was sent and the verification window is still
    /// open.  * `challenged` - The verification was restricted to non-SMS and non-voice
    /// channels.  * `suspected_fraud` - The anti-fraud system blocked the verification.
    ///  * `in_blocklist` - The phone number is on the configured block list.  *
    /// `invalid_line` - The phone number is not a valid line type.  * `invalid_number`
    /// - The phone number is not a valid number.  * `rate_limited` - The verification
    /// was refused by a rate limit.  * `expired_signals` - The SDK signals were
    /// collected too long before the request.  * `shadowed` - The anti-fraud system
    /// flagged the verification without blocking it.
    /// </summary>
    public required ApiEnum<string, HistoryListResponseVerificationStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, HistoryListResponseVerificationStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Number of messages sent for the verification, `0` when none was. Absent for
    /// sandboxed phone numbers.
    /// </summary>
    public long? Attempts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("attempts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("attempts", value);
        }
    }

    /// <summary>
    /// When the end user submitted a valid code. Absent unless the verification converted.
    /// </summary>
    public System::DateTimeOffset? ConvertedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("converted_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("converted_at", value);
        }
    }

    /// <summary>
    /// Total cost of the verification. Absent when nothing was billed.
    /// </summary>
    public PhoneVerificationMoney? Cost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneVerificationMoney>("cost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cost", value);
        }
    }

    /// <summary>
    /// Platform of the end-user device, when known.
    /// </summary>
    public ApiEnum<string, HistoryListResponseVerificationDevicePlatform>? DevicePlatform
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, HistoryListResponseVerificationDevicePlatform>
            >("device_platform");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("device_platform", value);
        }
    }

    /// <summary>
    /// Whether the phone number was allow-listed, block-listed, or sandboxed at
    /// verification time.
    /// </summary>
    public ApiEnum<
        string,
        HistoryListResponseVerificationPhoneNumberCondition
    >? PhoneNumberCondition
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, HistoryListResponseVerificationPhoneNumberCondition>
            >("phone_number_condition");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_number_condition", value);
        }
    }

    /// <summary>
    /// Whether the SDK signals integrity check passed.
    /// </summary>
    public ApiEnum<string, HistoryListResponseVerificationSignalsHashStatus>? SignalsHashStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, HistoryListResponseVerificationSignalsHashStatus>
            >("signals_hash_status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("signals_hash_status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Channels)
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        _ = this.Delivered;
        _ = this.PhoneNumber;
        this.Status.Validate();
        _ = this.Attempts;
        _ = this.ConvertedAt;
        this.Cost?.Validate();
        this.DevicePlatform?.Validate();
        this.PhoneNumberCondition?.Validate();
        this.SignalsHashStatus?.Validate();
    }

    public HistoryListResponseVerification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HistoryListResponseVerification(
        HistoryListResponseVerification historyListResponseVerification
    )
        : base(historyListResponseVerification) { }
#pragma warning restore CS8618

    public HistoryListResponseVerification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HistoryListResponseVerification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HistoryListResponseVerificationFromRaw.FromRawUnchecked"/>
    public static HistoryListResponseVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HistoryListResponseVerificationFromRaw : IFromRawJson<HistoryListResponseVerification>
{
    /// <inheritdoc/>
    public HistoryListResponseVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => HistoryListResponseVerification.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        HistoryListResponseVerificationChannel,
        HistoryListResponseVerificationChannelFromRaw
    >)
)]
public sealed record class HistoryListResponseVerificationChannel : JsonModel
{
    public required ApiEnum<string, HistoryListResponseVerificationChannelChannel> Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, HistoryListResponseVerificationChannelChannel>
            >("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <summary>
    /// Whether the end user submitted a valid code received through this channel.
    /// </summary>
    public required bool Converted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("converted");
        }
        init { this._rawData.Set("converted", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Channel.Validate();
        _ = this.Converted;
    }

    public HistoryListResponseVerificationChannel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HistoryListResponseVerificationChannel(
        HistoryListResponseVerificationChannel historyListResponseVerificationChannel
    )
        : base(historyListResponseVerificationChannel) { }
#pragma warning restore CS8618

    public HistoryListResponseVerificationChannel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HistoryListResponseVerificationChannel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HistoryListResponseVerificationChannelFromRaw.FromRawUnchecked"/>
    public static HistoryListResponseVerificationChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HistoryListResponseVerificationChannelFromRaw
    : IFromRawJson<HistoryListResponseVerificationChannel>
{
    /// <inheritdoc/>
    public HistoryListResponseVerificationChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => HistoryListResponseVerificationChannel.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(HistoryListResponseVerificationChannelChannelConverter))]
public enum HistoryListResponseVerificationChannelChannel
{
    Sms,
    Rcs,
    Whatsapp,
    Viber,
    Zalo,
    Telegram,
    Voice,
    Silent,
}

sealed class HistoryListResponseVerificationChannelChannelConverter
    : JsonConverter<HistoryListResponseVerificationChannelChannel>
{
    public override HistoryListResponseVerificationChannelChannel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms" => HistoryListResponseVerificationChannelChannel.Sms,
            "rcs" => HistoryListResponseVerificationChannelChannel.Rcs,
            "whatsapp" => HistoryListResponseVerificationChannelChannel.Whatsapp,
            "viber" => HistoryListResponseVerificationChannelChannel.Viber,
            "zalo" => HistoryListResponseVerificationChannelChannel.Zalo,
            "telegram" => HistoryListResponseVerificationChannelChannel.Telegram,
            "voice" => HistoryListResponseVerificationChannelChannel.Voice,
            "silent" => HistoryListResponseVerificationChannelChannel.Silent,
            _ => (HistoryListResponseVerificationChannelChannel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        HistoryListResponseVerificationChannelChannel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                HistoryListResponseVerificationChannelChannel.Sms => "sms",
                HistoryListResponseVerificationChannelChannel.Rcs => "rcs",
                HistoryListResponseVerificationChannelChannel.Whatsapp => "whatsapp",
                HistoryListResponseVerificationChannelChannel.Viber => "viber",
                HistoryListResponseVerificationChannelChannel.Zalo => "zalo",
                HistoryListResponseVerificationChannelChannel.Telegram => "telegram",
                HistoryListResponseVerificationChannelChannel.Voice => "voice",
                HistoryListResponseVerificationChannelChannel.Silent => "silent",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The outcome of the verification.  * `converted` - The end user submitted a valid
/// code.  * `not_converted` - The verification expired without a valid code.  *
/// `pending_check` - A code was delivered and Prelude is still waiting for a check.
///  * `sent` - A code was sent and the verification window is still open.  * `challenged`
/// - The verification was restricted to non-SMS and non-voice channels.  * `suspected_fraud`
/// - The anti-fraud system blocked the verification.  * `in_blocklist` - The phone
/// number is on the configured block list.  * `invalid_line` - The phone number is
/// not a valid line type.  * `invalid_number` - The phone number is not a valid number.
///  * `rate_limited` - The verification was refused by a rate limit.  * `expired_signals`
/// - The SDK signals were collected too long before the request.  * `shadowed` -
/// The anti-fraud system flagged the verification without blocking it.
/// </summary>
[JsonConverter(typeof(HistoryListResponseVerificationStatusConverter))]
public enum HistoryListResponseVerificationStatus
{
    Converted,
    NotConverted,
    PendingCheck,
    Sent,
    Challenged,
    SuspectedFraud,
    InBlocklist,
    InvalidLine,
    InvalidNumber,
    RateLimited,
    ExpiredSignals,
    Shadowed,
}

sealed class HistoryListResponseVerificationStatusConverter
    : JsonConverter<HistoryListResponseVerificationStatus>
{
    public override HistoryListResponseVerificationStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "converted" => HistoryListResponseVerificationStatus.Converted,
            "not_converted" => HistoryListResponseVerificationStatus.NotConverted,
            "pending_check" => HistoryListResponseVerificationStatus.PendingCheck,
            "sent" => HistoryListResponseVerificationStatus.Sent,
            "challenged" => HistoryListResponseVerificationStatus.Challenged,
            "suspected_fraud" => HistoryListResponseVerificationStatus.SuspectedFraud,
            "in_blocklist" => HistoryListResponseVerificationStatus.InBlocklist,
            "invalid_line" => HistoryListResponseVerificationStatus.InvalidLine,
            "invalid_number" => HistoryListResponseVerificationStatus.InvalidNumber,
            "rate_limited" => HistoryListResponseVerificationStatus.RateLimited,
            "expired_signals" => HistoryListResponseVerificationStatus.ExpiredSignals,
            "shadowed" => HistoryListResponseVerificationStatus.Shadowed,
            _ => (HistoryListResponseVerificationStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        HistoryListResponseVerificationStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                HistoryListResponseVerificationStatus.Converted => "converted",
                HistoryListResponseVerificationStatus.NotConverted => "not_converted",
                HistoryListResponseVerificationStatus.PendingCheck => "pending_check",
                HistoryListResponseVerificationStatus.Sent => "sent",
                HistoryListResponseVerificationStatus.Challenged => "challenged",
                HistoryListResponseVerificationStatus.SuspectedFraud => "suspected_fraud",
                HistoryListResponseVerificationStatus.InBlocklist => "in_blocklist",
                HistoryListResponseVerificationStatus.InvalidLine => "invalid_line",
                HistoryListResponseVerificationStatus.InvalidNumber => "invalid_number",
                HistoryListResponseVerificationStatus.RateLimited => "rate_limited",
                HistoryListResponseVerificationStatus.ExpiredSignals => "expired_signals",
                HistoryListResponseVerificationStatus.Shadowed => "shadowed",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Platform of the end-user device, when known.
/// </summary>
[JsonConverter(typeof(HistoryListResponseVerificationDevicePlatformConverter))]
public enum HistoryListResponseVerificationDevicePlatform
{
    Android,
    Ios,
    Ipados,
    Tvos,
    Web,
}

sealed class HistoryListResponseVerificationDevicePlatformConverter
    : JsonConverter<HistoryListResponseVerificationDevicePlatform>
{
    public override HistoryListResponseVerificationDevicePlatform Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "android" => HistoryListResponseVerificationDevicePlatform.Android,
            "ios" => HistoryListResponseVerificationDevicePlatform.Ios,
            "ipados" => HistoryListResponseVerificationDevicePlatform.Ipados,
            "tvos" => HistoryListResponseVerificationDevicePlatform.Tvos,
            "web" => HistoryListResponseVerificationDevicePlatform.Web,
            _ => (HistoryListResponseVerificationDevicePlatform)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        HistoryListResponseVerificationDevicePlatform value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                HistoryListResponseVerificationDevicePlatform.Android => "android",
                HistoryListResponseVerificationDevicePlatform.Ios => "ios",
                HistoryListResponseVerificationDevicePlatform.Ipados => "ipados",
                HistoryListResponseVerificationDevicePlatform.Tvos => "tvos",
                HistoryListResponseVerificationDevicePlatform.Web => "web",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether the phone number was allow-listed, block-listed, or sandboxed at verification time.
/// </summary>
[JsonConverter(typeof(HistoryListResponseVerificationPhoneNumberConditionConverter))]
public enum HistoryListResponseVerificationPhoneNumberCondition
{
    AllowListed,
    BlockListed,
    Sandboxed,
}

sealed class HistoryListResponseVerificationPhoneNumberConditionConverter
    : JsonConverter<HistoryListResponseVerificationPhoneNumberCondition>
{
    public override HistoryListResponseVerificationPhoneNumberCondition Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allow_listed" => HistoryListResponseVerificationPhoneNumberCondition.AllowListed,
            "block_listed" => HistoryListResponseVerificationPhoneNumberCondition.BlockListed,
            "sandboxed" => HistoryListResponseVerificationPhoneNumberCondition.Sandboxed,
            _ => (HistoryListResponseVerificationPhoneNumberCondition)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        HistoryListResponseVerificationPhoneNumberCondition value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                HistoryListResponseVerificationPhoneNumberCondition.AllowListed => "allow_listed",
                HistoryListResponseVerificationPhoneNumberCondition.BlockListed => "block_listed",
                HistoryListResponseVerificationPhoneNumberCondition.Sandboxed => "sandboxed",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether the SDK signals integrity check passed.
/// </summary>
[JsonConverter(typeof(HistoryListResponseVerificationSignalsHashStatusConverter))]
public enum HistoryListResponseVerificationSignalsHashStatus
{
    Valid,
    Invalid,
}

sealed class HistoryListResponseVerificationSignalsHashStatusConverter
    : JsonConverter<HistoryListResponseVerificationSignalsHashStatus>
{
    public override HistoryListResponseVerificationSignalsHashStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "valid" => HistoryListResponseVerificationSignalsHashStatus.Valid,
            "invalid" => HistoryListResponseVerificationSignalsHashStatus.Invalid,
            _ => (HistoryListResponseVerificationSignalsHashStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        HistoryListResponseVerificationSignalsHashStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                HistoryListResponseVerificationSignalsHashStatus.Valid => "valid",
                HistoryListResponseVerificationSignalsHashStatus.Invalid => "invalid",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
