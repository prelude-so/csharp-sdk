using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using System = System;

namespace PreludeSdk.Models.Watch;

[JsonConverter(typeof(JsonModelConverter<WatchPredictResponse, WatchPredictResponseFromRaw>))]
public sealed record class WatchPredictResponse : JsonModel
{
    /// <summary>
    /// The prediction identifier.
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
    /// The prediction outcome.
    /// </summary>
    public required ApiEnum<string, Prediction> Prediction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Prediction>>("prediction");
        }
        init { this._rawData.Set("prediction", value); }
    }

    /// <summary>
    /// A string that identifies this specific request. Report it back to us to help
    /// us diagnose your issues.
    /// </summary>
    public required string RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("request_id");
        }
        init { this._rawData.Set("request_id", value); }
    }

    /// <summary>
    /// The risk factors that contributed to the suspicious prediction. Only present
    /// when prediction is "suspicious" and the anti-fraud system detected specific
    /// risk signals.  * `account_risk_profile` - The request matches a risk profile
    /// derived from the outcomes reported on your own account.  * `automation_signature`
    /// - The request appears to come from an automated client rather than a person.
    ///  * `carrier_not_permitted` - The destination carrier is one this account does
    /// not accept traffic for.  * `client_fingerprint_mismatch` - The client does
    /// not appear to be the platform it identifies itself as.  * `custom_policy`
    /// - A rule configured for your account matched this request.  * `device_emulator`
    /// - The request appears to come from an emulator rather than a physical device.
    ///  * `device_not_permitted` - The device platform is one your account blocks.
    ///  * `device_reuse` - One device is driving verifications for an unusual number
    /// of phone numbers.  * `expired_signals` - The SDK signals were collected too
    /// long before the request to still attest to it.  * `fraud_database` - The
    /// phone number is flagged in one or more of the fraud databases Prelude consults.
    ///  * `invalid_signature` - The SDK signature did not verify, so the request
    /// cannot be attributed to the device it claims to come from.  * `ip_concentration`
    /// - The request shares its origin with an unusual volume of other verifications.
    ///  * `ip_reputation` - The originating IP address is not trusted.  * `location_mismatch`
    /// - The network location and the phone number's country are inconsistent.  *
    /// `missing_signals` - The verification expected Prelude SDK signals and none
    /// arrived.  * `number_range_abuse` - The phone number belongs to a range currently
    /// associated with abuse.  * `poor_conversion_history` - Traffic resembling
    /// this request rarely completes a verification.  * `proxy_network` - The request
    /// did not arrive over the subscriber's own access network.  * `repeated_attempts`
    /// - The phone number exceeded the allowed number of verification attempts in
    /// a short period.  * `temporary_phone_number` - The phone number belongs to
    /// a disposable or short-lived numbering service.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Prediction.Validate();
        _ = this.RequestID;
        foreach (var item in this.RiskFactors ?? [])
        {
            item.Validate();
        }
    }

    public WatchPredictResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WatchPredictResponse(WatchPredictResponse watchPredictResponse)
        : base(watchPredictResponse) { }
#pragma warning restore CS8618

    public WatchPredictResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WatchPredictResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WatchPredictResponseFromRaw.FromRawUnchecked"/>
    public static WatchPredictResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WatchPredictResponseFromRaw : IFromRawJson<WatchPredictResponse>
{
    /// <inheritdoc/>
    public WatchPredictResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WatchPredictResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The prediction outcome.
/// </summary>
[JsonConverter(typeof(PredictionConverter))]
public enum Prediction
{
    Legitimate,
    Suspicious,
}

sealed class PredictionConverter : JsonConverter<Prediction>
{
    public override Prediction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "legitimate" => Prediction.Legitimate,
            "suspicious" => Prediction.Suspicious,
            _ => (Prediction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Prediction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Prediction.Legitimate => "legitimate",
                Prediction.Suspicious => "suspicious",
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
    AccountRiskProfile,
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
            "account_risk_profile" => RiskFactor.AccountRiskProfile,
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
                RiskFactor.AccountRiskProfile => "account_risk_profile",
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
