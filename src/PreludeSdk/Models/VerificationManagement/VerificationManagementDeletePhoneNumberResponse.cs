using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;

namespace PreludeSdk.Models.VerificationManagement;

[JsonConverter(
    typeof(JsonModelConverter<
        VerificationManagementDeletePhoneNumberResponse,
        VerificationManagementDeletePhoneNumberResponseFromRaw
    >)
)]
public sealed record class VerificationManagementDeletePhoneNumberResponse : JsonModel
{
    /// <summary>
    /// The E.164 formatted phone number that was removed from the list.
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

    public VerificationManagementDeletePhoneNumberResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerificationManagementDeletePhoneNumberResponse(
        VerificationManagementDeletePhoneNumberResponse verificationManagementDeletePhoneNumberResponse
    )
        : base(verificationManagementDeletePhoneNumberResponse) { }
#pragma warning restore CS8618

    public VerificationManagementDeletePhoneNumberResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerificationManagementDeletePhoneNumberResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerificationManagementDeletePhoneNumberResponseFromRaw.FromRawUnchecked"/>
    public static VerificationManagementDeletePhoneNumberResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VerificationManagementDeletePhoneNumberResponse(string phoneNumber)
        : this()
    {
        this.PhoneNumber = phoneNumber;
    }
}

class VerificationManagementDeletePhoneNumberResponseFromRaw
    : IFromRawJson<VerificationManagementDeletePhoneNumberResponse>
{
    /// <inheritdoc/>
    public VerificationManagementDeletePhoneNumberResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerificationManagementDeletePhoneNumberResponse.FromRawUnchecked(rawData);
}
