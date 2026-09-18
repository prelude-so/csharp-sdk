using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using System = System;

namespace PreludeSdk.Models.Intel.Kyc;

/// <summary>
/// The per-attribute match result. Each `&lt;attribute&gt;_match` field is one of
/// `true`, `false`, or `not_available` (the operator could not answer for that attribute).
/// Fuzzy attributes additionally return a `&lt;attribute&gt;_match_score` (0-99 similarity)
/// when they do not match exactly; the score is omitted on a match or when `not_available`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<KycMatchResponse, KycMatchResponseFromRaw>))]
public sealed record class KycMatchResponse : JsonModel
{
    /// <summary>
    /// Whether the street address matched the operator's record.
    /// </summary>
    public ApiEnum<string, AddressMatch>? AddressMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AddressMatch>>("address_match");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address_match", value);
        }
    }

    /// <summary>
    /// Similarity score (0-99) for the address. Returned only on a non-match.
    /// </summary>
    public long? AddressMatchScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("address_match_score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address_match_score", value);
        }
    }

    /// <summary>
    /// Whether the date of birth matched the operator's record. Compared exactly;
    /// never scored.
    /// </summary>
    public ApiEnum<string, BirthdateMatch>? BirthdateMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BirthdateMatch>>(
                "birthdate_match"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("birthdate_match", value);
        }
    }

    /// <summary>
    /// The country code of the phone number.
    /// </summary>
    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    /// <summary>
    /// Whether the country matched the operator's record. Compared exactly; never scored.
    /// </summary>
    public ApiEnum<string, CountryMatch>? CountryMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CountryMatch>>("country_match");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country_match", value);
        }
    }

    /// <summary>
    /// Whether the email address matched the operator's record.
    /// </summary>
    public ApiEnum<string, EmailMatch>? EmailMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EmailMatch>>("email_match");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email_match", value);
        }
    }

    /// <summary>
    /// Similarity score (0-99) for the email. Returned only on a non-match.
    /// </summary>
    public long? EmailMatchScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("email_match_score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email_match_score", value);
        }
    }

    /// <summary>
    /// Whether the family name matched the operator's record.
    /// </summary>
    public ApiEnum<string, FamilyNameMatch>? FamilyNameMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FamilyNameMatch>>(
                "family_name_match"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("family_name_match", value);
        }
    }

    /// <summary>
    /// Similarity score (0-99) for the family name. Returned only on a non-match.
    /// </summary>
    public long? FamilyNameMatchScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("family_name_match_score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("family_name_match_score", value);
        }
    }

    /// <summary>
    /// Whether the given name matched the operator's record.
    /// </summary>
    public ApiEnum<string, GivenNameMatch>? GivenNameMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, GivenNameMatch>>(
                "given_name_match"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("given_name_match", value);
        }
    }

    /// <summary>
    /// Similarity score (0-99) for the given name. Returned only on a non-match.
    /// </summary>
    public long? GivenNameMatchScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("given_name_match_score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("given_name_match_score", value);
        }
    }

    /// <summary>
    /// Whether the locality matched the operator's record.
    /// </summary>
    public ApiEnum<string, LocalityMatch>? LocalityMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LocalityMatch>>("locality_match");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("locality_match", value);
        }
    }

    /// <summary>
    /// Similarity score (0-99) for the locality. Returned only on a non-match.
    /// </summary>
    public long? LocalityMatchScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("locality_match_score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("locality_match_score", value);
        }
    }

    /// <summary>
    /// The mobile operator that answered the match.
    /// </summary>
    public string? Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("operator");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("operator", value);
        }
    }

    /// <summary>
    /// The phone number that was matched, in E.164 format.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// Whether the postal code matched the operator's record. Compared exactly;
    /// never scored.
    /// </summary>
    public ApiEnum<string, PostalCodeMatch>? PostalCodeMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PostalCodeMatch>>(
                "postal_code_match"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("postal_code_match", value);
        }
    }

    /// <summary>
    /// Whether the region matched the operator's record.
    /// </summary>
    public ApiEnum<string, RegionMatch>? RegionMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RegionMatch>>("region_match");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("region_match", value);
        }
    }

    /// <summary>
    /// Similarity score (0-99) for the region. Returned only on a non-match.
    /// </summary>
    public long? RegionMatchScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("region_match_score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("region_match_score", value);
        }
    }

    /// <summary>
    /// A string that identifies this specific request. Report it back to us to help
    /// us diagnose your issues.
    /// </summary>
    public string? RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("request_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("request_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AddressMatch?.Validate();
        _ = this.AddressMatchScore;
        this.BirthdateMatch?.Validate();
        _ = this.CountryCode;
        this.CountryMatch?.Validate();
        this.EmailMatch?.Validate();
        _ = this.EmailMatchScore;
        this.FamilyNameMatch?.Validate();
        _ = this.FamilyNameMatchScore;
        this.GivenNameMatch?.Validate();
        _ = this.GivenNameMatchScore;
        this.LocalityMatch?.Validate();
        _ = this.LocalityMatchScore;
        _ = this.Operator;
        _ = this.PhoneNumber;
        this.PostalCodeMatch?.Validate();
        this.RegionMatch?.Validate();
        _ = this.RegionMatchScore;
        _ = this.RequestID;
    }

    public KycMatchResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public KycMatchResponse(KycMatchResponse kycMatchResponse)
        : base(kycMatchResponse) { }
