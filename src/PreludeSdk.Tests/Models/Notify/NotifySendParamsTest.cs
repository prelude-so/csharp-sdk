using System;
using System.Collections.Generic;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.Notify;

namespace PreludeSdk.Tests.Models.Notify;

public class NotifySendParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotifySendParams
        {
            TemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9",
            To = "+33612345678",
            CallbackUrl = "https://your-app.com/webhooks/notify",
            CorrelationID = "order-12345",
            Document = new() { Url = "https://example.com/invoice.pdf", Filename = "invoice.pdf" },
            ExpiresAt = DateTimeOffset.Parse("2025-12-25T18:00:00Z"),
            From = "from",
            Locale = "el-GR",
            MaxAutoRetries = 2,
            PreferredChannel = PreferredChannel.Whatsapp,
            ScheduleAt = DateTimeOffset.Parse("2025-12-25T10:00:00Z"),
            Variables = new Dictionary<string, string>()
            {
                { "order_id", "12345" },
                { "amount", "$49.99" },
            },
        };

        string expectedTemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9";
        string expectedTo = "+33612345678";
        string expectedCallbackUrl = "https://your-app.com/webhooks/notify";
        string expectedCorrelationID = "order-12345";
        Document expectedDocument = new()
        {
            Url = "https://example.com/invoice.pdf",
            Filename = "invoice.pdf",
        };
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2025-12-25T18:00:00Z");
        string expectedFrom = "from";
        string expectedLocale = "el-GR";
        long expectedMaxAutoRetries = 2;
        ApiEnum<string, PreferredChannel> expectedPreferredChannel = PreferredChannel.Whatsapp;
        DateTimeOffset expectedScheduleAt = DateTimeOffset.Parse("2025-12-25T10:00:00Z");
        Dictionary<string, string> expectedVariables = new()
        {
            { "order_id", "12345" },
            { "amount", "$49.99" },
        };

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedTo, parameters.To);
        Assert.Equal(expectedCallbackUrl, parameters.CallbackUrl);
        Assert.Equal(expectedCorrelationID, parameters.CorrelationID);
        Assert.Equal(expectedDocument, parameters.Document);
        Assert.Equal(expectedExpiresAt, parameters.ExpiresAt);
        Assert.Equal(expectedFrom, parameters.From);
        Assert.Equal(expectedLocale, parameters.Locale);
        Assert.Equal(expectedMaxAutoRetries, parameters.MaxAutoRetries);
        Assert.Equal(expectedPreferredChannel, parameters.PreferredChannel);
        Assert.Equal(expectedScheduleAt, parameters.ScheduleAt);
        Assert.NotNull(parameters.Variables);
        Assert.Equal(expectedVariables.Count, parameters.Variables.Count);
        foreach (var item in expectedVariables)
        {
            Assert.True(parameters.Variables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Variables[item.Key]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotifySendParams
        {
            TemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9",
            To = "+33612345678",
        };

        Assert.Null(parameters.CallbackUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("callback_url"));
        Assert.Null(parameters.CorrelationID);
        Assert.False(parameters.RawBodyData.ContainsKey("correlation_id"));
        Assert.Null(parameters.Document);
        Assert.False(parameters.RawBodyData.ContainsKey("document"));
        Assert.Null(parameters.ExpiresAt);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_at"));
        Assert.Null(parameters.From);
        Assert.False(parameters.RawBodyData.ContainsKey("from"));
        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawBodyData.ContainsKey("locale"));
        Assert.Null(parameters.MaxAutoRetries);
        Assert.False(parameters.RawBodyData.ContainsKey("max_auto_retries"));
        Assert.Null(parameters.PreferredChannel);
        Assert.False(parameters.RawBodyData.ContainsKey("preferred_channel"));
        Assert.Null(parameters.ScheduleAt);
        Assert.False(parameters.RawBodyData.ContainsKey("schedule_at"));
        Assert.Null(parameters.Variables);
        Assert.False(parameters.RawBodyData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotifySendParams
        {
            TemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9",
            To = "+33612345678",

            // Null should be interpreted as omitted for these properties
            CallbackUrl = null,
            CorrelationID = null,
            Document = null,
            ExpiresAt = null,
            From = null,
            Locale = null,
            MaxAutoRetries = null,
            PreferredChannel = null,
            ScheduleAt = null,
            Variables = null,
        };

        Assert.Null(parameters.CallbackUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("callback_url"));
        Assert.Null(parameters.CorrelationID);
        Assert.False(parameters.RawBodyData.ContainsKey("correlation_id"));
        Assert.Null(parameters.Document);
        Assert.False(parameters.RawBodyData.ContainsKey("document"));
        Assert.Null(parameters.ExpiresAt);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_at"));
        Assert.Null(parameters.From);
        Assert.False(parameters.RawBodyData.ContainsKey("from"));
        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawBodyData.ContainsKey("locale"));
        Assert.Null(parameters.MaxAutoRetries);
        Assert.False(parameters.RawBodyData.ContainsKey("max_auto_retries"));
        Assert.Null(parameters.PreferredChannel);
        Assert.False(parameters.RawBodyData.ContainsKey("preferred_channel"));
        Assert.Null(parameters.ScheduleAt);
        Assert.False(parameters.RawBodyData.ContainsKey("schedule_at"));
        Assert.Null(parameters.Variables);
        Assert.False(parameters.RawBodyData.ContainsKey("variables"));
    }

    [Fact]
    public void Url_Works()
    {
        NotifySendParams parameters = new()
        {
            TemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9",
            To = "+33612345678",
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.prelude.dev/v2/notify"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotifySendParams
        {
            TemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9",
            To = "+33612345678",
            CallbackUrl = "https://your-app.com/webhooks/notify",
            CorrelationID = "order-12345",
            Document = new() { Url = "https://example.com/invoice.pdf", Filename = "invoice.pdf" },
            ExpiresAt = DateTimeOffset.Parse("2025-12-25T18:00:00Z"),
            From = "from",
            Locale = "el-GR",
            MaxAutoRetries = 2,
            PreferredChannel = PreferredChannel.Whatsapp,
            ScheduleAt = DateTimeOffset.Parse("2025-12-25T10:00:00Z"),
            Variables = new Dictionary<string, string>()
            {
                { "order_id", "12345" },
                { "amount", "$49.99" },
            },
        };

        NotifySendParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DocumentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Document
        {
            Url = "https://example.com/invoice.pdf",
            Filename = "invoice.pdf",
        };

        string expectedUrl = "https://example.com/invoice.pdf";
        string expectedFilename = "invoice.pdf";

        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedFilename, model.Filename);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Document
        {
            Url = "https://example.com/invoice.pdf",
            Filename = "invoice.pdf",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Document>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Document
        {
            Url = "https://example.com/invoice.pdf",
            Filename = "invoice.pdf",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Document>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUrl = "https://example.com/invoice.pdf";
        string expectedFilename = "invoice.pdf";

        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedFilename, deserialized.Filename);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Document
        {
            Url = "https://example.com/invoice.pdf",
            Filename = "invoice.pdf",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Document { Url = "https://example.com/invoice.pdf" };

        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Document { Url = "https://example.com/invoice.pdf" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Document
        {
            Url = "https://example.com/invoice.pdf",

            // Null should be interpreted as omitted for these properties
            Filename = null,
        };

        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Document
        {
            Url = "https://example.com/invoice.pdf",

            // Null should be interpreted as omitted for these properties
            Filename = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Document
        {
            Url = "https://example.com/invoice.pdf",
            Filename = "invoice.pdf",
        };

        Document copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PreferredChannelTest : TestBase
{
    [Theory]
    [InlineData(PreferredChannel.Sms)]
    [InlineData(PreferredChannel.Rcs)]
    [InlineData(PreferredChannel.Whatsapp)]
    public void Validation_Works(PreferredChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreferredChannel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreferredChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PreferredChannel.Sms)]
    [InlineData(PreferredChannel.Rcs)]
    [InlineData(PreferredChannel.Whatsapp)]
    public void SerializationRoundtrip_Works(PreferredChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreferredChannel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreferredChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreferredChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreferredChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
