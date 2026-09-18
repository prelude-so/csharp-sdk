using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;

namespace PreludeSdk.Models.VerificationManagement.Sandbox;

[JsonConverter(
    typeof(JsonModelConverter<
        SandboxListPhoneNumbersResponse,
        SandboxListPhoneNumbersResponseFromRaw
    >)
)]
public sealed record class SandboxListPhoneNumbersResponse : JsonModel
{
    /// <summary>
    /// A list of sandbox phone numbers.
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

    public SandboxListPhoneNumbersResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SandboxListPhoneNumbersResponse(
        SandboxListPhoneNumbersResponse sandboxListPhoneNumbersResponse
    )
        : base(sandboxListPhoneNumbersResponse) { }
#pragma warning restore CS8618

    public SandboxListPhoneNumbersResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SandboxListPhoneNumbersResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SandboxListPhoneNumbersResponseFromRaw.FromRawUnchecked"/>
    public static SandboxListPhoneNumbersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SandboxListPhoneNumbersResponse(IReadOnlyList<PhoneNumber> phoneNumbers)
        : this()
    {
        this.PhoneNumbers = phoneNumbers;
    }
}

class SandboxListPhoneNumbersResponseFromRaw : IFromRawJson<SandboxListPhoneNumbersResponse>
{
    /// <inheritdoc/>
    public SandboxListPhoneNumbersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SandboxListPhoneNumbersResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PhoneNumber, PhoneNumberFromRaw>))]
public sealed record class PhoneNumber : JsonModel
{
    /// <summary>
    /// The fixed attempt code associated with the sandbox phone number.
    /// </summary>
    public required string AttemptCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("attempt_code");
        }
        init { this._rawData.Set("attempt_code", value); }
    }

    /// <summary>
    /// The date and time when the phone number was added to the sandbox list.
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
        _ = this.AttemptCode;
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
