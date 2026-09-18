using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;

namespace PreludeSdk.Models.VerificationManagement.Sandbox;

[JsonConverter(
    typeof(JsonModelConverter<SandboxAddPhoneNumberResponse, SandboxAddPhoneNumberResponseFromRaw>)
)]
public sealed record class SandboxAddPhoneNumberResponse : JsonModel
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
    /// The E.164 formatted phone number that was added to the sandbox list.
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
        _ = this.AttemptCode;
        _ = this.PhoneNumber;
    }

    public SandboxAddPhoneNumberResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SandboxAddPhoneNumberResponse(
        SandboxAddPhoneNumberResponse sandboxAddPhoneNumberResponse
    )
        : base(sandboxAddPhoneNumberResponse) { }
#pragma warning restore CS8618

    public SandboxAddPhoneNumberResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SandboxAddPhoneNumberResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SandboxAddPhoneNumberResponseFromRaw.FromRawUnchecked"/>
    public static SandboxAddPhoneNumberResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SandboxAddPhoneNumberResponseFromRaw : IFromRawJson<SandboxAddPhoneNumberResponse>
{
    /// <inheritdoc/>
    public SandboxAddPhoneNumberResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SandboxAddPhoneNumberResponse.FromRawUnchecked(rawData);
}
