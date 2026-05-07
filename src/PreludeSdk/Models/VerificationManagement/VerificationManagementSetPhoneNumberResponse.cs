using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;

namespace PreludeSdk.Models.VerificationManagement;

[JsonConverter(
    typeof(JsonModelConverter<
        VerificationManagementSetPhoneNumberResponse,
        VerificationManagementSetPhoneNumberResponseFromRaw
    >)
)]
public sealed record class VerificationManagementSetPhoneNumberResponse : JsonModel
{
    /// <summary>
    /// The E.164 formatted phone number that was added to the list.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PhoneNumber;
    }

    public VerificationManagementSetPhoneNumberResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerificationManagementSetPhoneNumberResponse(
        VerificationManagementSetPhoneNumberResponse verificationManagementSetPhoneNumberResponse
    )
        : base(verificationManagementSetPhoneNumberResponse) { }
#pragma warning restore CS8618

    public VerificationManagementSetPhoneNumberResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerificationManagementSetPhoneNumberResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerificationManagementSetPhoneNumberResponseFromRaw.FromRawUnchecked"/>
    public static VerificationManagementSetPhoneNumberResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VerificationManagementSetPhoneNumberResponse(string phoneNumber)
        : this()
    {
        this.PhoneNumber = phoneNumber;
    }
}

class VerificationManagementSetPhoneNumberResponseFromRaw
    : IFromRawJson<VerificationManagementSetPhoneNumberResponse>
{
    /// <inheritdoc/>
    public VerificationManagementSetPhoneNumberResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerificationManagementSetPhoneNumberResponse.FromRawUnchecked(rawData);
}
