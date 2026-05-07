using System;
using System.Collections.Generic;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Models.VerificationManagement;

namespace PreludeSdk.Tests.Models.VerificationManagement;

public class VerificationManagementListPhoneNumbersResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerificationManagementListPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    PhoneNumberValue = "+30123456789",
                },
            ],
        };

        List<PhoneNumber> expectedPhoneNumbers =
        [
            new()
            {
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
        var model = new VerificationManagementListPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    PhoneNumberValue = "+30123456789",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerificationManagementListPhoneNumbersResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerificationManagementListPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    PhoneNumberValue = "+30123456789",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerificationManagementListPhoneNumbersResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<PhoneNumber> expectedPhoneNumbers =
        [
            new()
            {
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
        var model = new VerificationManagementListPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
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
        var model = new VerificationManagementListPhoneNumbersResponse
        {
            PhoneNumbers =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    PhoneNumberValue = "+30123456789",
                },
            ],
        };

        VerificationManagementListPhoneNumbersResponse copied = new(model);

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
            CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            PhoneNumberValue = "+30123456789",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z");
        string expectedPhoneNumberValue = "+30123456789";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedPhoneNumberValue, model.PhoneNumberValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhoneNumber
        {
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
            CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            PhoneNumberValue = "+30123456789",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumber>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z");
        string expectedPhoneNumberValue = "+30123456789";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedPhoneNumberValue, deserialized.PhoneNumberValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhoneNumber
        {
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
            CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            PhoneNumberValue = "+30123456789",
        };

        PhoneNumber copied = new(model);

        Assert.Equal(model, copied);
    }
}
