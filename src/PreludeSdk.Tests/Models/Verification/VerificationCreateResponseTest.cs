using System.Collections.Generic;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.Verification;

namespace PreludeSdk.Tests.Models.Verification;

public class VerificationCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerificationCreateResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Method = VerificationCreateResponseMethod.Email,
            Status = Status.Success,
            Channels = [Channel.Rcs],
            Metadata = new() { CorrelationID = "correlation_id" },
            Reason = Reason.InvalidPhoneNumber,
            RequestID = "request_id",
            RiskFactors = [RiskFactor.SuspiciousIPAddress, RiskFactor.FraudDatabase],
            Silent = new("request_url"),
        };

        string expectedID = "vrf_01jc0t6fwwfgfsq1md24mhyztj";
        ApiEnum<string, VerificationCreateResponseMethod> expectedMethod =
            VerificationCreateResponseMethod.Email;
        ApiEnum<string, Status> expectedStatus = Status.Success;
        List<ApiEnum<string, Channel>> expectedChannels = [Channel.Rcs];
        VerificationCreateResponseMetadata expectedMetadata = new()
        {
            CorrelationID = "correlation_id",
        };
        ApiEnum<string, Reason> expectedReason = Reason.InvalidPhoneNumber;
        string expectedRequestID = "request_id";
        List<ApiEnum<string, RiskFactor>> expectedRiskFactors =
        [
            RiskFactor.SuspiciousIPAddress,
            RiskFactor.FraudDatabase,
        ];
        Silent expectedSilent = new("request_url");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedRequestID, model.RequestID);
        Assert.NotNull(model.RiskFactors);
        Assert.Equal(expectedRiskFactors.Count, model.RiskFactors.Count);
        for (int i = 0; i < expectedRiskFactors.Count; i++)
        {
            Assert.Equal(expectedRiskFactors[i], model.RiskFactors[i]);
        }
        Assert.Equal(expectedSilent, model.Silent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerificationCreateResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Method = VerificationCreateResponseMethod.Email,
            Status = Status.Success,
            Channels = [Channel.Rcs],
            Metadata = new() { CorrelationID = "correlation_id" },
            Reason = Reason.InvalidPhoneNumber,
            RequestID = "request_id",
            RiskFactors = [RiskFactor.SuspiciousIPAddress, RiskFactor.FraudDatabase],
            Silent = new("request_url"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerificationCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerificationCreateResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Method = VerificationCreateResponseMethod.Email,
            Status = Status.Success,
            Channels = [Channel.Rcs],
            Metadata = new() { CorrelationID = "correlation_id" },
            Reason = Reason.InvalidPhoneNumber,
            RequestID = "request_id",
            RiskFactors = [RiskFactor.SuspiciousIPAddress, RiskFactor.FraudDatabase],
            Silent = new("request_url"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerificationCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "vrf_01jc0t6fwwfgfsq1md24mhyztj";
        ApiEnum<string, VerificationCreateResponseMethod> expectedMethod =
            VerificationCreateResponseMethod.Email;
        ApiEnum<string, Status> expectedStatus = Status.Success;
        List<ApiEnum<string, Channel>> expectedChannels = [Channel.Rcs];
        VerificationCreateResponseMetadata expectedMetadata = new()
        {
            CorrelationID = "correlation_id",
        };
        ApiEnum<string, Reason> expectedReason = Reason.InvalidPhoneNumber;
        string expectedRequestID = "request_id";
        List<ApiEnum<string, RiskFactor>> expectedRiskFactors =
        [
            RiskFactor.SuspiciousIPAddress,
            RiskFactor.FraudDatabase,
        ];
        Silent expectedSilent = new("request_url");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedRequestID, deserialized.RequestID);
        Assert.NotNull(deserialized.RiskFactors);
        Assert.Equal(expectedRiskFactors.Count, deserialized.RiskFactors.Count);
        for (int i = 0; i < expectedRiskFactors.Count; i++)
        {
            Assert.Equal(expectedRiskFactors[i], deserialized.RiskFactors[i]);
        }
        Assert.Equal(expectedSilent, deserialized.Silent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerificationCreateResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Method = VerificationCreateResponseMethod.Email,
            Status = Status.Success,
            Channels = [Channel.Rcs],
            Metadata = new() { CorrelationID = "correlation_id" },
            Reason = Reason.InvalidPhoneNumber,
            RequestID = "request_id",
            RiskFactors = [RiskFactor.SuspiciousIPAddress, RiskFactor.FraudDatabase],
            Silent = new("request_url"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerificationCreateResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Method = VerificationCreateResponseMethod.Email,
            Status = Status.Success,
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
        Assert.Null(model.RiskFactors);
        Assert.False(model.RawData.ContainsKey("risk_factors"));
        Assert.Null(model.Silent);
        Assert.False(model.RawData.ContainsKey("silent"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerificationCreateResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Method = VerificationCreateResponseMethod.Email,
            Status = Status.Success,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerificationCreateResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Method = VerificationCreateResponseMethod.Email,
            Status = Status.Success,

            // Null should be interpreted as omitted for these properties
            Channels = null,
            Metadata = null,
            Reason = null,
            RequestID = null,
            RiskFactors = null,
            Silent = null,
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
        Assert.Null(model.RiskFactors);
        Assert.False(model.RawData.ContainsKey("risk_factors"));
        Assert.Null(model.Silent);
        Assert.False(model.RawData.ContainsKey("silent"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerificationCreateResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Method = VerificationCreateResponseMethod.Email,
            Status = Status.Success,

            // Null should be interpreted as omitted for these properties
            Channels = null,
            Metadata = null,
            Reason = null,
            RequestID = null,
            RiskFactors = null,
            Silent = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerificationCreateResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Method = VerificationCreateResponseMethod.Email,
            Status = Status.Success,
            Channels = [Channel.Rcs],
            Metadata = new() { CorrelationID = "correlation_id" },
            Reason = Reason.InvalidPhoneNumber,
            RequestID = "request_id",
            RiskFactors = [RiskFactor.SuspiciousIPAddress, RiskFactor.FraudDatabase],
            Silent = new("request_url"),
        };

        VerificationCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerificationCreateResponseMethodTest : TestBase
{
    [Theory]
    [InlineData(VerificationCreateResponseMethod.Email)]
    [InlineData(VerificationCreateResponseMethod.Message)]
    [InlineData(VerificationCreateResponseMethod.Silent)]
    [InlineData(VerificationCreateResponseMethod.Voice)]
    public void Validation_Works(VerificationCreateResponseMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationCreateResponseMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerificationCreateResponseMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerificationCreateResponseMethod.Email)]
    [InlineData(VerificationCreateResponseMethod.Message)]
    [InlineData(VerificationCreateResponseMethod.Silent)]
    [InlineData(VerificationCreateResponseMethod.Voice)]
    public void SerializationRoundtrip_Works(VerificationCreateResponseMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationCreateResponseMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationCreateResponseMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerificationCreateResponseMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerificationCreateResponseMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Success)]
    [InlineData(Status.Retry)]
    [InlineData(Status.Challenged)]
    [InlineData(Status.Blocked)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Success)]
    [InlineData(Status.Retry)]
    [InlineData(Status.Challenged)]
    [InlineData(Status.Blocked)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChannelTest : TestBase
{
    [Theory]
    [InlineData(Channel.Rcs)]
    [InlineData(Channel.Silent)]
    [InlineData(Channel.Sms)]
    [InlineData(Channel.Telegram)]
    [InlineData(Channel.Viber)]
    [InlineData(Channel.Voice)]
    [InlineData(Channel.Whatsapp)]
    [InlineData(Channel.Zalo)]
    public void Validation_Works(Channel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Channel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Channel.Rcs)]
    [InlineData(Channel.Silent)]
    [InlineData(Channel.Sms)]
    [InlineData(Channel.Telegram)]
    [InlineData(Channel.Viber)]
    [InlineData(Channel.Voice)]
    [InlineData(Channel.Whatsapp)]
    [InlineData(Channel.Zalo)]
    public void SerializationRoundtrip_Works(Channel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Channel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VerificationCreateResponseMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerificationCreateResponseMetadata { CorrelationID = "correlation_id" };

        string expectedCorrelationID = "correlation_id";

        Assert.Equal(expectedCorrelationID, model.CorrelationID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerificationCreateResponseMetadata { CorrelationID = "correlation_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerificationCreateResponseMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerificationCreateResponseMetadata { CorrelationID = "correlation_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerificationCreateResponseMetadata>(
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
        var model = new VerificationCreateResponseMetadata { CorrelationID = "correlation_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerificationCreateResponseMetadata { };

        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerificationCreateResponseMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerificationCreateResponseMetadata
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
        var model = new VerificationCreateResponseMetadata
        {
            // Null should be interpreted as omitted for these properties
            CorrelationID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerificationCreateResponseMetadata { CorrelationID = "correlation_id" };

        VerificationCreateResponseMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Reason.ExpiredSignature)]
    [InlineData(Reason.InBlockList)]
    [InlineData(Reason.InvalidPhoneLine)]
    [InlineData(Reason.InvalidPhoneNumber)]
    [InlineData(Reason.InvalidSignature)]
    [InlineData(Reason.RepeatedAttempts)]
    [InlineData(Reason.Suspicious)]
    public void Validation_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Reason.ExpiredSignature)]
    [InlineData(Reason.InBlockList)]
    [InlineData(Reason.InvalidPhoneLine)]
    [InlineData(Reason.InvalidPhoneNumber)]
    [InlineData(Reason.InvalidSignature)]
    [InlineData(Reason.RepeatedAttempts)]
    [InlineData(Reason.Suspicious)]
    public void SerializationRoundtrip_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
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

public class SilentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Silent { RequestUrl = "request_url" };

        string expectedRequestUrl = "request_url";

        Assert.Equal(expectedRequestUrl, model.RequestUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Silent { RequestUrl = "request_url" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Silent>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Silent { RequestUrl = "request_url" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Silent>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedRequestUrl = "request_url";

        Assert.Equal(expectedRequestUrl, deserialized.RequestUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Silent { RequestUrl = "request_url" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Silent { RequestUrl = "request_url" };

        Silent copied = new(model);

        Assert.Equal(model, copied);
    }
}
