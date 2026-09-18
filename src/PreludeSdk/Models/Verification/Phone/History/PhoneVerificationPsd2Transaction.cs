using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;

namespace PreludeSdk.Models.Verification.Phone.History;

[JsonConverter(
    typeof(JsonModelConverter<
        PhoneVerificationPsd2Transaction,
        PhoneVerificationPsd2TransactionFromRaw
    >)
)]
public sealed record class PhoneVerificationPsd2Transaction : JsonModel
{
    public PhoneVerificationMoney? Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneVerificationMoney>("amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// Payee name displayed to the payer.
    /// </summary>
    public string? Recipient
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("recipient");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("recipient", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Amount?.Validate();
        _ = this.Recipient;
    }

    public PhoneVerificationPsd2Transaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneVerificationPsd2Transaction(
        PhoneVerificationPsd2Transaction phoneVerificationPsd2Transaction
    )
        : base(phoneVerificationPsd2Transaction) { }
#pragma warning restore CS8618

    public PhoneVerificationPsd2Transaction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneVerificationPsd2Transaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhoneVerificationPsd2TransactionFromRaw.FromRawUnchecked"/>
    public static PhoneVerificationPsd2Transaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhoneVerificationPsd2TransactionFromRaw : IFromRawJson<PhoneVerificationPsd2Transaction>
{
    /// <inheritdoc/>
    public PhoneVerificationPsd2Transaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhoneVerificationPsd2Transaction.FromRawUnchecked(rawData);
}
