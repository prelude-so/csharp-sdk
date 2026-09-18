using System;
using PreludeSdk.Models.Intel.Kyc;

namespace PreludeSdk.Tests.Models.Intel.Kyc;

public class KycMatchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new KycMatchParams
        {
            Phone = "+12065550100",
            Address = "12 rue de la Paix",
            Birthdate = "1990-01-15",
            Country = "FR",
            Email = "jean.dupont@example.com",
            FamilyName = "Dupont",
            GivenName = "Jean",
            Locality = "Paris",
            PostalCode = "75002",
            Region = "Île-de-France",
        };

        string expectedPhone = "+12065550100";
        string expectedAddress = "12 rue de la Paix";
        string expectedBirthdate = "1990-01-15";
        string expectedCountry = "FR";
        string expectedEmail = "jean.dupont@example.com";
        string expectedFamilyName = "Dupont";
        string expectedGivenName = "Jean";
        string expectedLocality = "Paris";
        string expectedPostalCode = "75002";
        string expectedRegion = "Île-de-France";

        Assert.Equal(expectedPhone, parameters.Phone);
        Assert.Equal(expectedAddress, parameters.Address);
        Assert.Equal(expectedBirthdate, parameters.Birthdate);
        Assert.Equal(expectedCountry, parameters.Country);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedFamilyName, parameters.FamilyName);
        Assert.Equal(expectedGivenName, parameters.GivenName);
        Assert.Equal(expectedLocality, parameters.Locality);
        Assert.Equal(expectedPostalCode, parameters.PostalCode);
        Assert.Equal(expectedRegion, parameters.Region);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new KycMatchParams { Phone = "+12065550100" };

        Assert.Null(parameters.Address);
        Assert.False(parameters.RawBodyData.ContainsKey("address"));
        Assert.Null(parameters.Birthdate);
        Assert.False(parameters.RawBodyData.ContainsKey("birthdate"));
        Assert.Null(parameters.Country);
        Assert.False(parameters.RawBodyData.ContainsKey("country"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.FamilyName);
        Assert.False(parameters.RawBodyData.ContainsKey("family_name"));
        Assert.Null(parameters.GivenName);
        Assert.False(parameters.RawBodyData.ContainsKey("given_name"));
        Assert.Null(parameters.Locality);
        Assert.False(parameters.RawBodyData.ContainsKey("locality"));
        Assert.Null(parameters.PostalCode);
        Assert.False(parameters.RawBodyData.ContainsKey("postal_code"));
        Assert.Null(parameters.Region);
        Assert.False(parameters.RawBodyData.ContainsKey("region"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new KycMatchParams
        {
            Phone = "+12065550100",

            // Null should be interpreted as omitted for these properties
            Address = null,
            Birthdate = null,
            Country = null,
            Email = null,
            FamilyName = null,
            GivenName = null,
            Locality = null,
            PostalCode = null,
            Region = null,
        };

        Assert.Null(parameters.Address);
        Assert.False(parameters.RawBodyData.ContainsKey("address"));
        Assert.Null(parameters.Birthdate);
        Assert.False(parameters.RawBodyData.ContainsKey("birthdate"));
        Assert.Null(parameters.Country);
        Assert.False(parameters.RawBodyData.ContainsKey("country"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.FamilyName);
        Assert.False(parameters.RawBodyData.ContainsKey("family_name"));
        Assert.Null(parameters.GivenName);
        Assert.False(parameters.RawBodyData.ContainsKey("given_name"));
        Assert.Null(parameters.Locality);
        Assert.False(parameters.RawBodyData.ContainsKey("locality"));
        Assert.Null(parameters.PostalCode);
        Assert.False(parameters.RawBodyData.ContainsKey("postal_code"));
        Assert.Null(parameters.Region);
        Assert.False(parameters.RawBodyData.ContainsKey("region"));
    }

    [Fact]
    public void Url_Works()
    {
        KycMatchParams parameters = new() { Phone = "+12065550100" };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.prelude.dev/v2/intel/kyc/match/+12065550100"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new KycMatchParams
        {
            Phone = "+12065550100",
            Address = "12 rue de la Paix",
            Birthdate = "1990-01-15",
            Country = "FR",
            Email = "jean.dupont@example.com",
            FamilyName = "Dupont",
            GivenName = "Jean",
            Locality = "Paris",
            PostalCode = "75002",
            Region = "Île-de-France",
        };

        KycMatchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
