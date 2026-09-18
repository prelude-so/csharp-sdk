using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models;

namespace PreludeSdk.Tests.Models;

public class SignalsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Signals
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = DevicePlatform.Ios,
            ExistingUser = false,
            IP = "203.0.113.123",
            IsTrustedUser = false,
            Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
            OsVersion = "18.0.1",
            UserAgent =
                "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
        };

        string expectedAppVersion = "1.2.34";
        string expectedDeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2";
        string expectedDeviceModel = "iPhone17,2";
        ApiEnum<string, DevicePlatform> expectedDevicePlatform = DevicePlatform.Ios;
        bool expectedExistingUser = false;
        string expectedIP = "203.0.113.123";
        bool expectedIsTrustedUser = false;
        string expectedJa4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1";
        string expectedOsVersion = "18.0.1";
        string expectedUserAgent =
            "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1";

        Assert.Equal(expectedAppVersion, model.AppVersion);
        Assert.Equal(expectedDeviceID, model.DeviceID);
        Assert.Equal(expectedDeviceModel, model.DeviceModel);
        Assert.Equal(expectedDevicePlatform, model.DevicePlatform);
        Assert.Equal(expectedExistingUser, model.ExistingUser);
        Assert.Equal(expectedIP, model.IP);
        Assert.Equal(expectedIsTrustedUser, model.IsTrustedUser);
        Assert.Equal(expectedJa4Fingerprint, model.Ja4Fingerprint);
        Assert.Equal(expectedOsVersion, model.OsVersion);
        Assert.Equal(expectedUserAgent, model.UserAgent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Signals
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = DevicePlatform.Ios,
            ExistingUser = false,
            IP = "203.0.113.123",
            IsTrustedUser = false,
            Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
            OsVersion = "18.0.1",
            UserAgent =
                "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Signals>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Signals
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = DevicePlatform.Ios,
            ExistingUser = false,
            IP = "203.0.113.123",
            IsTrustedUser = false,
            Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
            OsVersion = "18.0.1",
            UserAgent =
                "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Signals>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAppVersion = "1.2.34";
        string expectedDeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2";
        string expectedDeviceModel = "iPhone17,2";
        ApiEnum<string, DevicePlatform> expectedDevicePlatform = DevicePlatform.Ios;
        bool expectedExistingUser = false;
        string expectedIP = "203.0.113.123";
        bool expectedIsTrustedUser = false;
        string expectedJa4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1";
        string expectedOsVersion = "18.0.1";
        string expectedUserAgent =
            "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1";

        Assert.Equal(expectedAppVersion, deserialized.AppVersion);
        Assert.Equal(expectedDeviceID, deserialized.DeviceID);
        Assert.Equal(expectedDeviceModel, deserialized.DeviceModel);
        Assert.Equal(expectedDevicePlatform, deserialized.DevicePlatform);
        Assert.Equal(expectedExistingUser, deserialized.ExistingUser);
        Assert.Equal(expectedIP, deserialized.IP);
        Assert.Equal(expectedIsTrustedUser, deserialized.IsTrustedUser);
        Assert.Equal(expectedJa4Fingerprint, deserialized.Ja4Fingerprint);
        Assert.Equal(expectedOsVersion, deserialized.OsVersion);
        Assert.Equal(expectedUserAgent, deserialized.UserAgent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Signals
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = DevicePlatform.Ios,
            ExistingUser = false,
            IP = "203.0.113.123",
            IsTrustedUser = false,
            Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
            OsVersion = "18.0.1",
            UserAgent =
                "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Signals { };

        Assert.Null(model.AppVersion);
        Assert.False(model.RawData.ContainsKey("app_version"));
        Assert.Null(model.DeviceID);
        Assert.False(model.RawData.ContainsKey("device_id"));
        Assert.Null(model.DeviceModel);
        Assert.False(model.RawData.ContainsKey("device_model"));
        Assert.Null(model.DevicePlatform);
        Assert.False(model.RawData.ContainsKey("device_platform"));
        Assert.Null(model.ExistingUser);
        Assert.False(model.RawData.ContainsKey("existing_user"));
        Assert.Null(model.IP);
        Assert.False(model.RawData.ContainsKey("ip"));
        Assert.Null(model.IsTrustedUser);
        Assert.False(model.RawData.ContainsKey("is_trusted_user"));
        Assert.Null(model.Ja4Fingerprint);
        Assert.False(model.RawData.ContainsKey("ja4_fingerprint"));
        Assert.Null(model.OsVersion);
        Assert.False(model.RawData.ContainsKey("os_version"));
        Assert.Null(model.UserAgent);
        Assert.False(model.RawData.ContainsKey("user_agent"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Signals { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Signals
        {
            // Null should be interpreted as omitted for these properties
            AppVersion = null,
            DeviceID = null,
            DeviceModel = null,
            DevicePlatform = null,
            ExistingUser = null,
            IP = null,
            IsTrustedUser = null,
            Ja4Fingerprint = null,
            OsVersion = null,
            UserAgent = null,
        };

        Assert.Null(model.AppVersion);
        Assert.False(model.RawData.ContainsKey("app_version"));
        Assert.Null(model.DeviceID);
        Assert.False(model.RawData.ContainsKey("device_id"));
        Assert.Null(model.DeviceModel);
        Assert.False(model.RawData.ContainsKey("device_model"));
        Assert.Null(model.DevicePlatform);
        Assert.False(model.RawData.ContainsKey("device_platform"));
        Assert.Null(model.ExistingUser);
        Assert.False(model.RawData.ContainsKey("existing_user"));
        Assert.Null(model.IP);
        Assert.False(model.RawData.ContainsKey("ip"));
        Assert.Null(model.IsTrustedUser);
        Assert.False(model.RawData.ContainsKey("is_trusted_user"));
        Assert.Null(model.Ja4Fingerprint);
        Assert.False(model.RawData.ContainsKey("ja4_fingerprint"));
        Assert.Null(model.OsVersion);
        Assert.False(model.RawData.ContainsKey("os_version"));
        Assert.Null(model.UserAgent);
        Assert.False(model.RawData.ContainsKey("user_agent"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Signals
        {
            // Null should be interpreted as omitted for these properties
            AppVersion = null,
            DeviceID = null,
            DeviceModel = null,
            DevicePlatform = null,
            ExistingUser = null,
            IP = null,
            IsTrustedUser = null,
            Ja4Fingerprint = null,
            OsVersion = null,
            UserAgent = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Signals
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = DevicePlatform.Ios,
            ExistingUser = false,
            IP = "203.0.113.123",
            IsTrustedUser = false,
            Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
            OsVersion = "18.0.1",
            UserAgent =
                "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
        };

        Signals copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DevicePlatformTest : TestBase
{
    [Theory]
    [InlineData(DevicePlatform.Android)]
    [InlineData(DevicePlatform.Ios)]
    [InlineData(DevicePlatform.Ipados)]
    [InlineData(DevicePlatform.Tvos)]
    [InlineData(DevicePlatform.Web)]
    public void Validation_Works(DevicePlatform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DevicePlatform> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DevicePlatform>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DevicePlatform.Android)]
    [InlineData(DevicePlatform.Ios)]
    [InlineData(DevicePlatform.Ipados)]
    [InlineData(DevicePlatform.Tvos)]
    [InlineData(DevicePlatform.Web)]
    public void SerializationRoundtrip_Works(DevicePlatform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DevicePlatform> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DevicePlatform>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DevicePlatform>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DevicePlatform>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
