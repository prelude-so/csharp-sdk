using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using PreludeSdk.Core;

namespace PreludeSdk.Models.Notify;

/// <summary>
/// Retrieve the current subscription status for a specific phone number within a
/// subscription configuration.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class NotifyGetSubscriptionPhoneNumberParams : ParamsBase
{
    public required string ConfigID { get; init; }

    public string? PhoneNumber { get; init; }

    public NotifyGetSubscriptionPhoneNumberParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotifyGetSubscriptionPhoneNumberParams(
        NotifyGetSubscriptionPhoneNumberParams notifyGetSubscriptionPhoneNumberParams
    )
        : base(notifyGetSubscriptionPhoneNumberParams)
    {
        this.ConfigID = notifyGetSubscriptionPhoneNumberParams.ConfigID;
        this.PhoneNumber = notifyGetSubscriptionPhoneNumberParams.PhoneNumber;
    }
#pragma warning restore CS8618

    public NotifyGetSubscriptionPhoneNumberParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotifyGetSubscriptionPhoneNumberParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string configID,
        string phoneNumber
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ConfigID = configID;
        this.PhoneNumber = phoneNumber;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static NotifyGetSubscriptionPhoneNumberParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string configID,
        string phoneNumber
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            configID,
            phoneNumber
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ConfigID"] = JsonSerializer.SerializeToElement(this.ConfigID),
                    ["PhoneNumber"] = JsonSerializer.SerializeToElement(this.PhoneNumber),
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

    public virtual bool Equals(NotifyGetSubscriptionPhoneNumberParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.ConfigID.Equals(other.ConfigID)
            && (this.PhoneNumber?.Equals(other.PhoneNumber) ?? other.PhoneNumber == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v2/notify/management/subscriptions/{0}/phone_numbers/{1}",
                    this.ConfigID,
                    this.PhoneNumber
                )
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
