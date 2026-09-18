using System;
using System.Collections.Generic;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.Verification.Phone.History;

namespace PreludeSdk.Tests.Models.Verification.Phone.History;

public class HistoryListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new HistoryListParams
        {
            Channels = [Channel.Sms],
            Cursor = "cursor",
            DevicePlatform = DevicePlatform.Android,
            From = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
            Limit = 1,
            MaxAttempts = 0,
            MinAttempts = 0,
            PhoneNumber = "+33612345678",
            Region = "FR",
            Status = Status.Converted,
            TemplateID = "template_01jc0t6fwwfgfsq1md24mhyztj",
            To = DateTimeOffset.Parse("2026-09-08T00:00:00Z"),
        };

        List<ApiEnum<string, Channel>> expectedChannels = [Channel.Sms];
        string expectedCursor = "cursor";
        ApiEnum<string, DevicePlatform> expectedDevicePlatform = DevicePlatform.Android;
        DateTimeOffset expectedFrom = DateTimeOffset.Parse("2026-09-01T00:00:00Z");
        long expectedLimit = 1;
        long expectedMaxAttempts = 0;
        long expectedMinAttempts = 0;
        string expectedPhoneNumber = "+33612345678";
        string expectedRegion = "FR";
        ApiEnum<string, Status> expectedStatus = Status.Converted;
        string expectedTemplateID = "template_01jc0t6fwwfgfsq1md24mhyztj";
        DateTimeOffset expectedTo = DateTimeOffset.Parse("2026-09-08T00:00:00Z");

        Assert.NotNull(parameters.Channels);
        Assert.Equal(expectedChannels.Count, parameters.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], parameters.Channels[i]);
        }
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedDevicePlatform, parameters.DevicePlatform);
        Assert.Equal(expectedFrom, parameters.From);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMaxAttempts, parameters.MaxAttempts);
        Assert.Equal(expectedMinAttempts, parameters.MinAttempts);
        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
        Assert.Equal(expectedRegion, parameters.Region);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedTo, parameters.To);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new HistoryListParams { };

        Assert.Null(parameters.Channels);
        Assert.False(parameters.RawQueryData.ContainsKey("channels"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.DevicePlatform);
        Assert.False(parameters.RawQueryData.ContainsKey("device_platform"));
        Assert.Null(parameters.From);
        Assert.False(parameters.RawQueryData.ContainsKey("from"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.MaxAttempts);
        Assert.False(parameters.RawQueryData.ContainsKey("max_attempts"));
        Assert.Null(parameters.MinAttempts);
        Assert.False(parameters.RawQueryData.ContainsKey("min_attempts"));
        Assert.Null(parameters.PhoneNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("phone_number"));
        Assert.Null(parameters.Region);
        Assert.False(parameters.RawQueryData.ContainsKey("region"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.TemplateID);
        Assert.False(parameters.RawQueryData.ContainsKey("template_id"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawQueryData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new HistoryListParams
        {
            // Null should be interpreted as omitted for these properties
            Channels = null,
            Cursor = null,
            DevicePlatform = null,
            From = null,
            Limit = null,
            MaxAttempts = null,
            MinAttempts = null,
            PhoneNumber = null,
            Region = null,
            Status = null,
            TemplateID = null,
            To = null,
        };

        Assert.Null(parameters.Channels);
        Assert.False(parameters.RawQueryData.ContainsKey("channels"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.DevicePlatform);
        Assert.False(parameters.RawQueryData.ContainsKey("device_platform"));
        Assert.Null(parameters.From);
        Assert.False(parameters.RawQueryData.ContainsKey("from"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.MaxAttempts);
        Assert.False(parameters.RawQueryData.ContainsKey("max_attempts"));
        Assert.Null(parameters.MinAttempts);
        Assert.False(parameters.RawQueryData.ContainsKey("min_attempts"));
        Assert.Null(parameters.PhoneNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("phone_number"));
        Assert.Null(parameters.Region);
        Assert.False(parameters.RawQueryData.ContainsKey("region"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.TemplateID);
        Assert.False(parameters.RawQueryData.ContainsKey("template_id"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawQueryData.ContainsKey("to"));
    }

    [Fact]
    public void Url_Works()
    {
        HistoryListParams parameters = new()
        {
            Channels = [Channel.Sms],
            Cursor = "cursor",
            DevicePlatform = DevicePlatform.Android,
            From = DateTimeOffset.Parse("2026-09-01T00:00:00+00:00"),
            Limit = 1,
            MaxAttempts = 0,
            MinAttempts = 0,
            PhoneNumber = "+33612345678",
            Region = "FR",
            Status = Status.Converted,
            TemplateID = "template_01jc0t6fwwfgfsq1md24mhyztj",
            To = DateTimeOffset.Parse("2026-09-08T00:00:00+00:00"),
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.prelude.dev/v2/verification/phone/history?channels=sms&cursor=cursor&device_platform=android&from=2026-09-01T00%3a00%3a00%2b00%3a00&limit=1&max_attempts=0&min_attempts=0&phone_number=%2b33612345678&region=FR&status=converted&template_id=template_01jc0t6fwwfgfsq1md24mhyztj&to=2026-09-08T00%3a00%3a00%2b00%3a00"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new HistoryListParams
        {
            Channels = [Channel.Sms],
            Cursor = "cursor",
            DevicePlatform = DevicePlatform.Android,
            From = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
            Limit = 1,
            MaxAttempts = 0,
            MinAttempts = 0,
            PhoneNumber = "+33612345678",
            Region = "FR",
            Status = Status.Converted,
            TemplateID = "template_01jc0t6fwwfgfsq1md24mhyztj",
            To = DateTimeOffset.Parse("2026-09-08T00:00:00Z"),
        };

        HistoryListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ChannelTest : TestBase
{
    [Theory]
    [InlineData(Channel.Sms)]
    [InlineData(Channel.Rcs)]
    [InlineData(Channel.Whatsapp)]
    [InlineData(Channel.Viber)]
    [InlineData(Channel.Zalo)]
    [InlineData(Channel.Telegram)]
    [InlineData(Channel.Voice)]
    [InlineData(Channel.Silent)]
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
    [InlineData(Channel.Sms)]
    [InlineData(Channel.Rcs)]
    [InlineData(Channel.Whatsapp)]
    [InlineData(Channel.Viber)]
    [InlineData(Channel.Zalo)]
    [InlineData(Channel.Telegram)]
    [InlineData(Channel.Voice)]
    [InlineData(Channel.Silent)]
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

public class DevicePlatformTest : TestBase
{
    [Theory]
    [InlineData(DevicePlatform.Android)]
    [InlineData(DevicePlatform.Ios)]
    [InlineData(DevicePlatform.Ipados)]
    [InlineData(DevicePlatform.Tvos)]
    [InlineData(DevicePlatform.Web)]
    public void Validation_Works(DevicePlatform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DevicePlatform> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DevicePlatform>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DevicePlatform.Android)]
    [InlineData(DevicePlatform.Ios)]
    [InlineData(DevicePlatform.Ipados)]
    [InlineData(DevicePlatform.Tvos)]
    [InlineData(DevicePlatform.Web)]
    public void SerializationRoundtrip_Works(DevicePlatform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DevicePlatform> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DevicePlatform>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DevicePlatform>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DevicePlatform>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Converted)]
    [InlineData(Status.NotConverted)]
    [InlineData(Status.PendingCheck)]
    [InlineData(Status.Sent)]
    [InlineData(Status.Challenged)]
    [InlineData(Status.SuspectedFraud)]
    [InlineData(Status.InBlocklist)]
    [InlineData(Status.InvalidLine)]
    [InlineData(Status.InvalidNumber)]
    [InlineData(Status.RateLimited)]
    [InlineData(Status.ExpiredSignals)]
    [InlineData(Status.Shadowed)]
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
    [InlineData(Status.Converted)]
    [InlineData(Status.NotConverted)]
    [InlineData(Status.PendingCheck)]
    [InlineData(Status.Sent)]
    [InlineData(Status.Challenged)]
    [InlineData(Status.SuspectedFraud)]
    [InlineData(Status.InBlocklist)]
    [InlineData(Status.InvalidLine)]
    [InlineData(Status.InvalidNumber)]
    [InlineData(Status.RateLimited)]
    [InlineData(Status.ExpiredSignals)]
    [InlineData(Status.Shadowed)]
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
