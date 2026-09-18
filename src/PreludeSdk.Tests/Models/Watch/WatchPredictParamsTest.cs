using System;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Models.Watch;
using Models = PreludeSdk.Models;

namespace PreludeSdk.Tests.Models.Watch;

public class WatchPredictParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WatchPredictParams
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
            DispatchID = "123e4567-e89b-12d3-a456-426614174000",
            Metadata = new() { CorrelationID = "correlation_id" },
            Signals = new()
            {
                AppVersion = "1.2.34",
                DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
                DeviceModel = "iPhone17,2",
                DevicePlatform = Models::DevicePlatform.Ios,
                ExistingUser = false,
                IP = "203.0.113.123",
                IsTrustedUser = false,
                Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
                OsVersion = "18.0.1",
                UserAgent =
                    "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
            },
        };

        Models::Target expectedTarget = new()
        {
            Type = Models::Type.PhoneNumber,
            Value = "+30123456789",
        };
        string expectedDispatchID = "123e4567-e89b-12d3-a456-426614174000";
        Metadata expectedMetadata = new() { CorrelationID = "correlation_id" };
        Models::Signals expectedSignals = new()
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = Models::DevicePlatform.Ios,
            ExistingUser = false,
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
        var parameters = new WatchPredictParams
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
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
        var parameters = new WatchPredictParams
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },

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
        WatchPredictParams parameters = new()
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.prelude.dev/v2/watch/predict"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WatchPredictParams
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
            DispatchID = "123e4567-e89b-12d3-a456-426614174000",
            Metadata = new() { CorrelationID = "correlation_id" },
            Signals = new()
            {
                AppVersion = "1.2.34",
                DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
                DeviceModel = "iPhone17,2",
                DevicePlatform = Models::DevicePlatform.Ios,
                ExistingUser = false,
                IP = "203.0.113.123",
                IsTrustedUser = false,
                Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
                OsVersion = "18.0.1",
                UserAgent =
                    "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
            },
        };

        WatchPredictParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class MetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Metadata { CorrelationID = "correlation_id" };

        string expectedCorrelationID = "correlation_id";

        Assert.Equal(expectedCorrelationID, model.CorrelationID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Metadata { CorrelationID = "correlation_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Metadata { CorrelationID = "correlation_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(
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
        var model = new Metadata { CorrelationID = "correlation_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Metadata { };

        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Metadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Metadata
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
        var model = new Metadata
        {
            // Null should be interpreted as omitted for these properties
            CorrelationID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Metadata { CorrelationID = "correlation_id" };

        Metadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
