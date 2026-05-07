using System;
using System.Collections.Generic;
using System.Text.Json;
using Prelude.Core;
using Prelude.Exceptions;
using Prelude.Models.Notify;

namespace Prelude.Tests.Models.Notify;

public class NotifyListSubscriptionPhoneNumbersResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumberValue = "+33612345678",
                    Source = PhoneNumberSource.MoKeyword,
                    State = PhoneNumberState.Sub,
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],
            NextCursor = "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==",
        };

        List<PhoneNumber> expectedPhoneNumbers =
        [
            new()
            {
                ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                PhoneNumberValue = "+33612345678",
                Source = PhoneNumberSource.MoKeyword,
                State = PhoneNumberState.Sub,
                UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                Reason = "STOP",
            },
        ];
        string expectedNextCursor =
            "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==";

        Assert.Equal(expectedPhoneNumbers.Count, model.PhoneNumbers.Count);
        for (int i = 0; i < expectedPhoneNumbers.Count; i++)
        {
            Assert.Equal(expectedPhoneNumbers[i], model.PhoneNumbers[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumberValue = "+33612345678",
                    Source = PhoneNumberSource.MoKeyword,
                    State = PhoneNumberState.Sub,
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],
            NextCursor = "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotifyListSubscriptionPhoneNumbersResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumberValue = "+33612345678",
                    Source = PhoneNumberSource.MoKeyword,
                    State = PhoneNumberState.Sub,
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],
            NextCursor = "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotifyListSubscriptionPhoneNumbersResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<PhoneNumber> expectedPhoneNumbers =
        [
            new()
            {
                ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                PhoneNumberValue = "+33612345678",
                Source = PhoneNumberSource.MoKeyword,
                State = PhoneNumberState.Sub,
                UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                Reason = "STOP",
            },
        ];
        string expectedNextCursor =
            "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==";

        Assert.Equal(expectedPhoneNumbers.Count, deserialized.PhoneNumbers.Count);
        for (int i = 0; i < expectedPhoneNumbers.Count; i++)
        {
            Assert.Equal(expectedPhoneNumbers[i], deserialized.PhoneNumbers[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumberValue = "+33612345678",
                    Source = PhoneNumberSource.MoKeyword,
                    State = PhoneNumberState.Sub,
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],
            NextCursor = "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumberValue = "+33612345678",
                    Source = PhoneNumberSource.MoKeyword,
                    State = PhoneNumberState.Sub,
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("next_cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumberValue = "+33612345678",
                    Source = PhoneNumberSource.MoKeyword,
                    State = PhoneNumberState.Sub,
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumberValue = "+33612345678",
                    Source = PhoneNumberSource.MoKeyword,
                    State = PhoneNumberState.Sub,
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("next_cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumberValue = "+33612345678",
                    Source = PhoneNumberSource.MoKeyword,
                    State = PhoneNumberState.Sub,
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotifyListSubscriptionPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    PhoneNumberValue = "+33612345678",
                    Source = PhoneNumberSource.MoKeyword,
                    State = PhoneNumberState.Sub,
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Reason = "STOP",
                },
            ],
            NextCursor = "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==",
        };

        NotifyListSubscriptionPhoneNumbersResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PhoneNumberTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhoneNumber
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumberValue = "+33612345678",
            Source = PhoneNumberSource.MoKeyword,
            State = PhoneNumberState.Sub,
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Reason = "STOP",
        };

        string expectedConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9";
        string expectedPhoneNumberValue = "+33612345678";
        ApiEnum<string, PhoneNumberSource> expectedSource = PhoneNumberSource.MoKeyword;
        ApiEnum<string, PhoneNumberState> expectedState = PhoneNumberState.Sub;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z");
        string expectedReason = "STOP";

        Assert.Equal(expectedConfigID, model.ConfigID);
        Assert.Equal(expectedPhoneNumberValue, model.PhoneNumberValue);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhoneNumber
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumberValue = "+33612345678",
            Source = PhoneNumberSource.MoKeyword,
            State = PhoneNumberState.Sub,
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Reason = "STOP",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumber>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhoneNumber
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumberValue = "+33612345678",
            Source = PhoneNumberSource.MoKeyword,
            State = PhoneNumberState.Sub,
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Reason = "STOP",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumber>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9";
        string expectedPhoneNumberValue = "+33612345678";
        ApiEnum<string, PhoneNumberSource> expectedSource = PhoneNumberSource.MoKeyword;
        ApiEnum<string, PhoneNumberState> expectedState = PhoneNumberState.Sub;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z");
        string expectedReason = "STOP";

        Assert.Equal(expectedConfigID, deserialized.ConfigID);
        Assert.Equal(expectedPhoneNumberValue, deserialized.PhoneNumberValue);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhoneNumber
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumberValue = "+33612345678",
            Source = PhoneNumberSource.MoKeyword,
            State = PhoneNumberState.Sub,
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Reason = "STOP",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PhoneNumber
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumberValue = "+33612345678",
            Source = PhoneNumberSource.MoKeyword,
            State = PhoneNumberState.Sub,
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PhoneNumber
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumberValue = "+33612345678",
            Source = PhoneNumberSource.MoKeyword,
            State = PhoneNumberState.Sub,
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PhoneNumber
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumberValue = "+33612345678",
            Source = PhoneNumberSource.MoKeyword,
            State = PhoneNumberState.Sub,
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
        var model = new PhoneNumber
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumberValue = "+33612345678",
            Source = PhoneNumberSource.MoKeyword,
            State = PhoneNumberState.Sub,
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),

            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhoneNumber
        {
            ConfigID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            PhoneNumberValue = "+33612345678",
            Source = PhoneNumberSource.MoKeyword,
            State = PhoneNumberState.Sub,
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Reason = "STOP",
        };

        PhoneNumber copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PhoneNumberSourceTest : TestBase
{
    [Theory]
    [InlineData(PhoneNumberSource.MoKeyword)]
    [InlineData(PhoneNumberSource.Api)]
    [InlineData(PhoneNumberSource.CsvImport)]
    [InlineData(PhoneNumberSource.CarrierDisconnect)]
    public void Validation_Works(PhoneNumberSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhoneNumberSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhoneNumberSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PhoneNumberSource.MoKeyword)]
    [InlineData(PhoneNumberSource.Api)]
    [InlineData(PhoneNumberSource.CsvImport)]
    [InlineData(PhoneNumberSource.CarrierDisconnect)]
    public void SerializationRoundtrip_Works(PhoneNumberSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhoneNumberSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PhoneNumberSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhoneNumberSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PhoneNumberSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PhoneNumberStateTest : TestBase
{
    [Theory]
    [InlineData(PhoneNumberState.Sub)]
    [InlineData(PhoneNumberState.Unsub)]
    public void Validation_Works(PhoneNumberState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhoneNumberState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhoneNumberState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PhoneNumberState.Sub)]
    [InlineData(PhoneNumberState.Unsub)]
    public void SerializationRoundtrip_Works(PhoneNumberState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhoneNumberState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PhoneNumberState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhoneNumberState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PhoneNumberState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
