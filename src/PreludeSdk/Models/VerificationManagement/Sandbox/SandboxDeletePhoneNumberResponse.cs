using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;

namespace PreludeSdk.Models.VerificationManagement.Sandbox;

[JsonConverter(
    typeof(JsonModelConverter<
        SandboxDeletePhoneNumberResponse,
        SandboxDeletePhoneNumberResponseFromRaw
    >)
)]
public sealed record class SandboxDeletePhoneNumberResponse : JsonModel
{
    /// <summary>
    /// The E.164 formatted phone number that was removed from the sandbox list.
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

    public SandboxDeletePhoneNumberResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SandboxDeletePhoneNumberResponse(
        SandboxDeletePhoneNumberResponse sandboxDeletePhoneNumberResponse
    )
        : base(sandboxDeletePhoneNumberResponse) { }
#pragma warning restore CS8618

    public SandboxDeletePhoneNumberResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SandboxDeletePhoneNumberResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SandboxDeletePhoneNumberResponseFromRaw.FromRawUnchecked"/>
    public static SandboxDeletePhoneNumberResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SandboxDeletePhoneNumberResponse(string phoneNumber)
        : this()
    {
        this.PhoneNumber = phoneNumber;
    }
}

class SandboxDeletePhoneNumberResponseFromRaw : IFromRawJson<SandboxDeletePhoneNumberResponse>
{
    /// <inheritdoc/>
    public SandboxDeletePhoneNumberResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SandboxDeletePhoneNumberResponse.FromRawUnchecked(rawData);
}
