using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using System = System;

namespace PreludeSdk.Models;

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
    /// Whether the end-user already exists in your system, for example an existing
    /// account signing in again rather than a first-time signup. Unlike `is_trusted_user`,
    /// this signal does not bypass fraud checks; it is taken into account as one
    /// additional anti-fraud signal. For more details, refer to [Signals](/verify/v2/documentation/prevent-fraud#signals).
    /// </summary>
    public bool? ExistingUser
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("existing_user");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("existing_user", value);
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
        _ = this.ExistingUser;
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
