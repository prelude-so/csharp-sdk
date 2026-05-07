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
    /// risk signals.  * `behavioral_pattern` - The phone number past behavior during
    /// verification flows exhibits suspicious patterns.  * `device_attribute` -
    /// The device exhibits characteristics associated with suspicious activity patterns.
    ///  * `fraud_database` - The phone number has been flagged as suspicious in one
    /// or more of our fraud databases.  * `location_discrepancy` - The phone number
    /// prefix and IP address discrepancy indicates potential fraud.  * `network_fingerprint`
    /// - The network connection exhibits characteristics associated with suspicious
    /// activity patterns.  * `poor_conversion_history` - The phone number has a history
    /// of poorly converting to a verified phone number.  * `prefix_concentration`
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
