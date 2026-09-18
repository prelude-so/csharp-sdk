using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using System = System;

namespace PreludeSdk.Models.Verification.Phone.History;

/// <summary>
/// A verification and everything Prelude recorded about it.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<HistoryRetrieveResponse, HistoryRetrieveResponseFromRaw>))]
public sealed record class HistoryRetrieveResponse : JsonModel
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

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required System::DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// The E.164 phone number the verification targeted.
    /// </summary>
    public required string PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("phone_number");
        }
        init { this._rawData.Set("phone_number", value); }
    }

    /// <summary>
    /// The outcome of the verification.  * `converted` - The end user submitted
    /// a valid code.  * `not_converted` - The verification expired without a valid
    /// code.  * `pending_check` - A code was delivered and Prelude is still waiting
    /// for a check.  * `sent` - A code was sent and the verification window is still
    /// open.  * `challenged` - The verification was restricted to non-SMS and non-voice
    /// channels.  * `suspected_fraud` - The anti-fraud system blocked the verification.
    ///  * `in_blocklist` - The phone number is on the configured block list.  *
    /// `invalid_line` - The phone number is not a valid line type.  * `invalid_number`
    /// - The phone number is not a valid number.  * `rate_limited` - The verification
    /// was refused by a rate limit.  * `expired_signals` - The SDK signals were
    /// collected too long before the request.  * `shadowed` - The anti-fraud system
    /// flagged the verification without blocking it.
    /// </summary>
    public required ApiEnum<string, HistoryRetrieveResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, HistoryRetrieveResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Version of your application, when known.
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
    /// Why the anti-fraud system blocked the verification. Empty unless it did.
    /// * `behavioral_pattern` - The phone number past behavior during verification
    /// flows exhibits suspicious patterns.  * `device_attribute` - The end-user
    /// device reported attributes associated with fraud or emulation.  * `fraud_database`
    /// - The phone number appears in a fraud database.  * `location_discrepancy`
    /// - The phone number region and the observed location disagree.  * `missing_signals`
    /// - The verification expected Prelude SDK signals and none arrived.  * `network_fingerprint`
    /// - The network fingerprint matches known fraudulent traffic.  * `poor_conversion_history`
    /// - The phone number rarely completes the verifications it starts.  * `prefix_concentration`
    /// - The phone number is part of a range known to be associated with suspicious
    /// activity patterns.  * `repeated_number` - The phone number was used far more
    /// often than normal traffic would explain.  * `suspected_request_tampering`
    /// - The SDK signals were altered or expired between collection and use.  * `suspicious_ip_address`
    /// - The originating IP address is associated with suspicious activity.  * `temporary_phone_number`
    /// - The phone number is known to be a temporary or disposable number.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, BlockReason>>? BlockReasons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, BlockReason>>>(
                "block_reasons"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, BlockReason>>?>(
                "block_reasons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The end user's mobile network.
    /// </summary>
    public PhoneVerificationCarrier? Carrier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneVerificationCarrier>("carrier");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("carrier", value);
        }
    }

    /// <summary>
    /// The correlation identifier you supplied when creating the verification.
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

    /// <summary>
    /// Model of the end-user device, when known.
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
    /// Platform of the end-user device, when known.
    /// </summary>
    public ApiEnum<string, HistoryRetrieveResponseDevicePlatform>? DevicePlatform
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, HistoryRetrieveResponseDevicePlatform>
            >("device_platform");
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
    /// IP address the verification was created from.
    /// </summary>
    public string? IPAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ip_address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ip_address", value);
        }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 region of the caller's IP address.
    /// </summary>
    public string? IPAddressRegion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ip_address_region");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ip_address_region", value);
        }
    }

    /// <summary>
    /// Distance between the phone number region and the IP location.
    /// </summary>
    public long? IPDistanceMeters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ip_distance_meters");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ip_distance_meters", value);
        }
    }

    /// <summary>
    /// Chronological timeline of the verification: creation, message attempts with
    /// delivery events, code checks and signals reception. Omitted when Prelude holds
    /// no timeline for the verification.
    /// </summary>
    public Lifecycle? Lifecycle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Lifecycle>("lifecycle");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lifecycle", value);
        }
    }

    /// <summary>
    /// Whether the phone number was allow-listed, block-listed, or sandboxed at
    /// verification time.
    /// </summary>
    public ApiEnum<string, PhoneNumberCondition>? PhoneNumberCondition
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberCondition>>(
                "phone_number_condition"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_number_condition", value);
        }
    }

    /// <summary>
    /// Whether the phone number is currently allow-listed, block-listed, or sandboxed.
    /// </summary>
    public ApiEnum<string, PhoneNumberCurrentCondition>? PhoneNumberCurrentCondition
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberCurrentCondition>>(
                "phone_number_current_condition"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_number_current_condition", value);
        }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 region of the phone number.
    /// </summary>
    public string? PhoneNumberRegion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number_region");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_number_region", value);
        }
    }

    /// <summary>
    /// The anti-fraud signals you forwarded when creating the verification.
    /// </summary>
    public HistoryRetrieveResponseSignals? Signals
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<HistoryRetrieveResponseSignals>("signals");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("signals", value);
        }
    }

    /// <summary>
    /// Whether the SDK signals integrity check passed.
    /// </summary>
    public ApiEnum<string, SignalsHashStatus>? SignalsHashStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SignalsHashStatus>>(
                "signals_hash_status"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("signals_hash_status", value);
        }
    }

    /// <summary>
    /// The template used for this verification.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.ExpiresAt;
        _ = this.PhoneNumber;
        this.Status.Validate();
        _ = this.AppVersion;
        foreach (var item in this.BlockReasons ?? [])
        {
            item.Validate();
        }
        this.Carrier?.Validate();
        _ = this.CorrelationID;
        _ = this.DeviceModel;
        this.DevicePlatform?.Validate();
        _ = this.IPAddress;
        _ = this.IPAddressRegion;
        _ = this.IPDistanceMeters;
        this.Lifecycle?.Validate();
        this.PhoneNumberCondition?.Validate();
        this.PhoneNumberCurrentCondition?.Validate();
        _ = this.PhoneNumberRegion;
        this.Signals?.Validate();
        this.SignalsHashStatus?.Validate();
        _ = this.TemplateID;
    }

    public HistoryRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HistoryRetrieveResponse(HistoryRetrieveResponse historyRetrieveResponse)
        : base(historyRetrieveResponse) { }
