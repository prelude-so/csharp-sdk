using System;
using System.Collections.Generic;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Models.Notify;

namespace PreludeSdk.Tests.Models.Notify;

public class NotifyListSubscriptionConfigsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotifyListSubscriptionConfigsResponse
        {
            Configs =
            [
                new()
                {
                    ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    CallbackUrl = "https://your-app.com/webhooks/subscription",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Messages = new()
                    {
                        HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                        StartMessage =
                            "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                        StopMessage =
                            "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
                    },
                    Name = "Marketing Campaign",
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    MoPhoneNumbers =
                    [
                        new() { CountryCode = "US", PhoneNumber = "+15551234567" },
                        new() { CountryCode = "FR", PhoneNumber = "36184" },
                    ],
                },
            ],
            NextCursor = "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==",
        };

        List<Config> expectedConfigs =
        [
            new()
            {
                ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                CallbackUrl = "https://your-app.com/webhooks/subscription",
                CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                Messages = new()
                {
                    HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                    StartMessage =
                        "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                    StopMessage =
                        "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
                },
                Name = "Marketing Campaign",
                UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                MoPhoneNumbers =
                [
                    new() { CountryCode = "US", PhoneNumber = "+15551234567" },
                    new() { CountryCode = "FR", PhoneNumber = "36184" },
                ],
            },
        ];
        string expectedNextCursor =
            "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==";

        Assert.Equal(expectedConfigs.Count, model.Configs.Count);
        for (int i = 0; i < expectedConfigs.Count; i++)
        {
            Assert.Equal(expectedConfigs[i], model.Configs[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotifyListSubscriptionConfigsResponse
        {
            Configs =
            [
                new()
                {
                    ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    CallbackUrl = "https://your-app.com/webhooks/subscription",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Messages = new()
                    {
                        HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                        StartMessage =
                            "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                        StopMessage =
                            "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
                    },
                    Name = "Marketing Campaign",
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    MoPhoneNumbers =
                    [
                        new() { CountryCode = "US", PhoneNumber = "+15551234567" },
                        new() { CountryCode = "FR", PhoneNumber = "36184" },
                    ],
                },
            ],
            NextCursor = "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotifyListSubscriptionConfigsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotifyListSubscriptionConfigsResponse
        {
            Configs =
            [
                new()
                {
                    ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    CallbackUrl = "https://your-app.com/webhooks/subscription",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Messages = new()
                    {
                        HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                        StartMessage =
                            "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                        StopMessage =
                            "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
                    },
                    Name = "Marketing Campaign",
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    MoPhoneNumbers =
                    [
                        new() { CountryCode = "US", PhoneNumber = "+15551234567" },
                        new() { CountryCode = "FR", PhoneNumber = "36184" },
                    ],
                },
            ],
            NextCursor = "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotifyListSubscriptionConfigsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Config> expectedConfigs =
        [
            new()
            {
                ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                CallbackUrl = "https://your-app.com/webhooks/subscription",
                CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                Messages = new()
                {
                    HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                    StartMessage =
                        "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                    StopMessage =
                        "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
                },
                Name = "Marketing Campaign",
                UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                MoPhoneNumbers =
                [
                    new() { CountryCode = "US", PhoneNumber = "+15551234567" },
                    new() { CountryCode = "FR", PhoneNumber = "36184" },
                ],
            },
        ];
        string expectedNextCursor =
            "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==";

        Assert.Equal(expectedConfigs.Count, deserialized.Configs.Count);
        for (int i = 0; i < expectedConfigs.Count; i++)
        {
            Assert.Equal(expectedConfigs[i], deserialized.Configs[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotifyListSubscriptionConfigsResponse
        {
            Configs =
            [
                new()
                {
                    ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    CallbackUrl = "https://your-app.com/webhooks/subscription",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Messages = new()
                    {
                        HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                        StartMessage =
                            "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                        StopMessage =
                            "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
                    },
                    Name = "Marketing Campaign",
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    MoPhoneNumbers =
                    [
                        new() { CountryCode = "US", PhoneNumber = "+15551234567" },
                        new() { CountryCode = "FR", PhoneNumber = "36184" },
                    ],
                },
            ],
            NextCursor = "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NotifyListSubscriptionConfigsResponse
        {
            Configs =
            [
                new()
                {
                    ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    CallbackUrl = "https://your-app.com/webhooks/subscription",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Messages = new()
                    {
                        HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                        StartMessage =
                            "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                        StopMessage =
                            "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
                    },
                    Name = "Marketing Campaign",
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    MoPhoneNumbers =
                    [
                        new() { CountryCode = "US", PhoneNumber = "+15551234567" },
                        new() { CountryCode = "FR", PhoneNumber = "36184" },
                    ],
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("next_cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NotifyListSubscriptionConfigsResponse
        {
            Configs =
            [
                new()
                {
                    ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    CallbackUrl = "https://your-app.com/webhooks/subscription",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Messages = new()
                    {
                        HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                        StartMessage =
                            "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                        StopMessage =
                            "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
                    },
                    Name = "Marketing Campaign",
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    MoPhoneNumbers =
                    [
                        new() { CountryCode = "US", PhoneNumber = "+15551234567" },
                        new() { CountryCode = "FR", PhoneNumber = "36184" },
                    ],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NotifyListSubscriptionConfigsResponse
        {
            Configs =
            [
                new()
                {
                    ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    CallbackUrl = "https://your-app.com/webhooks/subscription",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Messages = new()
                    {
                        HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                        StartMessage =
                            "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                        StopMessage =
                            "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
                    },
                    Name = "Marketing Campaign",
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    MoPhoneNumbers =
                    [
                        new() { CountryCode = "US", PhoneNumber = "+15551234567" },
                        new() { CountryCode = "FR", PhoneNumber = "36184" },
                    ],
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
        var model = new NotifyListSubscriptionConfigsResponse
        {
            Configs =
            [
                new()
                {
                    ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    CallbackUrl = "https://your-app.com/webhooks/subscription",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Messages = new()
                    {
                        HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                        StartMessage =
                            "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                        StopMessage =
                            "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
                    },
                    Name = "Marketing Campaign",
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    MoPhoneNumbers =
                    [
                        new() { CountryCode = "US", PhoneNumber = "+15551234567" },
                        new() { CountryCode = "FR", PhoneNumber = "36184" },
                    ],
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
        var model = new NotifyListSubscriptionConfigsResponse
        {
            Configs =
            [
                new()
                {
                    ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
                    CallbackUrl = "https://your-app.com/webhooks/subscription",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    Messages = new()
                    {
                        HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                        StartMessage =
                            "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                        StopMessage =
                            "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
                    },
                    Name = "Marketing Campaign",
                    UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
                    MoPhoneNumbers =
                    [
                        new() { CountryCode = "US", PhoneNumber = "+15551234567" },
                        new() { CountryCode = "FR", PhoneNumber = "36184" },
                    ],
                },
            ],
            NextCursor = "eyJwayI6IjEyMzQ1Njc4LTkwYWItMTJjZC00NTY3LTg5MGFiMTJjZGU0NTYifQ==",
        };

        NotifyListSubscriptionConfigsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Config
        {
            ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            CallbackUrl = "https://your-app.com/webhooks/subscription",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Messages = new()
            {
                HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                StartMessage =
                    "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                StopMessage =
                    "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
            },
            Name = "Marketing Campaign",
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            MoPhoneNumbers =
            [
                new() { CountryCode = "US", PhoneNumber = "+15551234567" },
                new() { CountryCode = "FR", PhoneNumber = "36184" },
            ],
        };

        string expectedID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9";
        string expectedCallbackUrl = "https://your-app.com/webhooks/subscription";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z");
        ConfigMessages expectedMessages = new()
        {
            HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
            StartMessage =
                "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
            StopMessage =
                "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
        };
        string expectedName = "Marketing Campaign";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z");
        List<ConfigMoPhoneNumber> expectedMoPhoneNumbers =
        [
            new() { CountryCode = "US", PhoneNumber = "+15551234567" },
            new() { CountryCode = "FR", PhoneNumber = "36184" },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCallbackUrl, model.CallbackUrl);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMessages, model.Messages);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.NotNull(model.MoPhoneNumbers);
        Assert.Equal(expectedMoPhoneNumbers.Count, model.MoPhoneNumbers.Count);
        for (int i = 0; i < expectedMoPhoneNumbers.Count; i++)
        {
            Assert.Equal(expectedMoPhoneNumbers[i], model.MoPhoneNumbers[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Config
        {
            ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            CallbackUrl = "https://your-app.com/webhooks/subscription",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Messages = new()
            {
                HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                StartMessage =
                    "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                StopMessage =
                    "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
            },
            Name = "Marketing Campaign",
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            MoPhoneNumbers =
            [
                new() { CountryCode = "US", PhoneNumber = "+15551234567" },
                new() { CountryCode = "FR", PhoneNumber = "36184" },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Config>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Config
        {
            ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            CallbackUrl = "https://your-app.com/webhooks/subscription",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Messages = new()
            {
                HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                StartMessage =
                    "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                StopMessage =
                    "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
            },
            Name = "Marketing Campaign",
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            MoPhoneNumbers =
            [
                new() { CountryCode = "US", PhoneNumber = "+15551234567" },
                new() { CountryCode = "FR", PhoneNumber = "36184" },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Config>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9";
        string expectedCallbackUrl = "https://your-app.com/webhooks/subscription";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z");
        ConfigMessages expectedMessages = new()
        {
            HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
            StartMessage =
                "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
            StopMessage =
                "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
        };
        string expectedName = "Marketing Campaign";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z");
        List<ConfigMoPhoneNumber> expectedMoPhoneNumbers =
        [
            new() { CountryCode = "US", PhoneNumber = "+15551234567" },
            new() { CountryCode = "FR", PhoneNumber = "36184" },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCallbackUrl, deserialized.CallbackUrl);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMessages, deserialized.Messages);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.NotNull(deserialized.MoPhoneNumbers);
        Assert.Equal(expectedMoPhoneNumbers.Count, deserialized.MoPhoneNumbers.Count);
        for (int i = 0; i < expectedMoPhoneNumbers.Count; i++)
        {
            Assert.Equal(expectedMoPhoneNumbers[i], deserialized.MoPhoneNumbers[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Config
        {
            ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            CallbackUrl = "https://your-app.com/webhooks/subscription",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Messages = new()
            {
                HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                StartMessage =
                    "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                StopMessage =
                    "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
            },
            Name = "Marketing Campaign",
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            MoPhoneNumbers =
            [
                new() { CountryCode = "US", PhoneNumber = "+15551234567" },
                new() { CountryCode = "FR", PhoneNumber = "36184" },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Config
        {
            ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            CallbackUrl = "https://your-app.com/webhooks/subscription",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Messages = new()
            {
                HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                StartMessage =
                    "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                StopMessage =
                    "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
            },
            Name = "Marketing Campaign",
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
        };

        Assert.Null(model.MoPhoneNumbers);
        Assert.False(model.RawData.ContainsKey("mo_phone_numbers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Config
        {
            ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            CallbackUrl = "https://your-app.com/webhooks/subscription",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Messages = new()
            {
                HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                StartMessage =
                    "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                StopMessage =
                    "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
            },
            Name = "Marketing Campaign",
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Config
        {
            ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            CallbackUrl = "https://your-app.com/webhooks/subscription",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Messages = new()
            {
                HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                StartMessage =
                    "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                StopMessage =
                    "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
            },
            Name = "Marketing Campaign",
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),

            // Null should be interpreted as omitted for these properties
            MoPhoneNumbers = null,
        };

        Assert.Null(model.MoPhoneNumbers);
        Assert.False(model.RawData.ContainsKey("mo_phone_numbers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Config
        {
            ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            CallbackUrl = "https://your-app.com/webhooks/subscription",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Messages = new()
            {
                HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                StartMessage =
                    "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                StopMessage =
                    "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
            },
            Name = "Marketing Campaign",
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),

            // Null should be interpreted as omitted for these properties
            MoPhoneNumbers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Config
        {
            ID = "subcfg_01k8ap1btqf5r9fq2c8ax5fhc9",
            CallbackUrl = "https://your-app.com/webhooks/subscription",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            Messages = new()
            {
                HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
                StartMessage =
                    "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
                StopMessage =
                    "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
            },
            Name = "Marketing Campaign",
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T12:00:00Z"),
            MoPhoneNumbers =
            [
                new() { CountryCode = "US", PhoneNumber = "+15551234567" },
                new() { CountryCode = "FR", PhoneNumber = "36184" },
            ],
        };

        Config copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConfigMessagesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConfigMessages
        {
            HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
            StartMessage =
                "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
            StopMessage =
                "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
        };

        string expectedHelpMessage = "Reply STOP to unsubscribe or START to resubscribe.";
        string expectedStartMessage =
            "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.";
        string expectedStopMessage =
            "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.";

        Assert.Equal(expectedHelpMessage, model.HelpMessage);
        Assert.Equal(expectedStartMessage, model.StartMessage);
        Assert.Equal(expectedStopMessage, model.StopMessage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConfigMessages
        {
            HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
            StartMessage =
                "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
            StopMessage =
                "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigMessages>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConfigMessages
        {
            HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
            StartMessage =
                "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
            StopMessage =
                "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigMessages>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedHelpMessage = "Reply STOP to unsubscribe or START to resubscribe.";
        string expectedStartMessage =
            "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.";
        string expectedStopMessage =
            "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.";

        Assert.Equal(expectedHelpMessage, deserialized.HelpMessage);
        Assert.Equal(expectedStartMessage, deserialized.StartMessage);
        Assert.Equal(expectedStopMessage, deserialized.StopMessage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConfigMessages
        {
            HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
            StartMessage =
                "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
            StopMessage =
                "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConfigMessages { };

        Assert.Null(model.HelpMessage);
        Assert.False(model.RawData.ContainsKey("help_message"));
        Assert.Null(model.StartMessage);
        Assert.False(model.RawData.ContainsKey("start_message"));
        Assert.Null(model.StopMessage);
        Assert.False(model.RawData.ContainsKey("stop_message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConfigMessages { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConfigMessages
        {
            // Null should be interpreted as omitted for these properties
            HelpMessage = null,
            StartMessage = null,
            StopMessage = null,
        };

        Assert.Null(model.HelpMessage);
        Assert.False(model.RawData.ContainsKey("help_message"));
        Assert.Null(model.StartMessage);
        Assert.False(model.RawData.ContainsKey("start_message"));
        Assert.Null(model.StopMessage);
        Assert.False(model.RawData.ContainsKey("stop_message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConfigMessages
        {
            // Null should be interpreted as omitted for these properties
            HelpMessage = null,
            StartMessage = null,
            StopMessage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConfigMessages
        {
            HelpMessage = "Reply STOP to unsubscribe or START to resubscribe.",
            StartMessage =
                "You have been resubscribed and will receive messages again. Reply STOP to unsubscribe.",
            StopMessage =
                "You have been unsubscribed and will not receive further messages. Reply START to resubscribe.",
        };

        ConfigMessages copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConfigMoPhoneNumberTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConfigMoPhoneNumber { CountryCode = "US", PhoneNumber = "+15551234567" };

        string expectedCountryCode = "US";
        string expectedPhoneNumber = "+15551234567";

        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConfigMoPhoneNumber { CountryCode = "US", PhoneNumber = "+15551234567" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigMoPhoneNumber>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConfigMoPhoneNumber { CountryCode = "US", PhoneNumber = "+15551234567" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigMoPhoneNumber>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCountryCode = "US";
        string expectedPhoneNumber = "+15551234567";

        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConfigMoPhoneNumber { CountryCode = "US", PhoneNumber = "+15551234567" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConfigMoPhoneNumber { CountryCode = "US", PhoneNumber = "+15551234567" };

        ConfigMoPhoneNumber copied = new(model);

        Assert.Equal(model, copied);
    }
}
