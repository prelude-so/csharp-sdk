using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.Intel.Kyc;

namespace PreludeSdk.Tests.Models.Intel.Kyc;

public class KycMatchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new KycMatchResponse
        {
            AddressMatch = AddressMatch.False,
            AddressMatchScore = 64,
            BirthdateMatch = BirthdateMatch.True,
            CountryCode = "FR",
            CountryMatch = CountryMatch.True,
            EmailMatch = EmailMatch.NotAvailable,
            EmailMatchScore = 0,
            FamilyNameMatch = FamilyNameMatch.False,
            FamilyNameMatchScore = 82,
            GivenNameMatch = GivenNameMatch.True,
            GivenNameMatchScore = 0,
            LocalityMatch = LocalityMatch.True,
            LocalityMatchScore = 0,
            Operator = "orange_fr",
            PhoneNumber = "+33612345678",
            PostalCodeMatch = PostalCodeMatch.True,
            RegionMatch = RegionMatch.NotAvailable,
            RegionMatchScore = 0,
            RequestID = "01HVE0000000000000000000000",
        };

        ApiEnum<string, AddressMatch> expectedAddressMatch = AddressMatch.False;
        long expectedAddressMatchScore = 64;
        ApiEnum<string, BirthdateMatch> expectedBirthdateMatch = BirthdateMatch.True;
        string expectedCountryCode = "FR";
        ApiEnum<string, CountryMatch> expectedCountryMatch = CountryMatch.True;
        ApiEnum<string, EmailMatch> expectedEmailMatch = EmailMatch.NotAvailable;
        long expectedEmailMatchScore = 0;
        ApiEnum<string, FamilyNameMatch> expectedFamilyNameMatch = FamilyNameMatch.False;
        long expectedFamilyNameMatchScore = 82;
        ApiEnum<string, GivenNameMatch> expectedGivenNameMatch = GivenNameMatch.True;
        long expectedGivenNameMatchScore = 0;
        ApiEnum<string, LocalityMatch> expectedLocalityMatch = LocalityMatch.True;
        long expectedLocalityMatchScore = 0;
        string expectedOperator = "orange_fr";
        string expectedPhoneNumber = "+33612345678";
        ApiEnum<string, PostalCodeMatch> expectedPostalCodeMatch = PostalCodeMatch.True;
        ApiEnum<string, RegionMatch> expectedRegionMatch = RegionMatch.NotAvailable;
        long expectedRegionMatchScore = 0;
        string expectedRequestID = "01HVE0000000000000000000000";

        Assert.Equal(expectedAddressMatch, model.AddressMatch);
        Assert.Equal(expectedAddressMatchScore, model.AddressMatchScore);
        Assert.Equal(expectedBirthdateMatch, model.BirthdateMatch);
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedCountryMatch, model.CountryMatch);
        Assert.Equal(expectedEmailMatch, model.EmailMatch);
        Assert.Equal(expectedEmailMatchScore, model.EmailMatchScore);
        Assert.Equal(expectedFamilyNameMatch, model.FamilyNameMatch);
        Assert.Equal(expectedFamilyNameMatchScore, model.FamilyNameMatchScore);
        Assert.Equal(expectedGivenNameMatch, model.GivenNameMatch);
        Assert.Equal(expectedGivenNameMatchScore, model.GivenNameMatchScore);
        Assert.Equal(expectedLocalityMatch, model.LocalityMatch);
        Assert.Equal(expectedLocalityMatchScore, model.LocalityMatchScore);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedPostalCodeMatch, model.PostalCodeMatch);
        Assert.Equal(expectedRegionMatch, model.RegionMatch);
        Assert.Equal(expectedRegionMatchScore, model.RegionMatchScore);
        Assert.Equal(expectedRequestID, model.RequestID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new KycMatchResponse
        {
            AddressMatch = AddressMatch.False,
            AddressMatchScore = 64,
            BirthdateMatch = BirthdateMatch.True,
            CountryCode = "FR",
            CountryMatch = CountryMatch.True,
            EmailMatch = EmailMatch.NotAvailable,
            EmailMatchScore = 0,
            FamilyNameMatch = FamilyNameMatch.False,
            FamilyNameMatchScore = 82,
            GivenNameMatch = GivenNameMatch.True,
            GivenNameMatchScore = 0,
            LocalityMatch = LocalityMatch.True,
            LocalityMatchScore = 0,
            Operator = "orange_fr",
            PhoneNumber = "+33612345678",
            PostalCodeMatch = PostalCodeMatch.True,
            RegionMatch = RegionMatch.NotAvailable,
            RegionMatchScore = 0,
            RequestID = "01HVE0000000000000000000000",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<KycMatchResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new KycMatchResponse
        {
            AddressMatch = AddressMatch.False,
            AddressMatchScore = 64,
            BirthdateMatch = BirthdateMatch.True,
            CountryCode = "FR",
            CountryMatch = CountryMatch.True,
            EmailMatch = EmailMatch.NotAvailable,
            EmailMatchScore = 0,
            FamilyNameMatch = FamilyNameMatch.False,
            FamilyNameMatchScore = 82,
            GivenNameMatch = GivenNameMatch.True,
            GivenNameMatchScore = 0,
            LocalityMatch = LocalityMatch.True,
            LocalityMatchScore = 0,
            Operator = "orange_fr",
            PhoneNumber = "+33612345678",
            PostalCodeMatch = PostalCodeMatch.True,
            RegionMatch = RegionMatch.NotAvailable,
            RegionMatchScore = 0,
            RequestID = "01HVE0000000000000000000000",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<KycMatchResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AddressMatch> expectedAddressMatch = AddressMatch.False;
        long expectedAddressMatchScore = 64;
        ApiEnum<string, BirthdateMatch> expectedBirthdateMatch = BirthdateMatch.True;
        string expectedCountryCode = "FR";
        ApiEnum<string, CountryMatch> expectedCountryMatch = CountryMatch.True;
        ApiEnum<string, EmailMatch> expectedEmailMatch = EmailMatch.NotAvailable;
        long expectedEmailMatchScore = 0;
        ApiEnum<string, FamilyNameMatch> expectedFamilyNameMatch = FamilyNameMatch.False;
        long expectedFamilyNameMatchScore = 82;
        ApiEnum<string, GivenNameMatch> expectedGivenNameMatch = GivenNameMatch.True;
        long expectedGivenNameMatchScore = 0;
        ApiEnum<string, LocalityMatch> expectedLocalityMatch = LocalityMatch.True;
        long expectedLocalityMatchScore = 0;
        string expectedOperator = "orange_fr";
        string expectedPhoneNumber = "+33612345678";
        ApiEnum<string, PostalCodeMatch> expectedPostalCodeMatch = PostalCodeMatch.True;
        ApiEnum<string, RegionMatch> expectedRegionMatch = RegionMatch.NotAvailable;
        long expectedRegionMatchScore = 0;
        string expectedRequestID = "01HVE0000000000000000000000";

        Assert.Equal(expectedAddressMatch, deserialized.AddressMatch);
        Assert.Equal(expectedAddressMatchScore, deserialized.AddressMatchScore);
        Assert.Equal(expectedBirthdateMatch, deserialized.BirthdateMatch);
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedCountryMatch, deserialized.CountryMatch);
        Assert.Equal(expectedEmailMatch, deserialized.EmailMatch);
        Assert.Equal(expectedEmailMatchScore, deserialized.EmailMatchScore);
        Assert.Equal(expectedFamilyNameMatch, deserialized.FamilyNameMatch);
        Assert.Equal(expectedFamilyNameMatchScore, deserialized.FamilyNameMatchScore);
        Assert.Equal(expectedGivenNameMatch, deserialized.GivenNameMatch);
        Assert.Equal(expectedGivenNameMatchScore, deserialized.GivenNameMatchScore);
        Assert.Equal(expectedLocalityMatch, deserialized.LocalityMatch);
        Assert.Equal(expectedLocalityMatchScore, deserialized.LocalityMatchScore);
        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedPostalCodeMatch, deserialized.PostalCodeMatch);
        Assert.Equal(expectedRegionMatch, deserialized.RegionMatch);
        Assert.Equal(expectedRegionMatchScore, deserialized.RegionMatchScore);
        Assert.Equal(expectedRequestID, deserialized.RequestID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new KycMatchResponse
        {
            AddressMatch = AddressMatch.False,
            AddressMatchScore = 64,
            BirthdateMatch = BirthdateMatch.True,
            CountryCode = "FR",
            CountryMatch = CountryMatch.True,
            EmailMatch = EmailMatch.NotAvailable,
            EmailMatchScore = 0,
            FamilyNameMatch = FamilyNameMatch.False,
            FamilyNameMatchScore = 82,
            GivenNameMatch = GivenNameMatch.True,
            GivenNameMatchScore = 0,
            LocalityMatch = LocalityMatch.True,
            LocalityMatchScore = 0,
            Operator = "orange_fr",
            PhoneNumber = "+33612345678",
            PostalCodeMatch = PostalCodeMatch.True,
            RegionMatch = RegionMatch.NotAvailable,
            RegionMatchScore = 0,
            RequestID = "01HVE0000000000000000000000",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new KycMatchResponse { };

        Assert.Null(model.AddressMatch);
        Assert.False(model.RawData.ContainsKey("address_match"));
        Assert.Null(model.AddressMatchScore);
        Assert.False(model.RawData.ContainsKey("address_match_score"));
        Assert.Null(model.BirthdateMatch);
        Assert.False(model.RawData.ContainsKey("birthdate_match"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.CountryMatch);
        Assert.False(model.RawData.ContainsKey("country_match"));
        Assert.Null(model.EmailMatch);
        Assert.False(model.RawData.ContainsKey("email_match"));
        Assert.Null(model.EmailMatchScore);
        Assert.False(model.RawData.ContainsKey("email_match_score"));
        Assert.Null(model.FamilyNameMatch);
        Assert.False(model.RawData.ContainsKey("family_name_match"));
        Assert.Null(model.FamilyNameMatchScore);
        Assert.False(model.RawData.ContainsKey("family_name_match_score"));
        Assert.Null(model.GivenNameMatch);
        Assert.False(model.RawData.ContainsKey("given_name_match"));
        Assert.Null(model.GivenNameMatchScore);
        Assert.False(model.RawData.ContainsKey("given_name_match_score"));
        Assert.Null(model.LocalityMatch);
        Assert.False(model.RawData.ContainsKey("locality_match"));
        Assert.Null(model.LocalityMatchScore);
        Assert.False(model.RawData.ContainsKey("locality_match_score"));
        Assert.Null(model.Operator);
        Assert.False(model.RawData.ContainsKey("operator"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
        Assert.Null(model.PostalCodeMatch);
        Assert.False(model.RawData.ContainsKey("postal_code_match"));
        Assert.Null(model.RegionMatch);
        Assert.False(model.RawData.ContainsKey("region_match"));
        Assert.Null(model.RegionMatchScore);
        Assert.False(model.RawData.ContainsKey("region_match_score"));
        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new KycMatchResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new KycMatchResponse
        {
            // Null should be interpreted as omitted for these properties
            AddressMatch = null,
            AddressMatchScore = null,
            BirthdateMatch = null,
            CountryCode = null,
            CountryMatch = null,
            EmailMatch = null,
            EmailMatchScore = null,
            FamilyNameMatch = null,
            FamilyNameMatchScore = null,
            GivenNameMatch = null,
            GivenNameMatchScore = null,
            LocalityMatch = null,
            LocalityMatchScore = null,
            Operator = null,
            PhoneNumber = null,
            PostalCodeMatch = null,
            RegionMatch = null,
            RegionMatchScore = null,
            RequestID = null,
        };

        Assert.Null(model.AddressMatch);
        Assert.False(model.RawData.ContainsKey("address_match"));
        Assert.Null(model.AddressMatchScore);
        Assert.False(model.RawData.ContainsKey("address_match_score"));
        Assert.Null(model.BirthdateMatch);
        Assert.False(model.RawData.ContainsKey("birthdate_match"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.CountryMatch);
        Assert.False(model.RawData.ContainsKey("country_match"));
        Assert.Null(model.EmailMatch);
        Assert.False(model.RawData.ContainsKey("email_match"));
        Assert.Null(model.EmailMatchScore);
        Assert.False(model.RawData.ContainsKey("email_match_score"));
        Assert.Null(model.FamilyNameMatch);
        Assert.False(model.RawData.ContainsKey("family_name_match"));
        Assert.Null(model.FamilyNameMatchScore);
        Assert.False(model.RawData.ContainsKey("family_name_match_score"));
        Assert.Null(model.GivenNameMatch);
        Assert.False(model.RawData.ContainsKey("given_name_match"));
        Assert.Null(model.GivenNameMatchScore);
        Assert.False(model.RawData.ContainsKey("given_name_match_score"));
        Assert.Null(model.LocalityMatch);
        Assert.False(model.RawData.ContainsKey("locality_match"));
        Assert.Null(model.LocalityMatchScore);
        Assert.False(model.RawData.ContainsKey("locality_match_score"));
        Assert.Null(model.Operator);
        Assert.False(model.RawData.ContainsKey("operator"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
        Assert.Null(model.PostalCodeMatch);
        Assert.False(model.RawData.ContainsKey("postal_code_match"));
        Assert.Null(model.RegionMatch);
        Assert.False(model.RawData.ContainsKey("region_match"));
        Assert.Null(model.RegionMatchScore);
        Assert.False(model.RawData.ContainsKey("region_match_score"));
        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new KycMatchResponse
        {
            // Null should be interpreted as omitted for these properties
            AddressMatch = null,
            AddressMatchScore = null,
            BirthdateMatch = null,
            CountryCode = null,
            CountryMatch = null,
            EmailMatch = null,
            EmailMatchScore = null,
            FamilyNameMatch = null,
            FamilyNameMatchScore = null,
            GivenNameMatch = null,
            GivenNameMatchScore = null,
            LocalityMatch = null,
            LocalityMatchScore = null,
            Operator = null,
            PhoneNumber = null,
            PostalCodeMatch = null,
            RegionMatch = null,
            RegionMatchScore = null,
            RequestID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new KycMatchResponse
        {
            AddressMatch = AddressMatch.False,
            AddressMatchScore = 64,
            BirthdateMatch = BirthdateMatch.True,
            CountryCode = "FR",
            CountryMatch = CountryMatch.True,
            EmailMatch = EmailMatch.NotAvailable,
            EmailMatchScore = 0,
            FamilyNameMatch = FamilyNameMatch.False,
            FamilyNameMatchScore = 82,
            GivenNameMatch = GivenNameMatch.True,
            GivenNameMatchScore = 0,
            LocalityMatch = LocalityMatch.True,
            LocalityMatchScore = 0,
            Operator = "orange_fr",
            PhoneNumber = "+33612345678",
            PostalCodeMatch = PostalCodeMatch.True,
            RegionMatch = RegionMatch.NotAvailable,
            RegionMatchScore = 0,
            RequestID = "01HVE0000000000000000000000",
        };

        KycMatchResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddressMatchTest : TestBase
{
    [Theory]
    [InlineData(AddressMatch.True)]
    [InlineData(AddressMatch.False)]
    [InlineData(AddressMatch.NotAvailable)]
    public void Validation_Works(AddressMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddressMatch> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddressMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddressMatch.True)]
    [InlineData(AddressMatch.False)]
    [InlineData(AddressMatch.NotAvailable)]
    public void SerializationRoundtrip_Works(AddressMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddressMatch> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AddressMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddressMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AddressMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BirthdateMatchTest : TestBase
{
    [Theory]
    [InlineData(BirthdateMatch.True)]
    [InlineData(BirthdateMatch.False)]
    [InlineData(BirthdateMatch.NotAvailable)]
    public void Validation_Works(BirthdateMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BirthdateMatch> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BirthdateMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BirthdateMatch.True)]
    [InlineData(BirthdateMatch.False)]
    [InlineData(BirthdateMatch.NotAvailable)]
    public void SerializationRoundtrip_Works(BirthdateMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BirthdateMatch> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BirthdateMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BirthdateMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BirthdateMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CountryMatchTest : TestBase
{
    [Theory]
    [InlineData(CountryMatch.True)]
    [InlineData(CountryMatch.False)]
    [InlineData(CountryMatch.NotAvailable)]
    public void Validation_Works(CountryMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CountryMatch> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CountryMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CountryMatch.True)]
    [InlineData(CountryMatch.False)]
    [InlineData(CountryMatch.NotAvailable)]
    public void SerializationRoundtrip_Works(CountryMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CountryMatch> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CountryMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CountryMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CountryMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EmailMatchTest : TestBase
{
    [Theory]
    [InlineData(EmailMatch.True)]
    [InlineData(EmailMatch.False)]
    [InlineData(EmailMatch.NotAvailable)]
    public void Validation_Works(EmailMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EmailMatch> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EmailMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EmailMatch.True)]
    [InlineData(EmailMatch.False)]
    [InlineData(EmailMatch.NotAvailable)]
    public void SerializationRoundtrip_Works(EmailMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EmailMatch> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EmailMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EmailMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EmailMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FamilyNameMatchTest : TestBase
{
    [Theory]
    [InlineData(FamilyNameMatch.True)]
    [InlineData(FamilyNameMatch.False)]
    [InlineData(FamilyNameMatch.NotAvailable)]
    public void Validation_Works(FamilyNameMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FamilyNameMatch> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FamilyNameMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FamilyNameMatch.True)]
    [InlineData(FamilyNameMatch.False)]
    [InlineData(FamilyNameMatch.NotAvailable)]
    public void SerializationRoundtrip_Works(FamilyNameMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FamilyNameMatch> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FamilyNameMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FamilyNameMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FamilyNameMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GivenNameMatchTest : TestBase
{
    [Theory]
    [InlineData(GivenNameMatch.True)]
    [InlineData(GivenNameMatch.False)]
    [InlineData(GivenNameMatch.NotAvailable)]
    public void Validation_Works(GivenNameMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GivenNameMatch> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GivenNameMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GivenNameMatch.True)]
    [InlineData(GivenNameMatch.False)]
    [InlineData(GivenNameMatch.NotAvailable)]
    public void SerializationRoundtrip_Works(GivenNameMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GivenNameMatch> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GivenNameMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GivenNameMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GivenNameMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class LocalityMatchTest : TestBase
{
    [Theory]
    [InlineData(LocalityMatch.True)]
    [InlineData(LocalityMatch.False)]
    [InlineData(LocalityMatch.NotAvailable)]
    public void Validation_Works(LocalityMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LocalityMatch> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LocalityMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LocalityMatch.True)]
    [InlineData(LocalityMatch.False)]
    [InlineData(LocalityMatch.NotAvailable)]
    public void SerializationRoundtrip_Works(LocalityMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LocalityMatch> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LocalityMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LocalityMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LocalityMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PostalCodeMatchTest : TestBase
{
    [Theory]
    [InlineData(PostalCodeMatch.True)]
    [InlineData(PostalCodeMatch.False)]
    [InlineData(PostalCodeMatch.NotAvailable)]
    public void Validation_Works(PostalCodeMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PostalCodeMatch> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PostalCodeMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PostalCodeMatch.True)]
    [InlineData(PostalCodeMatch.False)]
    [InlineData(PostalCodeMatch.NotAvailable)]
    public void SerializationRoundtrip_Works(PostalCodeMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PostalCodeMatch> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PostalCodeMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PostalCodeMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PostalCodeMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RegionMatchTest : TestBase
{
    [Theory]
    [InlineData(RegionMatch.True)]
    [InlineData(RegionMatch.False)]
    [InlineData(RegionMatch.NotAvailable)]
    public void Validation_Works(RegionMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RegionMatch> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RegionMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RegionMatch.True)]
    [InlineData(RegionMatch.False)]
    [InlineData(RegionMatch.NotAvailable)]
    public void SerializationRoundtrip_Works(RegionMatch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RegionMatch> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RegionMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RegionMatch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RegionMatch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
