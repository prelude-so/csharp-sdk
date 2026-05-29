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

namespace PreludeSdk.Models.Watch;

/// <summary>
/// Optional. Report verification-funnel steps (verification.started, verification.completed)
/// when you run phone verification outside Prelude Verify. Feeds Watch abuse-rate
/// counters for your own flow. Call Predict on the same target before verification.started
/// and reuse metadata.correlation_id so auth-start counters receive predict signals;
/// without a linked predict, only attempt-rate counters update on started. Not required
/// if you only use Events and/or Predict, or if Verify already handles verification
/// for that traffic.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WatchSendFeedbacksParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// A list of feedbacks to send. A maximum of 100 feedbacks can be sent in a
    /// single request.
    /// </summary>
    public required IReadOnlyList<Feedback> Feedbacks
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Feedback>>("feedbacks");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Feedback>>(
                "feedbacks",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public WatchSendFeedbacksParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WatchSendFeedbacksParams(WatchSendFeedbacksParams watchSendFeedbacksParams)
        : base(watchSendFeedbacksParams)
    {
        this._rawBodyData = new(watchSendFeedbacksParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WatchSendFeedbacksParams(
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
    WatchSendFeedbacksParams(
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
    public static WatchSendFeedbacksParams FromRawUnchecked(
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

    public virtual bool Equals(WatchSendFeedbacksParams? other)
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
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v2/watch/feedback"
        )
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

[JsonConverter(typeof(JsonModelConverter<Feedback, FeedbackFromRaw>))]
public sealed record class Feedback : JsonModel
{
    /// <summary>
    /// The feedback target. Only supports phone numbers for now.
    /// </summary>
    public required FeedbackTarget Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FeedbackTarget>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    /// <summary>
    /// The type of feedback.
    /// </summary>
    public required ApiEnum<string, FeedbackType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FeedbackType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The metadata for this feedback.
    /// </summary>
    public FeedbackMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FeedbackMetadata>("metadata");
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Target.Validate();
        this.Type.Validate();
        this.Metadata?.Validate();
    }

    public Feedback() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Feedback(Feedback feedback)
        : base(feedback) { }
#pragma warning restore CS8618

    public Feedback(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Feedback(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeedbackFromRaw.FromRawUnchecked"/>
    public static Feedback FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeedbackFromRaw : IFromRawJson<Feedback>
{
    /// <inheritdoc/>
    public Feedback FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Feedback.FromRawUnchecked(rawData);
}

/// <summary>
/// The feedback target. Only supports phone numbers for now.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FeedbackTarget, FeedbackTargetFromRaw>))]
public sealed record class FeedbackTarget : JsonModel
{
    /// <summary>
    /// The type of the target. Either "phone_number" or "email_address".
    /// </summary>
    public required ApiEnum<string, FeedbackTargetType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FeedbackTargetType>>("type");
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

    public FeedbackTarget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeedbackTarget(FeedbackTarget feedbackTarget)
        : base(feedbackTarget) { }
#pragma warning restore CS8618

    public FeedbackTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeedbackTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeedbackTargetFromRaw.FromRawUnchecked"/>
    public static FeedbackTarget FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeedbackTargetFromRaw : IFromRawJson<FeedbackTarget>
{
    /// <inheritdoc/>
    public FeedbackTarget FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FeedbackTarget.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the target. Either "phone_number" or "email_address".
/// </summary>
[JsonConverter(typeof(FeedbackTargetTypeConverter))]
public enum FeedbackTargetType
{
    PhoneNumber,
    EmailAddress,
}

sealed class FeedbackTargetTypeConverter : JsonConverter<FeedbackTargetType>
{
    public override FeedbackTargetType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "phone_number" => FeedbackTargetType.PhoneNumber,
            "email_address" => FeedbackTargetType.EmailAddress,
            _ => (FeedbackTargetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeedbackTargetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeedbackTargetType.PhoneNumber => "phone_number",
                FeedbackTargetType.EmailAddress => "email_address",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of feedback.
/// </summary>
[JsonConverter(typeof(FeedbackTypeConverter))]
public enum FeedbackType
{
    VerificationStarted,
    VerificationCompleted,
}

sealed class FeedbackTypeConverter : JsonConverter<FeedbackType>
{
    public override FeedbackType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "verification.started" => FeedbackType.VerificationStarted,
            "verification.completed" => FeedbackType.VerificationCompleted,
            _ => (FeedbackType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeedbackType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeedbackType.VerificationStarted => "verification.started",
                FeedbackType.VerificationCompleted => "verification.completed",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The metadata for this feedback.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FeedbackMetadata, FeedbackMetadataFromRaw>))]
public sealed record class FeedbackMetadata : JsonModel
{
    /// <summary>
    /// A user-defined identifier to correlate this feedback with. It is returned
    /// in the response and any webhook events that refer to this feedback.
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

    public FeedbackMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeedbackMetadata(FeedbackMetadata feedbackMetadata)
        : base(feedbackMetadata) { }
#pragma warning restore CS8618

    public FeedbackMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeedbackMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeedbackMetadataFromRaw.FromRawUnchecked"/>
    public static FeedbackMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeedbackMetadataFromRaw : IFromRawJson<FeedbackMetadata>
{
    /// <inheritdoc/>
    public FeedbackMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FeedbackMetadata.FromRawUnchecked(rawData);
}
