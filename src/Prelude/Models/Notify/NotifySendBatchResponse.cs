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

[JsonConverter(typeof(JsonModelConverter<NotifySendBatchResponse, NotifySendBatchResponseFromRaw>))]
public sealed record class NotifySendBatchResponse : JsonModel
{
    /// <summary>
    /// Number of failed sends.
    /// </summary>
    public required long ErrorCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("error_count");
        }
        init { this._rawData.Set("error_count", value); }
    }

    /// <summary>
    /// The per-recipient result of the bulk send.
    /// </summary>
    public required IReadOnlyList<Result> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Result>>("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Result>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number of successful sends.
    /// </summary>
    public required long SuccessCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("success_count");
        }
        init { this._rawData.Set("success_count", value); }
    }

    /// <summary>
    /// Total number of recipients.
    /// </summary>
    public required long TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_count");
        }
        init { this._rawData.Set("total_count", value); }
    }

    /// <summary>
    /// The callback URL used for this bulk request, if any.
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
    /// A string that identifies this specific request.
    /// </summary>
    public string? RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("request_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("request_id", value);
        }
    }

    /// <summary>
    /// The template identifier used for this bulk request.
    /// </summary>
    public string? TemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("template_id", value);
        }
    }

    /// <summary>
    /// The variables used for this bulk request.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("variables");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "variables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ErrorCount;
        foreach (var item in this.Results)
        {
            item.Validate();
        }
        _ = this.SuccessCount;
        _ = this.TotalCount;
        _ = this.CallbackUrl;
        _ = this.RequestID;
        _ = this.TemplateID;
        _ = this.Variables;
    }

    public NotifySendBatchResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotifySendBatchResponse(NotifySendBatchResponse notifySendBatchResponse)
        : base(notifySendBatchResponse) { }
#pragma warning restore CS8618

    public NotifySendBatchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotifySendBatchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotifySendBatchResponseFromRaw.FromRawUnchecked"/>
    public static NotifySendBatchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotifySendBatchResponseFromRaw : IFromRawJson<NotifySendBatchResponse>
{
    /// <inheritdoc/>
    public NotifySendBatchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotifySendBatchResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// The recipient's phone number in E.164 format.
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
    /// Whether the message was accepted for delivery.
    /// </summary>
    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <summary>
    /// Present only if success is false.
    /// </summary>
    public Error? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Error>("error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("error", value);
        }
    }

    /// <summary>
    /// Present only if success is true.
    /// </summary>
    public Message? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Message>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PhoneNumber;
        _ = this.Success;
        this.Error?.Validate();
        this.Message?.Validate();
    }

    public Result() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result(Result result)
        : base(result) { }
#pragma warning restore CS8618

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}

/// <summary>
/// Present only if success is false.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Error, ErrorFromRaw>))]
public sealed record class Error : JsonModel
{
    /// <summary>
    /// The error code.
    /// </summary>
    public string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    /// <summary>
    /// A human-readable error message.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Message;
    }

    public Error() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Error(Error error)
        : base(error) { }
#pragma warning restore CS8618

    public Error(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Error(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ErrorFromRaw.FromRawUnchecked"/>
    public static Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ErrorFromRaw : IFromRawJson<Error>
{
    /// <inheritdoc/>
    public Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Error.FromRawUnchecked(rawData);
}

/// <summary>
/// Present only if success is true.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Message, MessageFromRaw>))]
public sealed record class Message : JsonModel
{
    /// <summary>
    /// The message identifier.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// The correlation identifier for the message.
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
    /// The message creation date in RFC3339 format.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// The SMS encoding type based on message content. GSM-7 supports standard characters
    /// (up to 160 chars per segment), while UCS-2 supports Unicode including emoji
    /// (up to 70 chars per segment). Only present for SMS messages.
    /// </summary>
    public ApiEnum<string, MessageEncoding>? Encoding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessageEncoding>>("encoding");
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
    /// The message expiration date in RFC3339 format.
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expires_at", value);
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
    /// The locale used for the message, if any.
    /// </summary>
    public string? Locale
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("locale");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("locale", value);
        }
    }

    /// <summary>
    /// When the message will actually be sent in RFC3339 format with timezone offset.
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

    /// <summary>
    /// The recipient's phone number in E.164 format.
    /// </summary>
    public string? To
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("to");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("to", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CorrelationID;
        _ = this.CreatedAt;
        this.Encoding?.Validate();
        _ = this.EstimatedSegmentCount;
        _ = this.ExpiresAt;
        _ = this.From;
        _ = this.Locale;
        _ = this.ScheduleAt;
        _ = this.To;
    }

    public Message() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Message(Message message)
        : base(message) { }
#pragma warning restore CS8618

    public Message(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Message(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageFromRaw.FromRawUnchecked"/>
    public static Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageFromRaw : IFromRawJson<Message>
{
    /// <inheritdoc/>
    public Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Message.FromRawUnchecked(rawData);
}

/// <summary>
/// The SMS encoding type based on message content. GSM-7 supports standard characters
/// (up to 160 chars per segment), while UCS-2 supports Unicode including emoji (up
/// to 70 chars per segment). Only present for SMS messages.
/// </summary>
[JsonConverter(typeof(MessageEncodingConverter))]
public enum MessageEncoding
{
    Gsm7,
    Ucs2,
}

sealed class MessageEncodingConverter : JsonConverter<MessageEncoding>
{
    public override MessageEncoding Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GSM-7" => MessageEncoding.Gsm7,
            "UCS-2" => MessageEncoding.Ucs2,
            _ => (MessageEncoding)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageEncoding value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MessageEncoding.Gsm7 => "GSM-7",
                MessageEncoding.Ucs2 => "UCS-2",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
