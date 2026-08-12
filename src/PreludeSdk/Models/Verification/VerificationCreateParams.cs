using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using System = System;

namespace PreludeSdk.Models.Verification;

/// <summary>
/// Create a new verification for a specific phone number. If another non-expired
/// verification exists (the request is performed within the verification window),
/// this endpoint will perform a retry instead.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VerificationCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The verification target. Either a phone number or an email address. To use
    /// the email verification feature contact us to discuss your use case.
    /// </summary>
    public required Target Target
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Target>("target");
        }
        init { this._rawBodyData.Set("target", value); }
    }

    /// <summary>
    /// The identifier of the dispatch that came from the front-end SDK.
    /// </summary>
    public string? DispatchID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("dispatch_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("dispatch_id", value);
        }
    }

    /// <summary>
    /// The metadata for this verification. This object will be returned with every
    /// response or webhook sent that refers to this verification.
    /// </summary>
    public Metadata? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Metadata>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("metadata", value);
        }
    }

    /// <summary>
    /// Verification options
    /// </summary>
    public Options? Options
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Options>("options");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("options", value);
        }
    }

    /// <summary>
    /// The signals used for anti-fraud. For more details, refer to [Signals](/verify/v2/documentation/prevent-fraud#signals).
    /// </summary>
    public Signals? Signals
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Signals>("signals");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("signals", value);
        }
    }

    public VerificationCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerificationCreateParams(VerificationCreateParams verificationCreateParams)
        : base(verificationCreateParams)
    {
        this._rawBodyData = new(verificationCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public VerificationCreateParams(
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
    VerificationCreateParams(
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
    public static VerificationCreateParams FromRawUnchecked(
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

    public virtual bool Equals(VerificationCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v2/verification")
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
/// The verification target. Either a phone number or an email address. To use the
/// email verification feature contact us to discuss your use case.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Target, TargetFromRaw>))]
public sealed record class Target : JsonModel
{
    /// <summary>
    /// The type of the target. Either "phone_number" or "email_address".
    /// </summary>
    public required ApiEnum<string, global::PreludeSdk.Models.Verification.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::PreludeSdk.Models.Verification.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// An E.164 formatted phone number or an email address.
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Value;
    }

    public Target() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Target(Target target)
        : base(target) { }
#pragma warning restore CS8618

    public Target(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Target(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TargetFromRaw.FromRawUnchecked"/>
    public static Target FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TargetFromRaw : IFromRawJson<Target>
{
    /// <inheritdoc/>
    public Target FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Target.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the target. Either "phone_number" or "email_address".
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    PhoneNumber,
    EmailAddress,
}

sealed class TypeConverter : JsonConverter<global::PreludeSdk.Models.Verification.Type>
{
    public override global::PreludeSdk.Models.Verification.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "phone_number" => global::PreludeSdk.Models.Verification.Type.PhoneNumber,
            "email_address" => global::PreludeSdk.Models.Verification.Type.EmailAddress,
            _ => (global::PreludeSdk.Models.Verification.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::PreludeSdk.Models.Verification.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::PreludeSdk.Models.Verification.Type.PhoneNumber => "phone_number",
                global::PreludeSdk.Models.Verification.Type.EmailAddress => "email_address",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The metadata for this verification. This object will be returned with every response
/// or webhook sent that refers to this verification.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Metadata, MetadataFromRaw>))]
public sealed record class Metadata : JsonModel
{
    /// <summary>
    /// A user-defined identifier to correlate this verification with. It is returned
    /// in the response and any webhook events that refer to this verification.
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
        _ = this.CorrelationID;
    }

    public Metadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Metadata(Metadata metadata)
        : base(metadata) { }
#pragma warning restore CS8618

    public Metadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetadataFromRaw.FromRawUnchecked"/>
    public static Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetadataFromRaw : IFromRawJson<Metadata>
{
    /// <inheritdoc/>
    public Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Metadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Verification options
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Options, OptionsFromRaw>))]
public sealed record class Options : JsonModel
{
    /// <summary>
    /// This allows automatic OTP retrieval on mobile apps and web browsers. Supported
    /// platforms are Android (SMS Retriever API) and Web (WebOTP API).
    /// </summary>
    public AppRealm? AppRealm
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AppRealm>("app_realm");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("app_realm", value);
        }
    }

    /// <summary>
    /// The URL where webhooks will be sent when verification events occur, including
    /// verification creation, attempt creation, and delivery status changes. For
    /// more details, refer to [Webhook](/verify/v2/documentation/webhook).
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
    /// The channels this verification may use, in the order they are tried. Channels
    /// you omit are never used, including on retries. This option can only be set
    /// when the verification is created. The list is recorded on the verification
    /// and applies for its whole lifecycle, so `channels` sent while retrying an
    /// existing verification is ignored — unlike `preferred_channel`, which is honored
    /// on every retry. Every channel you list must be enabled on your account and
    /// active in the destination country, otherwise the request fails with `channel_not_enabled_in_region`.
    /// Prelude still picks the best provider within each channel. Cannot be combined
    /// with `preferred_channel`. Voice is requested through `method` instead. Disabled
    /// by default — contact support to enable it.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, Channel>>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, Channel>>>(
                "channels"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, Channel>>?>(
                "channels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The size of the code generated. It should be between 4 and 8. Defaults to
    /// the code size specified from the Dashboard.
    /// </summary>
    public long? CodeSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("code_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code_size", value);
        }
    }

    /// <summary>
    /// The custom code to use for OTP verification. To use the custom code feature,
    /// contact us to enable it for your account. For more details, refer to [Custom Code](/verify/v2/documentation/custom-codes).
    /// </summary>
    public string? CustomCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("custom_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("custom_code", value);
        }
    }

    /// <summary>
    /// When `true`, the verification is routed through challenge-safe channels (non-SMS/Voice)
    /// regardless of country eligibility or any antispam outcome. The resulting
    /// verification has `status: "challenged"`. Use this when you have your own signal
    /// that the request is suspicious and want stricter routing — the verification
    /// is **not** classified as fraud and does not contribute to anti-fraud counters
    /// or risk factors. This feature is disabled by default — contact Prelude support
    /// to enable it on your account.
    /// </summary>
    public bool? ForceChallenge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("force_challenge");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("force_challenge", value);
        }
    }

    /// <summary>
    /// A BCP-47 formatted locale string with the language the text message will
    /// be sent to. If there's no locale set, the language will be determined by
    /// the country code of the phone number. If the language specified doesn't exist,
    /// it defaults to US English.
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
    /// Maximum number of delivery attempts Prelude may add on its own after the one
    /// you requested. `0` means a single attempt: if it cannot be delivered, Prelude
    /// neither tries another provider nor another channel, and does not retry automatically.
    /// `1` allows one additional attempt, and so on — a value larger than the number
    /// of routes available for the destination simply behaves like the default. When
    /// omitted, Prelude retries as your account is configured, across as many channels
    /// as the route offers.
    ///
    /// <para>This option can only be set when the verification is created. The value
    /// is recorded on the verification and applies for its whole lifecycle, so a
    /// `max_auto_fallbacks` sent while retrying an existing verification is ignored
    /// — the limit cannot be raised or lowered after the fact. A retry you ask for
    /// is not an automatic attempt, so it gets a fresh allowance of the same limit.
    /// This option is disabled by default — contact Prelude support to enable it
    /// on your account. </para>
    /// </summary>
    public long? MaxAutoFallbacks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_auto_fallbacks");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("max_auto_fallbacks", value);
        }
    }

    /// <summary>
    /// The method used for verifying this phone number. The 'voice' option provides
    /// an accessible alternative for visually impaired users by delivering the verification
    /// code through a phone call rather than a text message. It also allows verification
    /// of landline numbers that cannot receive SMS messages. The 'message' option
    /// explicitly requests message delivery (SMS, WhatsApp ...) and skips silent
    /// verification, useful for scenarios requiring direct user interaction.
    /// </summary>
    public ApiEnum<string, Method>? Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Method>>("method");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("method", value);
        }
    }

    /// <summary>
    /// The channel to prioritize when delivering the verification. Prelude prioritizes
    /// this channel on the first attempt and continues to prefer it on retries while
    /// an untried route on that channel remains; once those are exhausted, retries
    /// fall back to the next best available route. If the channel is unavailable
    /// (for example, when a verification is challenged), Prelude uses the best available
    /// route instead. Cannot be combined with `channels`.
    /// </summary>
    public ApiEnum<string, PreferredChannel>? PreferredChannel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PreferredChannel>>(
                "preferred_channel"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("preferred_channel", value);
        }
    }

    /// <summary>
    /// The Sender ID to use for this message. The Sender ID needs to be enabled by Prelude.
    /// </summary>
    public string? SenderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sender_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sender_id", value);
        }
    }

    /// <summary>
    /// The identifier of a verification template. It applies use case-specific settings,
    /// such as the message content or certain verification parameters.
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
    /// The variables to be replaced in the template.
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
        this.AppRealm?.Validate();
        _ = this.CallbackUrl;
        foreach (var item in this.Channels ?? [])
        {
            item.Validate();
        }
        _ = this.CodeSize;
        _ = this.CustomCode;
        _ = this.ForceChallenge;
        _ = this.Locale;
        _ = this.MaxAutoFallbacks;
        this.Method?.Validate();
        this.PreferredChannel?.Validate();
        _ = this.SenderID;
        _ = this.TemplateID;
        _ = this.Variables;
    }

    public Options() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Options(Options options)
        : base(options) { }
