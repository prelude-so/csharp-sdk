using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using PreludeSdk.Core;
using Text = System.Text;

namespace PreludeSdk.Models.Notify;

/// <summary>
/// Send a free-form text reply to an inbound WhatsApp message within the 24-hour
/// conversation window. See [WhatsApp 2-Way Messaging](/notify/v2/documentation/whatsapp)
/// for details.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class NotifyReplyParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The inbound message ID (prefixed with `im_`) to reply to. This ID is provided
    /// in the `inbound.message.received` webhook event.
    /// </summary>
    public required string ReplyTo
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("reply_to");
        }
        init { this._rawBodyData.Set("reply_to", value); }
    }

    /// <summary>
    /// The reply message body sent as a free-form WhatsApp text.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("text");
        }
        init { this._rawBodyData.Set("text", value); }
    }

    /// <summary>
    /// The recipient's phone number in E.164 format. Must match the phone number
    /// that sent the original inbound message.
    /// </summary>
    public required string To
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("to");
        }
        init { this._rawBodyData.Set("to", value); }
    }

    /// <summary>
    /// The URL where webhooks will be sent for delivery events of this reply.
    /// </summary>
    public string? CallbackUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("callback_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("callback_url", value);
        }
    }

    /// <summary>
    /// A user-defined identifier to correlate this reply with your internal systems.
    /// It is returned in the response and any webhook events that refer to this message.
    /// </summary>
    public string? CorrelationID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("correlation_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("correlation_id", value);
        }
    }

    public NotifyReplyParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotifyReplyParams(NotifyReplyParams notifyReplyParams)
        : base(notifyReplyParams)
    {
        this._rawBodyData = new(notifyReplyParams._rawBodyData);
    }
#pragma warning restore CS8618

    public NotifyReplyParams(
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
    NotifyReplyParams(
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
    public static NotifyReplyParams FromRawUnchecked(
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

    public virtual bool Equals(NotifyReplyParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v2/notify/reply")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Text::Encoding.UTF8,
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
