using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;

namespace PreludeSdk.Models.Transactional;

/// <summary>
/// Legacy route maintained for backward compatibility. Migrate to `/v2/notify` instead.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
[Obsolete("deprecated")]
public record class TransactionalSendParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The template identifier.
    /// </summary>
    public required string TemplateID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("template_id");
        }
        init { this._rawBodyData.Set("template_id", value); }
    }

    /// <summary>
    /// The recipient's phone number.
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
    /// The callback URL.
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
    /// A user-defined identifier to correlate this transactional message with. It
    /// is returned in the response and any webhook events that refer to this transactionalmessage.
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

    /// <summary>
    /// A media attachment to include in the message header. Supported on WhatsApp
    /// templates registered with a `DOCUMENT`, `IMAGE`, or `VIDEO` header. The media
    /// type is determined by the template's registered header format; send the matching
    /// file type for each.
    ///
    /// <para>- `DOCUMENT` headers accept PDF and other document formats; `filename`
    /// is required and displayed to the recipient. - `IMAGE` headers accept `.png`,
    /// `.jpg`, `.jpeg`, and `.webp` URLs; `filename` is ignored. - `VIDEO` headers
    /// accept `.mp4` and `.3gp` URLs; `filename` is ignored. </para>
    /// </summary>
    public Document? Document
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Document>("document");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("document", value);
        }
    }

    /// <summary>
    /// The message expiration date.
    /// </summary>
    public string? ExpiresAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("expires_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("expires_at", value);
        }
    }

    /// <summary>
    /// The Sender ID.
    /// </summary>
    public string? From
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("from");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("from", value);
        }
    }

    /// <summary>
    /// A BCP-47 formatted locale string with the language the text message will
    /// be sent to. If there's no locale set, the language will be determined by
    /// the country code of the phone number. If the language specified doesn't exist,
    /// the default set on the template will be used.
    /// </summary>
    public string? Locale
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("locale");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("locale", value);
        }
    }

    /// <summary>
    /// The preferred delivery channel for the message. When specified, the system
    /// will prioritize sending via the requested channel if the template is configured
    /// for it.
    ///
    /// <para>If not specified and the template is configured for WhatsApp, the message
    /// will be sent via WhatsApp first, with automatic fallback to SMS if WhatsApp
    /// delivery is unavailable.</para>
    ///
    /// <para>Supported channels: `sms`, `rcs`, `whatsapp`. </para>
    /// </summary>
    public ApiEnum<string, PreferredChannel>? PreferredChannel
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, PreferredChannel>>(
                "preferred_channel"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("preferred_channel", value);
        }
    }

    /// <summary>
    /// The variables to be replaced in the template.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Variables
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>(
                "variables"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "variables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public TransactionalSendParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransactionalSendParams(TransactionalSendParams transactionalSendParams)
        : base(transactionalSendParams)
    {
        this._rawBodyData = new(transactionalSendParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TransactionalSendParams(
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
    TransactionalSendParams(
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
    public static TransactionalSendParams FromRawUnchecked(
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

    public virtual bool Equals(TransactionalSendParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v2/transactional")
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

/// <summary>
/// A media attachment to include in the message header. Supported on WhatsApp templates
/// registered with a `DOCUMENT`, `IMAGE`, or `VIDEO` header. The media type is determined
/// by the template's registered header format; send the matching file type for each.
///
/// <para>- `DOCUMENT` headers accept PDF and other document formats; `filename`
/// is required and displayed to the recipient. - `IMAGE` headers accept `.png`,
/// `.jpg`, `.jpeg`, and `.webp` URLs; `filename` is ignored. - `VIDEO` headers accept
/// `.mp4` and `.3gp` URLs; `filename` is ignored. </para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Document, DocumentFromRaw>))]
public sealed record class Document : JsonModel
{
    /// <summary>
    /// HTTPS URL of the media file. The file extension must match the template's
    /// registered header format (PDF for DOCUMENT; PNG/JPG/JPEG/WEBP for IMAGE;
    /// MP4/3GP for VIDEO).
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Filename displayed to the recipient. Required for templates with a `DOCUMENT`
    /// header; ignored for `IMAGE` and `VIDEO` headers.
    /// </summary>
    public string? Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("filename");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filename", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
        _ = this.Filename;
    }

    public Document() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Document(Document document)
        : base(document) { }
#pragma warning restore CS8618

    public Document(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Document(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentFromRaw.FromRawUnchecked"/>
    public static Document FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Document(string url)
        : this()
    {
        this.Url = url;
    }
}

class DocumentFromRaw : IFromRawJson<Document>
{
    /// <inheritdoc/>
    public Document FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Document.FromRawUnchecked(rawData);
}

/// <summary>
/// The preferred delivery channel for the message. When specified, the system will
/// prioritize sending via the requested channel if the template is configured for it.
///
/// <para>If not specified and the template is configured for WhatsApp, the message
/// will be sent via WhatsApp first, with automatic fallback to SMS if WhatsApp delivery
/// is unavailable.</para>
///
/// <para>Supported channels: `sms`, `rcs`, `whatsapp`. </para>
/// </summary>
[JsonConverter(typeof(PreferredChannelConverter))]
public enum PreferredChannel
{
    Sms,
    Rcs,
    Whatsapp,
}

sealed class PreferredChannelConverter : JsonConverter<PreferredChannel>
{
    public override PreferredChannel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms" => PreferredChannel.Sms,
            "rcs" => PreferredChannel.Rcs,
            "whatsapp" => PreferredChannel.Whatsapp,
            _ => (PreferredChannel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreferredChannel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PreferredChannel.Sms => "sms",
                PreferredChannel.Rcs => "rcs",
                PreferredChannel.Whatsapp => "whatsapp",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
