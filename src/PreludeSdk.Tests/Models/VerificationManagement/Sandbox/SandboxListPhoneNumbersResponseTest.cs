using System;
using System.Collections.Generic;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Models.VerificationManagement.Sandbox;

namespace PreludeSdk.Tests.Models.VerificationManagement.Sandbox;

public class SandboxListPhoneNumbersResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SandboxListPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    AttemptCode = "123456",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    PhoneNumberValue = "+30123456789",
                },
            ],
        };

        List<PhoneNumber> expectedPhoneNumbers =
        [
            new()
            {
                AttemptCode = "123456",
                CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                PhoneNumberValue = "+30123456789",
            },
        ];

        Assert.Equal(expectedPhoneNumbers.Count, model.PhoneNumbers.Count);
        for (int i = 0; i < expectedPhoneNumbers.Count; i++)
        {
            Assert.Equal(expectedPhoneNumbers[i], model.PhoneNumbers[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SandboxListPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    AttemptCode = "123456",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    PhoneNumberValue = "+30123456789",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SandboxListPhoneNumbersResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SandboxListPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    AttemptCode = "123456",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    PhoneNumberValue = "+30123456789",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SandboxListPhoneNumbersResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<PhoneNumber> expectedPhoneNumbers =
        [
            new()
            {
                AttemptCode = "123456",
                CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                PhoneNumberValue = "+30123456789",
            },
        ];

        Assert.Equal(expectedPhoneNumbers.Count, deserialized.PhoneNumbers.Count);
        for (int i = 0; i < expectedPhoneNumbers.Count; i++)
        {
            Assert.Equal(expectedPhoneNumbers[i], deserialized.PhoneNumbers[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SandboxListPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    AttemptCode = "123456",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    PhoneNumberValue = "+30123456789",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SandboxListPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    AttemptCode = "123456",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    PhoneNumberValue = "+30123456789",
                },
            ],
        };

        SandboxListPhoneNumbersResponse copied = new(model);

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
            AttemptCode = "123456",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            PhoneNumberValue = "+30123456789",
        };

        string expectedAttemptCode = "123456";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z");
        string expectedPhoneNumberValue = "+30123456789";

        Assert.Equal(expectedAttemptCode, model.AttemptCode);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedPhoneNumberValue, model.PhoneNumberValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhoneNumber
        {
            AttemptCode = "123456",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            PhoneNumberValue = "+30123456789",
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
            AttemptCode = "123456",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            PhoneNumberValue = "+30123456789",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumber>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAttemptCode = "123456";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z");
        string expectedPhoneNumberValue = "+30123456789";

        Assert.Equal(expectedAttemptCode, deserialized.AttemptCode);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedPhoneNumberValue, deserialized.PhoneNumberValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhoneNumber
        {
            AttemptCode = "123456",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            PhoneNumberValue = "+30123456789",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhoneNumber
        {
            AttemptCode = "123456",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            PhoneNumberValue = "+30123456789",
        };

        PhoneNumber copied = new(model);

        Assert.Equal(model, copied);
    }
}