#pragma warning restore CS8618

    public KycMatchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    KycMatchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="KycMatchResponseFromRaw.FromRawUnchecked"/>
    public static KycMatchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class KycMatchResponseFromRaw : IFromRawJson<KycMatchResponse>
{
    /// <inheritdoc/>
    public KycMatchResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        KycMatchResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the street address matched the operator's record.
/// </summary>
[JsonConverter(typeof(AddressMatchConverter))]
public enum AddressMatch
{
    True,
    False,
    NotAvailable,
}

sealed class AddressMatchConverter : JsonConverter<AddressMatch>
{
    public override AddressMatch Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => AddressMatch.True,
            "false" => AddressMatch.False,
            "not_available" => AddressMatch.NotAvailable,
            _ => (AddressMatch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddressMatch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddressMatch.True => "true",
                AddressMatch.False => "false",
                AddressMatch.NotAvailable => "not_available",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether the date of birth matched the operator's record. Compared exactly; never scored.
/// </summary>
[JsonConverter(typeof(BirthdateMatchConverter))]
public enum BirthdateMatch
{
    True,
    False,
    NotAvailable,
}

sealed class BirthdateMatchConverter : JsonConverter<BirthdateMatch>
{
    public override BirthdateMatch Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => BirthdateMatch.True,
            "false" => BirthdateMatch.False,
            "not_available" => BirthdateMatch.NotAvailable,
            _ => (BirthdateMatch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BirthdateMatch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BirthdateMatch.True => "true",
                BirthdateMatch.False => "false",
                BirthdateMatch.NotAvailable => "not_available",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether the country matched the operator's record. Compared exactly; never scored.
/// </summary>
[JsonConverter(typeof(CountryMatchConverter))]
public enum CountryMatch
{
    True,
    False,
    NotAvailable,
}

sealed class CountryMatchConverter : JsonConverter<CountryMatch>
{
    public override CountryMatch Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => CountryMatch.True,
            "false" => CountryMatch.False,
            "not_available" => CountryMatch.NotAvailable,
            _ => (CountryMatch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CountryMatch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CountryMatch.True => "true",
                CountryMatch.False => "false",
                CountryMatch.NotAvailable => "not_available",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether the email address matched the operator's record.
/// </summary>
[JsonConverter(typeof(EmailMatchConverter))]
public enum EmailMatch
{
    True,
    False,
    NotAvailable,
}

sealed class EmailMatchConverter : JsonConverter<EmailMatch>
{
    public override EmailMatch Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => EmailMatch.True,
            "false" => EmailMatch.False,
            "not_available" => EmailMatch.NotAvailable,
            _ => (EmailMatch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailMatch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EmailMatch.True => "true",
                EmailMatch.False => "false",
                EmailMatch.NotAvailable => "not_available",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether the family name matched the operator's record.
/// </summary>
[JsonConverter(typeof(FamilyNameMatchConverter))]
public enum FamilyNameMatch
{
    True,
    False,
    NotAvailable,
}

sealed class FamilyNameMatchConverter : JsonConverter<FamilyNameMatch>
{
    public override FamilyNameMatch Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => FamilyNameMatch.True,
            "false" => FamilyNameMatch.False,
            "not_available" => FamilyNameMatch.NotAvailable,
            _ => (FamilyNameMatch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FamilyNameMatch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FamilyNameMatch.True => "true",
                FamilyNameMatch.False => "false",
                FamilyNameMatch.NotAvailable => "not_available",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether the given name matched the operator's record.
/// </summary>
[JsonConverter(typeof(GivenNameMatchConverter))]
public enum GivenNameMatch
{
    True,
    False,
    NotAvailable,
}

sealed class GivenNameMatchConverter : JsonConverter<GivenNameMatch>
{
    public override GivenNameMatch Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => GivenNameMatch.True,
            "false" => GivenNameMatch.False,
            "not_available" => GivenNameMatch.NotAvailable,
            _ => (GivenNameMatch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GivenNameMatch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GivenNameMatch.True => "true",
                GivenNameMatch.False => "false",
                GivenNameMatch.NotAvailable => "not_available",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether the locality matched the operator's record.
/// </summary>
[JsonConverter(typeof(LocalityMatchConverter))]
public enum LocalityMatch
{
    True,
    False,
    NotAvailable,
}

sealed class LocalityMatchConverter : JsonConverter<LocalityMatch>
{
    public override LocalityMatch Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => LocalityMatch.True,
            "false" => LocalityMatch.False,
            "not_available" => LocalityMatch.NotAvailable,
            _ => (LocalityMatch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LocalityMatch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LocalityMatch.True => "true",
                LocalityMatch.False => "false",
                LocalityMatch.NotAvailable => "not_available",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether the postal code matched the operator's record. Compared exactly; never scored.
/// </summary>
[JsonConverter(typeof(PostalCodeMatchConverter))]
public enum PostalCodeMatch
{
    True,
    False,
    NotAvailable,
}

sealed class PostalCodeMatchConverter : JsonConverter<PostalCodeMatch>
{
    public override PostalCodeMatch Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => PostalCodeMatch.True,
            "false" => PostalCodeMatch.False,
            "not_available" => PostalCodeMatch.NotAvailable,
            _ => (PostalCodeMatch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PostalCodeMatch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PostalCodeMatch.True => "true",
                PostalCodeMatch.False => "false",
                PostalCodeMatch.NotAvailable => "not_available",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether the region matched the operator's record.
/// </summary>
[JsonConverter(typeof(RegionMatchConverter))]
public enum RegionMatch
{
    True,
    False,
    NotAvailable,
}

sealed class RegionMatchConverter : JsonConverter<RegionMatch>
{
    public override RegionMatch Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => RegionMatch.True,
            "false" => RegionMatch.False,
            "not_available" => RegionMatch.NotAvailable,
            _ => (RegionMatch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RegionMatch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RegionMatch.True => "true",
                RegionMatch.False => "false",
                RegionMatch.NotAvailable => "not_available",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
