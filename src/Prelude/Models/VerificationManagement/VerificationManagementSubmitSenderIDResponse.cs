using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Prelude.Core;
using Prelude.Exceptions;

namespace Prelude.Models.VerificationManagement;

[JsonConverter(
    typeof(JsonModelConverter<
        VerificationManagementSubmitSenderIDResponse,
        VerificationManagementSubmitSenderIDResponseFromRaw
    >)
)]
public sealed record class VerificationManagementSubmitSenderIDResponse : JsonModel
{
    /// <summary>
    /// The sender ID that was added.
    /// </summary>
    public required string SenderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sender_id");
        }
        init { this._rawData.Set("sender_id", value); }
    }

    /// <summary>
    /// It indicates the status of the sender ID. Possible values are:   * `approved`
    /// - The sender ID is approved.   * `pending` - The sender ID is pending.   *
    /// `rejected` - The sender ID is rejected.
    /// </summary>
    public required ApiEnum<string, VerificationManagementSubmitSenderIDResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, VerificationManagementSubmitSenderIDResponseStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The reason why the sender ID was rejected.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SenderID;
        this.Status.Validate();
        _ = this.Reason;
    }

    public VerificationManagementSubmitSenderIDResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerificationManagementSubmitSenderIDResponse(
        VerificationManagementSubmitSenderIDResponse verificationManagementSubmitSenderIDResponse
    )
        : base(verificationManagementSubmitSenderIDResponse) { }
#pragma warning restore CS8618

    public VerificationManagementSubmitSenderIDResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerificationManagementSubmitSenderIDResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerificationManagementSubmitSenderIDResponseFromRaw.FromRawUnchecked"/>
    public static VerificationManagementSubmitSenderIDResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerificationManagementSubmitSenderIDResponseFromRaw
    : IFromRawJson<VerificationManagementSubmitSenderIDResponse>
{
    /// <inheritdoc/>
    public VerificationManagementSubmitSenderIDResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerificationManagementSubmitSenderIDResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// It indicates the status of the sender ID. Possible values are:   * `approved`
/// - The sender ID is approved.   * `pending` - The sender ID is pending.   * `rejected`
/// - The sender ID is rejected.
/// </summary>
[JsonConverter(typeof(VerificationManagementSubmitSenderIDResponseStatusConverter))]
public enum VerificationManagementSubmitSenderIDResponseStatus
{
    Approved,
    Pending,
    Rejected,
}

sealed class VerificationManagementSubmitSenderIDResponseStatusConverter
    : JsonConverter<VerificationManagementSubmitSenderIDResponseStatus>
{
    public override VerificationManagementSubmitSenderIDResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approved" => VerificationManagementSubmitSenderIDResponseStatus.Approved,
            "pending" => VerificationManagementSubmitSenderIDResponseStatus.Pending,
            "rejected" => VerificationManagementSubmitSenderIDResponseStatus.Rejected,
            _ => (VerificationManagementSubmitSenderIDResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerificationManagementSubmitSenderIDResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerificationManagementSubmitSenderIDResponseStatus.Approved => "approved",
                VerificationManagementSubmitSenderIDResponseStatus.Pending => "pending",
                VerificationManagementSubmitSenderIDResponseStatus.Rejected => "rejected",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