#pragma warning restore CS8618

    public HistoryRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HistoryRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HistoryRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static HistoryRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HistoryRetrieveResponseFromRaw : IFromRawJson<HistoryRetrieveResponse>
{
    /// <inheritdoc/>
    public HistoryRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => HistoryRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The outcome of the verification.  * `converted` - The end user submitted a valid
/// code.  * `not_converted` - The verification expired without a valid code.  *
/// `pending_check` - A code was delivered and Prelude is still waiting for a check.
///  * `sent` - A code was sent and the verification window is still open.  * `challenged`
/// - The verification was restricted to non-SMS and non-voice channels.  * `suspected_fraud`
/// - The anti-fraud system blocked the verification.  * `in_blocklist` - The phone
/// number is on the configured block list.  * `invalid_line` - The phone number is
/// not a valid line type.  * `invalid_number` - The phone number is not a valid number.
///  * `rate_limited` - The verification was refused by a rate limit.  * `expired_signals`
/// - The SDK signals were collected too long before the request.  * `shadowed` -
/// The anti-fraud system flagged the verification without blocking it.
/// </summary>
[JsonConverter(typeof(HistoryRetrieveResponseStatusConverter))]
public enum HistoryRetrieveResponseStatus
{
    Converted,
    NotConverted,
    PendingCheck,
    Sent,
    Challenged,
    SuspectedFraud,
    InBlocklist,
    InvalidLine,
    InvalidNumber,
    RateLimited,
    ExpiredSignals,
    Shadowed,
}

sealed class HistoryRetrieveResponseStatusConverter : JsonConverter<HistoryRetrieveResponseStatus>
{
    public override HistoryRetrieveResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "converted" => HistoryRetrieveResponseStatus.Converted,
            "not_converted" => HistoryRetrieveResponseStatus.NotConverted,
            "pending_check" => HistoryRetrieveResponseStatus.PendingCheck,
            "sent" => HistoryRetrieveResponseStatus.Sent,
            "challenged" => HistoryRetrieveResponseStatus.Challenged,
            "suspected_fraud" => HistoryRetrieveResponseStatus.SuspectedFraud,
            "in_blocklist" => HistoryRetrieveResponseStatus.InBlocklist,
            "invalid_line" => HistoryRetrieveResponseStatus.InvalidLine,
            "invalid_number" => HistoryRetrieveResponseStatus.InvalidNumber,
            "rate_limited" => HistoryRetrieveResponseStatus.RateLimited,
            "expired_signals" => HistoryRetrieveResponseStatus.ExpiredSignals,
            "shadowed" => HistoryRetrieveResponseStatus.Shadowed,
            _ => (HistoryRetrieveResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        HistoryRetrieveResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                HistoryRetrieveResponseStatus.Converted => "converted",
                HistoryRetrieveResponseStatus.NotConverted => "not_converted",
                HistoryRetrieveResponseStatus.PendingCheck => "pending_check",
                HistoryRetrieveResponseStatus.Sent => "sent",
                HistoryRetrieveResponseStatus.Challenged => "challenged",
                HistoryRetrieveResponseStatus.SuspectedFraud => "suspected_fraud",
                HistoryRetrieveResponseStatus.InBlocklist => "in_blocklist",
                HistoryRetrieveResponseStatus.InvalidLine => "invalid_line",
                HistoryRetrieveResponseStatus.InvalidNumber => "invalid_number",
                HistoryRetrieveResponseStatus.RateLimited => "rate_limited",
                HistoryRetrieveResponseStatus.ExpiredSignals => "expired_signals",
                HistoryRetrieveResponseStatus.Shadowed => "shadowed",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(BlockReasonConverter))]
public enum BlockReason
{
    BehavioralPattern,
    DeviceAttribute,
    FraudDatabase,
    LocationDiscrepancy,
    MissingSignals,
    NetworkFingerprint,
    PoorConversionHistory,
    PrefixConcentration,
    RepeatedNumber,
    SuspectedRequestTampering,
    SuspiciousIPAddress,
    TemporaryPhoneNumber,
}

sealed class BlockReasonConverter : JsonConverter<BlockReason>
{
    public override BlockReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "behavioral_pattern" => BlockReason.BehavioralPattern,
            "device_attribute" => BlockReason.DeviceAttribute,
            "fraud_database" => BlockReason.FraudDatabase,
            "location_discrepancy" => BlockReason.LocationDiscrepancy,
            "missing_signals" => BlockReason.MissingSignals,
            "network_fingerprint" => BlockReason.NetworkFingerprint,
            "poor_conversion_history" => BlockReason.PoorConversionHistory,
            "prefix_concentration" => BlockReason.PrefixConcentration,
            "repeated_number" => BlockReason.RepeatedNumber,
            "suspected_request_tampering" => BlockReason.SuspectedRequestTampering,
            "suspicious_ip_address" => BlockReason.SuspiciousIPAddress,
            "temporary_phone_number" => BlockReason.TemporaryPhoneNumber,
            _ => (BlockReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BlockReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BlockReason.BehavioralPattern => "behavioral_pattern",
                BlockReason.DeviceAttribute => "device_attribute",
                BlockReason.FraudDatabase => "fraud_database",
                BlockReason.LocationDiscrepancy => "location_discrepancy",
                BlockReason.MissingSignals => "missing_signals",
                BlockReason.NetworkFingerprint => "network_fingerprint",
                BlockReason.PoorConversionHistory => "poor_conversion_history",
                BlockReason.PrefixConcentration => "prefix_concentration",
                BlockReason.RepeatedNumber => "repeated_number",
                BlockReason.SuspectedRequestTampering => "suspected_request_tampering",
                BlockReason.SuspiciousIPAddress => "suspicious_ip_address",
                BlockReason.TemporaryPhoneNumber => "temporary_phone_number",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Platform of the end-user device, when known.
/// </summary>
[JsonConverter(typeof(HistoryRetrieveResponseDevicePlatformConverter))]
public enum HistoryRetrieveResponseDevicePlatform
{
    Android,
    Ios,
    Ipados,
    Tvos,
    Web,
}

sealed class HistoryRetrieveResponseDevicePlatformConverter
    : JsonConverter<HistoryRetrieveResponseDevicePlatform>
{
    public override HistoryRetrieveResponseDevicePlatform Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "android" => HistoryRetrieveResponseDevicePlatform.Android,
            "ios" => HistoryRetrieveResponseDevicePlatform.Ios,
            "ipados" => HistoryRetrieveResponseDevicePlatform.Ipados,
            "tvos" => HistoryRetrieveResponseDevicePlatform.Tvos,
            "web" => HistoryRetrieveResponseDevicePlatform.Web,
            _ => (HistoryRetrieveResponseDevicePlatform)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        HistoryRetrieveResponseDevicePlatform value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                HistoryRetrieveResponseDevicePlatform.Android => "android",
                HistoryRetrieveResponseDevicePlatform.Ios => "ios",
                HistoryRetrieveResponseDevicePlatform.Ipados => "ipados",
                HistoryRetrieveResponseDevicePlatform.Tvos => "tvos",
                HistoryRetrieveResponseDevicePlatform.Web => "web",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Chronological timeline of the verification: creation, message attempts with delivery
/// events, code checks and signals reception. Omitted when Prelude holds no timeline
/// for the verification.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Lifecycle, LifecycleFromRaw>))]
public sealed record class Lifecycle : JsonModel
{
    public required IReadOnlyList<Event> Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Event>>("events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Event>>(
                "events",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PhoneVerificationMoney? TotalCost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneVerificationMoney>("total_cost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_cost", value);
        }
    }

    /// <summary>
    /// How many times the message was reported undeliverable by independent routes.
    /// Above zero usually means the phone number is incorrect or the device unreachable.
    /// </summary>
    public long? UndeliverableRouteCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("undeliverable_route_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("undeliverable_route_count", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Events)
        {
            item.Validate();
        }
        this.TotalCost?.Validate();
        _ = this.UndeliverableRouteCount;
    }

    public Lifecycle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Lifecycle(Lifecycle lifecycle)
        : base(lifecycle) { }
#pragma warning restore CS8618

    public Lifecycle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Lifecycle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LifecycleFromRaw.FromRawUnchecked"/>
    public static Lifecycle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Lifecycle(IReadOnlyList<Event> events)
        : this()
    {
        this.Events = events;
    }
}

class LifecycleFromRaw : IFromRawJson<Lifecycle>
{
    /// <inheritdoc/>
    public Lifecycle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Lifecycle.FromRawUnchecked(rawData);
}

/// <summary>
/// One timeline entry. `type` names the single payload field that is set.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Event, EventFromRaw>))]
public sealed record class Event : JsonModel
{
    public required ApiEnum<string, global::PreludeSdk.Models.Verification.Phone.History.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::PreludeSdk.Models.Verification.Phone.History.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// One message sent for this verification.
    /// </summary>
    public Attempt? Attempt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Attempt>("attempt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("attempt", value);
        }
    }

    /// <summary>
    /// One code submission for this verification.
    /// </summary>
    public Check? Check
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Check>("check");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("check", value);
        }
    }

    public Create? Create
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Create>("create");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("create", value);
        }
    }

    public Signals? Signals
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Signals>("signals");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("signals", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        this.Attempt?.Validate();
        this.Check?.Validate();
        this.Create?.Validate();
        this.Signals?.Validate();
    }

    public Event() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Event(Event event_)
        : base(event_) { }
