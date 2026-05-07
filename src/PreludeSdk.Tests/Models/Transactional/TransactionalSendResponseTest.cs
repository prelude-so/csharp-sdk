using System;
using System.Collections.Generic;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Models.Transactional;

namespace PreludeSdk.Tests.Models.Transactional;

public class TransactionalSendResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TransactionalSendResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateID = "template_id",
            To = "to",
            Variables = new Dictionary<string, string>() { { "foo", "string" } },
            CallbackUrl = "callback_url",
            CorrelationID = "correlation_id",
            From = "from",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTemplateID = "template_id";
        string expectedTo = "to";
        Dictionary<string, string> expectedVariables = new() { { "foo", "string" } };
        string expectedCallbackUrl = "callback_url";
        string expectedCorrelationID = "correlation_id";
        string expectedFrom = "from";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.Equal(expectedTo, model.To);
        Assert.Equal(expectedVariables.Count, model.Variables.Count);
        foreach (var item in expectedVariables)
        {
            Assert.True(model.Variables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Variables[item.Key]);
        }
        Assert.Equal(expectedCallbackUrl, model.CallbackUrl);
        Assert.Equal(expectedCorrelationID, model.CorrelationID);
        Assert.Equal(expectedFrom, model.From);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TransactionalSendResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateID = "template_id",
            To = "to",
            Variables = new Dictionary<string, string>() { { "foo", "string" } },
            CallbackUrl = "callback_url",
            CorrelationID = "correlation_id",
            From = "from",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransactionalSendResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TransactionalSendResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateID = "template_id",
            To = "to",
            Variables = new Dictionary<string, string>() { { "foo", "string" } },
            CallbackUrl = "callback_url",
            CorrelationID = "correlation_id",
            From = "from",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransactionalSendResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTemplateID = "template_id";
        string expectedTo = "to";
        Dictionary<string, string> expectedVariables = new() { { "foo", "string" } };
        string expectedCallbackUrl = "callback_url";
        string expectedCorrelationID = "correlation_id";
        string expectedFrom = "from";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.Equal(expectedTo, deserialized.To);
        Assert.Equal(expectedVariables.Count, deserialized.Variables.Count);
        foreach (var item in expectedVariables)
        {
            Assert.True(deserialized.Variables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Variables[item.Key]);
        }
        Assert.Equal(expectedCallbackUrl, deserialized.CallbackUrl);
        Assert.Equal(expectedCorrelationID, deserialized.CorrelationID);
        Assert.Equal(expectedFrom, deserialized.From);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TransactionalSendResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateID = "template_id",
            To = "to",
            Variables = new Dictionary<string, string>() { { "foo", "string" } },
            CallbackUrl = "callback_url",
            CorrelationID = "correlation_id",
            From = "from",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TransactionalSendResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateID = "template_id",
            To = "to",
            Variables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TransactionalSendResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateID = "template_id",
            To = "to",
            Variables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TransactionalSendResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateID = "template_id",
            To = "to",
            Variables = new Dictionary<string, string>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            CallbackUrl = null,
            CorrelationID = null,
            From = null,
        };

        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TransactionalSendResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateID = "template_id",
            To = "to",
            Variables = new Dictionary<string, string>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            CallbackUrl = null,
            CorrelationID = null,
            From = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TransactionalSendResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateID = "template_id",
            To = "to",
            Variables = new Dictionary<string, string>() { { "foo", "string" } },
            CallbackUrl = "callback_url",
            CorrelationID = "correlation_id",
            From = "from",
        };

        TransactionalSendResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
