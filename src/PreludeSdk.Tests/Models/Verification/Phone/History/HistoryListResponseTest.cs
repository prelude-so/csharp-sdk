using System;
using System.Collections.Generic;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.Verification.Phone.History;

namespace PreludeSdk.Tests.Models.Verification.Phone.History;

public class HistoryListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new HistoryListResponse
        {
            Verifications =
            [
                new()
                {
                    ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
                    Channels =
                    [
                        new()
                        {
                            Channel = HistoryListResponseVerificationChannelChannel.Sms,
                            Converted = true,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Delivered = true,
                    PhoneNumber = "+33612345678",
                    Status = HistoryListResponseVerificationStatus.Converted,
                    Attempts = 0,
                    ConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Cost = new() { Amount = "0.042", Currency = "EUR" },
                    DevicePlatform = HistoryListResponseVerificationDevicePlatform.Android,
                    PhoneNumberCondition =
                        HistoryListResponseVerificationPhoneNumberCondition.AllowListed,
                    SignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid,
                },
            ],
            NextCursor =
                "MIZw2XwtkcEcC5SKsMEfSx6a3XAgW-Ct6waU8NCqUkAvFxz41DJbjQIkqHWJS1JY6-it7ZsZHFYN3luFH8yTdCAB",
        };

        List<HistoryListResponseVerification> expectedVerifications =
        [
            new()
            {
                ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
                Channels =
                [
                    new()
                    {
                        Channel = HistoryListResponseVerificationChannelChannel.Sms,
                        Converted = true,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Delivered = true,
                PhoneNumber = "+33612345678",
                Status = HistoryListResponseVerificationStatus.Converted,
                Attempts = 0,
                ConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Cost = new() { Amount = "0.042", Currency = "EUR" },
                DevicePlatform = HistoryListResponseVerificationDevicePlatform.Android,
                PhoneNumberCondition =
                    HistoryListResponseVerificationPhoneNumberCondition.AllowListed,
                SignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid,
            },
        ];
        string expectedNextCursor =
            "MIZw2XwtkcEcC5SKsMEfSx6a3XAgW-Ct6waU8NCqUkAvFxz41DJbjQIkqHWJS1JY6-it7ZsZHFYN3luFH8yTdCAB";

        Assert.Equal(expectedVerifications.Count, model.Verifications.Count);
        for (int i = 0; i < expectedVerifications.Count; i++)
        {
            Assert.Equal(expectedVerifications[i], model.Verifications[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new HistoryListResponse
        {
            Verifications =
            [
                new()
                {
                    ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
                    Channels =
                    [
                        new()
                        {
                            Channel = HistoryListResponseVerificationChannelChannel.Sms,
                            Converted = true,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Delivered = true,
                    PhoneNumber = "+33612345678",
                    Status = HistoryListResponseVerificationStatus.Converted,
                    Attempts = 0,
                    ConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Cost = new() { Amount = "0.042", Currency = "EUR" },
                    DevicePlatform = HistoryListResponseVerificationDevicePlatform.Android,
                    PhoneNumberCondition =
                        HistoryListResponseVerificationPhoneNumberCondition.AllowListed,
                    SignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid,
                },
            ],
            NextCursor =
                "MIZw2XwtkcEcC5SKsMEfSx6a3XAgW-Ct6waU8NCqUkAvFxz41DJbjQIkqHWJS1JY6-it7ZsZHFYN3luFH8yTdCAB",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HistoryListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new HistoryListResponse
        {
            Verifications =
            [
                new()
                {
                    ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
                    Channels =
                    [
                        new()
                        {
                            Channel = HistoryListResponseVerificationChannelChannel.Sms,
                            Converted = true,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Delivered = true,
                    PhoneNumber = "+33612345678",
                    Status = HistoryListResponseVerificationStatus.Converted,
                    Attempts = 0,
                    ConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Cost = new() { Amount = "0.042", Currency = "EUR" },
                    DevicePlatform = HistoryListResponseVerificationDevicePlatform.Android,
                    PhoneNumberCondition =
                        HistoryListResponseVerificationPhoneNumberCondition.AllowListed,
                    SignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid,
                },
            ],
            NextCursor =
                "MIZw2XwtkcEcC5SKsMEfSx6a3XAgW-Ct6waU8NCqUkAvFxz41DJbjQIkqHWJS1JY6-it7ZsZHFYN3luFH8yTdCAB",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HistoryListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<HistoryListResponseVerification> expectedVerifications =
        [
            new()
            {
                ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
                Channels =
                [
                    new()
                    {
                        Channel = HistoryListResponseVerificationChannelChannel.Sms,
                        Converted = true,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Delivered = true,
                PhoneNumber = "+33612345678",
                Status = HistoryListResponseVerificationStatus.Converted,
                Attempts = 0,
                ConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Cost = new() { Amount = "0.042", Currency = "EUR" },
                DevicePlatform = HistoryListResponseVerificationDevicePlatform.Android,
                PhoneNumberCondition =
                    HistoryListResponseVerificationPhoneNumberCondition.AllowListed,
                SignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid,
            },
        ];
        string expectedNextCursor =
            "MIZw2XwtkcEcC5SKsMEfSx6a3XAgW-Ct6waU8NCqUkAvFxz41DJbjQIkqHWJS1JY6-it7ZsZHFYN3luFH8yTdCAB";

        Assert.Equal(expectedVerifications.Count, deserialized.Verifications.Count);
        for (int i = 0; i < expectedVerifications.Count; i++)
        {
            Assert.Equal(expectedVerifications[i], deserialized.Verifications[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new HistoryListResponse
        {
            Verifications =
            [
                new()
                {
                    ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
                    Channels =
                    [
                        new()
                        {
                            Channel = HistoryListResponseVerificationChannelChannel.Sms,
                            Converted = true,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Delivered = true,
                    PhoneNumber = "+33612345678",
                    Status = HistoryListResponseVerificationStatus.Converted,
                    Attempts = 0,
                    ConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Cost = new() { Amount = "0.042", Currency = "EUR" },
                    DevicePlatform = HistoryListResponseVerificationDevicePlatform.Android,
                    PhoneNumberCondition =
                        HistoryListResponseVerificationPhoneNumberCondition.AllowListed,
                    SignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid,
                },
            ],
            NextCursor =
                "MIZw2XwtkcEcC5SKsMEfSx6a3XAgW-Ct6waU8NCqUkAvFxz41DJbjQIkqHWJS1JY6-it7ZsZHFYN3luFH8yTdCAB",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new HistoryListResponse
        {
            Verifications =
            [
                new()
                {
                    ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
                    Channels =
                    [
                        new()
                        {
                            Channel = HistoryListResponseVerificationChannelChannel.Sms,
                            Converted = true,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Delivered = true,
                    PhoneNumber = "+33612345678",
                    Status = HistoryListResponseVerificationStatus.Converted,
                    Attempts = 0,
                    ConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Cost = new() { Amount = "0.042", Currency = "EUR" },
                    DevicePlatform = HistoryListResponseVerificationDevicePlatform.Android,
                    PhoneNumberCondition =
                        HistoryListResponseVerificationPhoneNumberCondition.AllowListed,
                    SignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid,
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("next_cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new HistoryListResponse
        {
            Verifications =
            [
                new()
                {
                    ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
                    Channels =
                    [
                        new()
                        {
                            Channel = HistoryListResponseVerificationChannelChannel.Sms,
                            Converted = true,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Delivered = true,
                    PhoneNumber = "+33612345678",
                    Status = HistoryListResponseVerificationStatus.Converted,
                    Attempts = 0,
                    ConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Cost = new() { Amount = "0.042", Currency = "EUR" },
                    DevicePlatform = HistoryListResponseVerificationDevicePlatform.Android,
                    PhoneNumberCondition =
                        HistoryListResponseVerificationPhoneNumberCondition.AllowListed,
                    SignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new HistoryListResponse
        {
            Verifications =
            [
                new()
                {
                    ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
                    Channels =
                    [
                        new()
                        {
                            Channel = HistoryListResponseVerificationChannelChannel.Sms,
                            Converted = true,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Delivered = true,
                    PhoneNumber = "+33612345678",
                    Status = HistoryListResponseVerificationStatus.Converted,
                    Attempts = 0,
                    ConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Cost = new() { Amount = "0.042", Currency = "EUR" },
                    DevicePlatform = HistoryListResponseVerificationDevicePlatform.Android,
                    PhoneNumberCondition =
                        HistoryListResponseVerificationPhoneNumberCondition.AllowListed,
                    SignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid,
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
        var model = new HistoryListResponse
        {
            Verifications =
            [
                new()
                {
                    ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
                    Channels =
                    [
                        new()
                        {
                            Channel = HistoryListResponseVerificationChannelChannel.Sms,
                            Converted = true,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Delivered = true,
                    PhoneNumber = "+33612345678",
                    Status = HistoryListResponseVerificationStatus.Converted,
                    Attempts = 0,
                    ConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Cost = new() { Amount = "0.042", Currency = "EUR" },
                    DevicePlatform = HistoryListResponseVerificationDevicePlatform.Android,
                    PhoneNumberCondition =
                        HistoryListResponseVerificationPhoneNumberCondition.AllowListed,
                    SignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid,
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
        var model = new HistoryListResponse
        {
            Verifications =
            [
                new()
                {
                    ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
                    Channels =
                    [
                        new()
                        {
                            Channel = HistoryListResponseVerificationChannelChannel.Sms,
                            Converted = true,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Delivered = true,
                    PhoneNumber = "+33612345678",
                    Status = HistoryListResponseVerificationStatus.Converted,
                    Attempts = 0,
                    ConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Cost = new() { Amount = "0.042", Currency = "EUR" },
                    DevicePlatform = HistoryListResponseVerificationDevicePlatform.Android,
                    PhoneNumberCondition =
                        HistoryListResponseVerificationPhoneNumberCondition.AllowListed,
                    SignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid,
                },
            ],
            NextCursor =
                "MIZw2XwtkcEcC5SKsMEfSx6a3XAgW-Ct6waU8NCqUkAvFxz41DJbjQIkqHWJS1JY6-it7ZsZHFYN3luFH8yTdCAB",
        };

        HistoryListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class HistoryListResponseVerificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new HistoryListResponseVerification
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Channels =
            [
                new()
                {
                    Channel = HistoryListResponseVerificationChannelChannel.Sms,
                    Converted = true,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Delivered = true,
            PhoneNumber = "+33612345678",
            Status = HistoryListResponseVerificationStatus.Converted,
            Attempts = 0,
            ConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = new() { Amount = "0.042", Currency = "EUR" },
            DevicePlatform = HistoryListResponseVerificationDevicePlatform.Android,
            PhoneNumberCondition = HistoryListResponseVerificationPhoneNumberCondition.AllowListed,
            SignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid,
        };

        string expectedID = "vrf_01jc0t6fwwfgfsq1md24mhyztj";
        List<HistoryListResponseVerificationChannel> expectedChannels =
        [
            new() { Channel = HistoryListResponseVerificationChannelChannel.Sms, Converted = true },
        ];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedDelivered = true;
        string expectedPhoneNumber = "+33612345678";
        ApiEnum<string, HistoryListResponseVerificationStatus> expectedStatus =
            HistoryListResponseVerificationStatus.Converted;
        long expectedAttempts = 0;
        DateTimeOffset expectedConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        PhoneVerificationMoney expectedCost = new() { Amount = "0.042", Currency = "EUR" };
        ApiEnum<string, HistoryListResponseVerificationDevicePlatform> expectedDevicePlatform =
            HistoryListResponseVerificationDevicePlatform.Android;
        ApiEnum<
            string,
            HistoryListResponseVerificationPhoneNumberCondition
        > expectedPhoneNumberCondition =
            HistoryListResponseVerificationPhoneNumberCondition.AllowListed;
        ApiEnum<
            string,
            HistoryListResponseVerificationSignalsHashStatus
        > expectedSignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDelivered, model.Delivered);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedAttempts, model.Attempts);
        Assert.Equal(expectedConvertedAt, model.ConvertedAt);
        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedDevicePlatform, model.DevicePlatform);
        Assert.Equal(expectedPhoneNumberCondition, model.PhoneNumberCondition);
        Assert.Equal(expectedSignalsHashStatus, model.SignalsHashStatus);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new HistoryListResponseVerification
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Channels =
            [
                new()
                {
                    Channel = HistoryListResponseVerificationChannelChannel.Sms,
                    Converted = true,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Delivered = true,
            PhoneNumber = "+33612345678",
            Status = HistoryListResponseVerificationStatus.Converted,
            Attempts = 0,
            ConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = new() { Amount = "0.042", Currency = "EUR" },
            DevicePlatform = HistoryListResponseVerificationDevicePlatform.Android,
            PhoneNumberCondition = HistoryListResponseVerificationPhoneNumberCondition.AllowListed,
            SignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HistoryListResponseVerification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new HistoryListResponseVerification
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Channels =
            [
                new()
                {
                    Channel = HistoryListResponseVerificationChannelChannel.Sms,
                    Converted = true,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Delivered = true,
            PhoneNumber = "+33612345678",
            Status = HistoryListResponseVerificationStatus.Converted,
            Attempts = 0,
            ConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = new() { Amount = "0.042", Currency = "EUR" },
            DevicePlatform = HistoryListResponseVerificationDevicePlatform.Android,
            PhoneNumberCondition = HistoryListResponseVerificationPhoneNumberCondition.AllowListed,
            SignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HistoryListResponseVerification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "vrf_01jc0t6fwwfgfsq1md24mhyztj";
        List<HistoryListResponseVerificationChannel> expectedChannels =
        [
            new() { Channel = HistoryListResponseVerificationChannelChannel.Sms, Converted = true },
        ];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedDelivered = true;
        string expectedPhoneNumber = "+33612345678";
        ApiEnum<string, HistoryListResponseVerificationStatus> expectedStatus =
            HistoryListResponseVerificationStatus.Converted;
        long expectedAttempts = 0;
        DateTimeOffset expectedConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        PhoneVerificationMoney expectedCost = new() { Amount = "0.042", Currency = "EUR" };
        ApiEnum<string, HistoryListResponseVerificationDevicePlatform> expectedDevicePlatform =
            HistoryListResponseVerificationDevicePlatform.Android;
        ApiEnum<
            string,
            HistoryListResponseVerificationPhoneNumberCondition
        > expectedPhoneNumberCondition =
            HistoryListResponseVerificationPhoneNumberCondition.AllowListed;
        ApiEnum<
            string,
            HistoryListResponseVerificationSignalsHashStatus
        > expectedSignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDelivered, deserialized.Delivered);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedAttempts, deserialized.Attempts);
        Assert.Equal(expectedConvertedAt, deserialized.ConvertedAt);
        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedDevicePlatform, deserialized.DevicePlatform);
        Assert.Equal(expectedPhoneNumberCondition, deserialized.PhoneNumberCondition);
        Assert.Equal(expectedSignalsHashStatus, deserialized.SignalsHashStatus);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new HistoryListResponseVerification
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Channels =
            [
                new()
                {
                    Channel = HistoryListResponseVerificationChannelChannel.Sms,
                    Converted = true,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Delivered = true,
            PhoneNumber = "+33612345678",
            Status = HistoryListResponseVerificationStatus.Converted,
            Attempts = 0,
            ConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = new() { Amount = "0.042", Currency = "EUR" },
            DevicePlatform = HistoryListResponseVerificationDevicePlatform.Android,
            PhoneNumberCondition = HistoryListResponseVerificationPhoneNumberCondition.AllowListed,
            SignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new HistoryListResponseVerification
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Channels =
            [
                new()
                {
                    Channel = HistoryListResponseVerificationChannelChannel.Sms,
                    Converted = true,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Delivered = true,
            PhoneNumber = "+33612345678",
            Status = HistoryListResponseVerificationStatus.Converted,
        };

        Assert.Null(model.Attempts);
        Assert.False(model.RawData.ContainsKey("attempts"));
        Assert.Null(model.ConvertedAt);
        Assert.False(model.RawData.ContainsKey("converted_at"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.DevicePlatform);
        Assert.False(model.RawData.ContainsKey("device_platform"));
        Assert.Null(model.PhoneNumberCondition);
        Assert.False(model.RawData.ContainsKey("phone_number_condition"));
        Assert.Null(model.SignalsHashStatus);
        Assert.False(model.RawData.ContainsKey("signals_hash_status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new HistoryListResponseVerification
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Channels =
            [
                new()
                {
                    Channel = HistoryListResponseVerificationChannelChannel.Sms,
                    Converted = true,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Delivered = true,
            PhoneNumber = "+33612345678",
            Status = HistoryListResponseVerificationStatus.Converted,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new HistoryListResponseVerification
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Channels =
            [
                new()
                {
                    Channel = HistoryListResponseVerificationChannelChannel.Sms,
                    Converted = true,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Delivered = true,
            PhoneNumber = "+33612345678",
            Status = HistoryListResponseVerificationStatus.Converted,

            // Null should be interpreted as omitted for these properties
            Attempts = null,
            ConvertedAt = null,
            Cost = null,
            DevicePlatform = null,
            PhoneNumberCondition = null,
            SignalsHashStatus = null,
        };

        Assert.Null(model.Attempts);
        Assert.False(model.RawData.ContainsKey("attempts"));
        Assert.Null(model.ConvertedAt);
        Assert.False(model.RawData.ContainsKey("converted_at"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.DevicePlatform);
        Assert.False(model.RawData.ContainsKey("device_platform"));
        Assert.Null(model.PhoneNumberCondition);
        Assert.False(model.RawData.ContainsKey("phone_number_condition"));
        Assert.Null(model.SignalsHashStatus);
        Assert.False(model.RawData.ContainsKey("signals_hash_status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new HistoryListResponseVerification
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Channels =
            [
                new()
                {
                    Channel = HistoryListResponseVerificationChannelChannel.Sms,
                    Converted = true,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Delivered = true,
            PhoneNumber = "+33612345678",
            Status = HistoryListResponseVerificationStatus.Converted,

            // Null should be interpreted as omitted for these properties
            Attempts = null,
            ConvertedAt = null,
            Cost = null,
            DevicePlatform = null,
            PhoneNumberCondition = null,
            SignalsHashStatus = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new HistoryListResponseVerification
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            Channels =
            [
                new()
                {
                    Channel = HistoryListResponseVerificationChannelChannel.Sms,
                    Converted = true,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Delivered = true,
            PhoneNumber = "+33612345678",
            Status = HistoryListResponseVerificationStatus.Converted,
            Attempts = 0,
            ConvertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = new() { Amount = "0.042", Currency = "EUR" },
            DevicePlatform = HistoryListResponseVerificationDevicePlatform.Android,
            PhoneNumberCondition = HistoryListResponseVerificationPhoneNumberCondition.AllowListed,
            SignalsHashStatus = HistoryListResponseVerificationSignalsHashStatus.Valid,
        };

        HistoryListResponseVerification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class HistoryListResponseVerificationChannelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new HistoryListResponseVerificationChannel
        {
            Channel = HistoryListResponseVerificationChannelChannel.Sms,
            Converted = true,
        };

        ApiEnum<string, HistoryListResponseVerificationChannelChannel> expectedChannel =
            HistoryListResponseVerificationChannelChannel.Sms;
        bool expectedConverted = true;

        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedConverted, model.Converted);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new HistoryListResponseVerificationChannel
        {
            Channel = HistoryListResponseVerificationChannelChannel.Sms,
            Converted = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HistoryListResponseVerificationChannel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new HistoryListResponseVerificationChannel
        {
            Channel = HistoryListResponseVerificationChannelChannel.Sms,
            Converted = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HistoryListResponseVerificationChannel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, HistoryListResponseVerificationChannelChannel> expectedChannel =
            HistoryListResponseVerificationChannelChannel.Sms;
        bool expectedConverted = true;

        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedConverted, deserialized.Converted);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new HistoryListResponseVerificationChannel
        {
            Channel = HistoryListResponseVerificationChannelChannel.Sms,
            Converted = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new HistoryListResponseVerificationChannel
        {
            Channel = HistoryListResponseVerificationChannelChannel.Sms,
            Converted = true,
        };

        HistoryListResponseVerificationChannel copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class HistoryListResponseVerificationChannelChannelTest : TestBase
{
    [Theory]
    [InlineData(HistoryListResponseVerificationChannelChannel.Sms)]
    [InlineData(HistoryListResponseVerificationChannelChannel.Rcs)]
    [InlineData(HistoryListResponseVerificationChannelChannel.Whatsapp)]
    [InlineData(HistoryListResponseVerificationChannelChannel.Viber)]
    [InlineData(HistoryListResponseVerificationChannelChannel.Zalo)]
    [InlineData(HistoryListResponseVerificationChannelChannel.Telegram)]
    [InlineData(HistoryListResponseVerificationChannelChannel.Voice)]
    [InlineData(HistoryListResponseVerificationChannelChannel.Silent)]
    public void Validation_Works(HistoryListResponseVerificationChannelChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, HistoryListResponseVerificationChannelChannel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationChannelChannel>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(HistoryListResponseVerificationChannelChannel.Sms)]
    [InlineData(HistoryListResponseVerificationChannelChannel.Rcs)]
    [InlineData(HistoryListResponseVerificationChannelChannel.Whatsapp)]
    [InlineData(HistoryListResponseVerificationChannelChannel.Viber)]
    [InlineData(HistoryListResponseVerificationChannelChannel.Zalo)]
    [InlineData(HistoryListResponseVerificationChannelChannel.Telegram)]
    [InlineData(HistoryListResponseVerificationChannelChannel.Voice)]
    [InlineData(HistoryListResponseVerificationChannelChannel.Silent)]
    public void SerializationRoundtrip_Works(HistoryListResponseVerificationChannelChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, HistoryListResponseVerificationChannelChannel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationChannelChannel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationChannelChannel>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationChannelChannel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class HistoryListResponseVerificationStatusTest : TestBase
{
    [Theory]
    [InlineData(HistoryListResponseVerificationStatus.Converted)]
    [InlineData(HistoryListResponseVerificationStatus.NotConverted)]
    [InlineData(HistoryListResponseVerificationStatus.PendingCheck)]
    [InlineData(HistoryListResponseVerificationStatus.Sent)]
    [InlineData(HistoryListResponseVerificationStatus.Challenged)]
    [InlineData(HistoryListResponseVerificationStatus.SuspectedFraud)]
    [InlineData(HistoryListResponseVerificationStatus.InBlocklist)]
    [InlineData(HistoryListResponseVerificationStatus.InvalidLine)]
    [InlineData(HistoryListResponseVerificationStatus.InvalidNumber)]
    [InlineData(HistoryListResponseVerificationStatus.RateLimited)]
    [InlineData(HistoryListResponseVerificationStatus.ExpiredSignals)]
    [InlineData(HistoryListResponseVerificationStatus.Shadowed)]
    public void Validation_Works(HistoryListResponseVerificationStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, HistoryListResponseVerificationStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(HistoryListResponseVerificationStatus.Converted)]
    [InlineData(HistoryListResponseVerificationStatus.NotConverted)]
    [InlineData(HistoryListResponseVerificationStatus.PendingCheck)]
    [InlineData(HistoryListResponseVerificationStatus.Sent)]
    [InlineData(HistoryListResponseVerificationStatus.Challenged)]
    [InlineData(HistoryListResponseVerificationStatus.SuspectedFraud)]
    [InlineData(HistoryListResponseVerificationStatus.InBlocklist)]
    [InlineData(HistoryListResponseVerificationStatus.InvalidLine)]
    [InlineData(HistoryListResponseVerificationStatus.InvalidNumber)]
    [InlineData(HistoryListResponseVerificationStatus.RateLimited)]
    [InlineData(HistoryListResponseVerificationStatus.ExpiredSignals)]
    [InlineData(HistoryListResponseVerificationStatus.Shadowed)]
    public void SerializationRoundtrip_Works(HistoryListResponseVerificationStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, HistoryListResponseVerificationStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class HistoryListResponseVerificationDevicePlatformTest : TestBase
{
    [Theory]
    [InlineData(HistoryListResponseVerificationDevicePlatform.Android)]
    [InlineData(HistoryListResponseVerificationDevicePlatform.Ios)]
    [InlineData(HistoryListResponseVerificationDevicePlatform.Ipados)]
    [InlineData(HistoryListResponseVerificationDevicePlatform.Tvos)]
    [InlineData(HistoryListResponseVerificationDevicePlatform.Web)]
    public void Validation_Works(HistoryListResponseVerificationDevicePlatform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, HistoryListResponseVerificationDevicePlatform> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationDevicePlatform>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(HistoryListResponseVerificationDevicePlatform.Android)]
    [InlineData(HistoryListResponseVerificationDevicePlatform.Ios)]
    [InlineData(HistoryListResponseVerificationDevicePlatform.Ipados)]
    [InlineData(HistoryListResponseVerificationDevicePlatform.Tvos)]
    [InlineData(HistoryListResponseVerificationDevicePlatform.Web)]
    public void SerializationRoundtrip_Works(HistoryListResponseVerificationDevicePlatform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, HistoryListResponseVerificationDevicePlatform> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationDevicePlatform>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationDevicePlatform>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationDevicePlatform>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class HistoryListResponseVerificationPhoneNumberConditionTest : TestBase
{
    [Theory]
    [InlineData(HistoryListResponseVerificationPhoneNumberCondition.AllowListed)]
    [InlineData(HistoryListResponseVerificationPhoneNumberCondition.BlockListed)]
    [InlineData(HistoryListResponseVerificationPhoneNumberCondition.Sandboxed)]
    public void Validation_Works(HistoryListResponseVerificationPhoneNumberCondition rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, HistoryListResponseVerificationPhoneNumberCondition> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationPhoneNumberCondition>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(HistoryListResponseVerificationPhoneNumberCondition.AllowListed)]
    [InlineData(HistoryListResponseVerificationPhoneNumberCondition.BlockListed)]
    [InlineData(HistoryListResponseVerificationPhoneNumberCondition.Sandboxed)]
    public void SerializationRoundtrip_Works(
        HistoryListResponseVerificationPhoneNumberCondition rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, HistoryListResponseVerificationPhoneNumberCondition> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationPhoneNumberCondition>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationPhoneNumberCondition>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationPhoneNumberCondition>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class HistoryListResponseVerificationSignalsHashStatusTest : TestBase
{
    [Theory]
    [InlineData(HistoryListResponseVerificationSignalsHashStatus.Valid)]
    [InlineData(HistoryListResponseVerificationSignalsHashStatus.Invalid)]
    public void Validation_Works(HistoryListResponseVerificationSignalsHashStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, HistoryListResponseVerificationSignalsHashStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationSignalsHashStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(HistoryListResponseVerificationSignalsHashStatus.Valid)]
    [InlineData(HistoryListResponseVerificationSignalsHashStatus.Invalid)]
    public void SerializationRoundtrip_Works(
        HistoryListResponseVerificationSignalsHashStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, HistoryListResponseVerificationSignalsHashStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationSignalsHashStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationSignalsHashStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, HistoryListResponseVerificationSignalsHashStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
