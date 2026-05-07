using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using System = System;

namespace PreludeSdk.Models.Lookup;

[JsonConverter(typeof(JsonModelConverter<LookupLookupResponse, LookupLookupResponseFromRaw>))]
public sealed record class LookupLookupResponse : JsonModel
{
    /// <summary>
    /// The CNAM (Caller ID Name) associated with the phone number. Contact us if
    /// you need to use this functionality. Once enabled, put `cnam` option to `type`
    /// query parameter.
    /// </summary>
    public string? CallerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("caller_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("caller_name", value);
        }
    }

    /// <summary>
    /// The country code of the phone number.
    /// </summary>
    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    /// <summary>
    /// A list of flags associated with the phone number.   * `ported` - Indicates
    /// the phone number has been transferred from one carrier to another.   * `temporary`
    /// - Indicates the phone number is likely a temporary or virtual number, often
    /// used for verification services or burner phones.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, Flag>>? Flags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, Flag>>>("flags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, Flag>>?>(
                "flags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The type of phone line.   * `calling_cards` - Numbers that are associated
    /// with providers of pre-paid domestic and international calling cards.   *
    /// `fixed_line` - Landline phone numbers.   * `isp` - Numbers reserved for Internet
    /// Service Providers.   * `local_rate` - Numbers that can be assigned non-geographically.
    ///   * `mobile` - Mobile phone numbers.   * `other` - Other types of services.
    ///   * `pager` - Number ranges specifically allocated to paging devices.   *
    /// `payphone` - Allocated numbers for payphone kiosks in some countries.   *
    /// `premium_rate` - Landline numbers where the calling party pays more than standard.
    ///   * `satellite` - Satellite phone numbers.   * `service` - Automated applications.
    ///   * `shared_cost` - Specific landline ranges where the cost of making the
    /// call is shared between the calling and called party.   * `short_codes_commercial`
    /// - Short codes are memorable, easy-to-use numbers, like the UK's NHS 111,
    /// often sold to businesses. Not available in all countries.   * `toll_free`
    /// - Number where the called party pays for the cost of the call not the calling
    /// party.   * `universal_access` - Number ranges reserved for Universal Access
    /// initiatives.   * `unknown` - Unknown phone number type.   * `vpn` - Numbers
    /// are used exclusively within a private telecommunications network, connecting
    /// the operator's terminals internally and not accessible via the public telephone
    /// network.   * `voice_mail` - A specific category of Interactive Voice Response
    /// (IVR) services.   * `voip` - Specific ranges for providers of VoIP services
    /// to allow incoming calls from the regular telephony network.
    /// </summary>
    public ApiEnum<string, LineType>? LineType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LineType>>("line_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line_type", value);
        }
    }

    /// <summary>
    /// The current carrier information.
    /// </summary>
    public NetworkInfo? NetworkInfo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NetworkInfo>("network_info");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("network_info", value);
        }
    }

    /// <summary>
    /// The original carrier information.
    /// </summary>
    public OriginalNetworkInfo? OriginalNetworkInfo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OriginalNetworkInfo>("original_network_info");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("original_network_info", value);
        }
    }

    /// <summary>
    /// The phone number.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallerName;
        _ = this.CountryCode;
        foreach (var item in this.Flags ?? [])
        {
            item.Validate();
        }
        this.LineType?.Validate();
        this.NetworkInfo?.Validate();
        this.OriginalNetworkInfo?.Validate();
        _ = this.PhoneNumber;
    }

    public LookupLookupResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LookupLookupResponse(LookupLookupResponse lookupLookupResponse)
        : base(lookupLookupResponse) { }
#pragma warning restore CS8618

    public LookupLookupResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LookupLookupResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LookupLookupResponseFromRaw.FromRawUnchecked"/>
    public static LookupLookupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LookupLookupResponseFromRaw : IFromRawJson<LookupLookupResponse>
{
    /// <inheritdoc/>
    public LookupLookupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LookupLookupResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FlagConverter))]
public enum Flag
{
    Ported,
    Temporary,
}

