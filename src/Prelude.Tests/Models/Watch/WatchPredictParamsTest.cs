using System;
using System.Text.Json;
using Prelude.Core;
using Prelude.Exceptions;
using Watch = Prelude.Models.Watch;

namespace Prelude.Tests.Models.Watch;

public class WatchPredictParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Watch::WatchPredictParams
        {
            Target = new() { Type = Watch::Type.PhoneNumber, Value = "+30123456789" },
            DispatchID = "123e4567-e89b-12d3-a456-426614174000",
            Metadata = new() { CorrelationID = "correlation_id" },
            Signals = new()
            {
                AppVersion = "1.2.34",
                DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
                DeviceModel = "iPhone17,2",
                DevicePlatform = Watch::DevicePlatform.Ios,
                IP = "203.0.113.123",
                IsTrustedUser = false,
                Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
                OsVersion = "18.0.1",
                UserAgent =
                    "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
            },
        };

        Watch::Target expectedTarget = new()
        {
            Type = Watch::Type.PhoneNumber,
            Value = "+30123456789",
        };
        string expectedDispatchID = "123e4567-e89b-12d3-a456-426614174000";
        Watch::Metadata expectedMetadata = new() { CorrelationID = "correlation_id" };
        Watch::Signals expectedSignals = new()
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = Watch::DevicePlatform.Ios,
            IP = "203.0.113.123",
            IsTrustedUser = false,
            Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
            OsVersion = "18.0.1",
            UserAgent =
                "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
        };

        Assert.Equal(expectedTarget, parameters.Target);
        Assert.Equal(expectedDispatchID, parameters.DispatchID);
        Assert.Equal(expectedMetadata, parameters.Metadata);
        Assert.Equal(expectedSignals, parameters.Signals);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Watch::WatchPredictParams
        {
            Target = new() { Type = Watch::Type.PhoneNumber, Value = "+30123456789" },
        };

        Assert.Null(parameters.DispatchID);
        Assert.False(parameters.RawBodyData.ContainsKey("dispatch_id"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Signals);
        Assert.False(parameters.RawBodyData.ContainsKey("signals"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Watch::WatchPredictParams
        {
            Target = new() { Type = Watch::Type.PhoneNumber, Value = "+30123456789" },

            // Null should be interpreted as omitted for these properties
            DispatchID = null,
            Metadata = null,
            Signals = null,
        };

        Assert.Null(parameters.DispatchID);
        Assert.False(parameters.RawBodyData.ContainsKey("dispatch_id"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Signals);
        Assert.False(parameters.RawBodyData.ContainsKey("signals"));
    }

    [Fact]
    public void Url_Works()
    {
        Watch::WatchPredictParams parameters = new()
        {
            Target = new() { Type = Watch::Type.PhoneNumber, Value = "+30123456789" },
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.prelude.dev/v2/watch/predict"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Watch::WatchPredictParams
        {
            Target = new() { Type = Watch::Type.PhoneNumber, Value = "+30123456789" },
            DispatchID = "123e4567-e89b-12d3-a456-426614174000",
            Metadata = new() { CorrelationID = "correlation_id" },
            Signals = new()
            {
                AppVersion = "1.2.34",
                DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
                DeviceModel = "iPhone17,2",
                DevicePlatform = Watch::DevicePlatform.Ios,
                IP = "203.0.113.123",
                IsTrustedUser = false,
                Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
                OsVersion = "18.0.1",
                UserAgent =
                    "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
            },
        };

        Watch::WatchPredictParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TargetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Watch::Target { Type = Watch::Type.PhoneNumber, Value = "+30123456789" };

        ApiEnum<string, Watch::Type> expectedType = Watch::Type.PhoneNumber;
        string expectedValue = "+30123456789";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Watch::Target { Type = Watch::Type.PhoneNumber, Value = "+30123456789" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Watch::Target>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Watch::Target { Type = Watch::Type.PhoneNumber, Value = "+30123456789" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Watch::Target>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Watch::Type> expectedType = Watch::Type.PhoneNumber;
        string expectedValue = "+30123456789";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Watch::Target { Type = Watch::Type.PhoneNumber, Value = "+30123456789" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Watch::Target { Type = Watch::Type.PhoneNumber, Value = "+30123456789" };

        Watch::Target copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Watch::Type.PhoneNumber)]
    [InlineData(Watch::Type.EmailAddress)]
    public void Validation_Works(Watch::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Watch::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Watch::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Watch::Type.PhoneNumber)]
    [InlineData(Watch::Type.EmailAddress)]
    public void SerializationRoundtrip_Works(Watch::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Watch::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Watch::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Watch::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Watch::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Watch::Metadata { CorrelationID = "correlation_id" };

        string expectedCorrelationID = "correlation_id";

        Assert.Equal(expectedCorrelationID, model.CorrelationID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Watch::Metadata { CorrelationID = "correlation_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Watch::Metadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Watch::Metadata { CorrelationID = "correlation_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Watch::Metadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCorrelationID = "correlation_id";

        Assert.Equal(expectedCorrelationID, deserialized.CorrelationID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Watch::Metadata { CorrelationID = "correlation_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Watch::Metadata { };

        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Watch::Metadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Watch::Metadata
        {
            // Null should be interpreted as omitted for these properties
            CorrelationID = null,
        };

        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Watch::Metadata
        {
            // Null should be interpreted as omitted for these properties
            CorrelationID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Watch::Metadata { CorrelationID = "correlation_id" };

        Watch::Metadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SignalsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Watch::Signals
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = Watch::DevicePlatform.Ios,
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
        ApiEnum<string, Watch::DevicePlatform> expectedDevicePlatform = Watch::DevicePlatform.Ios;
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
        Assert.Equal(expectedIP, model.IP);
        Assert.Equal(expectedIsTrustedUser, model.IsTrustedUser);
        Assert.Equal(expectedJa4Fingerprint, model.Ja4Fingerprint);
        Assert.Equal(expectedOsVersion, model.OsVersion);
        Assert.Equal(expectedUserAgent, model.UserAgent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Watch::Signals
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = Watch::DevicePlatform.Ios,
            IP = "203.0.113.123",
            IsTrustedUser = false,
            Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
            OsVersion = "18.0.1",
            UserAgent =
                "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Watch::Signals>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Watch::Signals
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = Watch::DevicePlatform.Ios,
            IP = "203.0.113.123",
            IsTrustedUser = false,
            Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
            OsVersion = "18.0.1",
            UserAgent =
                "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Watch::Signals>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAppVersion = "1.2.34";
        string expectedDeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2";
        string expectedDeviceModel = "iPhone17,2";
        ApiEnum<string, Watch::DevicePlatform> expectedDevicePlatform = Watch::DevicePlatform.Ios;
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
        Assert.Equal(expectedIP, deserialized.IP);
        Assert.Equal(expectedIsTrustedUser, deserialized.IsTrustedUser);
        Assert.Equal(expectedJa4Fingerprint, deserialized.Ja4Fingerprint);
        Assert.Equal(expectedOsVersion, deserialized.OsVersion);
        Assert.Equal(expectedUserAgent, deserialized.UserAgent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Watch::Signals
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = Watch::DevicePlatform.Ios,
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
        var model = new Watch::Signals { };

        Assert.Null(model.AppVersion);
        Assert.False(model.RawData.ContainsKey("app_version"));
        Assert.Null(model.DeviceID);
        Assert.False(model.RawData.ContainsKey("device_id"));
        Assert.Null(model.DeviceModel);
        Assert.False(model.RawData.ContainsKey("device_model"));
        Assert.Null(model.DevicePlatform);
        Assert.False(model.RawData.ContainsKey("device_platform"));
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
        var model = new Watch::Signals { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Watch::Signals
        {
            // Null should be interpreted as omitted for these properties
            AppVersion = null,
            DeviceID = null,
            DeviceModel = null,
            DevicePlatform = null,
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
        var model = new Watch::Signals
        {
            // Null should be interpreted as omitted for these properties
            AppVersion = null,
            DeviceID = null,
            DeviceModel = null,
            DevicePlatform = null,
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
        var model = new Watch::Signals
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = Watch::DevicePlatform.Ios,
            IP = "203.0.113.123",
            IsTrustedUser = false,
            Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
            OsVersion = "18.0.1",
            UserAgent =
                "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
        };

        Watch::Signals copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DevicePlatformTest : TestBase
{
    [Theory]
    [InlineData(Watch::DevicePlatform.Android)]
    [InlineData(Watch::DevicePlatform.Ios)]
    [InlineData(Watch::DevicePlatform.Ipados)]
    [InlineData(Watch::DevicePlatform.Tvos)]
    [InlineData(Watch::DevicePlatform.Web)]
    public void Validation_Works(Watch::DevicePlatform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Watch::DevicePlatform> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Watch::DevicePlatform>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Watch::DevicePlatform.Android)]
    [InlineData(Watch::DevicePlatform.Ios)]
    [InlineData(Watch::DevicePlatform.Ipados)]
    [InlineData(Watch::DevicePlatform.Tvos)]
    [InlineData(Watch::DevicePlatform.Web)]
    public void SerializationRoundtrip_Works(Watch::DevicePlatform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Watch::DevicePlatform> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Watch::DevicePlatform>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Watch::DevicePlatform>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Watch::DevicePlatform>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