#pragma warning restore CS8618

    public Event(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Event(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventFromRaw.FromRawUnchecked"/>
    public static Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Event(ApiEnum<string, global::PreludeSdk.Models.Verification.Phone.History.Type> type)
        : this()
    {
        this.Type = type;
    }
}

class EventFromRaw : IFromRawJson<Event>
{
    /// <inheritdoc/>
    public Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Event.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Create,
    Attempt,
    Check,
    Signals,
}

sealed class TypeConverter
    : JsonConverter<global::PreludeSdk.Models.Verification.Phone.History.Type>
{
    public override global::PreludeSdk.Models.Verification.Phone.History.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "create" => global::PreludeSdk.Models.Verification.Phone.History.Type.Create,
            "attempt" => global::PreludeSdk.Models.Verification.Phone.History.Type.Attempt,
            "check" => global::PreludeSdk.Models.Verification.Phone.History.Type.Check,
            "signals" => global::PreludeSdk.Models.Verification.Phone.History.Type.Signals,
            _ => (global::PreludeSdk.Models.Verification.Phone.History.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::PreludeSdk.Models.Verification.Phone.History.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::PreludeSdk.Models.Verification.Phone.History.Type.Create => "create",
                global::PreludeSdk.Models.Verification.Phone.History.Type.Attempt => "attempt",
                global::PreludeSdk.Models.Verification.Phone.History.Type.Check => "check",
                global::PreludeSdk.Models.Verification.Phone.History.Type.Signals => "signals",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// One message sent for this verification.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Attempt, AttemptFromRaw>))]
public sealed record class Attempt : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The end user's mobile network.
    /// </summary>
    public PhoneVerificationCarrier? Carrier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneVerificationCarrier>("carrier");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("carrier", value);
        }
    }

    public ApiEnum<string, AttemptChannel>? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AttemptChannel>>("channel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("channel", value);
        }
    }

    /// <summary>
    /// Message body. While the verification can still be completed, the code inside
    /// it is masked rather than removed.
    /// </summary>
    public string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("content", value);
        }
    }

    public PhoneVerificationMoney? Cost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneVerificationMoney>("cost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cost", value);
        }
    }

    public IReadOnlyList<DeliveryEvent>? DeliveryEvents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DeliveryEvent>>(
                "delivery_events"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DeliveryEvent>?>(
                "delivery_events",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, DeliveryStatus>? DeliveryStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DeliveryStatus>>(
                "delivery_status"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("delivery_status", value);
        }
    }

    /// <summary>
    /// Channel you asked for, when it differs from the one used.
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

    public ApiEnum<string, AttemptStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AttemptStatus>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// What caused the attempt.
    /// </summary>
    public ApiEnum<string, Trigger>? Trigger
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Trigger>>("trigger");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("trigger", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.Carrier?.Validate();
        this.Channel?.Validate();
        _ = this.Content;
        this.Cost?.Validate();
        foreach (var item in this.DeliveryEvents ?? [])
        {
            item.Validate();
        }
        this.DeliveryStatus?.Validate();
        this.PreferredChannel?.Validate();
        this.Status?.Validate();
        this.Trigger?.Validate();
    }

    public Attempt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Attempt(Attempt attempt)
        : base(attempt) { }
#pragma warning restore CS8618

    public Attempt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Attempt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttemptFromRaw.FromRawUnchecked"/>
    public static Attempt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttemptFromRaw : IFromRawJson<Attempt>
{
    /// <inheritdoc/>
    public Attempt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Attempt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AttemptChannelConverter))]
