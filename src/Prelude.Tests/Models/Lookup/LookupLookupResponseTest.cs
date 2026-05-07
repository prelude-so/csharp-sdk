using System.Collections.Generic;
using System.Text.Json;
using Prelude.Core;
using Prelude.Exceptions;
using Prelude.Models.Lookup;

namespace Prelude.Tests.Models.Lookup;

public class LookupLookupResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LookupLookupResponse
        {
            CallerName = "FINN",
            CountryCode = "FR",
            Flags = [Flag.Ported],
            LineType = LineType.Mobile,
            NetworkInfo = new()
            {
                CarrierName = "SFR",
                Mcc = "208",
                Mnc = "13",
            },
            OriginalNetworkInfo = new()
            {
                CarrierName = "Orange",
                Mcc = "208",
                Mnc = "13",
            },
            PhoneNumber = "+33**********",
        };

        string expectedCallerName = "FINN";
        string expectedCountryCode = "FR";
        List<ApiEnum<string, Flag>> expectedFlags = [Flag.Ported];
        ApiEnum<string, LineType> expectedLineType = LineType.Mobile;
        NetworkInfo expectedNetworkInfo = new()
        {
            CarrierName = "SFR",
            Mcc = "208",
            Mnc = "13",
        };
        OriginalNetworkInfo expectedOriginalNetworkInfo = new()
        {
            CarrierName = "Orange",
            Mcc = "208",
            Mnc = "13",
        };
        string expectedPhoneNumber = "+33**********";

        Assert.Equal(expectedCallerName, model.CallerName);
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.NotNull(model.Flags);
        Assert.Equal(expectedFlags.Count, model.Flags.Count);
        for (int i = 0; i < expectedFlags.Count; i++)
        {
            Assert.Equal(expectedFlags[i], model.Flags[i]);
        }
        Assert.Equal(expectedLineType, model.LineType);
        Assert.Equal(expectedNetworkInfo, model.NetworkInfo);
        Assert.Equal(expectedOriginalNetworkInfo, model.OriginalNetworkInfo);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LookupLookupResponse
        {
            CallerName = "FINN",
            CountryCode = "FR",
            Flags = [Flag.Ported],
            LineType = LineType.Mobile,
            NetworkInfo = new()
            {
                CarrierName = "SFR",
                Mcc = "208",
                Mnc = "13",
            },
            OriginalNetworkInfo = new()
            {
                CarrierName = "Orange",
                Mcc = "208",
                Mnc = "13",
            },
            PhoneNumber = "+33**********",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LookupLookupResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LookupLookupResponse
        {
            CallerName = "FINN",
            CountryCode = "FR",
            Flags = [Flag.Ported],
            LineType = LineType.Mobile,
            NetworkInfo = new()
            {
                CarrierName = "SFR",
                Mcc = "208",
                Mnc = "13",
            },
            OriginalNetworkInfo = new()
            {
                CarrierName = "Orange",
                Mcc = "208",
                Mnc = "13",
            },
            PhoneNumber = "+33**********",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LookupLookupResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCallerName = "FINN";
        string expectedCountryCode = "FR";
        List<ApiEnum<string, Flag>> expectedFlags = [Flag.Ported];
        ApiEnum<string, LineType> expectedLineType = LineType.Mobile;
        NetworkInfo expectedNetworkInfo = new()
        {
            CarrierName = "SFR",
            Mcc = "208",
            Mnc = "13",
        };
        OriginalNetworkInfo expectedOriginalNetworkInfo = new()
        {
            CarrierName = "Orange",
            Mcc = "208",
            Mnc = "13",
        };
        string expectedPhoneNumber = "+33**********";

        Assert.Equal(expectedCallerName, deserialized.CallerName);
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.NotNull(deserialized.Flags);
        Assert.Equal(expectedFlags.Count, deserialized.Flags.Count);
        for (int i = 0; i < expectedFlags.Count; i++)
        {
            Assert.Equal(expectedFlags[i], deserialized.Flags[i]);
        }
        Assert.Equal(expectedLineType, deserialized.LineType);
        Assert.Equal(expectedNetworkInfo, deserialized.NetworkInfo);
        Assert.Equal(expectedOriginalNetworkInfo, deserialized.OriginalNetworkInfo);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LookupLookupResponse
        {
            CallerName = "FINN",
            CountryCode = "FR",
            Flags = [Flag.Ported],
            LineType = LineType.Mobile,
            NetworkInfo = new()
            {
                CarrierName = "SFR",
                Mcc = "208",
                Mnc = "13",
            },
            OriginalNetworkInfo = new()
            {
                CarrierName = "Orange",
                Mcc = "208",
                Mnc = "13",
            },
            PhoneNumber = "+33**********",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LookupLookupResponse { };

        Assert.Null(model.CallerName);
        Assert.False(model.RawData.ContainsKey("caller_name"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.Flags);
        Assert.False(model.RawData.ContainsKey("flags"));
        Assert.Null(model.LineType);
        Assert.False(model.RawData.ContainsKey("line_type"));
        Assert.Null(model.NetworkInfo);
        Assert.False(model.RawData.ContainsKey("network_info"));
        Assert.Null(model.OriginalNetworkInfo);
        Assert.False(model.RawData.ContainsKey("original_network_info"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new LookupLookupResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new LookupLookupResponse
        {
            // Null should be interpreted as omitted for these properties
            CallerName = null,
            CountryCode = null,
            Flags = null,
            LineType = null,
            NetworkInfo = null,
            OriginalNetworkInfo = null,
            PhoneNumber = null,
        };

        Assert.Null(model.CallerName);
        Assert.False(model.RawData.ContainsKey("caller_name"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.Flags);
        Assert.False(model.RawData.ContainsKey("flags"));
        Assert.Null(model.LineType);
        Assert.False(model.RawData.ContainsKey("line_type"));
        Assert.Null(model.NetworkInfo);
        Assert.False(model.RawData.ContainsKey("network_info"));
        Assert.Null(model.OriginalNetworkInfo);
        Assert.False(model.RawData.ContainsKey("original_network_info"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LookupLookupResponse
        {
            // Null should be interpreted as omitted for these properties
            CallerName = null,
            CountryCode = null,
            Flags = null,
            LineType = null,
            NetworkInfo = null,
            OriginalNetworkInfo = null,
            PhoneNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LookupLookupResponse
        {
            CallerName = "FINN",
            CountryCode = "FR",
            Flags = [Flag.Ported],
            LineType = LineType.Mobile,
            NetworkInfo = new()
            {
                CarrierName = "SFR",
                Mcc = "208",
                Mnc = "13",
            },
            OriginalNetworkInfo = new()
            {
                CarrierName = "Orange",
                Mcc = "208",
                Mnc = "13",
            },
            PhoneNumber = "+33**********",
        };

        LookupLookupResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FlagTest : TestBase
{
    [Theory]
    [InlineData(Flag.Ported)]
    [InlineData(Flag.Temporary)]
    public void Validation_Works(Flag rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Flag> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Flag>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Flag.Ported)]
    [InlineData(Flag.Temporary)]
    public void SerializationRoundtrip_Works(Flag rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Flag> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Flag>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Flag>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Flag>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class LineTypeTest : TestBase
{
    [Theory]
    [InlineData(LineType.CallingCards)]
    [InlineData(LineType.FixedLine)]
    [InlineData(LineType.Isp)]
    [InlineData(LineType.LocalRate)]
    [InlineData(LineType.Mobile)]
    [InlineData(LineType.Other)]
    [InlineData(LineType.Pager)]
    [InlineData(LineType.Payphone)]
    [InlineData(LineType.PremiumRate)]
    [InlineData(LineType.Satellite)]
    [InlineData(LineType.Service)]
    [InlineData(LineType.SharedCost)]
    [InlineData(LineType.ShortCodesCommercial)]
    [InlineData(LineType.TollFree)]
    [InlineData(LineType.UniversalAccess)]
    [InlineData(LineType.Unknown)]
    [InlineData(LineType.Vpn)]
    [InlineData(LineType.VoiceMail)]
    [InlineData(LineType.Voip)]
    public void Validation_Works(LineType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LineType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LineType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LineType.CallingCards)]
    [InlineData(LineType.FixedLine)]
    [InlineData(LineType.Isp)]
    [InlineData(LineType.LocalRate)]
    [InlineData(LineType.Mobile)]
    [InlineData(LineType.Other)]
    [InlineData(LineType.Pager)]
    [InlineData(LineType.Payphone)]
    [InlineData(LineType.PremiumRate)]
    [InlineData(LineType.Satellite)]
    [InlineData(LineType.Service)]
    [InlineData(LineType.SharedCost)]
    [InlineData(LineType.ShortCodesCommercial)]
    [InlineData(LineType.TollFree)]
    [InlineData(LineType.UniversalAccess)]
    [InlineData(LineType.Unknown)]
    [InlineData(LineType.Vpn)]
    [InlineData(LineType.VoiceMail)]
    [InlineData(LineType.Voip)]
    public void SerializationRoundtrip_Works(LineType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LineType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LineType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LineType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LineType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NetworkInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NetworkInfo
        {
            CarrierName = "SFR",
            Mcc = "208",
            Mnc = "13",
        };

        string expectedCarrierName = "SFR";
        string expectedMcc = "208";
        string expectedMnc = "13";

        Assert.Equal(expectedCarrierName, model.CarrierName);
        Assert.Equal(expectedMcc, model.Mcc);
        Assert.Equal(expectedMnc, model.Mnc);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NetworkInfo
        {
            CarrierName = "SFR",
            Mcc = "208",
            Mnc = "13",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NetworkInfo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NetworkInfo
        {
            CarrierName = "SFR",
            Mcc = "208",
            Mnc = "13",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NetworkInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCarrierName = "SFR";
        string expectedMcc = "208";
        string expectedMnc = "13";

        Assert.Equal(expectedCarrierName, deserialized.CarrierName);
        Assert.Equal(expectedMcc, deserialized.Mcc);
        Assert.Equal(expectedMnc, deserialized.Mnc);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NetworkInfo
        {
            CarrierName = "SFR",
            Mcc = "208",
            Mnc = "13",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NetworkInfo { };

        Assert.Null(model.CarrierName);
        Assert.False(model.RawData.ContainsKey("carrier_name"));
        Assert.Null(model.Mcc);
        Assert.False(model.RawData.ContainsKey("mcc"));
        Assert.Null(model.Mnc);
        Assert.False(model.RawData.ContainsKey("mnc"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NetworkInfo { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NetworkInfo
        {
            // Null should be interpreted as omitted for these properties
            CarrierName = null,
            Mcc = null,
            Mnc = null,
        };

        Assert.Null(model.CarrierName);
        Assert.False(model.RawData.ContainsKey("carrier_name"));
        Assert.Null(model.Mcc);
        Assert.False(model.RawData.ContainsKey("mcc"));
        Assert.Null(model.Mnc);
        Assert.False(model.RawData.ContainsKey("mnc"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NetworkInfo
        {
            // Null should be interpreted as omitted for these properties
            CarrierName = null,
            Mcc = null,
            Mnc = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NetworkInfo
        {
            CarrierName = "SFR",
            Mcc = "208",
            Mnc = "13",
        };

        NetworkInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginalNetworkInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OriginalNetworkInfo
        {
            CarrierName = "Orange",
            Mcc = "208",
            Mnc = "13",
        };

        string expectedCarrierName = "Orange";
        string expectedMcc = "208";
        string expectedMnc = "13";

        Assert.Equal(expectedCarrierName, model.CarrierName);
        Assert.Equal(expectedMcc, model.Mcc);
        Assert.Equal(expectedMnc, model.Mnc);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OriginalNetworkInfo
        {
            CarrierName = "Orange",
            Mcc = "208",
            Mnc = "13",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginalNetworkInfo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OriginalNetworkInfo
        {
            CarrierName = "Orange",
            Mcc = "208",
            Mnc = "13",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginalNetworkInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCarrierName = "Orange";
        string expectedMcc = "208";
        string expectedMnc = "13";

        Assert.Equal(expectedCarrierName, deserialized.CarrierName);
        Assert.Equal(expectedMcc, deserialized.Mcc);
        Assert.Equal(expectedMnc, deserialized.Mnc);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OriginalNetworkInfo
        {
            CarrierName = "Orange",
            Mcc = "208",
            Mnc = "13",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OriginalNetworkInfo { };

        Assert.Null(model.CarrierName);
        Assert.False(model.RawData.ContainsKey("carrier_name"));
        Assert.Null(model.Mcc);
        Assert.False(model.RawData.ContainsKey("mcc"));
        Assert.Null(model.Mnc);
        Assert.False(model.RawData.ContainsKey("mnc"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OriginalNetworkInfo { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OriginalNetworkInfo
        {
            // Null should be interpreted as omitted for these properties
            CarrierName = null,
            Mcc = null,
            Mnc = null,
        };

        Assert.Null(model.CarrierName);
        Assert.False(model.RawData.ContainsKey("carrier_name"));
        Assert.Null(model.Mcc);
        Assert.False(model.RawData.ContainsKey("mcc"));
        Assert.Null(model.Mnc);
        Assert.False(model.RawData.ContainsKey("mnc"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OriginalNetworkInfo
        {
            // Null should be interpreted as omitted for these properties
            CarrierName = null,
            Mcc = null,
            Mnc = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OriginalNetworkInfo
        {
            CarrierName = "Orange",
            Mcc = "208",
            Mnc = "13",
        };

        OriginalNetworkInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}