#pragma warning restore CS8618

    public Options(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Options(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OptionsFromRaw.FromRawUnchecked"/>
    public static Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OptionsFromRaw : IFromRawJson<Options>
{
    /// <inheritdoc/>
    public Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Options.FromRawUnchecked(rawData);
}

/// <summary>
/// This allows automatic OTP retrieval on mobile apps and web browsers. Supported
/// platforms are Android (SMS Retriever API) and Web (WebOTP API).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AppRealm, AppRealmFromRaw>))]
public sealed record class AppRealm : JsonModel
{
    /// <summary>
    /// The platform for automatic OTP retrieval. Use "android" for the SMS Retriever
    /// API or "web" for the WebOTP API.
    /// </summary>
    public required ApiEnum<string, Platform> Platform
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Platform>>("platform");
        }
        init { this._rawData.Set("platform", value); }
    }

    /// <summary>
    /// The value depends on the platform: - For Android: The SMS Retriever API hash
    /// code (11 characters). See [Google documentation](https://developers.google.com/identity/sms-retriever/verify#computing_your_apps_hash_string).
    /// - For Web: The origin domain (e.g., "example.com" or "www.example.com").
    /// See [WebOTP API documentation](https://developer.mozilla.org/en-US/docs/Web/API/WebOTP_API).
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Platform.Validate();
        _ = this.Value;
    }

    public AppRealm() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AppRealm(AppRealm appRealm)
        : base(appRealm) { }
