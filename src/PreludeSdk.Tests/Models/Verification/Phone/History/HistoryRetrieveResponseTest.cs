using System;
using System.Collections.Generic;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using History = PreludeSdk.Models.Verification.Phone.History;

namespace PreludeSdk.Tests.Models.Verification.Phone.History;

public class HistoryRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new History::HistoryRetrieveResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+33612345678",
            Status = History::HistoryRetrieveResponseStatus.Converted,
            AppVersion = "app_version",
            BlockReasons = [History::BlockReason.BehavioralPattern],
            Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
            CorrelationID = "correlation_id",
            DeviceModel = "iPhone15,2",
            DevicePlatform = History::HistoryRetrieveResponseDevicePlatform.Android,
            IPAddress = "ip_address",
            IPAddressRegion = "FR",
            IPDistanceMeters = 0,
            Lifecycle = new()
            {
                Events =
                [
                    new()
                    {
                        Type = History::Type.Create,
                        Attempt = new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                            Channel = History::AttemptChannel.Sms,
                            Content = "content",
                            Cost = new() { Amount = "0.042", Currency = "EUR" },
                            DeliveryEvents =
                            [
                                new()
                                {
                                    ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    Status = History::DeliveryEventStatus.Unknown,
                                },
                            ],
                            DeliveryStatus = History::DeliveryStatus.Unknown,
                            PreferredChannel = History::PreferredChannel.Sms,
                            Status = History::AttemptStatus.Succeeded,
                            Trigger = History::Trigger.Initial,
                        },
                        Check = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IsValid = true,
                            Channel = History::CheckChannel.Sms,
                            Psd2Info = new()
                            {
                                ExpectedTransaction = new()
                                {
                                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                                    Recipient = "recipient",
                                },
                                ReceivedTransaction = new()
                                {
                                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                                    Recipient = "recipient",
                                },
                            },
                            StatusDetail = History::StatusDetail.ExpiredAttempt,
                            Value = "value",
                        },
                        Create = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Cost = new() { Amount = "0.042", Currency = "EUR" },
                        },
                        Signals = new()
                        {
                            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Status = History::SignalsStatus.Valid,
                        },
                    },
                ],
                TotalCost = new() { Amount = "0.042", Currency = "EUR" },
                UndeliverableRouteCount = 0,
            },
            PhoneNumberCondition = History::PhoneNumberCondition.AllowListed,
            PhoneNumberCurrentCondition = History::PhoneNumberCurrentCondition.AllowListed,
            PhoneNumberRegion = "FR",
            Signals = new()
            {
                IsTrustedUser = true,
                DeviceID = "device_id",
                Ja4Fingerprint = "ja4_fingerprint",
                OsVersion = "os_version",
                UserAgent = "user_agent",
            },
            SignalsHashStatus = History::SignalsHashStatus.Valid,
            TemplateID = "template_id",
        };

        string expectedID = "vrf_01jc0t6fwwfgfsq1md24mhyztj";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPhoneNumber = "+33612345678";
        ApiEnum<string, History::HistoryRetrieveResponseStatus> expectedStatus =
            History::HistoryRetrieveResponseStatus.Converted;
        string expectedAppVersion = "app_version";
        List<ApiEnum<string, History::BlockReason>> expectedBlockReasons =
        [
            History::BlockReason.BehavioralPattern,
        ];
        History::PhoneVerificationCarrier expectedCarrier = new()
        {
            Mccmnc = "208-01",
            Name = "Orange",
        };
        string expectedCorrelationID = "correlation_id";
        string expectedDeviceModel = "iPhone15,2";
        ApiEnum<string, History::HistoryRetrieveResponseDevicePlatform> expectedDevicePlatform =
            History::HistoryRetrieveResponseDevicePlatform.Android;
        string expectedIPAddress = "ip_address";
        string expectedIPAddressRegion = "FR";
        long expectedIPDistanceMeters = 0;
        History::Lifecycle expectedLifecycle = new()
        {
            Events =
            [
                new()
                {
                    Type = History::Type.Create,
                    Attempt = new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                        Channel = History::AttemptChannel.Sms,
                        Content = "content",
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                        DeliveryEvents =
                        [
                            new()
                            {
                                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Status = History::DeliveryEventStatus.Unknown,
                            },
                        ],
                        DeliveryStatus = History::DeliveryStatus.Unknown,
                        PreferredChannel = History::PreferredChannel.Sms,
                        Status = History::AttemptStatus.Succeeded,
                        Trigger = History::Trigger.Initial,
                    },
                    Check = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsValid = true,
                        Channel = History::CheckChannel.Sms,
                        Psd2Info = new()
                        {
                            ExpectedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                            ReceivedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                        },
                        StatusDetail = History::StatusDetail.ExpiredAttempt,
                        Value = "value",
                    },
                    Create = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                    },
                    Signals = new()
                    {
                        ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = History::SignalsStatus.Valid,
                    },
                },
            ],
            TotalCost = new() { Amount = "0.042", Currency = "EUR" },
            UndeliverableRouteCount = 0,
        };
        ApiEnum<string, History::PhoneNumberCondition> expectedPhoneNumberCondition =
            History::PhoneNumberCondition.AllowListed;
        ApiEnum<string, History::PhoneNumberCurrentCondition> expectedPhoneNumberCurrentCondition =
            History::PhoneNumberCurrentCondition.AllowListed;
        string expectedPhoneNumberRegion = "FR";
        History::HistoryRetrieveResponseSignals expectedSignals = new()
        {
            IsTrustedUser = true,
            DeviceID = "device_id",
            Ja4Fingerprint = "ja4_fingerprint",
            OsVersion = "os_version",
            UserAgent = "user_agent",
        };
        ApiEnum<string, History::SignalsHashStatus> expectedSignalsHashStatus =
            History::SignalsHashStatus.Valid;
        string expectedTemplateID = "template_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedAppVersion, model.AppVersion);
        Assert.NotNull(model.BlockReasons);
        Assert.Equal(expectedBlockReasons.Count, model.BlockReasons.Count);
        for (int i = 0; i < expectedBlockReasons.Count; i++)
        {
            Assert.Equal(expectedBlockReasons[i], model.BlockReasons[i]);
        }
        Assert.Equal(expectedCarrier, model.Carrier);
        Assert.Equal(expectedCorrelationID, model.CorrelationID);
        Assert.Equal(expectedDeviceModel, model.DeviceModel);
        Assert.Equal(expectedDevicePlatform, model.DevicePlatform);
        Assert.Equal(expectedIPAddress, model.IPAddress);
        Assert.Equal(expectedIPAddressRegion, model.IPAddressRegion);
        Assert.Equal(expectedIPDistanceMeters, model.IPDistanceMeters);
        Assert.Equal(expectedLifecycle, model.Lifecycle);
        Assert.Equal(expectedPhoneNumberCondition, model.PhoneNumberCondition);
        Assert.Equal(expectedPhoneNumberCurrentCondition, model.PhoneNumberCurrentCondition);
        Assert.Equal(expectedPhoneNumberRegion, model.PhoneNumberRegion);
        Assert.Equal(expectedSignals, model.Signals);
        Assert.Equal(expectedSignalsHashStatus, model.SignalsHashStatus);
        Assert.Equal(expectedTemplateID, model.TemplateID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new History::HistoryRetrieveResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+33612345678",
            Status = History::HistoryRetrieveResponseStatus.Converted,
            AppVersion = "app_version",
            BlockReasons = [History::BlockReason.BehavioralPattern],
            Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
            CorrelationID = "correlation_id",
            DeviceModel = "iPhone15,2",
            DevicePlatform = History::HistoryRetrieveResponseDevicePlatform.Android,
            IPAddress = "ip_address",
            IPAddressRegion = "FR",
            IPDistanceMeters = 0,
            Lifecycle = new()
            {
                Events =
                [
                    new()
                    {
                        Type = History::Type.Create,
                        Attempt = new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                            Channel = History::AttemptChannel.Sms,
                            Content = "content",
                            Cost = new() { Amount = "0.042", Currency = "EUR" },
                            DeliveryEvents =
                            [
                                new()
                                {
                                    ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    Status = History::DeliveryEventStatus.Unknown,
                                },
                            ],
                            DeliveryStatus = History::DeliveryStatus.Unknown,
                            PreferredChannel = History::PreferredChannel.Sms,
                            Status = History::AttemptStatus.Succeeded,
                            Trigger = History::Trigger.Initial,
                        },
                        Check = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IsValid = true,
                            Channel = History::CheckChannel.Sms,
                            Psd2Info = new()
                            {
                                ExpectedTransaction = new()
                                {
                                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                                    Recipient = "recipient",
                                },
                                ReceivedTransaction = new()
                                {
                                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                                    Recipient = "recipient",
                                },
                            },
                            StatusDetail = History::StatusDetail.ExpiredAttempt,
                            Value = "value",
                        },
                        Create = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Cost = new() { Amount = "0.042", Currency = "EUR" },
                        },
                        Signals = new()
                        {
                            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Status = History::SignalsStatus.Valid,
                        },
                    },
                ],
                TotalCost = new() { Amount = "0.042", Currency = "EUR" },
                UndeliverableRouteCount = 0,
            },
            PhoneNumberCondition = History::PhoneNumberCondition.AllowListed,
            PhoneNumberCurrentCondition = History::PhoneNumberCurrentCondition.AllowListed,
            PhoneNumberRegion = "FR",
            Signals = new()
            {
                IsTrustedUser = true,
                DeviceID = "device_id",
                Ja4Fingerprint = "ja4_fingerprint",
                OsVersion = "os_version",
                UserAgent = "user_agent",
            },
            SignalsHashStatus = History::SignalsHashStatus.Valid,
            TemplateID = "template_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::HistoryRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new History::HistoryRetrieveResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+33612345678",
            Status = History::HistoryRetrieveResponseStatus.Converted,
            AppVersion = "app_version",
            BlockReasons = [History::BlockReason.BehavioralPattern],
            Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
            CorrelationID = "correlation_id",
            DeviceModel = "iPhone15,2",
            DevicePlatform = History::HistoryRetrieveResponseDevicePlatform.Android,
            IPAddress = "ip_address",
            IPAddressRegion = "FR",
            IPDistanceMeters = 0,
            Lifecycle = new()
            {
                Events =
                [
                    new()
                    {
                        Type = History::Type.Create,
                        Attempt = new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                            Channel = History::AttemptChannel.Sms,
                            Content = "content",
                            Cost = new() { Amount = "0.042", Currency = "EUR" },
                            DeliveryEvents =
                            [
                                new()
                                {
                                    ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    Status = History::DeliveryEventStatus.Unknown,
                                },
                            ],
                            DeliveryStatus = History::DeliveryStatus.Unknown,
                            PreferredChannel = History::PreferredChannel.Sms,
                            Status = History::AttemptStatus.Succeeded,
                            Trigger = History::Trigger.Initial,
                        },
                        Check = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IsValid = true,
                            Channel = History::CheckChannel.Sms,
                            Psd2Info = new()
                            {
                                ExpectedTransaction = new()
                                {
                                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                                    Recipient = "recipient",
                                },
                                ReceivedTransaction = new()
                                {
                                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                                    Recipient = "recipient",
                                },
                            },
                            StatusDetail = History::StatusDetail.ExpiredAttempt,
                            Value = "value",
                        },
                        Create = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Cost = new() { Amount = "0.042", Currency = "EUR" },
                        },
                        Signals = new()
                        {
                            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Status = History::SignalsStatus.Valid,
                        },
                    },
                ],
                TotalCost = new() { Amount = "0.042", Currency = "EUR" },
                UndeliverableRouteCount = 0,
            },
            PhoneNumberCondition = History::PhoneNumberCondition.AllowListed,
            PhoneNumberCurrentCondition = History::PhoneNumberCurrentCondition.AllowListed,
            PhoneNumberRegion = "FR",
            Signals = new()
            {
                IsTrustedUser = true,
                DeviceID = "device_id",
                Ja4Fingerprint = "ja4_fingerprint",
                OsVersion = "os_version",
                UserAgent = "user_agent",
            },
            SignalsHashStatus = History::SignalsHashStatus.Valid,
            TemplateID = "template_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::HistoryRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "vrf_01jc0t6fwwfgfsq1md24mhyztj";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPhoneNumber = "+33612345678";
        ApiEnum<string, History::HistoryRetrieveResponseStatus> expectedStatus =
            History::HistoryRetrieveResponseStatus.Converted;
        string expectedAppVersion = "app_version";
        List<ApiEnum<string, History::BlockReason>> expectedBlockReasons =
        [
            History::BlockReason.BehavioralPattern,
        ];
        History::PhoneVerificationCarrier expectedCarrier = new()
        {
            Mccmnc = "208-01",
            Name = "Orange",
        };
        string expectedCorrelationID = "correlation_id";
        string expectedDeviceModel = "iPhone15,2";
        ApiEnum<string, History::HistoryRetrieveResponseDevicePlatform> expectedDevicePlatform =
            History::HistoryRetrieveResponseDevicePlatform.Android;
        string expectedIPAddress = "ip_address";
        string expectedIPAddressRegion = "FR";
        long expectedIPDistanceMeters = 0;
        History::Lifecycle expectedLifecycle = new()
        {
            Events =
            [
                new()
                {
                    Type = History::Type.Create,
                    Attempt = new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                        Channel = History::AttemptChannel.Sms,
                        Content = "content",
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                        DeliveryEvents =
                        [
                            new()
                            {
                                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Status = History::DeliveryEventStatus.Unknown,
                            },
                        ],
                        DeliveryStatus = History::DeliveryStatus.Unknown,
                        PreferredChannel = History::PreferredChannel.Sms,
                        Status = History::AttemptStatus.Succeeded,
                        Trigger = History::Trigger.Initial,
                    },
                    Check = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsValid = true,
                        Channel = History::CheckChannel.Sms,
                        Psd2Info = new()
                        {
                            ExpectedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                            ReceivedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                        },
                        StatusDetail = History::StatusDetail.ExpiredAttempt,
                        Value = "value",
                    },
                    Create = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                    },
                    Signals = new()
                    {
                        ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = History::SignalsStatus.Valid,
                    },
                },
            ],
            TotalCost = new() { Amount = "0.042", Currency = "EUR" },
            UndeliverableRouteCount = 0,
        };
        ApiEnum<string, History::PhoneNumberCondition> expectedPhoneNumberCondition =
            History::PhoneNumberCondition.AllowListed;
        ApiEnum<string, History::PhoneNumberCurrentCondition> expectedPhoneNumberCurrentCondition =
            History::PhoneNumberCurrentCondition.AllowListed;
        string expectedPhoneNumberRegion = "FR";
        History::HistoryRetrieveResponseSignals expectedSignals = new()
        {
            IsTrustedUser = true,
            DeviceID = "device_id",
            Ja4Fingerprint = "ja4_fingerprint",
            OsVersion = "os_version",
            UserAgent = "user_agent",
        };
        ApiEnum<string, History::SignalsHashStatus> expectedSignalsHashStatus =
            History::SignalsHashStatus.Valid;
        string expectedTemplateID = "template_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedAppVersion, deserialized.AppVersion);
        Assert.NotNull(deserialized.BlockReasons);
        Assert.Equal(expectedBlockReasons.Count, deserialized.BlockReasons.Count);
        for (int i = 0; i < expectedBlockReasons.Count; i++)
        {
            Assert.Equal(expectedBlockReasons[i], deserialized.BlockReasons[i]);
        }
        Assert.Equal(expectedCarrier, deserialized.Carrier);
        Assert.Equal(expectedCorrelationID, deserialized.CorrelationID);
        Assert.Equal(expectedDeviceModel, deserialized.DeviceModel);
        Assert.Equal(expectedDevicePlatform, deserialized.DevicePlatform);
        Assert.Equal(expectedIPAddress, deserialized.IPAddress);
        Assert.Equal(expectedIPAddressRegion, deserialized.IPAddressRegion);
        Assert.Equal(expectedIPDistanceMeters, deserialized.IPDistanceMeters);
        Assert.Equal(expectedLifecycle, deserialized.Lifecycle);
        Assert.Equal(expectedPhoneNumberCondition, deserialized.PhoneNumberCondition);
        Assert.Equal(expectedPhoneNumberCurrentCondition, deserialized.PhoneNumberCurrentCondition);
        Assert.Equal(expectedPhoneNumberRegion, deserialized.PhoneNumberRegion);
        Assert.Equal(expectedSignals, deserialized.Signals);
        Assert.Equal(expectedSignalsHashStatus, deserialized.SignalsHashStatus);
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new History::HistoryRetrieveResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+33612345678",
            Status = History::HistoryRetrieveResponseStatus.Converted,
            AppVersion = "app_version",
            BlockReasons = [History::BlockReason.BehavioralPattern],
            Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
            CorrelationID = "correlation_id",
            DeviceModel = "iPhone15,2",
            DevicePlatform = History::HistoryRetrieveResponseDevicePlatform.Android,
            IPAddress = "ip_address",
            IPAddressRegion = "FR",
            IPDistanceMeters = 0,
            Lifecycle = new()
            {
                Events =
                [
                    new()
                    {
                        Type = History::Type.Create,
                        Attempt = new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                            Channel = History::AttemptChannel.Sms,
                            Content = "content",
                            Cost = new() { Amount = "0.042", Currency = "EUR" },
                            DeliveryEvents =
                            [
                                new()
                                {
                                    ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    Status = History::DeliveryEventStatus.Unknown,
                                },
                            ],
                            DeliveryStatus = History::DeliveryStatus.Unknown,
                            PreferredChannel = History::PreferredChannel.Sms,
                            Status = History::AttemptStatus.Succeeded,
                            Trigger = History::Trigger.Initial,
                        },
                        Check = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IsValid = true,
                            Channel = History::CheckChannel.Sms,
                            Psd2Info = new()
                            {
                                ExpectedTransaction = new()
                                {
                                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                                    Recipient = "recipient",
                                },
                                ReceivedTransaction = new()
                                {
                                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                                    Recipient = "recipient",
                                },
                            },
                            StatusDetail = History::StatusDetail.ExpiredAttempt,
                            Value = "value",
                        },
                        Create = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Cost = new() { Amount = "0.042", Currency = "EUR" },
                        },
                        Signals = new()
                        {
                            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Status = History::SignalsStatus.Valid,
                        },
                    },
                ],
                TotalCost = new() { Amount = "0.042", Currency = "EUR" },
                UndeliverableRouteCount = 0,
            },
            PhoneNumberCondition = History::PhoneNumberCondition.AllowListed,
            PhoneNumberCurrentCondition = History::PhoneNumberCurrentCondition.AllowListed,
            PhoneNumberRegion = "FR",
            Signals = new()
            {
                IsTrustedUser = true,
                DeviceID = "device_id",
                Ja4Fingerprint = "ja4_fingerprint",
                OsVersion = "os_version",
                UserAgent = "user_agent",
            },
            SignalsHashStatus = History::SignalsHashStatus.Valid,
            TemplateID = "template_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new History::HistoryRetrieveResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+33612345678",
            Status = History::HistoryRetrieveResponseStatus.Converted,
        };

        Assert.Null(model.AppVersion);
        Assert.False(model.RawData.ContainsKey("app_version"));
        Assert.Null(model.BlockReasons);
        Assert.False(model.RawData.ContainsKey("block_reasons"));
        Assert.Null(model.Carrier);
        Assert.False(model.RawData.ContainsKey("carrier"));
        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
        Assert.Null(model.DeviceModel);
        Assert.False(model.RawData.ContainsKey("device_model"));
        Assert.Null(model.DevicePlatform);
        Assert.False(model.RawData.ContainsKey("device_platform"));
        Assert.Null(model.IPAddress);
        Assert.False(model.RawData.ContainsKey("ip_address"));
        Assert.Null(model.IPAddressRegion);
        Assert.False(model.RawData.ContainsKey("ip_address_region"));
        Assert.Null(model.IPDistanceMeters);
        Assert.False(model.RawData.ContainsKey("ip_distance_meters"));
        Assert.Null(model.Lifecycle);
        Assert.False(model.RawData.ContainsKey("lifecycle"));
        Assert.Null(model.PhoneNumberCondition);
        Assert.False(model.RawData.ContainsKey("phone_number_condition"));
        Assert.Null(model.PhoneNumberCurrentCondition);
        Assert.False(model.RawData.ContainsKey("phone_number_current_condition"));
        Assert.Null(model.PhoneNumberRegion);
        Assert.False(model.RawData.ContainsKey("phone_number_region"));
        Assert.Null(model.Signals);
        Assert.False(model.RawData.ContainsKey("signals"));
        Assert.Null(model.SignalsHashStatus);
        Assert.False(model.RawData.ContainsKey("signals_hash_status"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("template_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new History::HistoryRetrieveResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+33612345678",
            Status = History::HistoryRetrieveResponseStatus.Converted,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new History::HistoryRetrieveResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+33612345678",
            Status = History::HistoryRetrieveResponseStatus.Converted,

            // Null should be interpreted as omitted for these properties
            AppVersion = null,
            BlockReasons = null,
            Carrier = null,
            CorrelationID = null,
            DeviceModel = null,
            DevicePlatform = null,
            IPAddress = null,
            IPAddressRegion = null,
            IPDistanceMeters = null,
            Lifecycle = null,
            PhoneNumberCondition = null,
            PhoneNumberCurrentCondition = null,
            PhoneNumberRegion = null,
            Signals = null,
            SignalsHashStatus = null,
            TemplateID = null,
        };

        Assert.Null(model.AppVersion);
        Assert.False(model.RawData.ContainsKey("app_version"));
        Assert.Null(model.BlockReasons);
        Assert.False(model.RawData.ContainsKey("block_reasons"));
        Assert.Null(model.Carrier);
        Assert.False(model.RawData.ContainsKey("carrier"));
        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
        Assert.Null(model.DeviceModel);
        Assert.False(model.RawData.ContainsKey("device_model"));
        Assert.Null(model.DevicePlatform);
        Assert.False(model.RawData.ContainsKey("device_platform"));
        Assert.Null(model.IPAddress);
        Assert.False(model.RawData.ContainsKey("ip_address"));
        Assert.Null(model.IPAddressRegion);
        Assert.False(model.RawData.ContainsKey("ip_address_region"));
        Assert.Null(model.IPDistanceMeters);
        Assert.False(model.RawData.ContainsKey("ip_distance_meters"));
        Assert.Null(model.Lifecycle);
        Assert.False(model.RawData.ContainsKey("lifecycle"));
        Assert.Null(model.PhoneNumberCondition);
        Assert.False(model.RawData.ContainsKey("phone_number_condition"));
        Assert.Null(model.PhoneNumberCurrentCondition);
        Assert.False(model.RawData.ContainsKey("phone_number_current_condition"));
        Assert.Null(model.PhoneNumberRegion);
        Assert.False(model.RawData.ContainsKey("phone_number_region"));
        Assert.Null(model.Signals);
        Assert.False(model.RawData.ContainsKey("signals"));
        Assert.Null(model.SignalsHashStatus);
        Assert.False(model.RawData.ContainsKey("signals_hash_status"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("template_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new History::HistoryRetrieveResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+33612345678",
            Status = History::HistoryRetrieveResponseStatus.Converted,

            // Null should be interpreted as omitted for these properties
            AppVersion = null,
            BlockReasons = null,
            Carrier = null,
            CorrelationID = null,
            DeviceModel = null,
            DevicePlatform = null,
            IPAddress = null,
            IPAddressRegion = null,
            IPDistanceMeters = null,
            Lifecycle = null,
            PhoneNumberCondition = null,
            PhoneNumberCurrentCondition = null,
            PhoneNumberRegion = null,
            Signals = null,
            SignalsHashStatus = null,
            TemplateID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new History::HistoryRetrieveResponse
        {
            ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+33612345678",
            Status = History::HistoryRetrieveResponseStatus.Converted,
            AppVersion = "app_version",
            BlockReasons = [History::BlockReason.BehavioralPattern],
            Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
            CorrelationID = "correlation_id",
            DeviceModel = "iPhone15,2",
            DevicePlatform = History::HistoryRetrieveResponseDevicePlatform.Android,
            IPAddress = "ip_address",
            IPAddressRegion = "FR",
            IPDistanceMeters = 0,
            Lifecycle = new()
            {
                Events =
                [
                    new()
                    {
                        Type = History::Type.Create,
                        Attempt = new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                            Channel = History::AttemptChannel.Sms,
                            Content = "content",
                            Cost = new() { Amount = "0.042", Currency = "EUR" },
                            DeliveryEvents =
                            [
                                new()
                                {
                                    ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    Status = History::DeliveryEventStatus.Unknown,
                                },
                            ],
                            DeliveryStatus = History::DeliveryStatus.Unknown,
                            PreferredChannel = History::PreferredChannel.Sms,
                            Status = History::AttemptStatus.Succeeded,
                            Trigger = History::Trigger.Initial,
                        },
                        Check = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IsValid = true,
                            Channel = History::CheckChannel.Sms,
                            Psd2Info = new()
                            {
                                ExpectedTransaction = new()
                                {
                                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                                    Recipient = "recipient",
                                },
                                ReceivedTransaction = new()
                                {
                                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                                    Recipient = "recipient",
                                },
                            },
                            StatusDetail = History::StatusDetail.ExpiredAttempt,
                            Value = "value",
                        },
                        Create = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Cost = new() { Amount = "0.042", Currency = "EUR" },
                        },
                        Signals = new()
                        {
                            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Status = History::SignalsStatus.Valid,
                        },
                    },
                ],
                TotalCost = new() { Amount = "0.042", Currency = "EUR" },
                UndeliverableRouteCount = 0,
            },
            PhoneNumberCondition = History::PhoneNumberCondition.AllowListed,
            PhoneNumberCurrentCondition = History::PhoneNumberCurrentCondition.AllowListed,
            PhoneNumberRegion = "FR",
            Signals = new()
            {
                IsTrustedUser = true,
                DeviceID = "device_id",
                Ja4Fingerprint = "ja4_fingerprint",
                OsVersion = "os_version",
                UserAgent = "user_agent",
            },
            SignalsHashStatus = History::SignalsHashStatus.Valid,
            TemplateID = "template_id",
        };

        History::HistoryRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class HistoryRetrieveResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(History::HistoryRetrieveResponseStatus.Converted)]
    [InlineData(History::HistoryRetrieveResponseStatus.NotConverted)]
    [InlineData(History::HistoryRetrieveResponseStatus.PendingCheck)]
    [InlineData(History::HistoryRetrieveResponseStatus.Sent)]
    [InlineData(History::HistoryRetrieveResponseStatus.Challenged)]
    [InlineData(History::HistoryRetrieveResponseStatus.SuspectedFraud)]
    [InlineData(History::HistoryRetrieveResponseStatus.InBlocklist)]
    [InlineData(History::HistoryRetrieveResponseStatus.InvalidLine)]
    [InlineData(History::HistoryRetrieveResponseStatus.InvalidNumber)]
    [InlineData(History::HistoryRetrieveResponseStatus.RateLimited)]
    [InlineData(History::HistoryRetrieveResponseStatus.ExpiredSignals)]
    [InlineData(History::HistoryRetrieveResponseStatus.Shadowed)]
    public void Validation_Works(History::HistoryRetrieveResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::HistoryRetrieveResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, History::HistoryRetrieveResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(History::HistoryRetrieveResponseStatus.Converted)]
    [InlineData(History::HistoryRetrieveResponseStatus.NotConverted)]
    [InlineData(History::HistoryRetrieveResponseStatus.PendingCheck)]
    [InlineData(History::HistoryRetrieveResponseStatus.Sent)]
    [InlineData(History::HistoryRetrieveResponseStatus.Challenged)]
    [InlineData(History::HistoryRetrieveResponseStatus.SuspectedFraud)]
    [InlineData(History::HistoryRetrieveResponseStatus.InBlocklist)]
    [InlineData(History::HistoryRetrieveResponseStatus.InvalidLine)]
    [InlineData(History::HistoryRetrieveResponseStatus.InvalidNumber)]
    [InlineData(History::HistoryRetrieveResponseStatus.RateLimited)]
    [InlineData(History::HistoryRetrieveResponseStatus.ExpiredSignals)]
    [InlineData(History::HistoryRetrieveResponseStatus.Shadowed)]
    public void SerializationRoundtrip_Works(History::HistoryRetrieveResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::HistoryRetrieveResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, History::HistoryRetrieveResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, History::HistoryRetrieveResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, History::HistoryRetrieveResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BlockReasonTest : TestBase
{
    [Theory]
    [InlineData(History::BlockReason.BehavioralPattern)]
    [InlineData(History::BlockReason.DeviceAttribute)]
    [InlineData(History::BlockReason.FraudDatabase)]
    [InlineData(History::BlockReason.LocationDiscrepancy)]
    [InlineData(History::BlockReason.MissingSignals)]
    [InlineData(History::BlockReason.NetworkFingerprint)]
    [InlineData(History::BlockReason.PoorConversionHistory)]
    [InlineData(History::BlockReason.PrefixConcentration)]
    [InlineData(History::BlockReason.RepeatedNumber)]
    [InlineData(History::BlockReason.SuspectedRequestTampering)]
    [InlineData(History::BlockReason.SuspiciousIPAddress)]
    [InlineData(History::BlockReason.TemporaryPhoneNumber)]
    public void Validation_Works(History::BlockReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::BlockReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::BlockReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(History::BlockReason.BehavioralPattern)]
    [InlineData(History::BlockReason.DeviceAttribute)]
    [InlineData(History::BlockReason.FraudDatabase)]
    [InlineData(History::BlockReason.LocationDiscrepancy)]
    [InlineData(History::BlockReason.MissingSignals)]
    [InlineData(History::BlockReason.NetworkFingerprint)]
    [InlineData(History::BlockReason.PoorConversionHistory)]
    [InlineData(History::BlockReason.PrefixConcentration)]
    [InlineData(History::BlockReason.RepeatedNumber)]
    [InlineData(History::BlockReason.SuspectedRequestTampering)]
    [InlineData(History::BlockReason.SuspiciousIPAddress)]
    [InlineData(History::BlockReason.TemporaryPhoneNumber)]
    public void SerializationRoundtrip_Works(History::BlockReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::BlockReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::BlockReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::BlockReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::BlockReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class HistoryRetrieveResponseDevicePlatformTest : TestBase
{
    [Theory]
    [InlineData(History::HistoryRetrieveResponseDevicePlatform.Android)]
    [InlineData(History::HistoryRetrieveResponseDevicePlatform.Ios)]
    [InlineData(History::HistoryRetrieveResponseDevicePlatform.Ipados)]
    [InlineData(History::HistoryRetrieveResponseDevicePlatform.Tvos)]
    [InlineData(History::HistoryRetrieveResponseDevicePlatform.Web)]
    public void Validation_Works(History::HistoryRetrieveResponseDevicePlatform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::HistoryRetrieveResponseDevicePlatform> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, History::HistoryRetrieveResponseDevicePlatform>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(History::HistoryRetrieveResponseDevicePlatform.Android)]
    [InlineData(History::HistoryRetrieveResponseDevicePlatform.Ios)]
    [InlineData(History::HistoryRetrieveResponseDevicePlatform.Ipados)]
    [InlineData(History::HistoryRetrieveResponseDevicePlatform.Tvos)]
    [InlineData(History::HistoryRetrieveResponseDevicePlatform.Web)]
    public void SerializationRoundtrip_Works(
        History::HistoryRetrieveResponseDevicePlatform rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::HistoryRetrieveResponseDevicePlatform> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, History::HistoryRetrieveResponseDevicePlatform>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, History::HistoryRetrieveResponseDevicePlatform>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, History::HistoryRetrieveResponseDevicePlatform>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class LifecycleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new History::Lifecycle
        {
            Events =
            [
                new()
                {
                    Type = History::Type.Create,
                    Attempt = new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                        Channel = History::AttemptChannel.Sms,
                        Content = "content",
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                        DeliveryEvents =
                        [
                            new()
                            {
                                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Status = History::DeliveryEventStatus.Unknown,
                            },
                        ],
                        DeliveryStatus = History::DeliveryStatus.Unknown,
                        PreferredChannel = History::PreferredChannel.Sms,
                        Status = History::AttemptStatus.Succeeded,
                        Trigger = History::Trigger.Initial,
                    },
                    Check = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsValid = true,
                        Channel = History::CheckChannel.Sms,
                        Psd2Info = new()
                        {
                            ExpectedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                            ReceivedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                        },
                        StatusDetail = History::StatusDetail.ExpiredAttempt,
                        Value = "value",
                    },
                    Create = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                    },
                    Signals = new()
                    {
                        ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = History::SignalsStatus.Valid,
                    },
                },
            ],
            TotalCost = new() { Amount = "0.042", Currency = "EUR" },
            UndeliverableRouteCount = 0,
        };

        List<History::Event> expectedEvents =
        [
            new()
            {
                Type = History::Type.Create,
                Attempt = new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                    Channel = History::AttemptChannel.Sms,
                    Content = "content",
                    Cost = new() { Amount = "0.042", Currency = "EUR" },
                    DeliveryEvents =
                    [
                        new()
                        {
                            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Status = History::DeliveryEventStatus.Unknown,
                        },
                    ],
                    DeliveryStatus = History::DeliveryStatus.Unknown,
                    PreferredChannel = History::PreferredChannel.Sms,
                    Status = History::AttemptStatus.Succeeded,
                    Trigger = History::Trigger.Initial,
                },
                Check = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsValid = true,
                    Channel = History::CheckChannel.Sms,
                    Psd2Info = new()
                    {
                        ExpectedTransaction = new()
                        {
                            Amount = new() { Amount = "0.042", Currency = "EUR" },
                            Recipient = "recipient",
                        },
                        ReceivedTransaction = new()
                        {
                            Amount = new() { Amount = "0.042", Currency = "EUR" },
                            Recipient = "recipient",
                        },
                    },
                    StatusDetail = History::StatusDetail.ExpiredAttempt,
                    Value = "value",
                },
                Create = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Cost = new() { Amount = "0.042", Currency = "EUR" },
                },
                Signals = new()
                {
                    ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = History::SignalsStatus.Valid,
                },
            },
        ];
        History::PhoneVerificationMoney expectedTotalCost = new()
        {
            Amount = "0.042",
            Currency = "EUR",
        };
        long expectedUndeliverableRouteCount = 0;

        Assert.Equal(expectedEvents.Count, model.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], model.Events[i]);
        }
        Assert.Equal(expectedTotalCost, model.TotalCost);
        Assert.Equal(expectedUndeliverableRouteCount, model.UndeliverableRouteCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new History::Lifecycle
        {
            Events =
            [
                new()
                {
                    Type = History::Type.Create,
                    Attempt = new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                        Channel = History::AttemptChannel.Sms,
                        Content = "content",
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                        DeliveryEvents =
                        [
                            new()
                            {
                                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Status = History::DeliveryEventStatus.Unknown,
                            },
                        ],
                        DeliveryStatus = History::DeliveryStatus.Unknown,
                        PreferredChannel = History::PreferredChannel.Sms,
                        Status = History::AttemptStatus.Succeeded,
                        Trigger = History::Trigger.Initial,
                    },
                    Check = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsValid = true,
                        Channel = History::CheckChannel.Sms,
                        Psd2Info = new()
                        {
                            ExpectedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                            ReceivedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                        },
                        StatusDetail = History::StatusDetail.ExpiredAttempt,
                        Value = "value",
                    },
                    Create = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                    },
                    Signals = new()
                    {
                        ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = History::SignalsStatus.Valid,
                    },
                },
            ],
            TotalCost = new() { Amount = "0.042", Currency = "EUR" },
            UndeliverableRouteCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::Lifecycle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new History::Lifecycle
        {
            Events =
            [
                new()
                {
                    Type = History::Type.Create,
                    Attempt = new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                        Channel = History::AttemptChannel.Sms,
                        Content = "content",
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                        DeliveryEvents =
                        [
                            new()
                            {
                                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Status = History::DeliveryEventStatus.Unknown,
                            },
                        ],
                        DeliveryStatus = History::DeliveryStatus.Unknown,
                        PreferredChannel = History::PreferredChannel.Sms,
                        Status = History::AttemptStatus.Succeeded,
                        Trigger = History::Trigger.Initial,
                    },
                    Check = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsValid = true,
                        Channel = History::CheckChannel.Sms,
                        Psd2Info = new()
                        {
                            ExpectedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                            ReceivedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                        },
                        StatusDetail = History::StatusDetail.ExpiredAttempt,
                        Value = "value",
                    },
                    Create = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                    },
                    Signals = new()
                    {
                        ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = History::SignalsStatus.Valid,
                    },
                },
            ],
            TotalCost = new() { Amount = "0.042", Currency = "EUR" },
            UndeliverableRouteCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::Lifecycle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<History::Event> expectedEvents =
        [
            new()
            {
                Type = History::Type.Create,
                Attempt = new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                    Channel = History::AttemptChannel.Sms,
                    Content = "content",
                    Cost = new() { Amount = "0.042", Currency = "EUR" },
                    DeliveryEvents =
                    [
                        new()
                        {
                            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Status = History::DeliveryEventStatus.Unknown,
                        },
                    ],
                    DeliveryStatus = History::DeliveryStatus.Unknown,
                    PreferredChannel = History::PreferredChannel.Sms,
                    Status = History::AttemptStatus.Succeeded,
                    Trigger = History::Trigger.Initial,
                },
                Check = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsValid = true,
                    Channel = History::CheckChannel.Sms,
                    Psd2Info = new()
                    {
                        ExpectedTransaction = new()
                        {
                            Amount = new() { Amount = "0.042", Currency = "EUR" },
                            Recipient = "recipient",
                        },
                        ReceivedTransaction = new()
                        {
                            Amount = new() { Amount = "0.042", Currency = "EUR" },
                            Recipient = "recipient",
                        },
                    },
                    StatusDetail = History::StatusDetail.ExpiredAttempt,
                    Value = "value",
                },
                Create = new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Cost = new() { Amount = "0.042", Currency = "EUR" },
                },
                Signals = new()
                {
                    ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = History::SignalsStatus.Valid,
                },
            },
        ];
        History::PhoneVerificationMoney expectedTotalCost = new()
        {
            Amount = "0.042",
            Currency = "EUR",
        };
        long expectedUndeliverableRouteCount = 0;

        Assert.Equal(expectedEvents.Count, deserialized.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], deserialized.Events[i]);
        }
        Assert.Equal(expectedTotalCost, deserialized.TotalCost);
        Assert.Equal(expectedUndeliverableRouteCount, deserialized.UndeliverableRouteCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new History::Lifecycle
        {
            Events =
            [
                new()
                {
                    Type = History::Type.Create,
                    Attempt = new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                        Channel = History::AttemptChannel.Sms,
                        Content = "content",
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                        DeliveryEvents =
                        [
                            new()
                            {
                                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Status = History::DeliveryEventStatus.Unknown,
                            },
                        ],
                        DeliveryStatus = History::DeliveryStatus.Unknown,
                        PreferredChannel = History::PreferredChannel.Sms,
                        Status = History::AttemptStatus.Succeeded,
                        Trigger = History::Trigger.Initial,
                    },
                    Check = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsValid = true,
                        Channel = History::CheckChannel.Sms,
                        Psd2Info = new()
                        {
                            ExpectedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                            ReceivedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                        },
                        StatusDetail = History::StatusDetail.ExpiredAttempt,
                        Value = "value",
                    },
                    Create = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                    },
                    Signals = new()
                    {
                        ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = History::SignalsStatus.Valid,
                    },
                },
            ],
            TotalCost = new() { Amount = "0.042", Currency = "EUR" },
            UndeliverableRouteCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new History::Lifecycle
        {
            Events =
            [
                new()
                {
                    Type = History::Type.Create,
                    Attempt = new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                        Channel = History::AttemptChannel.Sms,
                        Content = "content",
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                        DeliveryEvents =
                        [
                            new()
                            {
                                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Status = History::DeliveryEventStatus.Unknown,
                            },
                        ],
                        DeliveryStatus = History::DeliveryStatus.Unknown,
                        PreferredChannel = History::PreferredChannel.Sms,
                        Status = History::AttemptStatus.Succeeded,
                        Trigger = History::Trigger.Initial,
                    },
                    Check = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsValid = true,
                        Channel = History::CheckChannel.Sms,
                        Psd2Info = new()
                        {
                            ExpectedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                            ReceivedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                        },
                        StatusDetail = History::StatusDetail.ExpiredAttempt,
                        Value = "value",
                    },
                    Create = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                    },
                    Signals = new()
                    {
                        ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = History::SignalsStatus.Valid,
                    },
                },
            ],
        };

        Assert.Null(model.TotalCost);
        Assert.False(model.RawData.ContainsKey("total_cost"));
        Assert.Null(model.UndeliverableRouteCount);
        Assert.False(model.RawData.ContainsKey("undeliverable_route_count"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new History::Lifecycle
        {
            Events =
            [
                new()
                {
                    Type = History::Type.Create,
                    Attempt = new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                        Channel = History::AttemptChannel.Sms,
                        Content = "content",
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                        DeliveryEvents =
                        [
                            new()
                            {
                                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Status = History::DeliveryEventStatus.Unknown,
                            },
                        ],
                        DeliveryStatus = History::DeliveryStatus.Unknown,
                        PreferredChannel = History::PreferredChannel.Sms,
                        Status = History::AttemptStatus.Succeeded,
                        Trigger = History::Trigger.Initial,
                    },
                    Check = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsValid = true,
                        Channel = History::CheckChannel.Sms,
                        Psd2Info = new()
                        {
                            ExpectedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                            ReceivedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                        },
                        StatusDetail = History::StatusDetail.ExpiredAttempt,
                        Value = "value",
                    },
                    Create = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                    },
                    Signals = new()
                    {
                        ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = History::SignalsStatus.Valid,
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new History::Lifecycle
        {
            Events =
            [
                new()
                {
                    Type = History::Type.Create,
                    Attempt = new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                        Channel = History::AttemptChannel.Sms,
                        Content = "content",
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                        DeliveryEvents =
                        [
                            new()
                            {
                                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Status = History::DeliveryEventStatus.Unknown,
                            },
                        ],
                        DeliveryStatus = History::DeliveryStatus.Unknown,
                        PreferredChannel = History::PreferredChannel.Sms,
                        Status = History::AttemptStatus.Succeeded,
                        Trigger = History::Trigger.Initial,
                    },
                    Check = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsValid = true,
                        Channel = History::CheckChannel.Sms,
                        Psd2Info = new()
                        {
                            ExpectedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                            ReceivedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                        },
                        StatusDetail = History::StatusDetail.ExpiredAttempt,
                        Value = "value",
                    },
                    Create = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                    },
                    Signals = new()
                    {
                        ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = History::SignalsStatus.Valid,
                    },
                },
            ],

            // Null should be interpreted as omitted for these properties
            TotalCost = null,
            UndeliverableRouteCount = null,
        };

        Assert.Null(model.TotalCost);
        Assert.False(model.RawData.ContainsKey("total_cost"));
        Assert.Null(model.UndeliverableRouteCount);
        Assert.False(model.RawData.ContainsKey("undeliverable_route_count"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new History::Lifecycle
        {
            Events =
            [
                new()
                {
                    Type = History::Type.Create,
                    Attempt = new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                        Channel = History::AttemptChannel.Sms,
                        Content = "content",
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                        DeliveryEvents =
                        [
                            new()
                            {
                                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Status = History::DeliveryEventStatus.Unknown,
                            },
                        ],
                        DeliveryStatus = History::DeliveryStatus.Unknown,
                        PreferredChannel = History::PreferredChannel.Sms,
                        Status = History::AttemptStatus.Succeeded,
                        Trigger = History::Trigger.Initial,
                    },
                    Check = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsValid = true,
                        Channel = History::CheckChannel.Sms,
                        Psd2Info = new()
                        {
                            ExpectedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                            ReceivedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                        },
                        StatusDetail = History::StatusDetail.ExpiredAttempt,
                        Value = "value",
                    },
                    Create = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                    },
                    Signals = new()
                    {
                        ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = History::SignalsStatus.Valid,
                    },
                },
            ],

            // Null should be interpreted as omitted for these properties
            TotalCost = null,
            UndeliverableRouteCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new History::Lifecycle
        {
            Events =
            [
                new()
                {
                    Type = History::Type.Create,
                    Attempt = new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                        Channel = History::AttemptChannel.Sms,
                        Content = "content",
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                        DeliveryEvents =
                        [
                            new()
                            {
                                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Status = History::DeliveryEventStatus.Unknown,
                            },
                        ],
                        DeliveryStatus = History::DeliveryStatus.Unknown,
                        PreferredChannel = History::PreferredChannel.Sms,
                        Status = History::AttemptStatus.Succeeded,
                        Trigger = History::Trigger.Initial,
                    },
                    Check = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsValid = true,
                        Channel = History::CheckChannel.Sms,
                        Psd2Info = new()
                        {
                            ExpectedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                            ReceivedTransaction = new()
                            {
                                Amount = new() { Amount = "0.042", Currency = "EUR" },
                                Recipient = "recipient",
                            },
                        },
                        StatusDetail = History::StatusDetail.ExpiredAttempt,
                        Value = "value",
                    },
                    Create = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Cost = new() { Amount = "0.042", Currency = "EUR" },
                    },
                    Signals = new()
                    {
                        ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = History::SignalsStatus.Valid,
                    },
                },
            ],
            TotalCost = new() { Amount = "0.042", Currency = "EUR" },
            UndeliverableRouteCount = 0,
        };

        History::Lifecycle copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new History::Event
        {
            Type = History::Type.Create,
            Attempt = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                Channel = History::AttemptChannel.Sms,
                Content = "content",
                Cost = new() { Amount = "0.042", Currency = "EUR" },
                DeliveryEvents =
                [
                    new()
                    {
                        ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = History::DeliveryEventStatus.Unknown,
                    },
                ],
                DeliveryStatus = History::DeliveryStatus.Unknown,
                PreferredChannel = History::PreferredChannel.Sms,
                Status = History::AttemptStatus.Succeeded,
                Trigger = History::Trigger.Initial,
            },
            Check = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsValid = true,
                Channel = History::CheckChannel.Sms,
                Psd2Info = new()
                {
                    ExpectedTransaction = new()
                    {
                        Amount = new() { Amount = "0.042", Currency = "EUR" },
                        Recipient = "recipient",
                    },
                    ReceivedTransaction = new()
                    {
                        Amount = new() { Amount = "0.042", Currency = "EUR" },
                        Recipient = "recipient",
                    },
                },
                StatusDetail = History::StatusDetail.ExpiredAttempt,
                Value = "value",
            },
            Create = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Cost = new() { Amount = "0.042", Currency = "EUR" },
            },
            Signals = new()
            {
                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = History::SignalsStatus.Valid,
            },
        };

        ApiEnum<string, History::Type> expectedType = History::Type.Create;
        History::Attempt expectedAttempt = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
            Channel = History::AttemptChannel.Sms,
            Content = "content",
            Cost = new() { Amount = "0.042", Currency = "EUR" },
            DeliveryEvents =
            [
                new()
                {
                    ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = History::DeliveryEventStatus.Unknown,
                },
            ],
            DeliveryStatus = History::DeliveryStatus.Unknown,
            PreferredChannel = History::PreferredChannel.Sms,
            Status = History::AttemptStatus.Succeeded,
            Trigger = History::Trigger.Initial,
        };
        History::Check expectedCheck = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsValid = true,
            Channel = History::CheckChannel.Sms,
            Psd2Info = new()
            {
                ExpectedTransaction = new()
                {
                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                    Recipient = "recipient",
                },
                ReceivedTransaction = new()
                {
                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                    Recipient = "recipient",
                },
            },
            StatusDetail = History::StatusDetail.ExpiredAttempt,
            Value = "value",
        };
        History::Create expectedCreate = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = new() { Amount = "0.042", Currency = "EUR" },
        };
        History::Signals expectedSignals = new()
        {
            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = History::SignalsStatus.Valid,
        };

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedAttempt, model.Attempt);
        Assert.Equal(expectedCheck, model.Check);
        Assert.Equal(expectedCreate, model.Create);
        Assert.Equal(expectedSignals, model.Signals);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new History::Event
        {
            Type = History::Type.Create,
            Attempt = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                Channel = History::AttemptChannel.Sms,
                Content = "content",
                Cost = new() { Amount = "0.042", Currency = "EUR" },
                DeliveryEvents =
                [
                    new()
                    {
                        ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = History::DeliveryEventStatus.Unknown,
                    },
                ],
                DeliveryStatus = History::DeliveryStatus.Unknown,
                PreferredChannel = History::PreferredChannel.Sms,
                Status = History::AttemptStatus.Succeeded,
                Trigger = History::Trigger.Initial,
            },
            Check = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsValid = true,
                Channel = History::CheckChannel.Sms,
                Psd2Info = new()
                {
                    ExpectedTransaction = new()
                    {
                        Amount = new() { Amount = "0.042", Currency = "EUR" },
                        Recipient = "recipient",
                    },
                    ReceivedTransaction = new()
                    {
                        Amount = new() { Amount = "0.042", Currency = "EUR" },
                        Recipient = "recipient",
                    },
                },
                StatusDetail = History::StatusDetail.ExpiredAttempt,
                Value = "value",
            },
            Create = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Cost = new() { Amount = "0.042", Currency = "EUR" },
            },
            Signals = new()
            {
                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = History::SignalsStatus.Valid,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::Event>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new History::Event
        {
            Type = History::Type.Create,
            Attempt = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                Channel = History::AttemptChannel.Sms,
                Content = "content",
                Cost = new() { Amount = "0.042", Currency = "EUR" },
                DeliveryEvents =
                [
                    new()
                    {
                        ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = History::DeliveryEventStatus.Unknown,
                    },
                ],
                DeliveryStatus = History::DeliveryStatus.Unknown,
                PreferredChannel = History::PreferredChannel.Sms,
                Status = History::AttemptStatus.Succeeded,
                Trigger = History::Trigger.Initial,
            },
            Check = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsValid = true,
                Channel = History::CheckChannel.Sms,
                Psd2Info = new()
                {
                    ExpectedTransaction = new()
                    {
                        Amount = new() { Amount = "0.042", Currency = "EUR" },
                        Recipient = "recipient",
                    },
                    ReceivedTransaction = new()
                    {
                        Amount = new() { Amount = "0.042", Currency = "EUR" },
                        Recipient = "recipient",
                    },
                },
                StatusDetail = History::StatusDetail.ExpiredAttempt,
                Value = "value",
            },
            Create = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Cost = new() { Amount = "0.042", Currency = "EUR" },
            },
            Signals = new()
            {
                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = History::SignalsStatus.Valid,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::Event>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, History::Type> expectedType = History::Type.Create;
        History::Attempt expectedAttempt = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
            Channel = History::AttemptChannel.Sms,
            Content = "content",
            Cost = new() { Amount = "0.042", Currency = "EUR" },
            DeliveryEvents =
            [
                new()
                {
                    ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = History::DeliveryEventStatus.Unknown,
                },
            ],
            DeliveryStatus = History::DeliveryStatus.Unknown,
            PreferredChannel = History::PreferredChannel.Sms,
            Status = History::AttemptStatus.Succeeded,
            Trigger = History::Trigger.Initial,
        };
        History::Check expectedCheck = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsValid = true,
            Channel = History::CheckChannel.Sms,
            Psd2Info = new()
            {
                ExpectedTransaction = new()
                {
                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                    Recipient = "recipient",
                },
                ReceivedTransaction = new()
                {
                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                    Recipient = "recipient",
                },
            },
            StatusDetail = History::StatusDetail.ExpiredAttempt,
            Value = "value",
        };
        History::Create expectedCreate = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = new() { Amount = "0.042", Currency = "EUR" },
        };
        History::Signals expectedSignals = new()
        {
            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = History::SignalsStatus.Valid,
        };

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedAttempt, deserialized.Attempt);
        Assert.Equal(expectedCheck, deserialized.Check);
        Assert.Equal(expectedCreate, deserialized.Create);
        Assert.Equal(expectedSignals, deserialized.Signals);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new History::Event
        {
            Type = History::Type.Create,
            Attempt = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                Channel = History::AttemptChannel.Sms,
                Content = "content",
                Cost = new() { Amount = "0.042", Currency = "EUR" },
                DeliveryEvents =
                [
                    new()
                    {
                        ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = History::DeliveryEventStatus.Unknown,
                    },
                ],
                DeliveryStatus = History::DeliveryStatus.Unknown,
                PreferredChannel = History::PreferredChannel.Sms,
                Status = History::AttemptStatus.Succeeded,
                Trigger = History::Trigger.Initial,
            },
            Check = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsValid = true,
                Channel = History::CheckChannel.Sms,
                Psd2Info = new()
                {
                    ExpectedTransaction = new()
                    {
                        Amount = new() { Amount = "0.042", Currency = "EUR" },
                        Recipient = "recipient",
                    },
                    ReceivedTransaction = new()
                    {
                        Amount = new() { Amount = "0.042", Currency = "EUR" },
                        Recipient = "recipient",
                    },
                },
                StatusDetail = History::StatusDetail.ExpiredAttempt,
                Value = "value",
            },
            Create = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Cost = new() { Amount = "0.042", Currency = "EUR" },
            },
            Signals = new()
            {
                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = History::SignalsStatus.Valid,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new History::Event { Type = History::Type.Create };

        Assert.Null(model.Attempt);
        Assert.False(model.RawData.ContainsKey("attempt"));
        Assert.Null(model.Check);
        Assert.False(model.RawData.ContainsKey("check"));
        Assert.Null(model.Create);
        Assert.False(model.RawData.ContainsKey("create"));
        Assert.Null(model.Signals);
        Assert.False(model.RawData.ContainsKey("signals"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new History::Event { Type = History::Type.Create };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new History::Event
        {
            Type = History::Type.Create,

            // Null should be interpreted as omitted for these properties
            Attempt = null,
            Check = null,
            Create = null,
            Signals = null,
        };

        Assert.Null(model.Attempt);
        Assert.False(model.RawData.ContainsKey("attempt"));
        Assert.Null(model.Check);
        Assert.False(model.RawData.ContainsKey("check"));
        Assert.Null(model.Create);
        Assert.False(model.RawData.ContainsKey("create"));
        Assert.Null(model.Signals);
        Assert.False(model.RawData.ContainsKey("signals"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new History::Event
        {
            Type = History::Type.Create,

            // Null should be interpreted as omitted for these properties
            Attempt = null,
            Check = null,
            Create = null,
            Signals = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new History::Event
        {
            Type = History::Type.Create,
            Attempt = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
                Channel = History::AttemptChannel.Sms,
                Content = "content",
                Cost = new() { Amount = "0.042", Currency = "EUR" },
                DeliveryEvents =
                [
                    new()
                    {
                        ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Status = History::DeliveryEventStatus.Unknown,
                    },
                ],
                DeliveryStatus = History::DeliveryStatus.Unknown,
                PreferredChannel = History::PreferredChannel.Sms,
                Status = History::AttemptStatus.Succeeded,
                Trigger = History::Trigger.Initial,
            },
            Check = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsValid = true,
                Channel = History::CheckChannel.Sms,
                Psd2Info = new()
                {
                    ExpectedTransaction = new()
                    {
                        Amount = new() { Amount = "0.042", Currency = "EUR" },
                        Recipient = "recipient",
                    },
                    ReceivedTransaction = new()
                    {
                        Amount = new() { Amount = "0.042", Currency = "EUR" },
                        Recipient = "recipient",
                    },
                },
                StatusDetail = History::StatusDetail.ExpiredAttempt,
                Value = "value",
            },
            Create = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Cost = new() { Amount = "0.042", Currency = "EUR" },
            },
            Signals = new()
            {
                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = History::SignalsStatus.Valid,
            },
        };

        History::Event copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(History::Type.Create)]
    [InlineData(History::Type.Attempt)]
    [InlineData(History::Type.Check)]
    [InlineData(History::Type.Signals)]
    public void Validation_Works(History::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(History::Type.Create)]
    [InlineData(History::Type.Attempt)]
    [InlineData(History::Type.Check)]
    [InlineData(History::Type.Signals)]
    public void SerializationRoundtrip_Works(History::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AttemptTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new History::Attempt
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
            Channel = History::AttemptChannel.Sms,
            Content = "content",
            Cost = new() { Amount = "0.042", Currency = "EUR" },
            DeliveryEvents =
            [
                new()
                {
                    ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = History::DeliveryEventStatus.Unknown,
                },
            ],
            DeliveryStatus = History::DeliveryStatus.Unknown,
            PreferredChannel = History::PreferredChannel.Sms,
            Status = History::AttemptStatus.Succeeded,
            Trigger = History::Trigger.Initial,
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        History::PhoneVerificationCarrier expectedCarrier = new()
        {
            Mccmnc = "208-01",
            Name = "Orange",
        };
        ApiEnum<string, History::AttemptChannel> expectedChannel = History::AttemptChannel.Sms;
        string expectedContent = "content";
        History::PhoneVerificationMoney expectedCost = new() { Amount = "0.042", Currency = "EUR" };
        List<History::DeliveryEvent> expectedDeliveryEvents =
        [
            new()
            {
                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = History::DeliveryEventStatus.Unknown,
            },
        ];
        ApiEnum<string, History::DeliveryStatus> expectedDeliveryStatus =
            History::DeliveryStatus.Unknown;
        ApiEnum<string, History::PreferredChannel> expectedPreferredChannel =
            History::PreferredChannel.Sms;
        ApiEnum<string, History::AttemptStatus> expectedStatus = History::AttemptStatus.Succeeded;
        ApiEnum<string, History::Trigger> expectedTrigger = History::Trigger.Initial;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCarrier, model.Carrier);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedCost, model.Cost);
        Assert.NotNull(model.DeliveryEvents);
        Assert.Equal(expectedDeliveryEvents.Count, model.DeliveryEvents.Count);
        for (int i = 0; i < expectedDeliveryEvents.Count; i++)
        {
            Assert.Equal(expectedDeliveryEvents[i], model.DeliveryEvents[i]);
        }
        Assert.Equal(expectedDeliveryStatus, model.DeliveryStatus);
        Assert.Equal(expectedPreferredChannel, model.PreferredChannel);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTrigger, model.Trigger);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new History::Attempt
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
            Channel = History::AttemptChannel.Sms,
            Content = "content",
            Cost = new() { Amount = "0.042", Currency = "EUR" },
            DeliveryEvents =
            [
                new()
                {
                    ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = History::DeliveryEventStatus.Unknown,
                },
            ],
            DeliveryStatus = History::DeliveryStatus.Unknown,
            PreferredChannel = History::PreferredChannel.Sms,
            Status = History::AttemptStatus.Succeeded,
            Trigger = History::Trigger.Initial,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::Attempt>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new History::Attempt
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
            Channel = History::AttemptChannel.Sms,
            Content = "content",
            Cost = new() { Amount = "0.042", Currency = "EUR" },
            DeliveryEvents =
            [
                new()
                {
                    ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = History::DeliveryEventStatus.Unknown,
                },
            ],
            DeliveryStatus = History::DeliveryStatus.Unknown,
            PreferredChannel = History::PreferredChannel.Sms,
            Status = History::AttemptStatus.Succeeded,
            Trigger = History::Trigger.Initial,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::Attempt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        History::PhoneVerificationCarrier expectedCarrier = new()
        {
            Mccmnc = "208-01",
            Name = "Orange",
        };
        ApiEnum<string, History::AttemptChannel> expectedChannel = History::AttemptChannel.Sms;
        string expectedContent = "content";
        History::PhoneVerificationMoney expectedCost = new() { Amount = "0.042", Currency = "EUR" };
        List<History::DeliveryEvent> expectedDeliveryEvents =
        [
            new()
            {
                ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = History::DeliveryEventStatus.Unknown,
            },
        ];
        ApiEnum<string, History::DeliveryStatus> expectedDeliveryStatus =
            History::DeliveryStatus.Unknown;
        ApiEnum<string, History::PreferredChannel> expectedPreferredChannel =
            History::PreferredChannel.Sms;
        ApiEnum<string, History::AttemptStatus> expectedStatus = History::AttemptStatus.Succeeded;
        ApiEnum<string, History::Trigger> expectedTrigger = History::Trigger.Initial;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCarrier, deserialized.Carrier);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.NotNull(deserialized.DeliveryEvents);
        Assert.Equal(expectedDeliveryEvents.Count, deserialized.DeliveryEvents.Count);
        for (int i = 0; i < expectedDeliveryEvents.Count; i++)
        {
            Assert.Equal(expectedDeliveryEvents[i], deserialized.DeliveryEvents[i]);
        }
        Assert.Equal(expectedDeliveryStatus, deserialized.DeliveryStatus);
        Assert.Equal(expectedPreferredChannel, deserialized.PreferredChannel);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTrigger, deserialized.Trigger);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new History::Attempt
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
            Channel = History::AttemptChannel.Sms,
            Content = "content",
            Cost = new() { Amount = "0.042", Currency = "EUR" },
            DeliveryEvents =
            [
                new()
                {
                    ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = History::DeliveryEventStatus.Unknown,
                },
            ],
            DeliveryStatus = History::DeliveryStatus.Unknown,
            PreferredChannel = History::PreferredChannel.Sms,
            Status = History::AttemptStatus.Succeeded,
            Trigger = History::Trigger.Initial,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new History::Attempt
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Carrier);
        Assert.False(model.RawData.ContainsKey("carrier"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.DeliveryEvents);
        Assert.False(model.RawData.ContainsKey("delivery_events"));
        Assert.Null(model.DeliveryStatus);
        Assert.False(model.RawData.ContainsKey("delivery_status"));
        Assert.Null(model.PreferredChannel);
        Assert.False(model.RawData.ContainsKey("preferred_channel"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Trigger);
        Assert.False(model.RawData.ContainsKey("trigger"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new History::Attempt
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new History::Attempt
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Carrier = null,
            Channel = null,
            Content = null,
            Cost = null,
            DeliveryEvents = null,
            DeliveryStatus = null,
            PreferredChannel = null,
            Status = null,
            Trigger = null,
        };

        Assert.Null(model.Carrier);
        Assert.False(model.RawData.ContainsKey("carrier"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.DeliveryEvents);
        Assert.False(model.RawData.ContainsKey("delivery_events"));
        Assert.Null(model.DeliveryStatus);
        Assert.False(model.RawData.ContainsKey("delivery_status"));
        Assert.Null(model.PreferredChannel);
        Assert.False(model.RawData.ContainsKey("preferred_channel"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Trigger);
        Assert.False(model.RawData.ContainsKey("trigger"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new History::Attempt
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Carrier = null,
            Channel = null,
            Content = null,
            Cost = null,
            DeliveryEvents = null,
            DeliveryStatus = null,
            PreferredChannel = null,
            Status = null,
            Trigger = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new History::Attempt
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Carrier = new() { Mccmnc = "208-01", Name = "Orange" },
            Channel = History::AttemptChannel.Sms,
            Content = "content",
            Cost = new() { Amount = "0.042", Currency = "EUR" },
            DeliveryEvents =
            [
                new()
                {
                    ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = History::DeliveryEventStatus.Unknown,
                },
            ],
            DeliveryStatus = History::DeliveryStatus.Unknown,
            PreferredChannel = History::PreferredChannel.Sms,
            Status = History::AttemptStatus.Succeeded,
            Trigger = History::Trigger.Initial,
        };

        History::Attempt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AttemptChannelTest : TestBase
{
    [Theory]
    [InlineData(History::AttemptChannel.Sms)]
    [InlineData(History::AttemptChannel.Rcs)]
    [InlineData(History::AttemptChannel.Whatsapp)]
    [InlineData(History::AttemptChannel.Viber)]
    [InlineData(History::AttemptChannel.Zalo)]
    [InlineData(History::AttemptChannel.Telegram)]
    [InlineData(History::AttemptChannel.Voice)]
    [InlineData(History::AttemptChannel.Silent)]
    public void Validation_Works(History::AttemptChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::AttemptChannel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::AttemptChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(History::AttemptChannel.Sms)]
    [InlineData(History::AttemptChannel.Rcs)]
    [InlineData(History::AttemptChannel.Whatsapp)]
    [InlineData(History::AttemptChannel.Viber)]
    [InlineData(History::AttemptChannel.Zalo)]
    [InlineData(History::AttemptChannel.Telegram)]
    [InlineData(History::AttemptChannel.Voice)]
    [InlineData(History::AttemptChannel.Silent)]
    public void SerializationRoundtrip_Works(History::AttemptChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::AttemptChannel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::AttemptChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::AttemptChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::AttemptChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DeliveryEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new History::DeliveryEvent
        {
            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = History::DeliveryEventStatus.Unknown,
        };

        DateTimeOffset expectedReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, History::DeliveryEventStatus> expectedStatus =
            History::DeliveryEventStatus.Unknown;

        Assert.Equal(expectedReceivedAt, model.ReceivedAt);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new History::DeliveryEvent
        {
            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = History::DeliveryEventStatus.Unknown,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::DeliveryEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new History::DeliveryEvent
        {
            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = History::DeliveryEventStatus.Unknown,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::DeliveryEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, History::DeliveryEventStatus> expectedStatus =
            History::DeliveryEventStatus.Unknown;

        Assert.Equal(expectedReceivedAt, deserialized.ReceivedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new History::DeliveryEvent
        {
            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = History::DeliveryEventStatus.Unknown,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new History::DeliveryEvent
        {
            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = History::DeliveryEventStatus.Unknown,
        };

        History::DeliveryEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeliveryEventStatusTest : TestBase
{
    [Theory]
    [InlineData(History::DeliveryEventStatus.Unknown)]
    [InlineData(History::DeliveryEventStatus.Submitted)]
    [InlineData(History::DeliveryEventStatus.InTransit)]
    [InlineData(History::DeliveryEventStatus.Delivered)]
    [InlineData(History::DeliveryEventStatus.Undeliverable)]
    [InlineData(History::DeliveryEventStatus.Expired)]
    [InlineData(History::DeliveryEventStatus.Read)]
    [InlineData(History::DeliveryEventStatus.SilentStarted)]
    [InlineData(History::DeliveryEventStatus.SilentVerified)]
    [InlineData(History::DeliveryEventStatus.SilentMismatch)]
    public void Validation_Works(History::DeliveryEventStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::DeliveryEventStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::DeliveryEventStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(History::DeliveryEventStatus.Unknown)]
    [InlineData(History::DeliveryEventStatus.Submitted)]
    [InlineData(History::DeliveryEventStatus.InTransit)]
    [InlineData(History::DeliveryEventStatus.Delivered)]
    [InlineData(History::DeliveryEventStatus.Undeliverable)]
    [InlineData(History::DeliveryEventStatus.Expired)]
    [InlineData(History::DeliveryEventStatus.Read)]
    [InlineData(History::DeliveryEventStatus.SilentStarted)]
    [InlineData(History::DeliveryEventStatus.SilentVerified)]
    [InlineData(History::DeliveryEventStatus.SilentMismatch)]
    public void SerializationRoundtrip_Works(History::DeliveryEventStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::DeliveryEventStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, History::DeliveryEventStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::DeliveryEventStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, History::DeliveryEventStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DeliveryStatusTest : TestBase
{
    [Theory]
    [InlineData(History::DeliveryStatus.Unknown)]
    [InlineData(History::DeliveryStatus.InTransit)]
    [InlineData(History::DeliveryStatus.Delivered)]
    [InlineData(History::DeliveryStatus.Undeliverable)]
    [InlineData(History::DeliveryStatus.Read)]
    public void Validation_Works(History::DeliveryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::DeliveryStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::DeliveryStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(History::DeliveryStatus.Unknown)]
    [InlineData(History::DeliveryStatus.InTransit)]
    [InlineData(History::DeliveryStatus.Delivered)]
    [InlineData(History::DeliveryStatus.Undeliverable)]
    [InlineData(History::DeliveryStatus.Read)]
    public void SerializationRoundtrip_Works(History::DeliveryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::DeliveryStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::DeliveryStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::DeliveryStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::DeliveryStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PreferredChannelTest : TestBase
{
    [Theory]
    [InlineData(History::PreferredChannel.Sms)]
    [InlineData(History::PreferredChannel.Rcs)]
    [InlineData(History::PreferredChannel.Whatsapp)]
    [InlineData(History::PreferredChannel.Viber)]
    [InlineData(History::PreferredChannel.Zalo)]
    [InlineData(History::PreferredChannel.Telegram)]
    [InlineData(History::PreferredChannel.Voice)]
    [InlineData(History::PreferredChannel.Silent)]
    public void Validation_Works(History::PreferredChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::PreferredChannel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::PreferredChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(History::PreferredChannel.Sms)]
    [InlineData(History::PreferredChannel.Rcs)]
    [InlineData(History::PreferredChannel.Whatsapp)]
    [InlineData(History::PreferredChannel.Viber)]
    [InlineData(History::PreferredChannel.Zalo)]
    [InlineData(History::PreferredChannel.Telegram)]
    [InlineData(History::PreferredChannel.Voice)]
    [InlineData(History::PreferredChannel.Silent)]
    public void SerializationRoundtrip_Works(History::PreferredChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::PreferredChannel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::PreferredChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::PreferredChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::PreferredChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AttemptStatusTest : TestBase
{
    [Theory]
    [InlineData(History::AttemptStatus.Succeeded)]
    [InlineData(History::AttemptStatus.Failed)]
    public void Validation_Works(History::AttemptStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::AttemptStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::AttemptStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(History::AttemptStatus.Succeeded)]
    [InlineData(History::AttemptStatus.Failed)]
    public void SerializationRoundtrip_Works(History::AttemptStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::AttemptStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::AttemptStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::AttemptStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::AttemptStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TriggerTest : TestBase
{
    [Theory]
    [InlineData(History::Trigger.Initial)]
    [InlineData(History::Trigger.AutoRetry)]
    [InlineData(History::Trigger.UserRetry)]
    public void Validation_Works(History::Trigger rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::Trigger> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::Trigger>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(History::Trigger.Initial)]
    [InlineData(History::Trigger.AutoRetry)]
    [InlineData(History::Trigger.UserRetry)]
    public void SerializationRoundtrip_Works(History::Trigger rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::Trigger> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::Trigger>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::Trigger>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::Trigger>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CheckTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new History::Check
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsValid = true,
            Channel = History::CheckChannel.Sms,
            Psd2Info = new()
            {
                ExpectedTransaction = new()
                {
                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                    Recipient = "recipient",
                },
                ReceivedTransaction = new()
                {
                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                    Recipient = "recipient",
                },
            },
            StatusDetail = History::StatusDetail.ExpiredAttempt,
            Value = "value",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIsValid = true;
        ApiEnum<string, History::CheckChannel> expectedChannel = History::CheckChannel.Sms;
        History::Psd2Info expectedPsd2Info = new()
        {
            ExpectedTransaction = new()
            {
                Amount = new() { Amount = "0.042", Currency = "EUR" },
                Recipient = "recipient",
            },
            ReceivedTransaction = new()
            {
                Amount = new() { Amount = "0.042", Currency = "EUR" },
                Recipient = "recipient",
            },
        };
        ApiEnum<string, History::StatusDetail> expectedStatusDetail =
            History::StatusDetail.ExpiredAttempt;
        string expectedValue = "value";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIsValid, model.IsValid);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedPsd2Info, model.Psd2Info);
        Assert.Equal(expectedStatusDetail, model.StatusDetail);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new History::Check
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsValid = true,
            Channel = History::CheckChannel.Sms,
            Psd2Info = new()
            {
                ExpectedTransaction = new()
                {
                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                    Recipient = "recipient",
                },
                ReceivedTransaction = new()
                {
                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                    Recipient = "recipient",
                },
            },
            StatusDetail = History::StatusDetail.ExpiredAttempt,
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::Check>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new History::Check
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsValid = true,
            Channel = History::CheckChannel.Sms,
            Psd2Info = new()
            {
                ExpectedTransaction = new()
                {
                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                    Recipient = "recipient",
                },
                ReceivedTransaction = new()
                {
                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                    Recipient = "recipient",
                },
            },
            StatusDetail = History::StatusDetail.ExpiredAttempt,
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::Check>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIsValid = true;
        ApiEnum<string, History::CheckChannel> expectedChannel = History::CheckChannel.Sms;
        History::Psd2Info expectedPsd2Info = new()
        {
            ExpectedTransaction = new()
            {
                Amount = new() { Amount = "0.042", Currency = "EUR" },
                Recipient = "recipient",
            },
            ReceivedTransaction = new()
            {
                Amount = new() { Amount = "0.042", Currency = "EUR" },
                Recipient = "recipient",
            },
        };
        ApiEnum<string, History::StatusDetail> expectedStatusDetail =
            History::StatusDetail.ExpiredAttempt;
        string expectedValue = "value";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedIsValid, deserialized.IsValid);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedPsd2Info, deserialized.Psd2Info);
        Assert.Equal(expectedStatusDetail, deserialized.StatusDetail);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new History::Check
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsValid = true,
            Channel = History::CheckChannel.Sms,
            Psd2Info = new()
            {
                ExpectedTransaction = new()
                {
                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                    Recipient = "recipient",
                },
                ReceivedTransaction = new()
                {
                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                    Recipient = "recipient",
                },
            },
            StatusDetail = History::StatusDetail.ExpiredAttempt,
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new History::Check
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsValid = true,
        };

        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Psd2Info);
        Assert.False(model.RawData.ContainsKey("psd2_info"));
        Assert.Null(model.StatusDetail);
        Assert.False(model.RawData.ContainsKey("status_detail"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new History::Check
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsValid = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new History::Check
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsValid = true,

            // Null should be interpreted as omitted for these properties
            Channel = null,
            Psd2Info = null,
            StatusDetail = null,
            Value = null,
        };

        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Psd2Info);
        Assert.False(model.RawData.ContainsKey("psd2_info"));
        Assert.Null(model.StatusDetail);
        Assert.False(model.RawData.ContainsKey("status_detail"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new History::Check
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsValid = true,

            // Null should be interpreted as omitted for these properties
            Channel = null,
            Psd2Info = null,
            StatusDetail = null,
            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new History::Check
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsValid = true,
            Channel = History::CheckChannel.Sms,
            Psd2Info = new()
            {
                ExpectedTransaction = new()
                {
                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                    Recipient = "recipient",
                },
                ReceivedTransaction = new()
                {
                    Amount = new() { Amount = "0.042", Currency = "EUR" },
                    Recipient = "recipient",
                },
            },
            StatusDetail = History::StatusDetail.ExpiredAttempt,
            Value = "value",
        };

        History::Check copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckChannelTest : TestBase
{
    [Theory]
    [InlineData(History::CheckChannel.Sms)]
    [InlineData(History::CheckChannel.Rcs)]
    [InlineData(History::CheckChannel.Whatsapp)]
    [InlineData(History::CheckChannel.Viber)]
    [InlineData(History::CheckChannel.Zalo)]
    [InlineData(History::CheckChannel.Telegram)]
    [InlineData(History::CheckChannel.Voice)]
    [InlineData(History::CheckChannel.Silent)]
    public void Validation_Works(History::CheckChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::CheckChannel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::CheckChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(History::CheckChannel.Sms)]
    [InlineData(History::CheckChannel.Rcs)]
    [InlineData(History::CheckChannel.Whatsapp)]
    [InlineData(History::CheckChannel.Viber)]
    [InlineData(History::CheckChannel.Zalo)]
    [InlineData(History::CheckChannel.Telegram)]
    [InlineData(History::CheckChannel.Voice)]
    [InlineData(History::CheckChannel.Silent)]
    public void SerializationRoundtrip_Works(History::CheckChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::CheckChannel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::CheckChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::CheckChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::CheckChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class Psd2InfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new History::Psd2Info
        {
            ExpectedTransaction = new()
            {
                Amount = new() { Amount = "0.042", Currency = "EUR" },
                Recipient = "recipient",
            },
            ReceivedTransaction = new()
            {
                Amount = new() { Amount = "0.042", Currency = "EUR" },
                Recipient = "recipient",
            },
        };

        History::PhoneVerificationPsd2Transaction expectedExpectedTransaction = new()
        {
            Amount = new() { Amount = "0.042", Currency = "EUR" },
            Recipient = "recipient",
        };
        History::PhoneVerificationPsd2Transaction expectedReceivedTransaction = new()
        {
            Amount = new() { Amount = "0.042", Currency = "EUR" },
            Recipient = "recipient",
        };

        Assert.Equal(expectedExpectedTransaction, model.ExpectedTransaction);
        Assert.Equal(expectedReceivedTransaction, model.ReceivedTransaction);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new History::Psd2Info
        {
            ExpectedTransaction = new()
            {
                Amount = new() { Amount = "0.042", Currency = "EUR" },
                Recipient = "recipient",
            },
            ReceivedTransaction = new()
            {
                Amount = new() { Amount = "0.042", Currency = "EUR" },
                Recipient = "recipient",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::Psd2Info>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new History::Psd2Info
        {
            ExpectedTransaction = new()
            {
                Amount = new() { Amount = "0.042", Currency = "EUR" },
                Recipient = "recipient",
            },
            ReceivedTransaction = new()
            {
                Amount = new() { Amount = "0.042", Currency = "EUR" },
                Recipient = "recipient",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::Psd2Info>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        History::PhoneVerificationPsd2Transaction expectedExpectedTransaction = new()
        {
            Amount = new() { Amount = "0.042", Currency = "EUR" },
            Recipient = "recipient",
        };
        History::PhoneVerificationPsd2Transaction expectedReceivedTransaction = new()
        {
            Amount = new() { Amount = "0.042", Currency = "EUR" },
            Recipient = "recipient",
        };

        Assert.Equal(expectedExpectedTransaction, deserialized.ExpectedTransaction);
        Assert.Equal(expectedReceivedTransaction, deserialized.ReceivedTransaction);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new History::Psd2Info
        {
            ExpectedTransaction = new()
            {
                Amount = new() { Amount = "0.042", Currency = "EUR" },
                Recipient = "recipient",
            },
            ReceivedTransaction = new()
            {
                Amount = new() { Amount = "0.042", Currency = "EUR" },
                Recipient = "recipient",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new History::Psd2Info { };

        Assert.Null(model.ExpectedTransaction);
        Assert.False(model.RawData.ContainsKey("expected_transaction"));
        Assert.Null(model.ReceivedTransaction);
        Assert.False(model.RawData.ContainsKey("received_transaction"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new History::Psd2Info { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new History::Psd2Info
        {
            // Null should be interpreted as omitted for these properties
            ExpectedTransaction = null,
            ReceivedTransaction = null,
        };

        Assert.Null(model.ExpectedTransaction);
        Assert.False(model.RawData.ContainsKey("expected_transaction"));
        Assert.Null(model.ReceivedTransaction);
        Assert.False(model.RawData.ContainsKey("received_transaction"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new History::Psd2Info
        {
            // Null should be interpreted as omitted for these properties
            ExpectedTransaction = null,
            ReceivedTransaction = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new History::Psd2Info
        {
            ExpectedTransaction = new()
            {
                Amount = new() { Amount = "0.042", Currency = "EUR" },
                Recipient = "recipient",
            },
            ReceivedTransaction = new()
            {
                Amount = new() { Amount = "0.042", Currency = "EUR" },
                Recipient = "recipient",
            },
        };

        History::Psd2Info copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusDetailTest : TestBase
{
    [Theory]
    [InlineData(History::StatusDetail.ExpiredAttempt)]
    [InlineData(History::StatusDetail.ExpiredAuth)]
    [InlineData(History::StatusDetail.RateLimited)]
    [InlineData(History::StatusDetail.TransactionMissing)]
    [InlineData(History::StatusDetail.TransactionMismatch)]
    public void Validation_Works(History::StatusDetail rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::StatusDetail> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::StatusDetail>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(History::StatusDetail.ExpiredAttempt)]
    [InlineData(History::StatusDetail.ExpiredAuth)]
    [InlineData(History::StatusDetail.RateLimited)]
    [InlineData(History::StatusDetail.TransactionMissing)]
    [InlineData(History::StatusDetail.TransactionMismatch)]
    public void SerializationRoundtrip_Works(History::StatusDetail rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::StatusDetail> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::StatusDetail>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::StatusDetail>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::StatusDetail>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CreateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new History::Create
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = new() { Amount = "0.042", Currency = "EUR" },
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        History::PhoneVerificationMoney expectedCost = new() { Amount = "0.042", Currency = "EUR" };

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCost, model.Cost);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new History::Create
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = new() { Amount = "0.042", Currency = "EUR" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::Create>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new History::Create
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = new() { Amount = "0.042", Currency = "EUR" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::Create>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        History::PhoneVerificationMoney expectedCost = new() { Amount = "0.042", Currency = "EUR" };

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCost, deserialized.Cost);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new History::Create
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = new() { Amount = "0.042", Currency = "EUR" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new History::Create
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new History::Create
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new History::Create
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Cost = null,
        };

        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new History::Create
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Cost = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new History::Create
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = new() { Amount = "0.042", Currency = "EUR" },
        };

        History::Create copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SignalsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new History::Signals
        {
            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = History::SignalsStatus.Valid,
        };

        DateTimeOffset expectedReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, History::SignalsStatus> expectedStatus = History::SignalsStatus.Valid;

        Assert.Equal(expectedReceivedAt, model.ReceivedAt);
        Assert.Equal(expectedExpiredAt, model.ExpiredAt);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new History::Signals
        {
            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = History::SignalsStatus.Valid,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::Signals>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new History::Signals
        {
            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = History::SignalsStatus.Valid,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::Signals>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, History::SignalsStatus> expectedStatus = History::SignalsStatus.Valid;

        Assert.Equal(expectedReceivedAt, deserialized.ReceivedAt);
        Assert.Equal(expectedExpiredAt, deserialized.ExpiredAt);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new History::Signals
        {
            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = History::SignalsStatus.Valid,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new History::Signals
        {
            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ExpiredAt);
        Assert.False(model.RawData.ContainsKey("expired_at"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new History::Signals
        {
            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new History::Signals
        {
            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ExpiredAt = null,
            Status = null,
        };

        Assert.Null(model.ExpiredAt);
        Assert.False(model.RawData.ContainsKey("expired_at"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new History::Signals
        {
            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ExpiredAt = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new History::Signals
        {
            ReceivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = History::SignalsStatus.Valid,
        };

        History::Signals copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SignalsStatusTest : TestBase
{
    [Theory]
    [InlineData(History::SignalsStatus.Valid)]
    [InlineData(History::SignalsStatus.Invalid)]
    public void Validation_Works(History::SignalsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::SignalsStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::SignalsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(History::SignalsStatus.Valid)]
    [InlineData(History::SignalsStatus.Invalid)]
    public void SerializationRoundtrip_Works(History::SignalsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::SignalsStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::SignalsStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::SignalsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::SignalsStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PhoneNumberConditionTest : TestBase
{
    [Theory]
    [InlineData(History::PhoneNumberCondition.AllowListed)]
    [InlineData(History::PhoneNumberCondition.BlockListed)]
    [InlineData(History::PhoneNumberCondition.Sandboxed)]
    public void Validation_Works(History::PhoneNumberCondition rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::PhoneNumberCondition> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::PhoneNumberCondition>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(History::PhoneNumberCondition.AllowListed)]
    [InlineData(History::PhoneNumberCondition.BlockListed)]
    [InlineData(History::PhoneNumberCondition.Sandboxed)]
    public void SerializationRoundtrip_Works(History::PhoneNumberCondition rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::PhoneNumberCondition> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, History::PhoneNumberCondition>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::PhoneNumberCondition>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, History::PhoneNumberCondition>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PhoneNumberCurrentConditionTest : TestBase
{
    [Theory]
    [InlineData(History::PhoneNumberCurrentCondition.AllowListed)]
    [InlineData(History::PhoneNumberCurrentCondition.BlockListed)]
    [InlineData(History::PhoneNumberCurrentCondition.Sandboxed)]
    public void Validation_Works(History::PhoneNumberCurrentCondition rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::PhoneNumberCurrentCondition> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, History::PhoneNumberCurrentCondition>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(History::PhoneNumberCurrentCondition.AllowListed)]
    [InlineData(History::PhoneNumberCurrentCondition.BlockListed)]
    [InlineData(History::PhoneNumberCurrentCondition.Sandboxed)]
    public void SerializationRoundtrip_Works(History::PhoneNumberCurrentCondition rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::PhoneNumberCurrentCondition> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, History::PhoneNumberCurrentCondition>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, History::PhoneNumberCurrentCondition>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, History::PhoneNumberCurrentCondition>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class HistoryRetrieveResponseSignalsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new History::HistoryRetrieveResponseSignals
        {
            IsTrustedUser = true,
            DeviceID = "device_id",
            Ja4Fingerprint = "ja4_fingerprint",
            OsVersion = "os_version",
            UserAgent = "user_agent",
        };

        bool expectedIsTrustedUser = true;
        string expectedDeviceID = "device_id";
        string expectedJa4Fingerprint = "ja4_fingerprint";
        string expectedOsVersion = "os_version";
        string expectedUserAgent = "user_agent";

        Assert.Equal(expectedIsTrustedUser, model.IsTrustedUser);
        Assert.Equal(expectedDeviceID, model.DeviceID);
        Assert.Equal(expectedJa4Fingerprint, model.Ja4Fingerprint);
        Assert.Equal(expectedOsVersion, model.OsVersion);
        Assert.Equal(expectedUserAgent, model.UserAgent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new History::HistoryRetrieveResponseSignals
        {
            IsTrustedUser = true,
            DeviceID = "device_id",
            Ja4Fingerprint = "ja4_fingerprint",
            OsVersion = "os_version",
            UserAgent = "user_agent",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::HistoryRetrieveResponseSignals>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new History::HistoryRetrieveResponseSignals
        {
            IsTrustedUser = true,
            DeviceID = "device_id",
            Ja4Fingerprint = "ja4_fingerprint",
            OsVersion = "os_version",
            UserAgent = "user_agent",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History::HistoryRetrieveResponseSignals>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedIsTrustedUser = true;
        string expectedDeviceID = "device_id";
        string expectedJa4Fingerprint = "ja4_fingerprint";
        string expectedOsVersion = "os_version";
        string expectedUserAgent = "user_agent";

        Assert.Equal(expectedIsTrustedUser, deserialized.IsTrustedUser);
        Assert.Equal(expectedDeviceID, deserialized.DeviceID);
        Assert.Equal(expectedJa4Fingerprint, deserialized.Ja4Fingerprint);
        Assert.Equal(expectedOsVersion, deserialized.OsVersion);
        Assert.Equal(expectedUserAgent, deserialized.UserAgent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new History::HistoryRetrieveResponseSignals
        {
            IsTrustedUser = true,
            DeviceID = "device_id",
            Ja4Fingerprint = "ja4_fingerprint",
            OsVersion = "os_version",
            UserAgent = "user_agent",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new History::HistoryRetrieveResponseSignals { IsTrustedUser = true };

        Assert.Null(model.DeviceID);
        Assert.False(model.RawData.ContainsKey("device_id"));
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
        var model = new History::HistoryRetrieveResponseSignals { IsTrustedUser = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new History::HistoryRetrieveResponseSignals
        {
            IsTrustedUser = true,

            // Null should be interpreted as omitted for these properties
            DeviceID = null,
            Ja4Fingerprint = null,
            OsVersion = null,
            UserAgent = null,
        };

        Assert.Null(model.DeviceID);
        Assert.False(model.RawData.ContainsKey("device_id"));
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
        var model = new History::HistoryRetrieveResponseSignals
        {
            IsTrustedUser = true,

            // Null should be interpreted as omitted for these properties
            DeviceID = null,
            Ja4Fingerprint = null,
            OsVersion = null,
            UserAgent = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new History::HistoryRetrieveResponseSignals
        {
            IsTrustedUser = true,
            DeviceID = "device_id",
            Ja4Fingerprint = "ja4_fingerprint",
            OsVersion = "os_version",
            UserAgent = "user_agent",
        };

        History::HistoryRetrieveResponseSignals copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SignalsHashStatusTest : TestBase
{
    [Theory]
    [InlineData(History::SignalsHashStatus.Valid)]
    [InlineData(History::SignalsHashStatus.Invalid)]
    public void Validation_Works(History::SignalsHashStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::SignalsHashStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::SignalsHashStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(History::SignalsHashStatus.Valid)]
    [InlineData(History::SignalsHashStatus.Invalid)]
    public void SerializationRoundtrip_Works(History::SignalsHashStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, History::SignalsHashStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::SignalsHashStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, History::SignalsHashStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, History::SignalsHashStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