public enum AttemptChannel
{
    Sms,
    Rcs,
    Whatsapp,
    Viber,
    Zalo,
    Telegram,
    Voice,
    Silent,
}

sealed class AttemptChannelConverter : JsonConverter<AttemptChannel>
{
    public override AttemptChannel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms" => AttemptChannel.Sms,
            "rcs" => AttemptChannel.Rcs,
            "whatsapp" => AttemptChannel.Whatsapp,
            "viber" => AttemptChannel.Viber,
            "zalo" => AttemptChannel.Zalo,
            "telegram" => AttemptChannel.Telegram,
            "voice" => AttemptChannel.Voice,
            "silent" => AttemptChannel.Silent,
            _ => (AttemptChannel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AttemptChannel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AttemptChannel.Sms => "sms",
                AttemptChannel.Rcs => "rcs",
                AttemptChannel.Whatsapp => "whatsapp",
                AttemptChannel.Viber => "viber",
                AttemptChannel.Zalo => "zalo",
                AttemptChannel.Telegram => "telegram",
                AttemptChannel.Voice => "voice",
                AttemptChannel.Silent => "silent",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<DeliveryEvent, DeliveryEventFromRaw>))]
public sealed record class DeliveryEvent : JsonModel
{
    public required System::DateTimeOffset ReceivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("received_at");
        }
        init { this._rawData.Set("received_at", value); }
    }

    /// <summary>
    /// The state this event reported. It is finer-grained than the attempt's `delivery_status`
    /// and includes the states a silent verification goes through.
    /// </summary>
    public required ApiEnum<string, DeliveryEventStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DeliveryEventStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ReceivedAt;
        this.Status.Validate();
    }

    public DeliveryEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeliveryEvent(DeliveryEvent deliveryEvent)
        : base(deliveryEvent) { }
