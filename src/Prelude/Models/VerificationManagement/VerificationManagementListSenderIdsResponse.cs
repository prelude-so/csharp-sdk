using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Prelude.Core;
using Prelude.Exceptions;

namespace Prelude.Models.VerificationManagement;

/// <summary>
/// A list of Sender ID.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VerificationManagementListSenderIdsResponse,
        VerificationManagementListSenderIdsResponseFromRaw
    >)
)]
public sealed record class VerificationManagementListSenderIdsResponse : JsonModel
{
    public IReadOnlyList<SenderID>? SenderIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SenderID>>("sender_ids");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SenderID>?>(
                "sender_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.SenderIds ?? [])
        {
            item.Validate();
        }
    }

    public VerificationManagementListSenderIdsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerificationManagementListSenderIdsResponse(
        VerificationManagementListSenderIdsResponse verificationManagementListSenderIdsResponse
    )
        : base(verificationManagementListSenderIdsResponse) { }
#pragma warning restore CS8618

    public VerificationManagementListSenderIdsResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerificationManagementListSenderIdsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerificationManagementListSenderIdsResponseFromRaw.FromRawUnchecked"/>
    public static VerificationManagementListSenderIdsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerificationManagementListSenderIdsResponseFromRaw
    : IFromRawJson<VerificationManagementListSenderIdsResponse>
{
    /// <inheritdoc/>
    public VerificationManagementListSenderIdsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerificationManagementListSenderIdsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SenderID, SenderIDFromRaw>))]
public sealed record class SenderID : JsonModel
{
    /// <summary>
    /// Value that will be presented as Sender ID
    /// </summary>
    public string? SenderIDValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sender_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sender_id", value);
        }
    }

    /// <summary>
    /// It indicates the status of the Sender ID. Possible values are:   * `approved`
    /// - The Sender ID is approved.   * `pending` - The Sender ID is pending.   *
    /// `rejected` - The Sender ID is rejected.
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
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
        _ = this.SenderIDValue;
        this.Status?.Validate();
    }

    public SenderID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderID(SenderID senderID)
        : base(senderID) { }
#pragma warning restore CS8618

    public SenderID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SenderID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SenderIDFromRaw.FromRawUnchecked"/>
    public static SenderID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SenderIDFromRaw : IFromRawJson<SenderID>
{
    /// <inheritdoc/>
    public SenderID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SenderID.FromRawUnchecked(rawData);
}

/// <summary>
/// It indicates the status of the Sender ID. Possible values are:   * `approved`
/// - The Sender ID is approved.   * `pending` - The Sender ID is pending.   * `rejected`
/// - The Sender ID is rejected.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Approved,
    Pending,
    Rejected,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approved" => Status.Approved,
            "pending" => Status.Pending,
            "rejected" => Status.Rejected,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Approved => "approved",
                Status.Pending => "pending",
                Status.Rejected => "rejected",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
