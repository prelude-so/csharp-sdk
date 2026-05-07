using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Prelude.Core;

namespace Prelude.Models.VerificationManagement;

[JsonConverter(
    typeof(JsonModelConverter<
        VerificationManagementListPhoneNumbersResponse,
        VerificationManagementListPhoneNumbersResponseFromRaw
    >)
)]
public sealed record class VerificationManagementListPhoneNumbersResponse : JsonModel
{
    /// <summary>
    /// A list of phone numbers in the allow or block list.
    /// </summary>
    public required IReadOnlyList<PhoneNumber> PhoneNumbers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PhoneNumber>>("phone_numbers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PhoneNumber>>(
                "phone_numbers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.PhoneNumbers)
        {
            item.Validate();
        }
    }

    public VerificationManagementListPhoneNumbersResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerificationManagementListPhoneNumbersResponse(
        VerificationManagementListPhoneNumbersResponse verificationManagementListPhoneNumbersResponse
    )
        : base(verificationManagementListPhoneNumbersResponse) { }
#pragma warning restore CS8618

    public VerificationManagementListPhoneNumbersResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerificationManagementListPhoneNumbersResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerificationManagementListPhoneNumbersResponseFromRaw.FromRawUnchecked"/>
    public static VerificationManagementListPhoneNumbersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VerificationManagementListPhoneNumbersResponse(IReadOnlyList<PhoneNumber> phoneNumbers)
        : this()
    {
        this.PhoneNumbers = phoneNumbers;
    }
}

class VerificationManagementListPhoneNumbersResponseFromRaw
    : IFromRawJson<VerificationManagementListPhoneNumbersResponse>
{
    /// <inheritdoc/>
    public VerificationManagementListPhoneNumbersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerificationManagementListPhoneNumbersResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PhoneNumber, PhoneNumberFromRaw>))]
public sealed record class PhoneNumber : JsonModel
{
    /// <summary>
    /// The date and time when the phone number was added to the list.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// An E.164 formatted phone number.
    /// </summary>
    public required string PhoneNumberValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("phone_number");
        }
        init { this._rawData.Set("phone_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.PhoneNumberValue;
    }

    public PhoneNumber() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumber(PhoneNumber phoneNumber)
        : base(phoneNumber) { }
#pragma warning restore CS8618

    public PhoneNumber(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumber(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberFromRaw.FromRawUnchecked"/>
    public static PhoneNumber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhoneNumberFromRaw : IFromRawJson<PhoneNumber>
{
    /// <inheritdoc/>
    public PhoneNumber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PhoneNumber.FromRawUnchecked(rawData);
}