#pragma warning restore CS8618

    public DeliveryEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeliveryEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeliveryEventFromRaw.FromRawUnchecked"/>
    public static DeliveryEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeliveryEventFromRaw : IFromRawJson<DeliveryEvent>
{
    /// <inheritdoc/>
    public DeliveryEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DeliveryEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The state this event reported. It is finer-grained than the attempt's `delivery_status`
/// and includes the states a silent verification goes through.
/// </summary>
[JsonConverter(typeof(DeliveryEventStatusConverter))]
public enum DeliveryEventStatus
{
    Unknown,
    Submitted,
    InTransit,
    Delivered,
    Undeliverable,
    Expired,
    Read,
    SilentStarted,
    SilentVerified,
    SilentMismatch,
}

sealed class DeliveryEventStatusConverter : JsonConverter<DeliveryEventStatus>
{
    public override DeliveryEventStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown" => DeliveryEventStatus.Unknown,
            "submitted" => DeliveryEventStatus.Submitted,
            "in_transit" => DeliveryEventStatus.InTransit,
            "delivered" => DeliveryEventStatus.Delivered,
            "undeliverable" => DeliveryEventStatus.Undeliverable,
            "expired" => DeliveryEventStatus.Expired,
            "read" => DeliveryEventStatus.Read,
            "silent_started" => DeliveryEventStatus.SilentStarted,
            "silent_verified" => DeliveryEventStatus.SilentVerified,
            "silent_mismatch" => DeliveryEventStatus.SilentMismatch,
            _ => (DeliveryEventStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeliveryEventStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DeliveryEventStatus.Unknown => "unknown",
                DeliveryEventStatus.Submitted => "submitted",
                DeliveryEventStatus.InTransit => "in_transit",
                DeliveryEventStatus.Delivered => "delivered",
                DeliveryEventStatus.Undeliverable => "undeliverable",
                DeliveryEventStatus.Expired => "expired",
                DeliveryEventStatus.Read => "read",
                DeliveryEventStatus.SilentStarted => "silent_started",
                DeliveryEventStatus.SilentVerified => "silent_verified",
                DeliveryEventStatus.SilentMismatch => "silent_mismatch",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(DeliveryStatusConverter))]
public enum DeliveryStatus
{
    Unknown,
    InTransit,
    Delivered,
    Undeliverable,
    Read,
}

sealed class DeliveryStatusConverter : JsonConverter<DeliveryStatus>
{
    public override DeliveryStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown" => DeliveryStatus.Unknown,
            "in_transit" => DeliveryStatus.InTransit,
            "delivered" => DeliveryStatus.Delivered,
            "undeliverable" => DeliveryStatus.Undeliverable,
            "read" => DeliveryStatus.Read,
            _ => (DeliveryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeliveryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DeliveryStatus.Unknown => "unknown",
                DeliveryStatus.InTransit => "in_transit",
                DeliveryStatus.Delivered => "delivered",
                DeliveryStatus.Undeliverable => "undeliverable",
                DeliveryStatus.Read => "read",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Channel you asked for, when it differs from the one used.
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
    Voice,
    Silent,
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
            "voice" => PreferredChannel.Voice,
            "silent" => PreferredChannel.Silent,
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
                PreferredChannel.Voice => "voice",
                PreferredChannel.Silent => "silent",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AttemptStatusConverter))]