#pragma warning restore CS8618

    public AppRealm(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AppRealm(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AppRealmFromRaw.FromRawUnchecked"/>
    public static AppRealm FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AppRealmFromRaw : IFromRawJson<AppRealm>
{
    /// <inheritdoc/>
    public AppRealm FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AppRealm.FromRawUnchecked(rawData);
}

/// <summary>
/// The platform for automatic OTP retrieval. Use "android" for the SMS Retriever
/// API or "web" for the WebOTP API.
/// </summary>
[JsonConverter(typeof(PlatformConverter))]
public enum Platform
{
    Android,
    Web,
}

sealed class PlatformConverter : JsonConverter<Platform>
{
    public override Platform Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "android" => Platform.Android,
            "web" => Platform.Web,
            _ => (Platform)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Platform value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Platform.Android => "android",
                Platform.Web => "web",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
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
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The method used for verifying this phone number. The 'voice' option provides
/// an accessible alternative for visually impaired users by delivering the verification
/// code through a phone call rather than a text message. It also allows verification
/// of landline numbers that cannot receive SMS messages. The 'message' option explicitly
/// requests message delivery (SMS, WhatsApp ...) and skips silent verification, useful
/// for scenarios requiring direct user interaction.
/// </summary>
[JsonConverter(typeof(MethodConverter))]
public enum Method
{
    Auto,
    Voice,
    Message,
}

sealed class MethodConverter : JsonConverter<Method>
{
    public override Method Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => Method.Auto,
            "voice" => Method.Voice,
            "message" => Method.Message,
            _ => (Method)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Method value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Method.Auto => "auto",
                Method.Voice => "voice",
                Method.Message => "message",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The channel to prioritize when delivering the verification. Prelude prioritizes
/// this channel on the first attempt and continues to prefer it on retries while
/// an untried route on that channel remains; once those are exhausted, retries fall
/// back to the next best available route. If the channel is unavailable (for example,
/// when a verification is challenged), Prelude uses the best available route instead.
/// Cannot be combined with `channels`.
/// </summary>
[JsonConverter(typeof(PreferredChannelConverter))]
public enum PreferredChannel
{
    Sms,
    Rcs,
    Whatsapp,
    Viber,
    Zalo,
    Telegram,
}

sealed class PreferredChannelConverter : JsonConverter<PreferredChannel>
{
    public override PreferredChannel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms" => PreferredChannel.Sms,
            "rcs" => PreferredChannel.Rcs,
            "whatsapp" => PreferredChannel.Whatsapp,
            "viber" => PreferredChannel.Viber,
            "zalo" => PreferredChannel.Zalo,
            "telegram" => PreferredChannel.Telegram,
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
                PreferredChannel.Viber => "viber",
                PreferredChannel.Zalo => "zalo",
                PreferredChannel.Telegram => "telegram",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The signals used for anti-fraud. For more details, refer to [Signals](/verify/v2/documentation/prevent-fraud#signals).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Signals, SignalsFromRaw>))]
public sealed record class Signals : JsonModel
{
    /// <summary>
    /// The version of your application.
    /// </summary>
    public string? AppVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("app_version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("app_version", value);
        }
    }

    /// <summary>
    /// A unique ID for the user's device. You should ensure that each user device
    /// has a unique `device_id` value. Ideally, for Android, this corresponds to
    /// the `ANDROID_ID` and for iOS, this corresponds to the `identifierForVendor`.
    /// </summary>
    public string? DeviceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("device_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("device_id", value);
        }
    }

    /// <summary>
    /// The model of the user's device.
    /// </summary>
    public string? DeviceModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("device_model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("device_model", value);
        }
    }

    /// <summary>
    /// The type of the user's device.
    /// </summary>
    public ApiEnum<string, DevicePlatform>? DevicePlatform
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DevicePlatform>>(
                "device_platform"
            );
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
    /// The public IP v4 or v6 address of the end-user's device. You should collect
    /// this from your backend. If your backend is behind a proxy, use the `X-Forwarded-For`,
    /// `Forwarded`, `True-Client-IP`, `CF-Connecting-IP` or an equivalent header
    /// to get the actual public IP of the end-user's device.
    /// </summary>
    public string? IP
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ip");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ip", value);
        }
    }

    /// <summary>
    /// This signal should indicate a higher level of trust, explicitly stating that
    /// the user is genuine. Contact us to discuss your use case. For more details,
    /// refer to [Signals](/verify/v2/documentation/prevent-fraud#signals).
    /// </summary>
    public bool? IsTrustedUser
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_trusted_user");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_trusted_user", value);
        }
    }

    /// <summary>
    /// The JA4 fingerprint observed for the end-user's connection. Prelude will
    /// infer it automatically when you use our Frontend SDKs (which use Prelude's
    /// edge network), but you can also forward the value if you terminate TLS yourself.
    /// </summary>
    public string? Ja4Fingerprint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ja4_fingerprint");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ja4_fingerprint", value);
        }
    }

    /// <summary>
    /// The version of the user's device operating system.
    /// </summary>
    public string? OsVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("os_version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("os_version", value);
        }
    }

    /// <summary>
    /// The user agent of the user's device. If the individual fields (os_version,
    /// device_platform, device_model) are provided, we will prioritize those values
    /// instead of parsing them from the user agent string.
    /// </summary>
    public string? UserAgent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_agent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("user_agent", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AppVersion;
        _ = this.DeviceID;
        _ = this.DeviceModel;
        this.DevicePlatform?.Validate();
        _ = this.IP;
        _ = this.IsTrustedUser;
        _ = this.Ja4Fingerprint;
        _ = this.OsVersion;
        _ = this.UserAgent;
    }

    public Signals() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Signals(Signals signals)
        : base(signals) { }
#pragma warning restore CS8618

    public Signals(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Signals(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SignalsFromRaw.FromRawUnchecked"/>
    public static Signals FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SignalsFromRaw : IFromRawJson<Signals>
{
    /// <inheritdoc/>
    public Signals FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Signals.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the user's device.
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