sealed class FlagConverter : JsonConverter<Flag>
{
    public override Flag Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ported" => Flag.Ported,
            "temporary" => Flag.Temporary,
            _ => (Flag)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Flag value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Flag.Ported => "ported",
                Flag.Temporary => "temporary",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of phone line.   * `calling_cards` - Numbers that are associated with
/// providers of pre-paid domestic and international calling cards.   * `fixed_line`
/// - Landline phone numbers.   * `isp` - Numbers reserved for Internet Service Providers.
///   * `local_rate` - Numbers that can be assigned non-geographically.   * `mobile`
/// - Mobile phone numbers.   * `other` - Other types of services.   * `pager` - Number
/// ranges specifically allocated to paging devices.   * `payphone` - Allocated numbers
/// for payphone kiosks in some countries.   * `premium_rate` - Landline numbers
/// where the calling party pays more than standard.   * `satellite` - Satellite
/// phone numbers.   * `service` - Automated applications.   * `shared_cost` - Specific
/// landline ranges where the cost of making the call is shared between the calling
/// and called party.   * `short_codes_commercial` - Short codes are memorable, easy-to-use
/// numbers, like the UK's NHS 111, often sold to businesses. Not available in all
/// countries.   * `toll_free` - Number where the called party pays for the cost of
/// the call not the calling party.   * `universal_access` - Number ranges reserved
/// for Universal Access initiatives.   * `unknown` - Unknown phone number type.
///  * `vpn` - Numbers are used exclusively within a private telecommunications network,
/// connecting the operator's terminals internally and not accessible via the public
/// telephone network.   * `voice_mail` - A specific category of Interactive Voice
/// Response (IVR) services.   * `voip` - Specific ranges for providers of VoIP services
/// to allow incoming calls from the regular telephony network.
/// </summary>
[JsonConverter(typeof(LineTypeConverter))]
public enum LineType
{
    CallingCards,
    FixedLine,
    Isp,
    LocalRate,
    Mobile,
    Other,
    Pager,
    Payphone,
    PremiumRate,
    Satellite,
    Service,
    SharedCost,
    ShortCodesCommercial,
    TollFree,
    UniversalAccess,
    Unknown,
    Vpn,
    VoiceMail,
    Voip,
}

sealed class LineTypeConverter : JsonConverter<LineType>
{
    public override LineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "calling_cards" => LineType.CallingCards,
            "fixed_line" => LineType.FixedLine,
            "isp" => LineType.Isp,
            "local_rate" => LineType.LocalRate,
            "mobile" => LineType.Mobile,
            "other" => LineType.Other,
            "pager" => LineType.Pager,
            "payphone" => LineType.Payphone,
            "premium_rate" => LineType.PremiumRate,
            "satellite" => LineType.Satellite,
            "service" => LineType.Service,
            "shared_cost" => LineType.SharedCost,
            "short_codes_commercial" => LineType.ShortCodesCommercial,
            "toll_free" => LineType.TollFree,
            "universal_access" => LineType.UniversalAccess,
            "unknown" => LineType.Unknown,
            "vpn" => LineType.Vpn,
            "voice_mail" => LineType.VoiceMail,
            "voip" => LineType.Voip,
            _ => (LineType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, LineType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LineType.CallingCards => "calling_cards",
                LineType.FixedLine => "fixed_line",
                LineType.Isp => "isp",
                LineType.LocalRate => "local_rate",
                LineType.Mobile => "mobile",
                LineType.Other => "other",
                LineType.Pager => "pager",
                LineType.Payphone => "payphone",
                LineType.PremiumRate => "premium_rate",
                LineType.Satellite => "satellite",
                LineType.Service => "service",
                LineType.SharedCost => "shared_cost",
                LineType.ShortCodesCommercial => "short_codes_commercial",
                LineType.TollFree => "toll_free",
                LineType.UniversalAccess => "universal_access",
                LineType.Unknown => "unknown",
                LineType.Vpn => "vpn",
                LineType.VoiceMail => "voice_mail",
                LineType.Voip => "voip",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The current carrier information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NetworkInfo, NetworkInfoFromRaw>))]
public sealed record class NetworkInfo : JsonModel
{
    /// <summary>
    /// The name of the carrier.
    /// </summary>
    public string? CarrierName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("carrier_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("carrier_name", value);
        }
    }

    /// <summary>
    /// Mobile Country Code.
    /// </summary>
    public string? Mcc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mcc");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mcc", value);
        }
    }

    /// <summary>
    /// Mobile Network Code.
    /// </summary>
    public string? Mnc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mnc");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mnc", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CarrierName;
        _ = this.Mcc;
        _ = this.Mnc;
    }

    public NetworkInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkInfo(NetworkInfo networkInfo)
        : base(networkInfo) { }
#pragma warning restore CS8618

    public NetworkInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NetworkInfoFromRaw.FromRawUnchecked"/>
    public static NetworkInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NetworkInfoFromRaw : IFromRawJson<NetworkInfo>
{
    /// <inheritdoc/>
    public NetworkInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NetworkInfo.FromRawUnchecked(rawData);
}

/// <summary>
/// The original carrier information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OriginalNetworkInfo, OriginalNetworkInfoFromRaw>))]
public sealed record class OriginalNetworkInfo : JsonModel
{
    /// <summary>
    /// The name of the original carrier.
    /// </summary>
    public string? CarrierName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("carrier_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("carrier_name", value);
        }
    }

    /// <summary>
    /// Mobile Country Code.
    /// </summary>
    public string? Mcc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mcc");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mcc", value);
        }
    }

    /// <summary>
    /// Mobile Network Code.
    /// </summary>
    public string? Mnc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mnc");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mnc", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CarrierName;
        _ = this.Mcc;
        _ = this.Mnc;
    }

    public OriginalNetworkInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OriginalNetworkInfo(OriginalNetworkInfo originalNetworkInfo)
        : base(originalNetworkInfo) { }
#pragma warning restore CS8618

    public OriginalNetworkInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OriginalNetworkInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginalNetworkInfoFromRaw.FromRawUnchecked"/>
    public static OriginalNetworkInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginalNetworkInfoFromRaw : IFromRawJson<OriginalNetworkInfo>
{
    /// <inheritdoc/>
    public OriginalNetworkInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OriginalNetworkInfo.FromRawUnchecked(rawData);
}