public enum AttemptStatus
{
    Succeeded,
    Failed,
}

sealed class AttemptStatusConverter : JsonConverter<AttemptStatus>
{
    public override AttemptStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "succeeded" => AttemptStatus.Succeeded,
            "failed" => AttemptStatus.Failed,
            _ => (AttemptStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AttemptStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AttemptStatus.Succeeded => "succeeded",
                AttemptStatus.Failed => "failed",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// What caused the attempt.
/// </summary>
[JsonConverter(typeof(TriggerConverter))]
public enum Trigger
{
    Initial,
    AutoRetry,
    UserRetry,
}

sealed class TriggerConverter : JsonConverter<Trigger>
{
    public override Trigger Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "initial" => Trigger.Initial,
            "auto_retry" => Trigger.AutoRetry,
            "user_retry" => Trigger.UserRetry,
            _ => (Trigger)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Trigger value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Trigger.Initial => "initial",
                Trigger.AutoRetry => "auto_retry",
                Trigger.UserRetry => "user_retry",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// One code submission for this verification.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Check, CheckFromRaw>))]
public sealed record class Check : JsonModel
{
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required bool IsValid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_valid");
        }
        init { this._rawData.Set("is_valid", value); }
    }

    public ApiEnum<string, CheckChannel>? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CheckChannel>>("channel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("channel", value);
        }
    }

    /// <summary>
    /// Present on checks against a `prelude:psd2` code.
    /// </summary>
    public Psd2Info? Psd2Info
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Psd2Info>("psd2_info");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("psd2_info", value);
        }
    }

    /// <summary>
    /// Why an invalid check failed, when known.
    /// </summary>
    public ApiEnum<string, StatusDetail>? StatusDetail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, StatusDetail>>("status_detail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status_detail", value);
        }
    }

    /// <summary>
    /// The submitted code. Absent while the verification can still be completed,
    /// so that a check in flight cannot be read back through this endpoint, and absent
    /// on silent verification checks, which carry no code.
    /// </summary>
    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.IsValid;
        this.Channel?.Validate();
        this.Psd2Info?.Validate();
        this.StatusDetail?.Validate();
        _ = this.Value;
    }

    public Check() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Check(Check check)
        : base(check) { }
#pragma warning restore CS8618

    public Check(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Check(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckFromRaw.FromRawUnchecked"/>
    public static Check FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckFromRaw : IFromRawJson<Check>
{
    /// <inheritdoc/>
    public Check FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Check.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CheckChannelConverter))]
public enum CheckChannel
{
    Sms,
    Rcs,
    Whatsapp,
    Viber,
    Zalo,
    Telegram,
    Voice,
    Silent,
}

