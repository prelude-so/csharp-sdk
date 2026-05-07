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
    /// "blocked".  * `expired_signature` - The signature of the SDK signals is expired.
    /// They should be sent within    the hour following their collection.  * `in_block_list`
    /// - The phone number is part of the configured block list.  * `invalid_phone_line`
    /// - The phone number is not a valid line number (e.g. landline).  * `invalid_phone_number`
    /// - The phone number is not a valid phone number (e.g. unallocated range).
    ///  * `invalid_signature` - The signature of the SDK signals is invalid.  *
    /// `repeated_attempts` - The phone number has made too many verification attempts.
    ///  * `suspicious` - The verification attempt was deemed suspicious by the anti-fraud
    /// system.
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
    /// present when status is "blocked" and the anti-fraud system detected specific
    /// risk signals.  * `behavioral_pattern` - The phone number past behavior during
    /// verification flows exhibits suspicious patterns.  * `device_attribute` - The
    /// device exhibits characteristics associated with suspicious activity patterns.
    ///  * `fraud_database` - The phone number has been flagged as suspicious in
    /// one or more of our fraud databases.  * `location_discrepancy` - The phone
    /// number prefix and IP address discrepancy indicates potential fraud.  * `network_fingerprint`
    /// - The network connection exhibits characteristics associated with suspicious
    /// activity patterns.  * `poor_conversion_history` - The phone number has a
    /// history of poorly converting to a verified phone number.  * `prefix_concentration`
    /// - The phone number is part of a range known to be associated with suspicious
    /// activity patterns.  * `suspected_request_tampering` - The SDK signature is
    /// invalid and the request is considered to be tampered with.  * `suspicious_ip_address`
    /// - The IP address is deemed to be associated with suspicious activity patterns.
    ///  * `temporary_phone_number` - The phone number is known to be a temporary
    /// or disposable number.
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
/// by Prelude support.  * `blocked` - The verification was blocked.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Success,
    Retry,
    Challenged,
    Blocked,
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
    Rcs,
    Silent,
    Sms,
    Telegram,
    Viber,
    Voice,
    Whatsapp,
    Zalo,
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
            "rcs" => Channel.Rcs,
            "silent" => Channel.Silent,
            "sms" => Channel.Sms,
            "telegram" => Channel.Telegram,
            "viber" => Channel.Viber,
            "voice" => Channel.Voice,
            "whatsapp" => Channel.Whatsapp,
            "zalo" => Channel.Zalo,
            _ => (Channel)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Channel value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Channel.Rcs => "rcs",
                Channel.Silent => "silent",
                Channel.Sms => "sms",
                Channel.Telegram => "telegram",
                Channel.Viber => "viber",
                Channel.Voice => "voice",
                Channel.Whatsapp => "whatsapp",
                Channel.Zalo => "zalo",
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
/// The reason why the verification was blocked. Only present when status is "blocked".
///  * `expired_signature` - The signature of the SDK signals is expired. They should
/// be sent within    the hour following their collection.  * `in_block_list` - The
/// phone number is part of the configured block list.  * `invalid_phone_line` -
/// The phone number is not a valid line number (e.g. landline).  * `invalid_phone_number`
/// - The phone number is not a valid phone number (e.g. unallocated range).  * `invalid_signature`
/// - The signature of the SDK signals is invalid.  * `repeated_attempts` - The phone
/// number has made too many verification attempts.  * `suspicious` - The verification
/// attempt was deemed suspicious by the anti-fraud system.
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
    BehavioralPattern,
    DeviceAttribute,
    FraudDatabase,
    LocationDiscrepancy,
    NetworkFingerprint,
    PoorConversionHistory,
    PrefixConcentration,
    SuspectedRequestTampering,
    SuspiciousIPAddress,
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
            "behavioral_pattern" => RiskFactor.BehavioralPattern,
            "device_attribute" => RiskFactor.DeviceAttribute,
            "fraud_database" => RiskFactor.FraudDatabase,
            "location_discrepancy" => RiskFactor.LocationDiscrepancy,
            "network_fingerprint" => RiskFactor.NetworkFingerprint,
            "poor_conversion_history" => RiskFactor.PoorConversionHistory,
            "prefix_concentration" => RiskFactor.PrefixConcentration,
            "suspected_request_tampering" => RiskFactor.SuspectedRequestTampering,
            "suspicious_ip_address" => RiskFactor.SuspiciousIPAddress,
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
                RiskFactor.BehavioralPattern => "behavioral_pattern",
                RiskFactor.DeviceAttribute => "device_attribute",
                RiskFactor.FraudDatabase => "fraud_database",
                RiskFactor.LocationDiscrepancy => "location_discrepancy",
                RiskFactor.NetworkFingerprint => "network_fingerprint",
                RiskFactor.PoorConversionHistory => "poor_conversion_history",
                RiskFactor.PrefixConcentration => "prefix_concentration",
                RiskFactor.SuspectedRequestTampering => "suspected_request_tampering",
                RiskFactor.SuspiciousIPAddress => "suspicious_ip_address",
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
