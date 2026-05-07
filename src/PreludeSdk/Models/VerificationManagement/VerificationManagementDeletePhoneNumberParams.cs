using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;

namespace PreludeSdk.Models.VerificationManagement;

/// <summary>
/// Remove a phone number from the allow or block list.
///
/// <para>This operation is idempotent - re-deleting the same phone number will not
/// result in errors. If the phone number does not exist in the specified list, the
/// operation will succeed without making any changes.</para>
///
/// <para>In order to get access to this endpoint, contact our support team.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VerificationManagementDeletePhoneNumberParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public ApiEnum<
        string,
        global::PreludeSdk.Models.VerificationManagement.Action
    >? Action { get; init; }

    /// <summary>
    /// An E.164 formatted phone number to remove from the list.
    /// </summary>
    public required string PhoneNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("phone_number");
        }
        init { this._rawBodyData.Set("phone_number", value); }
    }

    public VerificationManagementDeletePhoneNumberParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerificationManagementDeletePhoneNumberParams(
        VerificationManagementDeletePhoneNumberParams verificationManagementDeletePhoneNumberParams
    )
        : base(verificationManagementDeletePhoneNumberParams)
    {
        this.Action = verificationManagementDeletePhoneNumberParams.Action;

        this._rawBodyData = new(verificationManagementDeletePhoneNumberParams._rawBodyData);
    }
#pragma warning restore CS8618

    public VerificationManagementDeletePhoneNumberParams(
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
    VerificationManagementDeletePhoneNumberParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        ApiEnum<string, global::PreludeSdk.Models.VerificationManagement.Action> action
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.Action = action;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static VerificationManagementDeletePhoneNumberParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        ApiEnum<string, global::PreludeSdk.Models.VerificationManagement.Action> action
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(VerificationManagementDeletePhoneNumberParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.Action?.Equals(other.Action) ?? other.Action == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
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

[JsonConverter(typeof(ActionConverter))]
public enum Action
{
    Allow,
    Block,
}

sealed class ActionConverter
    : JsonConverter<global::PreludeSdk.Models.VerificationManagement.Action>
{
    public override global::PreludeSdk.Models.VerificationManagement.Action Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allow" => global::PreludeSdk.Models.VerificationManagement.Action.Allow,
            "block" => global::PreludeSdk.Models.VerificationManagement.Action.Block,
            _ => (global::PreludeSdk.Models.VerificationManagement.Action)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::PreludeSdk.Models.VerificationManagement.Action value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::PreludeSdk.Models.VerificationManagement.Action.Allow => "allow",
                global::PreludeSdk.Models.VerificationManagement.Action.Block => "block",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
