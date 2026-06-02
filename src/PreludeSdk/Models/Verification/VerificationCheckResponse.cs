using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using System = System;

namespace PreludeSdk.Models.Verification;

[JsonConverter(
    typeof(JsonModelConverter<VerificationCheckResponse, VerificationCheckResponseFromRaw>)
)]
public sealed record class VerificationCheckResponse : JsonModel
{
    /// <summary>
    /// The status of the check. For `prelude:psd2` codes, `transaction_missing` is
    /// returned when the `psd2` block is omitted, and `transaction_mismatch` when
    /// the submitted variables differ from those provided at issuance.
    /// </summary>
    public required ApiEnum<string, VerificationCheckResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VerificationCheckResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The verification identifier.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// The metadata for this verification.
    /// </summary>
    public VerificationCheckResponseMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerificationCheckResponseMetadata>("metadata");
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
        _ = this.ID;
        this.Metadata?.Validate();
        _ = this.RequestID;
    }

    public VerificationCheckResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerificationCheckResponse(VerificationCheckResponse verificationCheckResponse)
        : base(verificationCheckResponse) { }
#pragma warning restore CS8618

    public VerificationCheckResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerificationCheckResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerificationCheckResponseFromRaw.FromRawUnchecked"/>
    public static VerificationCheckResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VerificationCheckResponse(ApiEnum<string, VerificationCheckResponseStatus> status)
        : this()
    {
        this.Status = status;
    }
}

class VerificationCheckResponseFromRaw : IFromRawJson<VerificationCheckResponse>
{
    /// <inheritdoc/>
    public VerificationCheckResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerificationCheckResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the check. For `prelude:psd2` codes, `transaction_missing` is returned
/// when the `psd2` block is omitted, and `transaction_mismatch` when the submitted
/// variables differ from those provided at issuance.
/// </summary>
[JsonConverter(typeof(VerificationCheckResponseStatusConverter))]
public enum VerificationCheckResponseStatus
{
    Success,
    Failure,
    ExpiredOrNotFound,
    TransactionMissing,
    TransactionMismatch,
}

sealed class VerificationCheckResponseStatusConverter
    : JsonConverter<VerificationCheckResponseStatus>
{
    public override VerificationCheckResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => VerificationCheckResponseStatus.Success,
            "failure" => VerificationCheckResponseStatus.Failure,
            "expired_or_not_found" => VerificationCheckResponseStatus.ExpiredOrNotFound,
            "transaction_missing" => VerificationCheckResponseStatus.TransactionMissing,
            "transaction_mismatch" => VerificationCheckResponseStatus.TransactionMismatch,
            _ => (VerificationCheckResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerificationCheckResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerificationCheckResponseStatus.Success => "success",
                VerificationCheckResponseStatus.Failure => "failure",
                VerificationCheckResponseStatus.ExpiredOrNotFound => "expired_or_not_found",
                VerificationCheckResponseStatus.TransactionMissing => "transaction_missing",
                VerificationCheckResponseStatus.TransactionMismatch => "transaction_mismatch",
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
        VerificationCheckResponseMetadata,
        VerificationCheckResponseMetadataFromRaw
    >)
)]
public sealed record class VerificationCheckResponseMetadata : JsonModel
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

    public VerificationCheckResponseMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerificationCheckResponseMetadata(
        VerificationCheckResponseMetadata verificationCheckResponseMetadata
    )
        : base(verificationCheckResponseMetadata) { }
#pragma warning restore CS8618

    public VerificationCheckResponseMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerificationCheckResponseMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerificationCheckResponseMetadataFromRaw.FromRawUnchecked"/>
    public static VerificationCheckResponseMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerificationCheckResponseMetadataFromRaw : IFromRawJson<VerificationCheckResponseMetadata>
{
    /// <inheritdoc/>
    public VerificationCheckResponseMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerificationCheckResponseMetadata.FromRawUnchecked(rawData);
}