sealed class CheckChannelConverter : JsonConverter<CheckChannel>
{
    public override CheckChannel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms" => CheckChannel.Sms,
            "rcs" => CheckChannel.Rcs,
            "whatsapp" => CheckChannel.Whatsapp,
            "viber" => CheckChannel.Viber,
            "zalo" => CheckChannel.Zalo,
            "telegram" => CheckChannel.Telegram,
            "voice" => CheckChannel.Voice,
            "silent" => CheckChannel.Silent,
            _ => (CheckChannel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckChannel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckChannel.Sms => "sms",
                CheckChannel.Rcs => "rcs",
                CheckChannel.Whatsapp => "whatsapp",
                CheckChannel.Viber => "viber",
                CheckChannel.Zalo => "zalo",
                CheckChannel.Telegram => "telegram",
                CheckChannel.Voice => "voice",
                CheckChannel.Silent => "silent",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Present on checks against a `prelude:psd2` code.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Psd2Info, Psd2InfoFromRaw>))]
public sealed record class Psd2Info : JsonModel
{
    /// <summary>
    /// The transaction submitted when the code was issued.
    /// </summary>
    public PhoneVerificationPsd2Transaction? ExpectedTransaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneVerificationPsd2Transaction>(
                "expected_transaction"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expected_transaction", value);
        }
    }

    /// <summary>
    /// The transaction submitted with this check. Differs from `expected_transaction`
    /// when `status_detail` is `transaction_mismatch`.
    /// </summary>
    public PhoneVerificationPsd2Transaction? ReceivedTransaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneVerificationPsd2Transaction>(
                "received_transaction"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("received_transaction", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ExpectedTransaction?.Validate();
        this.ReceivedTransaction?.Validate();
    }

    public Psd2Info() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Psd2Info(Psd2Info psd2Info)
        : base(psd2Info) { }
#pragma warning restore CS8618

    public Psd2Info(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Psd2Info(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Psd2InfoFromRaw.FromRawUnchecked"/>
    public static Psd2Info FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Psd2InfoFromRaw : IFromRawJson<Psd2Info>
{
    /// <inheritdoc/>
    public Psd2Info FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Psd2Info.FromRawUnchecked(rawData);
}

/// <summary>
/// Why an invalid check failed, when known.
/// </summary>
[JsonConverter(typeof(StatusDetailConverter))]
public enum StatusDetail
{
    ExpiredAttempt,
    ExpiredAuth,
    RateLimited,
    TransactionMissing,
    TransactionMismatch,
}

sealed class StatusDetailConverter : JsonConverter<StatusDetail>
{
    public override StatusDetail Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "expired_attempt" => StatusDetail.ExpiredAttempt,
            "expired_auth" => StatusDetail.ExpiredAuth,
            "rate_limited" => StatusDetail.RateLimited,
            "transaction_missing" => StatusDetail.TransactionMissing,
            "transaction_mismatch" => StatusDetail.TransactionMismatch,
            _ => (StatusDetail)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StatusDetail value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StatusDetail.ExpiredAttempt => "expired_attempt",
                StatusDetail.ExpiredAuth => "expired_auth",
                StatusDetail.RateLimited => "rate_limited",
                StatusDetail.TransactionMissing => "transaction_missing",
                StatusDetail.TransactionMismatch => "transaction_mismatch",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Create, CreateFromRaw>))]
public sealed record class Create : JsonModel
{
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public PhoneVerificationMoney? Cost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneVerificationMoney>("cost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cost", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        this.Cost?.Validate();
    }

    public Create() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Create(Create create)
        : base(create) { }
#pragma warning restore CS8618

    public Create(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Create(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreateFromRaw.FromRawUnchecked"/>
    public static Create FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Create(System::DateTimeOffset createdAt)
        : this()
    {
        this.CreatedAt = createdAt;
    }
}

class CreateFromRaw : IFromRawJson<Create>
{
    /// <inheritdoc/>
    public Create FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Create.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Signals, SignalsFromRaw>))]
public sealed record class Signals : JsonModel
{
    public required System::DateTimeOffset ReceivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("received_at");
        }
        init { this._rawData.Set("received_at", value); }
    }

    public System::DateTimeOffset? ExpiredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("expired_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expired_at", value);
        }
    }

    public ApiEnum<string, SignalsStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SignalsStatus>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ReceivedAt;
        _ = this.ExpiredAt;
        this.Status?.Validate();
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

    [SetsRequiredMembers]
    public Signals(System::DateTimeOffset receivedAt)
        : this()
    {
        this.ReceivedAt = receivedAt;
    }
}

class SignalsFromRaw : IFromRawJson<Signals>
{
    /// <inheritdoc/>
    public Signals FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Signals.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SignalsStatusConverter))]
