using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;

namespace PreludeSdk.Models.Verification.Phone.History;

/// <summary>
/// The end user's mobile network.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PhoneVerificationCarrier, PhoneVerificationCarrierFromRaw>)
)]
public sealed record class PhoneVerificationCarrier : JsonModel
{
    public required string Mccmnc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mccmnc");
        }
        init { this._rawData.Set("mccmnc", value); }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Mccmnc;
        _ = this.Name;
    }

    public PhoneVerificationCarrier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneVerificationCarrier(PhoneVerificationCarrier phoneVerificationCarrier)
        : base(phoneVerificationCarrier) { }
#pragma warning restore CS8618

    public PhoneVerificationCarrier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneVerificationCarrier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhoneVerificationCarrierFromRaw.FromRawUnchecked"/>
    public static PhoneVerificationCarrier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PhoneVerificationCarrier(string mccmnc)
        : this()
    {
        this.Mccmnc = mccmnc;
    }
}

class PhoneVerificationCarrierFromRaw : IFromRawJson<PhoneVerificationCarrier>
{
    /// <inheritdoc/>
    public PhoneVerificationCarrier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhoneVerificationCarrier.FromRawUnchecked(rawData);
}
