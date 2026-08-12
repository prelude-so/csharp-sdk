using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using System = System;

namespace PreludeSdk.Models.Verification;

/// <summary>
/// Check the validity of a verification code.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VerificationCheckParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The OTP code to validate.
    /// </summary>
    public required string Code
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("code");
        }
        init { this._rawBodyData.Set("code", value); }
    }

    /// <summary>
    /// The verification target. Either a phone number or an email address. To use
    /// the email verification feature contact us to discuss your use case.
    /// </summary>
    public required VerificationCheckParamsTarget Target
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<VerificationCheckParamsTarget>("target");
        }
        init { this._rawBodyData.Set("target", value); }
    }

    /// <summary>
    /// Required when checking a code issued under the `prelude:psd2` template. The
    /// submitted variables must match those provided at issuance; any mismatch invalidates
    /// the code (PSD2 SCA RTS Article 5 dynamic linking). Ignored on non-PSD2 verifications.
    /// </summary>
    public Psd2? Psd2
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Psd2>("psd2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("psd2", value);
        }
    }

    public VerificationCheckParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerificationCheckParams(VerificationCheckParams verificationCheckParams)
        : base(verificationCheckParams)
    {
        this._rawBodyData = new(verificationCheckParams._rawBodyData);
    }
#pragma warning restore CS8618

    public VerificationCheckParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerificationCheckParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static VerificationCheckParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(VerificationCheckParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v2/verification/check"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// The verification target. Either a phone number or an email address. To use the
/// email verification feature contact us to discuss your use case.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<VerificationCheckParamsTarget, VerificationCheckParamsTargetFromRaw>)
)]
public sealed record class VerificationCheckParamsTarget : JsonModel
{
    /// <summary>
    /// The type of the target. Either "phone_number" or "email_address".
    /// </summary>
    public required ApiEnum<string, VerificationCheckParamsTargetType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, VerificationCheckParamsTargetType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// An E.164 formatted phone number or an email address.
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Value;
    }

    public VerificationCheckParamsTarget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerificationCheckParamsTarget(
        VerificationCheckParamsTarget verificationCheckParamsTarget
    )
        : base(verificationCheckParamsTarget) { }
#pragma warning restore CS8618

    public VerificationCheckParamsTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerificationCheckParamsTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerificationCheckParamsTargetFromRaw.FromRawUnchecked"/>
    public static VerificationCheckParamsTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerificationCheckParamsTargetFromRaw : IFromRawJson<VerificationCheckParamsTarget>
{
    /// <inheritdoc/>
    public VerificationCheckParamsTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VerificationCheckParamsTarget.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the target. Either "phone_number" or "email_address".
/// </summary>
[JsonConverter(typeof(VerificationCheckParamsTargetTypeConverter))]
public enum VerificationCheckParamsTargetType
{
    PhoneNumber,
    EmailAddress,
}

sealed class VerificationCheckParamsTargetTypeConverter
    : JsonConverter<VerificationCheckParamsTargetType>
{
    public override VerificationCheckParamsTargetType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "phone_number" => VerificationCheckParamsTargetType.PhoneNumber,
            "email_address" => VerificationCheckParamsTargetType.EmailAddress,
            _ => (VerificationCheckParamsTargetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerificationCheckParamsTargetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerificationCheckParamsTargetType.PhoneNumber => "phone_number",
                VerificationCheckParamsTargetType.EmailAddress => "email_address",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Required when checking a code issued under the `prelude:psd2` template. The submitted
/// variables must match those provided at issuance; any mismatch invalidates the
/// code (PSD2 SCA RTS Article 5 dynamic linking). Ignored on non-PSD2 verifications.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Psd2, Psd2FromRaw>))]
public sealed record class Psd2 : JsonModel
{
    /// <summary>
    /// Decimal amount of the transaction.
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

    /// <summary>
    /// Payee name displayed to the payer.
    /// </summary>
    public required string Recipient
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("recipient");
        }
        init { this._rawData.Set("recipient", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
        _ = this.Recipient;
    }

    public Psd2() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Psd2(Psd2 psd2)
        : base(psd2) { }
#pragma warning restore CS8618

    public Psd2(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Psd2(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Psd2FromRaw.FromRawUnchecked"/>
    public static Psd2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Psd2FromRaw : IFromRawJson<Psd2>
{
    /// <inheritdoc/>
    public Psd2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Psd2.FromRawUnchecked(rawData);
}