public enum SignalsStatus
{
    Valid,
    Invalid,
}

sealed class SignalsStatusConverter : JsonConverter<SignalsStatus>
{
    public override SignalsStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "valid" => SignalsStatus.Valid,
            "invalid" => SignalsStatus.Invalid,
            _ => (SignalsStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SignalsStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SignalsStatus.Valid => "valid",
                SignalsStatus.Invalid => "invalid",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether the phone number was allow-listed, block-listed, or sandboxed at verification time.
/// </summary>
[JsonConverter(typeof(PhoneNumberConditionConverter))]
public enum PhoneNumberCondition
{
    AllowListed,
    BlockListed,
    Sandboxed,
}

sealed class PhoneNumberConditionConverter : JsonConverter<PhoneNumberCondition>
{
    public override PhoneNumberCondition Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allow_listed" => PhoneNumberCondition.AllowListed,
            "block_listed" => PhoneNumberCondition.BlockListed,
            "sandboxed" => PhoneNumberCondition.Sandboxed,
            _ => (PhoneNumberCondition)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberCondition value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PhoneNumberCondition.AllowListed => "allow_listed",
                PhoneNumberCondition.BlockListed => "block_listed",
                PhoneNumberCondition.Sandboxed => "sandboxed",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether the phone number is currently allow-listed, block-listed, or sandboxed.
/// </summary>
[JsonConverter(typeof(PhoneNumberCurrentConditionConverter))]
public enum PhoneNumberCurrentCondition
{
    AllowListed,
    BlockListed,
    Sandboxed,
}

sealed class PhoneNumberCurrentConditionConverter : JsonConverter<PhoneNumberCurrentCondition>
{
    public override PhoneNumberCurrentCondition Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allow_listed" => PhoneNumberCurrentCondition.AllowListed,
            "block_listed" => PhoneNumberCurrentCondition.BlockListed,
            "sandboxed" => PhoneNumberCurrentCondition.Sandboxed,
            _ => (PhoneNumberCurrentCondition)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberCurrentCondition value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PhoneNumberCurrentCondition.AllowListed => "allow_listed",
                PhoneNumberCurrentCondition.BlockListed => "block_listed",
                PhoneNumberCurrentCondition.Sandboxed => "sandboxed",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The anti-fraud signals you forwarded when creating the verification.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        HistoryRetrieveResponseSignals,
        HistoryRetrieveResponseSignalsFromRaw
    >)
)]
public sealed record class HistoryRetrieveResponseSignals : JsonModel
{
    /// <summary>
    /// Whether you flagged this end user as trusted when creating the verification.
    /// Declared by you, not computed by Prelude.
    /// </summary>
    public required bool IsTrustedUser
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_trusted_user");
        }
        init { this._rawData.Set("is_trusted_user", value); }
    }

    /// <summary>
    /// End-user device identifier you forwarded.
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
    /// TLS fingerprint you forwarded.
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
        _ = this.IsTrustedUser;
        _ = this.DeviceID;
        _ = this.Ja4Fingerprint;
        _ = this.OsVersion;
        _ = this.UserAgent;
    }

    public HistoryRetrieveResponseSignals() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HistoryRetrieveResponseSignals(
        HistoryRetrieveResponseSignals historyRetrieveResponseSignals
    )
        : base(historyRetrieveResponseSignals) { }
#pragma warning restore CS8618

    public HistoryRetrieveResponseSignals(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HistoryRetrieveResponseSignals(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HistoryRetrieveResponseSignalsFromRaw.FromRawUnchecked"/>
    public static HistoryRetrieveResponseSignals FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public HistoryRetrieveResponseSignals(bool isTrustedUser)
        : this()
    {
        this.IsTrustedUser = isTrustedUser;
    }
}

class HistoryRetrieveResponseSignalsFromRaw : IFromRawJson<HistoryRetrieveResponseSignals>
{
    /// <inheritdoc/>
    public HistoryRetrieveResponseSignals FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => HistoryRetrieveResponseSignals.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the SDK signals integrity check passed.
/// </summary>
[JsonConverter(typeof(SignalsHashStatusConverter))]
public enum SignalsHashStatus
{
    Valid,
    Invalid,
}

sealed class SignalsHashStatusConverter : JsonConverter<SignalsHashStatus>
{
    public override SignalsHashStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "valid" => SignalsHashStatus.Valid,
            "invalid" => SignalsHashStatus.Invalid,
            _ => (SignalsHashStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SignalsHashStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SignalsHashStatus.Valid => "valid",
                SignalsHashStatus.Invalid => "invalid",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
