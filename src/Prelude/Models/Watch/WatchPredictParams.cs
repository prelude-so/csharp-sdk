using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Prelude.Core;
using Prelude.Exceptions;
using System = System;

namespace Prelude.Models.Watch;

/// <summary>
/// Predict the outcome of a verification based on Prelude’s anti-fraud system.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WatchPredictParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The prediction target. Only supports phone numbers for now.
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
    /// The metadata for this prediction.
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

    public WatchPredictParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WatchPredictParams(WatchPredictParams watchPredictParams)
        : base(watchPredictParams)
    {
        this._rawBodyData = new(watchPredictParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WatchPredictParams(
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
    WatchPredictParams(
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
    public static WatchPredictParams FromRawUnchecked(
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

    public virtual bool Equals(WatchPredictParams? other)
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v2/watch/predict")
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
/// The prediction target. Only supports phone numbers for now.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Target, TargetFromRaw>))]
public sealed record class Target : JsonModel
{
    /// <summary>
    /// The type of the target. Either "phone_number" or "email_address".
    /// </summary>
    public required ApiEnum<string, global::Prelude.Models.Watch.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Prelude.Models.Watch.Type>
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

sealed class TypeConverter : JsonConverter<global::Prelude.Models.Watch.Type>
{
    public override global::Prelude.Models.Watch.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "phone_number" => global::Prelude.Models.Watch.Type.PhoneNumber,
            "email_address" => global::Prelude.Models.Watch.Type.EmailAddress,
            _ => (global::Prelude.Models.Watch.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Prelude.Models.Watch.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Prelude.Models.Watch.Type.PhoneNumber => "phone_number",
                global::Prelude.Models.Watch.Type.EmailAddress => "email_address",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The metadata for this prediction.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Metadata, MetadataFromRaw>))]
public sealed record class Metadata : JsonModel
{
    /// <summary>
    /// A user-defined identifier to correlate this prediction with. It is returned
    /// in the response and any webhook events that refer to this prediction.
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
