using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Prelude.Core;
using Prelude.Exceptions;

namespace Prelude.Models.Notify;

[JsonConverter(typeof(JsonModelConverter<NotifySendResponse, NotifySendResponseFromRaw>))]
public sealed record class NotifySendResponse : JsonModel
{
    /// <summary>
    /// The message identifier.
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
    /// The message creation date in RFC3339 format.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The message expiration date in RFC3339 format.
    /// </summary>
    public required DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// The template identifier.
    /// </summary>
    public required string TemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("template_id");
        }
        init { this._rawData.Set("template_id", value); }
    }

    /// <summary>
    /// The recipient's phone number in E.164 format.
    /// </summary>
    public required string To
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("to");
        }
        init { this._rawData.Set("to", value); }
    }

    /// <summary>
    /// The variables to be replaced in the template.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("variables");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "variables",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The callback URL where webhooks will be sent.
    /// </summary>
    public string? CallbackUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callback_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callback_url", value);
        }
    }

    /// <summary>
    /// A user-defined identifier to correlate this message with your internal systems.
    /// </summary>
    public string? CorrelationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("correlation_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("correlation_id", value);
        }
    }

    /// <summary>
    /// The SMS encoding type based on message content. GSM-7 supports standard characters
    /// (up to 160 chars per segment), while UCS-2 supports Unicode including emoji
    /// (up to 70 chars per segment). Only present for SMS messages.
    /// </summary>
    public ApiEnum<string, Encoding>? Encoding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Encoding>>("encoding");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("encoding", value);
        }
    }

    /// <summary>
    /// The estimated number of SMS segments for this message. This value is not contractual;
    /// the actual segment count will be determined after the SMS is sent by the
    /// provider. Only present for SMS messages.
    /// </summary>
    public long? EstimatedSegmentCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("estimated_segment_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("estimated_segment_count", value);
        }
    }

    /// <summary>
    /// The Sender ID used for this message.
    /// </summary>
    public string? From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("from");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    /// <summary>
    /// When the message will actually be sent in RFC3339 format with timezone offset.
    /// For marketing messages, this may differ from the requested schedule_at due
    /// to automatic compliance adjustments.
    /// </summary>
    public DateTimeOffset? ScheduleAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("schedule_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("schedule_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.ExpiresAt;
        _ = this.TemplateID;
        _ = this.To;
        _ = this.Variables;
        _ = this.CallbackUrl;
        _ = this.CorrelationID;
        this.Encoding?.Validate();
        _ = this.EstimatedSegmentCount;
        _ = this.From;
        _ = this.ScheduleAt;
    }

    public NotifySendResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotifySendResponse(NotifySendResponse notifySendResponse)
        : base(notifySendResponse) { }
#pragma warning restore CS8618

    public NotifySendResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotifySendResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotifySendResponseFromRaw.FromRawUnchecked"/>
    public static NotifySendResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotifySendResponseFromRaw : IFromRawJson<NotifySendResponse>
{
    /// <inheritdoc/>
    public NotifySendResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NotifySendResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The SMS encoding type based on message content. GSM-7 supports standard characters
/// (up to 160 chars per segment), while UCS-2 supports Unicode including emoji (up
/// to 70 chars per segment). Only present for SMS messages.
/// </summary>
[JsonConverter(typeof(EncodingConverter))]
public enum Encoding
{
    Gsm7,
    Ucs2,
}

sealed class EncodingConverter : JsonConverter<Encoding>
{
    public override Encoding Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GSM-7" => Encoding.Gsm7,
            "UCS-2" => Encoding.Ucs2,
            _ => (Encoding)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Encoding value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Encoding.Gsm7 => "GSM-7",
                Encoding.Ucs2 => "UCS-2",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
