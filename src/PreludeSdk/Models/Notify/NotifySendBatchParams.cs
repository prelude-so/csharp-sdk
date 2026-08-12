using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using Text = System.Text;

namespace PreludeSdk.Models.Notify;

/// <summary>
/// Send the same message to multiple recipients in a single request.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class NotifySendBatchParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The template identifier configured by your Customer Success team.
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
    /// The list of recipients' phone numbers in E.164 format.
    /// </summary>
    public required IReadOnlyList<string> To
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>("to");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>>(
                "to",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The URL where webhooks will be sent for delivery events.
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
    /// A user-defined identifier to correlate this request with your internal systems.
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
    public NotifySendBatchParamsDocument? Document
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<NotifySendBatchParamsDocument>("document");
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
    /// The message expiration date in RFC3339 format. Messages will not be sent
    /// after this time.
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("expires_at");
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
    /// The Sender ID. Must be approved for your account.
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
    /// A BCP-47 formatted locale string.
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
    /// Maximum number of automatic retry attempts across channels for each send in
    /// the batch, in addition to the first attempt. For example, `2` allows up to
    /// 3 total delivery attempts per recipient. Lower values reduce delivery cost
    /// on hard-to-reach numbers at the expense of deliverability. When omitted, your
    /// account's configured default applies.
    /// </summary>
    public long? MaxAutoRetries
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("max_auto_retries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("max_auto_retries", value);
        }
    }

    /// <summary>
    /// Preferred channel for delivery. If unavailable, automatic fallback applies.
    /// </summary>
    public ApiEnum<string, NotifySendBatchParamsPreferredChannel>? PreferredChannel
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, NotifySendBatchParamsPreferredChannel>
            >("preferred_channel");
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
    /// Schedule delivery in RFC3339 format. Marketing sends may be adjusted to comply
    /// with local time windows.
    /// </summary>
    public DateTimeOffset? ScheduleAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("schedule_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("schedule_at", value);
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

    public NotifySendBatchParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotifySendBatchParams(NotifySendBatchParams notifySendBatchParams)
        : base(notifySendBatchParams)
    {
        this._rawBodyData = new(notifySendBatchParams._rawBodyData);
    }
#pragma warning restore CS8618

    public NotifySendBatchParams(
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
    NotifySendBatchParams(
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
    public static NotifySendBatchParams FromRawUnchecked(
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

    public virtual bool Equals(NotifySendBatchParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v2/notify/batch")
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
[JsonConverter(
    typeof(JsonModelConverter<NotifySendBatchParamsDocument, NotifySendBatchParamsDocumentFromRaw>)
)]
public sealed record class NotifySendBatchParamsDocument : JsonModel
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

    public NotifySendBatchParamsDocument() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotifySendBatchParamsDocument(
        NotifySendBatchParamsDocument notifySendBatchParamsDocument
    )
        : base(notifySendBatchParamsDocument) { }
#pragma warning restore CS8618

    public NotifySendBatchParamsDocument(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotifySendBatchParamsDocument(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotifySendBatchParamsDocumentFromRaw.FromRawUnchecked"/>
    public static NotifySendBatchParamsDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NotifySendBatchParamsDocument(string url)
        : this()
    {
        this.Url = url;
    }
}

class NotifySendBatchParamsDocumentFromRaw : IFromRawJson<NotifySendBatchParamsDocument>
{
    /// <inheritdoc/>
    public NotifySendBatchParamsDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotifySendBatchParamsDocument.FromRawUnchecked(rawData);
}

/// <summary>
/// Preferred channel for delivery. If unavailable, automatic fallback applies.
/// </summary>
[JsonConverter(typeof(NotifySendBatchParamsPreferredChannelConverter))]
public enum NotifySendBatchParamsPreferredChannel
{
    Sms,
    Rcs,
    Whatsapp,
}

sealed class NotifySendBatchParamsPreferredChannelConverter
    : JsonConverter<NotifySendBatchParamsPreferredChannel>
{
    public override NotifySendBatchParamsPreferredChannel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms" => NotifySendBatchParamsPreferredChannel.Sms,
            "rcs" => NotifySendBatchParamsPreferredChannel.Rcs,
            "whatsapp" => NotifySendBatchParamsPreferredChannel.Whatsapp,
            _ => (NotifySendBatchParamsPreferredChannel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NotifySendBatchParamsPreferredChannel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NotifySendBatchParamsPreferredChannel.Sms => "sms",
                NotifySendBatchParamsPreferredChannel.Rcs => "rcs",
                NotifySendBatchParamsPreferredChannel.Whatsapp => "whatsapp",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
