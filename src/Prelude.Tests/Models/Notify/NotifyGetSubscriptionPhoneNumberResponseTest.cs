using System;
using System.Text.Json;
using Prelude.Core;
using Prelude.Exceptions;
using Prelude.Models.Notify;

namespace Prelude.Tests.Models.Notify;

public class NotifyGetSubscriptionPhoneNumberResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotifyGetSubscriptionPhoneNumberResponse
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = Source.MoKeyword,
            State = NotifyGetSubscriptionPhoneNumberResponseState.Sub,
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Reason = "STOP",
        };

        string expectedConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9";
        string expectedPhoneNumber = "+33612345678";
        ApiEnum<string, Source> expectedSource = Source.MoKeyword;
        ApiEnum<string, NotifyGetSubscriptionPhoneNumberResponseState> expectedState =
            NotifyGetSubscriptionPhoneNumberResponseState.Sub;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z");
        string expectedReason = "STOP";

        Assert.Equal(expectedConfigID, model.ConfigID);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotifyGetSubscriptionPhoneNumberResponse
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = Source.MoKeyword,
            State = NotifyGetSubscriptionPhoneNumberResponseState.Sub,
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Reason = "STOP",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotifyGetSubscriptionPhoneNumberResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotifyGetSubscriptionPhoneNumberResponse
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = Source.MoKeyword,
            State = NotifyGetSubscriptionPhoneNumberResponseState.Sub,
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Reason = "STOP",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotifyGetSubscriptionPhoneNumberResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9";
        string expectedPhoneNumber = "+33612345678";
        ApiEnum<string, Source> expectedSource = Source.MoKeyword;
        ApiEnum<string, NotifyGetSubscriptionPhoneNumberResponseState> expectedState =
            NotifyGetSubscriptionPhoneNumberResponseState.Sub;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z");
        string expectedReason = "STOP";

        Assert.Equal(expectedConfigID, deserialized.ConfigID);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotifyGetSubscriptionPhoneNumberResponse
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = Source.MoKeyword,
            State = NotifyGetSubscriptionPhoneNumberResponseState.Sub,
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Reason = "STOP",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NotifyGetSubscriptionPhoneNumberResponse
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = Source.MoKeyword,
            State = NotifyGetSubscriptionPhoneNumberResponseState.Sub,
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NotifyGetSubscriptionPhoneNumberResponse
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = Source.MoKeyword,
            State = NotifyGetSubscriptionPhoneNumberResponseState.Sub,
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NotifyGetSubscriptionPhoneNumberResponse
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = Source.MoKeyword,
            State = NotifyGetSubscriptionPhoneNumberResponseState.Sub,
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),

            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NotifyGetSubscriptionPhoneNumberResponse
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = Source.MoKeyword,
            State = NotifyGetSubscriptionPhoneNumberResponseState.Sub,
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),

            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotifyGetSubscriptionPhoneNumberResponse
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumber = "+33612345678",
            Source = Source.MoKeyword,
            State = NotifyGetSubscriptionPhoneNumberResponseState.Sub,
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Reason = "STOP",
        };

        NotifyGetSubscriptionPhoneNumberResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SourceTest : TestBase
{
    [Theory]
    [InlineData(Source.MoKeyword)]
    [InlineData(Source.Api)]
    [InlineData(Source.CsvImport)]
    [InlineData(Source.CarrierDisconnect)]
    public void Validation_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Source.MoKeyword)]
    [InlineData(Source.Api)]
    [InlineData(Source.CsvImport)]
    [InlineData(Source.CarrierDisconnect)]
    public void SerializationRoundtrip_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NotifyGetSubscriptionPhoneNumberResponseStateTest : TestBase
{
    [Theory]
    [InlineData(NotifyGetSubscriptionPhoneNumberResponseState.Sub)]
    [InlineData(NotifyGetSubscriptionPhoneNumberResponseState.Unsub)]
    public void Validation_Works(NotifyGetSubscriptionPhoneNumberResponseState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NotifyGetSubscriptionPhoneNumberResponseState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NotifyGetSubscriptionPhoneNumberResponseState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NotifyGetSubscriptionPhoneNumberResponseState.Sub)]
    [InlineData(NotifyGetSubscriptionPhoneNumberResponseState.Unsub)]
    public void SerializationRoundtrip_Works(NotifyGetSubscriptionPhoneNumberResponseState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NotifyGetSubscriptionPhoneNumberResponseState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NotifyGetSubscriptionPhoneNumberResponseState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NotifyGetSubscriptionPhoneNumberResponseState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NotifyGetSubscriptionPhoneNumberResponseState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
