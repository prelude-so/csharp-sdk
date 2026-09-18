using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;

namespace PreludeSdk.Models.Notify;

[JsonConverter(typeof(JsonModelConverter<NotifyReplyResponse, NotifyReplyResponseFromRaw>))]
public sealed record class NotifyReplyResponse : JsonModel
{
    /// <summary>
    /// The reply message identifier.
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
    /// The reply creation date in RFC3339 format.
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
    /// The inbound message ID this reply was sent in response to.
    /// </summary>
    public required string ReplyTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reply_to");
        }
        init { this._rawData.Set("reply_to", value); }
    }

    /// <summary>
    /// The reply message body that was sent.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
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
    /// The user-defined correlation identifier echoed back from the request.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.ReplyTo;
        _ = this.Text;
        _ = this.To;
        _ = this.CallbackUrl;
        _ = this.CorrelationID;
    }

    public NotifyReplyResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotifyReplyResponse(NotifyReplyResponse notifyReplyResponse)
        : base(notifyReplyResponse) { }
#pragma warning restore CS8618

    public NotifyReplyResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotifyReplyResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotifyReplyResponseFromRaw.FromRawUnchecked"/>
    public static NotifyReplyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotifyReplyResponseFromRaw : IFromRawJson<NotifyReplyResponse>
{
    /// <inheritdoc/>
    public NotifyReplyResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NotifyReplyResponse.FromRawUnchecked(rawData);
}
