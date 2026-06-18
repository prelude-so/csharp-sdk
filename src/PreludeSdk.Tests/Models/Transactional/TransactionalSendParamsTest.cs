using System;
using System.Collections.Generic;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.Transactional;

namespace PreludeSdk.Tests.Models.Transactional;

public class TransactionalSendParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TransactionalSendParams
        {
            TemplateID = "template_01hynf45qvevj844m9az2x2f3c",
            To = "+30123456789",
            CallbackUrl = "callback_url",
            CorrelationID = "correlation_id",
            Document = new() { Url = "https://example.com/invoice.pdf", Filename = "invoice.pdf" },
            ExpiresAt = "expires_at",
            From = "from",
            Locale = "el-GR",
            MaxAutoRetries = 2,
            PreferredChannel = PreferredChannel.Whatsapp,
            Variables = new Dictionary<string, string>() { { "foo", "bar" } },
        };

        string expectedTemplateID = "template_01hynf45qvevj844m9az2x2f3c";
        string expectedTo = "+30123456789";
        string expectedCallbackUrl = "callback_url";
        string expectedCorrelationID = "correlation_id";
        Document expectedDocument = new()
        {
            Url = "https://example.com/invoice.pdf",
            Filename = "invoice.pdf",
        };
        string expectedExpiresAt = "expires_at";
        string expectedFrom = "from";
        string expectedLocale = "el-GR";
        long expectedMaxAutoRetries = 2;
        ApiEnum<string, PreferredChannel> expectedPreferredChannel = PreferredChannel.Whatsapp;
        Dictionary<string, string> expectedVariables = new() { { "foo", "bar" } };

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
        var parameters = new TransactionalSendParams
        {
            TemplateID = "template_01hynf45qvevj844m9az2x2f3c",
            To = "+30123456789",
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
        Assert.Null(parameters.Variables);
        Assert.False(parameters.RawBodyData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TransactionalSendParams
        {
            TemplateID = "template_01hynf45qvevj844m9az2x2f3c",
            To = "+30123456789",

            // Null should be interpreted as omitted for these properties
            CallbackUrl = null,
            CorrelationID = null,
            Document = null,
            ExpiresAt = null,
            From = null,
            Locale = null,
            MaxAutoRetries = null,
            PreferredChannel = null,
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
        Assert.Null(parameters.Variables);
        Assert.False(parameters.RawBodyData.ContainsKey("variables"));
    }

    [Fact]
    public void Url_Works()
    {
        TransactionalSendParams parameters = new()
        {
            TemplateID = "template_01hynf45qvevj844m9az2x2f3c",
            To = "+30123456789",
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.prelude.dev/v2/transactional"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TransactionalSendParams
        {
            TemplateID = "template_01hynf45qvevj844m9az2x2f3c",
            To = "+30123456789",
            CallbackUrl = "callback_url",
            CorrelationID = "correlation_id",
            Document = new() { Url = "https://example.com/invoice.pdf", Filename = "invoice.pdf" },
            ExpiresAt = "expires_at",
            From = "from",
            Locale = "el-GR",
            MaxAutoRetries = 2,
            PreferredChannel = PreferredChannel.Whatsapp,
            Variables = new Dictionary<string, string>() { { "foo", "bar" } },
        };

        TransactionalSendParams copied = new(parameters);

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
