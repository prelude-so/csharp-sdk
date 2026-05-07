using System.Collections.Generic;
using System.Text.Json;
using Prelude.Core;
using Prelude.Exceptions;
using Prelude.Models.Watch;

namespace Prelude.Tests.Models.Watch;

public class WatchPredictResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WatchPredictResponse
        {
            ID = "prd_01jc0t6fwwfgfsq1md24mhyztj",
            Prediction = Prediction.Legitimate,
            RequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a",
            RiskFactors = [RiskFactor.SuspiciousIPAddress, RiskFactor.FraudDatabase],
        };

        string expectedID = "prd_01jc0t6fwwfgfsq1md24mhyztj";
        ApiEnum<string, Prediction> expectedPrediction = Prediction.Legitimate;
        string expectedRequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a";
        List<ApiEnum<string, RiskFactor>> expectedRiskFactors =
        [
            RiskFactor.SuspiciousIPAddress,
            RiskFactor.FraudDatabase,
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedPrediction, model.Prediction);
        Assert.Equal(expectedRequestID, model.RequestID);
        Assert.NotNull(model.RiskFactors);
        Assert.Equal(expectedRiskFactors.Count, model.RiskFactors.Count);
        for (int i = 0; i < expectedRiskFactors.Count; i++)
        {
            Assert.Equal(expectedRiskFactors[i], model.RiskFactors[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WatchPredictResponse
        {
            ID = "prd_01jc0t6fwwfgfsq1md24mhyztj",
            Prediction = Prediction.Legitimate,
            RequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a",
            RiskFactors = [RiskFactor.SuspiciousIPAddress, RiskFactor.FraudDatabase],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WatchPredictResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WatchPredictResponse
        {
            ID = "prd_01jc0t6fwwfgfsq1md24mhyztj",
            Prediction = Prediction.Legitimate,
            RequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a",
            RiskFactors = [RiskFactor.SuspiciousIPAddress, RiskFactor.FraudDatabase],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WatchPredictResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "prd_01jc0t6fwwfgfsq1md24mhyztj";
        ApiEnum<string, Prediction> expectedPrediction = Prediction.Legitimate;
        string expectedRequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a";
        List<ApiEnum<string, RiskFactor>> expectedRiskFactors =
        [
            RiskFactor.SuspiciousIPAddress,
            RiskFactor.FraudDatabase,
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedPrediction, deserialized.Prediction);
        Assert.Equal(expectedRequestID, deserialized.RequestID);
        Assert.NotNull(deserialized.RiskFactors);
        Assert.Equal(expectedRiskFactors.Count, deserialized.RiskFactors.Count);
        for (int i = 0; i < expectedRiskFactors.Count; i++)
        {
            Assert.Equal(expectedRiskFactors[i], deserialized.RiskFactors[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WatchPredictResponse
        {
            ID = "prd_01jc0t6fwwfgfsq1md24mhyztj",
            Prediction = Prediction.Legitimate,
            RequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a",
            RiskFactors = [RiskFactor.SuspiciousIPAddress, RiskFactor.FraudDatabase],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WatchPredictResponse
        {
            ID = "prd_01jc0t6fwwfgfsq1md24mhyztj",
            Prediction = Prediction.Legitimate,
            RequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a",
        };

        Assert.Null(model.RiskFactors);
        Assert.False(model.RawData.ContainsKey("risk_factors"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WatchPredictResponse
        {
            ID = "prd_01jc0t6fwwfgfsq1md24mhyztj",
            Prediction = Prediction.Legitimate,
            RequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WatchPredictResponse
        {
            ID = "prd_01jc0t6fwwfgfsq1md24mhyztj",
            Prediction = Prediction.Legitimate,
            RequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a",

            // Null should be interpreted as omitted for these properties
            RiskFactors = null,
        };

        Assert.Null(model.RiskFactors);
        Assert.False(model.RawData.ContainsKey("risk_factors"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WatchPredictResponse
        {
            ID = "prd_01jc0t6fwwfgfsq1md24mhyztj",
            Prediction = Prediction.Legitimate,
            RequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a",

            // Null should be interpreted as omitted for these properties
            RiskFactors = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WatchPredictResponse
        {
            ID = "prd_01jc0t6fwwfgfsq1md24mhyztj",
            Prediction = Prediction.Legitimate,
            RequestID = "3d19215e-2991-4a05-a41a-527314e6ff6a",
            RiskFactors = [RiskFactor.SuspiciousIPAddress, RiskFactor.FraudDatabase],
        };

        WatchPredictResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PredictionTest : TestBase
{
    [Theory]
    [InlineData(Prediction.Legitimate)]
    [InlineData(Prediction.Suspicious)]
    public void Validation_Works(Prediction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Prediction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Prediction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Prediction.Legitimate)]
    [InlineData(Prediction.Suspicious)]
    public void SerializationRoundtrip_Works(Prediction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Prediction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Prediction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Prediction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Prediction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RiskFactorTest : TestBase
{
    [Theory]
    [InlineData(RiskFactor.BehavioralPattern)]
    [InlineData(RiskFactor.DeviceAttribute)]
    [InlineData(RiskFactor.FraudDatabase)]
    [InlineData(RiskFactor.LocationDiscrepancy)]
    [InlineData(RiskFactor.NetworkFingerprint)]
    [InlineData(RiskFactor.PoorConversionHistory)]
    [InlineData(RiskFactor.PrefixConcentration)]
    [InlineData(RiskFactor.SuspectedRequestTampering)]
    [InlineData(RiskFactor.SuspiciousIPAddress)]
    [InlineData(RiskFactor.TemporaryPhoneNumber)]
    public void Validation_Works(RiskFactor rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RiskFactor> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RiskFactor>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RiskFactor.BehavioralPattern)]
    [InlineData(RiskFactor.DeviceAttribute)]
    [InlineData(RiskFactor.FraudDatabase)]
    [InlineData(RiskFactor.LocationDiscrepancy)]
    [InlineData(RiskFactor.NetworkFingerprint)]
    [InlineData(RiskFactor.PoorConversionHistory)]
    [InlineData(RiskFactor.PrefixConcentration)]
    [InlineData(RiskFactor.SuspectedRequestTampering)]
    [InlineData(RiskFactor.SuspiciousIPAddress)]
    [InlineData(RiskFactor.TemporaryPhoneNumber)]
    public void SerializationRoundtrip_Works(RiskFactor rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RiskFactor> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RiskFactor>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RiskFactor>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RiskFactor>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
