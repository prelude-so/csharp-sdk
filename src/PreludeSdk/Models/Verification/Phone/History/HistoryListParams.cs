using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using System = System;

namespace PreludeSdk.Models.Verification.Phone.History;

/// <summary>
/// List your phone verifications, most recent first, one entry per verification with
/// its outcome, channels, attempts and cost. Every filter is optional and they combine
/// with AND.
///
/// <para>Use it to find every verification a phone number went through from your
/// support tooling, then [Get a phone verification](/verify/v2/api-reference/history/get-a-phone-verification)
/// for the full timeline of one of them. A cursor is bound to the filters that produced
/// it: pass `next_cursor` back with the exact same query parameters.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class HistoryListParams : ParamsBase
{
    /// <summary>
    /// Only verifications that could use one of these channels. Repeat the parameter
    /// for several values.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, Channel>>? Channels
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<ApiEnum<string, Channel>>>(
                "channels"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, Channel>>?>(
                "channels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination cursor from the previous response.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    /// <summary>
    /// Only verifications created from this device platform.
    /// </summary>
    public ApiEnum<string, DevicePlatform>? DevicePlatform
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, DevicePlatform>>(
                "device_platform"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("device_platform", value);
        }
    }

    /// <summary>
    /// Only verifications created at or after this RFC 3339 timestamp. Goes with
    /// `to`, at most 6 months apart. Without them the whole history is searched.
    /// </summary>
    public System::DateTimeOffset? From
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("from");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("from", value);
        }
    }

    /// <summary>
    /// Maximum number of verifications to return per page.
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Only verifications that sent at most this many messages. `0` keeps the verifications
    /// that never sent one.
    /// </summary>
    public long? MaxAttempts
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("max_attempts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("max_attempts", value);
        }
    }

    /// <summary>
    /// Only verifications that sent at least this many messages.
    /// </summary>
    public long? MinAttempts
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("min_attempts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("min_attempts", value);
        }
    }

    /// <summary>
    /// Only verifications targeting this E.164 phone number. The leading `+` may
    /// be omitted.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("phone_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// Only verifications of phone numbers from this region, as an ISO 3166-1 alpha-2 code.
    /// </summary>
    public string? Region
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("region");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("region", value);
        }
    }

    /// <summary>
    /// Only verifications in this status. `pending_check` cannot be filtered on.
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("status", value);
        }
    }

    /// <summary>
    /// Only verifications sent with this template, as returned in `template_id`
    /// by [Get a phone verification](/verify/v2/api-reference/history/get-a-phone-verification).
    /// Built-in templates (`prelude:*`) cannot be filtered on.
    /// </summary>
    public string? TemplateID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("template_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("template_id", value);
        }
    }

    /// <summary>
    /// Only verifications created at or before this RFC 3339 timestamp. Goes with `from`.
    /// </summary>
    public System::DateTimeOffset? To
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("to");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("to", value);
        }
    }

    public HistoryListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HistoryListParams(HistoryListParams historyListParams)
        : base(historyListParams) { }
#pragma warning restore CS8618

    public HistoryListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HistoryListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static HistoryListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(HistoryListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v2/verification/phone/history"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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

[JsonConverter(typeof(ChannelConverter))]
public enum Channel
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

sealed class ChannelConverter : JsonConverter<Channel>
{
    public override Channel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms" => Channel.Sms,
            "rcs" => Channel.Rcs,
            "whatsapp" => Channel.Whatsapp,
            "viber" => Channel.Viber,
            "zalo" => Channel.Zalo,
            "telegram" => Channel.Telegram,
            "voice" => Channel.Voice,
            "silent" => Channel.Silent,
            _ => (Channel)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Channel value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Channel.Sms => "sms",
                Channel.Rcs => "rcs",
                Channel.Whatsapp => "whatsapp",
                Channel.Viber => "viber",
                Channel.Zalo => "zalo",
                Channel.Telegram => "telegram",
                Channel.Voice => "voice",
                Channel.Silent => "silent",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Only verifications created from this device platform.
/// </summary>
[JsonConverter(typeof(DevicePlatformConverter))]
public enum DevicePlatform
{
    Android,
    Ios,
    Ipados,
    Tvos,
    Web,
}

sealed class DevicePlatformConverter : JsonConverter<DevicePlatform>
{
    public override DevicePlatform Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "android" => DevicePlatform.Android,
            "ios" => DevicePlatform.Ios,
            "ipados" => DevicePlatform.Ipados,
            "tvos" => DevicePlatform.Tvos,
            "web" => DevicePlatform.Web,
            _ => (DevicePlatform)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DevicePlatform value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DevicePlatform.Android => "android",
                DevicePlatform.Ios => "ios",
                DevicePlatform.Ipados => "ipados",
                DevicePlatform.Tvos => "tvos",
                DevicePlatform.Web => "web",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Only verifications in this status. `pending_check` cannot be filtered on.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
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

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "converted" => Status.Converted,
            "not_converted" => Status.NotConverted,
            "pending_check" => Status.PendingCheck,
            "sent" => Status.Sent,
            "challenged" => Status.Challenged,
            "suspected_fraud" => Status.SuspectedFraud,
            "in_blocklist" => Status.InBlocklist,
            "invalid_line" => Status.InvalidLine,
            "invalid_number" => Status.InvalidNumber,
            "rate_limited" => Status.RateLimited,
            "expired_signals" => Status.ExpiredSignals,
            "shadowed" => Status.Shadowed,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Converted => "converted",
                Status.NotConverted => "not_converted",
                Status.PendingCheck => "pending_check",
                Status.Sent => "sent",
                Status.Challenged => "challenged",
                Status.SuspectedFraud => "suspected_fraud",
                Status.InBlocklist => "in_blocklist",
                Status.InvalidLine => "invalid_line",
                Status.InvalidNumber => "invalid_number",
                Status.RateLimited => "rate_limited",
                Status.ExpiredSignals => "expired_signals",
                Status.Shadowed => "shadowed",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
