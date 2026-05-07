using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using System = System;

namespace PreludeSdk.Models.Lookup;

/// <summary>
/// Retrieve detailed information about a phone number including carrier data, line
/// type, and portability status.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class LookupLookupParams : ParamsBase
{
    public string? PhoneNumber { get; init; }

    /// <summary>
    /// Optional features. Possible values are:   * `cnam` - Retrieve CNAM (Caller
    /// ID Name) along with other information. Contact us if you need to use this
    /// functionality.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, global::PreludeSdk.Models.Lookup.Type>>? Type
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, global::PreludeSdk.Models.Lookup.Type>>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<
                ApiEnum<string, global::PreludeSdk.Models.Lookup.Type>
            >?>("type", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    public LookupLookupParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LookupLookupParams(LookupLookupParams lookupLookupParams)
        : base(lookupLookupParams)
    {
        this.PhoneNumber = lookupLookupParams.PhoneNumber;
    }
#pragma warning restore CS8618

    public LookupLookupParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LookupLookupParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string phoneNumber
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.PhoneNumber = phoneNumber;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static LookupLookupParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string phoneNumber
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            phoneNumber
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(LookupLookupParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.PhoneNumber?.Equals(other.PhoneNumber) ?? other.PhoneNumber == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v2/lookup/{0}", this.PhoneNumber)
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

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Cnam,
}

sealed class TypeConverter : JsonConverter<global::PreludeSdk.Models.Lookup.Type>
{
    public override global::PreludeSdk.Models.Lookup.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cnam" => global::PreludeSdk.Models.Lookup.Type.Cnam,
            _ => (global::PreludeSdk.Models.Lookup.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::PreludeSdk.Models.Lookup.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::PreludeSdk.Models.Lookup.Type.Cnam => "cnam",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
