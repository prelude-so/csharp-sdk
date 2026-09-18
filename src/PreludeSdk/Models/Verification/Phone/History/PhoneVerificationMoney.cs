using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;

namespace PreludeSdk.Models.Verification.Phone.History;

[JsonConverter(typeof(JsonModelConverter<PhoneVerificationMoney, PhoneVerificationMoneyFromRaw>))]
public sealed record class PhoneVerificationMoney : JsonModel
{
    /// <summary>
    /// Exact decimal amount. It is never rounded to the currency's minor units,
    /// so a sub-cent cost reads as `0.0004` rather than as `0.00`.
    /// </summary>
    public required string Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// ISO 4217 currency code.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public PhoneVerificationMoney() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneVerificationMoney(PhoneVerificationMoney phoneVerificationMoney)
        : base(phoneVerificationMoney) { }
#pragma warning restore CS8618

    public PhoneVerificationMoney(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneVerificationMoney(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhoneVerificationMoneyFromRaw.FromRawUnchecked"/>
    public static PhoneVerificationMoney FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhoneVerificationMoneyFromRaw : IFromRawJson<PhoneVerificationMoney>
{
    /// <inheritdoc/>
    public PhoneVerificationMoney FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhoneVerificationMoney.FromRawUnchecked(rawData);
}
