using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using System = System;

namespace PreludeSdk.Models.Verification;

[JsonConverter(
    typeof(JsonModelConverter<VerificationCreateResponse, VerificationCreateResponseFromRaw>)
)]
public sealed record class VerificationCreateResponse : JsonModel
{
    /// <summary>
    /// The verification identifier.
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
    /// The method used for verifying this phone number.
    /// </summary>
    public required ApiEnum<string, VerificationCreateResponseMethod> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VerificationCreateResponseMethod>>(
                "method"
            );
        }
        init { this._rawData.Set("method", value); }
    }

    /// <summary>
    /// The status of the verification.  * `success` - A new verification window
    /// was created.  * `retry` - A new attempt was created for an existing verification
    /// window.  * `challenged` - The verification is suspicious and is restricted
    /// to non-SMS and non-voice channels only. This mode must be enabled for your
    /// customer account by Prelude support.  * `blocked` - The verification was blocked.
    ///  * `shadow_blocked` - The verification triggered a block rule but the decision
    /// was not enforced; this is used to dry-run anti-fraud configuration. This mode
    /// must be enabled for your customer account by Prelude support.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The ordered sequence of channels to be used for verification
    /// </summary>
    public IReadOnlyList<ApiEnum<string, VerificationCreateResponseChannel>>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, VerificationCreateResponseChannel>>
            >("channels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, VerificationCreateResponseChannel>>?>(
                "channels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The metadata for this verification.
    /// </summary>
    public VerificationCreateResponseMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerificationCreateResponseMetadata>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <summary>
    /// The reason why the verification was blocked. Only present when status is
    /// "blocked" or "shadow_blocked".  * `expired_signature` - The signature of the
    /// SDK signals is expired. They should be sent within    the hour following
    /// their collection.  * `in_block_list` - The phone number is part of the configured
    /// block list.  * `invalid_phone_line` - The phone number is not a valid line
    /// number (e.g. landline).  * `invalid_phone_number` - The phone number is not
    /// a valid phone number (e.g. unallocated range).  * `invalid_signature` - The
    /// SDK signature did not verify, so the request cannot be attributed to the device
    /// it claims to come from.  * `repeated_attempts` - The phone number exceeded
    /// the allowed number of verification attempts in a short period.  * `suspicious`
    /// - The verification attempt was deemed suspicious by the anti-fraud system.
    /// </summary>
    public ApiEnum<string, Reason>? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Reason>>("reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

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
    /// The risk factors that contributed to the verification being blocked. Only
    /// present when status is "blocked" or "shadow_blocked" and the anti-fraud system
    /// detected specific risk signals.  * `automation_signature` - The request appears
    /// to come from an automated client rather than a person.  * `carrier_not_permitted`
    /// - The destination carrier is one this account does not accept traffic for.
    ///  * `client_fingerprint_mismatch` - The client does not appear to be the platform
    /// it identifies itself as.  * `custom_policy` - A rule configured for your account
    /// matched this request.  * `device_emulator` - The request appears to come from
    /// an emulator rather than a physical device.  * `device_not_permitted` - The
    /// device platform is one your account blocks.  * `device_reuse` - One device
    /// is driving verifications for an unusual number of phone numbers.  * `expired_signals`
    /// - The SDK signals were collected too long before the request to still attest
    /// to it.  * `fraud_database` - The phone number is flagged in one or more of
    /// the fraud databases Prelude consults.  * `invalid_signature` - The SDK signature
    /// did not verify, so the request cannot be attributed to the device it claims
    /// to come from.  * `ip_concentration` - The request shares its origin with an
    /// unusual volume of other verifications.  * `ip_reputation` - The originating
    /// IP address is not trusted.  * `location_mismatch` - The network location and
    /// the phone number's country are inconsistent.  * `missing_signals` - The verification
    /// expected Prelude SDK signals and none arrived.  * `number_range_abuse` - The
    /// phone number belongs to a range currently associated with abuse.  * `poor_conversion_history`
    /// - Traffic resembling this request rarely completes a verification.  * `proxy_network`
    /// - The request did not arrive over the subscriber's own access network.  *
    /// `repeated_attempts` - The phone number exceeded the allowed number of verification
    /// attempts in a short period.  * `temporary_phone_number` - The phone number
    /// belongs to a disposable or short-lived numbering service.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, RiskFactor>>? RiskFactors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, RiskFactor>>>(
                "risk_factors"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, RiskFactor>>?>(
                "risk_factors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The silent verification specific properties.
    /// </summary>
    public Silent? Silent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Silent>("silent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("silent", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Method.Validate();
        this.Status.Validate();
        foreach (var item in this.Channels ?? [])
        {
            item.Validate();
        }
        this.Metadata?.Validate();
        this.Reason?.Validate();
        _ = this.RequestID;
        foreach (var item in this.RiskFactors ?? [])
        {
            item.Validate();
        }
        this.Silent?.Validate();
    }

    public VerificationCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerificationCreateResponse(VerificationCreateResponse verificationCreateResponse)
        : base(verificationCreateResponse) { }
#pragma warning restore CS8618

    public VerificationCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerificationCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerificationCreateResponseFromRaw.FromRawUnchecked"/>
    public static VerificationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerificationCreateResponseFromRaw : IFromRawJson<VerificationCreateResponse>
{
    /// <inheritdoc/>
    public VerificationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerificationCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The method used for verifying this phone number.
/// </summary>
[JsonConverter(typeof(VerificationCreateResponseMethodConverter))]
public enum VerificationCreateResponseMethod
{
    Email,
    Message,
    Silent,
    Voice,
}

sealed class VerificationCreateResponseMethodConverter
    : JsonConverter<VerificationCreateResponseMethod>
{
    public override VerificationCreateResponseMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email" => VerificationCreateResponseMethod.Email,
            "message" => VerificationCreateResponseMethod.Message,
            "silent" => VerificationCreateResponseMethod.Silent,
            "voice" => VerificationCreateResponseMethod.Voice,
            _ => (VerificationCreateResponseMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerificationCreateResponseMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerificationCreateResponseMethod.Email => "email",
                VerificationCreateResponseMethod.Message => "message",
                VerificationCreateResponseMethod.Silent => "silent",
                VerificationCreateResponseMethod.Voice => "voice",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the verification.  * `success` - A new verification window was created.
///  * `retry` - A new attempt was created for an existing verification window.  *
/// `challenged` - The verification is suspicious and is restricted to non-SMS and
/// non-voice channels only. This mode must be enabled for your customer account
/// by Prelude support.  * `blocked` - The verification was blocked.  * `shadow_blocked`
/// - The verification triggered a block rule but the decision was not enforced; this
/// is used to dry-run anti-fraud configuration. This mode must be enabled for your
/// customer account by Prelude support.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Success,
    Retry,
    Challenged,
    Blocked,
    ShadowBlocked,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => Status.Success,
            "retry" => Status.Retry,
            "challenged" => Status.Challenged,
            "blocked" => Status.Blocked,
            "shadow_blocked" => Status.ShadowBlocked,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Success => "success",
                Status.Retry => "retry",
                Status.Challenged => "challenged",
                Status.Blocked => "blocked",
                Status.ShadowBlocked => "shadow_blocked",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(VerificationCreateResponseChannelConverter))]
public enum VerificationCreateResponseChannel
{
    Rcs,
    Silent,
    Sms,
    Telegram,
    Viber,
    Voice,
    Whatsapp,
    Zalo,
}

sealed class VerificationCreateResponseChannelConverter
    : JsonConverter<VerificationCreateResponseChannel>
{
    public override VerificationCreateResponseChannel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "rcs" => VerificationCreateResponseChannel.Rcs,
            "silent" => VerificationCreateResponseChannel.Silent,
            "sms" => VerificationCreateResponseChannel.Sms,
            "telegram" => VerificationCreateResponseChannel.Telegram,
            "viber" => VerificationCreateResponseChannel.Viber,
            "voice" => VerificationCreateResponseChannel.Voice,
            "whatsapp" => VerificationCreateResponseChannel.Whatsapp,
            "zalo" => VerificationCreateResponseChannel.Zalo,
            _ => (VerificationCreateResponseChannel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerificationCreateResponseChannel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerificationCreateResponseChannel.Rcs => "rcs",
                VerificationCreateResponseChannel.Silent => "silent",
                VerificationCreateResponseChannel.Sms => "sms",
                VerificationCreateResponseChannel.Telegram => "telegram",
                VerificationCreateResponseChannel.Viber => "viber",
                VerificationCreateResponseChannel.Voice => "voice",
                VerificationCreateResponseChannel.Whatsapp => "whatsapp",
                VerificationCreateResponseChannel.Zalo => "zalo",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The metadata for this verification.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerificationCreateResponseMetadata,
        VerificationCreateResponseMetadataFromRaw
    >)
)]
public sealed record class VerificationCreateResponseMetadata : JsonModel
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

    public VerificationCreateResponseMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerificationCreateResponseMetadata(
        VerificationCreateResponseMetadata verificationCreateResponseMetadata
    )
        : base(verificationCreateResponseMetadata) { }
#pragma warning restore CS8618

    public VerificationCreateResponseMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerificationCreateResponseMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerificationCreateResponseMetadataFromRaw.FromRawUnchecked"/>
    public static VerificationCreateResponseMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerificationCreateResponseMetadataFromRaw : IFromRawJson<VerificationCreateResponseMetadata>
{
    /// <inheritdoc/>
    public VerificationCreateResponseMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerificationCreateResponseMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason why the verification was blocked. Only present when status is "blocked"
/// or "shadow_blocked".  * `expired_signature` - The signature of the SDK signals
/// is expired. They should be sent within    the hour following their collection.
///  * `in_block_list` - The phone number is part of the configured block list.  *
/// `invalid_phone_line` - The phone number is not a valid line number (e.g. landline).
///  * `invalid_phone_number` - The phone number is not a valid phone number (e.g.
/// unallocated range).  * `invalid_signature` - The SDK signature did not verify,
/// so the request cannot be attributed to the device it claims to come from.  *
/// `repeated_attempts` - The phone number exceeded the allowed number of verification
/// attempts in a short period.  * `suspicious` - The verification attempt was deemed
/// suspicious by the anti-fraud system.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    ExpiredSignature,
    InBlockList,
    InvalidPhoneLine,
    InvalidPhoneNumber,
    InvalidSignature,
    RepeatedAttempts,
    Suspicious,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "expired_signature" => Reason.ExpiredSignature,
            "in_block_list" => Reason.InBlockList,
            "invalid_phone_line" => Reason.InvalidPhoneLine,
            "invalid_phone_number" => Reason.InvalidPhoneNumber,
            "invalid_signature" => Reason.InvalidSignature,
            "repeated_attempts" => Reason.RepeatedAttempts,
            "suspicious" => Reason.Suspicious,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.ExpiredSignature => "expired_signature",
                Reason.InBlockList => "in_block_list",
                Reason.InvalidPhoneLine => "invalid_phone_line",
                Reason.InvalidPhoneNumber => "invalid_phone_number",
                Reason.InvalidSignature => "invalid_signature",
                Reason.RepeatedAttempts => "repeated_attempts",
                Reason.Suspicious => "suspicious",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(RiskFactorConverter))]
public enum RiskFactor
{
    AutomationSignature,
    CarrierNotPermitted,
    ClientFingerprintMismatch,
    CustomPolicy,
    DeviceEmulator,
    DeviceNotPermitted,
    DeviceReuse,
    ExpiredSignals,
    FraudDatabase,
    InvalidSignature,
    IPConcentration,
    IPReputation,
    LocationMismatch,
    MissingSignals,
    NumberRangeAbuse,
    PoorConversionHistory,
    ProxyNetwork,
    RepeatedAttempts,
    TemporaryPhoneNumber,
}

sealed class RiskFactorConverter : JsonConverter<RiskFactor>
{
    public override RiskFactor Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "automation_signature" => RiskFactor.AutomationSignature,
            "carrier_not_permitted" => RiskFactor.CarrierNotPermitted,
            "client_fingerprint_mismatch" => RiskFactor.ClientFingerprintMismatch,
            "custom_policy" => RiskFactor.CustomPolicy,
            "device_emulator" => RiskFactor.DeviceEmulator,
            "device_not_permitted" => RiskFactor.DeviceNotPermitted,
            "device_reuse" => RiskFactor.DeviceReuse,
            "expired_signals" => RiskFactor.ExpiredSignals,
            "fraud_database" => RiskFactor.FraudDatabase,
            "invalid_signature" => RiskFactor.InvalidSignature,
            "ip_concentration" => RiskFactor.IPConcentration,
            "ip_reputation" => RiskFactor.IPReputation,
            "location_mismatch" => RiskFactor.LocationMismatch,
            "missing_signals" => RiskFactor.MissingSignals,
            "number_range_abuse" => RiskFactor.NumberRangeAbuse,
            "poor_conversion_history" => RiskFactor.PoorConversionHistory,
            "proxy_network" => RiskFactor.ProxyNetwork,
            "repeated_attempts" => RiskFactor.RepeatedAttempts,
            "temporary_phone_number" => RiskFactor.TemporaryPhoneNumber,
            _ => (RiskFactor)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RiskFactor value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RiskFactor.AutomationSignature => "automation_signature",
                RiskFactor.CarrierNotPermitted => "carrier_not_permitted",
                RiskFactor.ClientFingerprintMismatch => "client_fingerprint_mismatch",
                RiskFactor.CustomPolicy => "custom_policy",
                RiskFactor.DeviceEmulator => "device_emulator",
                RiskFactor.DeviceNotPermitted => "device_not_permitted",
                RiskFactor.DeviceReuse => "device_reuse",
                RiskFactor.ExpiredSignals => "expired_signals",
                RiskFactor.FraudDatabase => "fraud_database",
                RiskFactor.InvalidSignature => "invalid_signature",
                RiskFactor.IPConcentration => "ip_concentration",
                RiskFactor.IPReputation => "ip_reputation",
                RiskFactor.LocationMismatch => "location_mismatch",
                RiskFactor.MissingSignals => "missing_signals",
                RiskFactor.NumberRangeAbuse => "number_range_abuse",
                RiskFactor.PoorConversionHistory => "poor_conversion_history",
                RiskFactor.ProxyNetwork => "proxy_network",
                RiskFactor.RepeatedAttempts => "repeated_attempts",
                RiskFactor.TemporaryPhoneNumber => "temporary_phone_number",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The silent verification specific properties.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Silent, SilentFromRaw>))]
public sealed record class Silent : JsonModel
{
    /// <summary>
    /// The URL to start the silent verification towards.
    /// </summary>
    public required string RequestUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("request_url");
        }
        init { this._rawData.Set("request_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RequestUrl;
    }

    public Silent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Silent(Silent silent)
        : base(silent) { }
#pragma warning restore CS8618

    public Silent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Silent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SilentFromRaw.FromRawUnchecked"/>
    public static Silent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Silent(string requestUrl)
        : this()
    {
        this.RequestUrl = requestUrl;
    }
}

class SilentFromRaw : IFromRawJson<Silent>
{
    /// <inheritdoc/>
    public Silent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Silent.FromRawUnchecked(rawData);
}
