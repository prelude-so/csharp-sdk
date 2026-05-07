using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;

namespace PreludeSdk.Models.VerificationManagement;

/// <summary>
/// Retrieve the list of phone numbers in the allow or block list.
///
/// <para>In order to get access to this endpoint, contact our support team.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VerificationManagementListPhoneNumbersParams : ParamsBase
{
    public ApiEnum<
        string,
        VerificationManagementListPhoneNumbersParamsAction
    >? Action { get; init; }

    public VerificationManagementListPhoneNumbersParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerificationManagementListPhoneNumbersParams(
        VerificationManagementListPhoneNumbersParams verificationManagementListPhoneNumbersParams
    )
        : base(verificationManagementListPhoneNumbersParams)
    {
        this.Action = verificationManagementListPhoneNumbersParams.Action;
    }
#pragma warning restore CS8618

    public VerificationManagementListPhoneNumbersParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerificationManagementListPhoneNumbersParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        ApiEnum<string, VerificationManagementListPhoneNumbersParamsAction> action
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.Action = action;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static VerificationManagementListPhoneNumbersParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        ApiEnum<string, VerificationManagementListPhoneNumbersParamsAction> action
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            action
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["Action"] = JsonSerializer.SerializeToElement(this.Action),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(VerificationManagementListPhoneNumbersParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.Action?.Equals(other.Action) ?? other.Action == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v2/verification/management/phone-numbers/{0}", this.Action?.Raw())
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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

[JsonConverter(typeof(VerificationManagementListPhoneNumbersParamsActionConverter))]
public enum VerificationManagementListPhoneNumbersParamsAction
{
    Allow,
    Block,
}

sealed class VerificationManagementListPhoneNumbersParamsActionConverter
    : JsonConverter<VerificationManagementListPhoneNumbersParamsAction>
{
    public override VerificationManagementListPhoneNumbersParamsAction Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allow" => VerificationManagementListPhoneNumbersParamsAction.Allow,
            "block" => VerificationManagementListPhoneNumbersParamsAction.Block,
            _ => (VerificationManagementListPhoneNumbersParamsAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerificationManagementListPhoneNumbersParamsAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerificationManagementListPhoneNumbersParamsAction.Allow => "allow",
                VerificationManagementListPhoneNumbersParamsAction.Block => "block",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
