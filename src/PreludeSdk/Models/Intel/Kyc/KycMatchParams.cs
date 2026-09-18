using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using PreludeSdk.Core;

namespace PreludeSdk.Models.Intel.Kyc;

/// <summary>
/// Verify identity attributes against the subscriber record held by the end-user's
/// mobile operator. Send a phone number along with the attributes to check; Prelude
/// resolves the operator internally and returns a per-attribute match. Currently
/// available for France only (Orange, SFR, Bouygues) and must be enabled for your account.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class KycMatchParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? Phone { get; init; }

    /// <summary>
    /// The street address.
    /// </summary>
    public string? Address
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("address", value);
        }
    }

    /// <summary>
    /// The date of birth in ISO 8601 (`YYYY-MM-DD`) format. Compared exactly.
    /// </summary>
    public string? Birthdate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("birthdate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("birthdate", value);
        }
    }

    /// <summary>
    /// The ISO 3166-1 alpha-2 country code. Compared exactly.
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("country", value);
        }
    }

    /// <summary>
    /// The email address.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("email", value);
        }
    }

    /// <summary>
    /// The end-user's family (last) name.
    /// </summary>
    public string? FamilyName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("family_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("family_name", value);
        }
    }

    /// <summary>
    /// The end-user's given (first) name.
    /// </summary>
    public string? GivenName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("given_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("given_name", value);
        }
    }

    /// <summary>
    /// The locality (city).
    /// </summary>
    public string? Locality
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("locality");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("locality", value);
        }
    }

    /// <summary>
    /// The postal code. Compared exactly.
    /// </summary>
    public string? PostalCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("postal_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("postal_code", value);
        }
    }

    /// <summary>
    /// The region, state, or province.
    /// </summary>
    public string? Region
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("region");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("region", value);
        }
    }

    public KycMatchParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public KycMatchParams(KycMatchParams kycMatchParams)
        : base(kycMatchParams)
    {
        this.Phone = kycMatchParams.Phone;

        this._rawBodyData = new(kycMatchParams._rawBodyData);
    }
#pragma warning restore CS8618

    public KycMatchParams(
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
    KycMatchParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string phone
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.Phone = phone;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static KycMatchParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string phone
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            phone
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["Phone"] = JsonSerializer.SerializeToElement(this.Phone),
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

    public virtual bool Equals(KycMatchParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.Phone?.Equals(other.Phone) ?? other.Phone == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v2/intel/kyc/match/{0}", this.Phone)
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
