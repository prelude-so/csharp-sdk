using System;
using System.Collections.Generic;
using System.Text.Json;
using Prelude.Core;
using Prelude.Exceptions;
using Prelude.Models.Notify;

namespace Prelude.Tests.Models.Notify;

public class NotifySendResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotifySendResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ExpiresAt = DateTimeOffset.Parse("2025-12-25T18:00:00Z"),
            TemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9",
            To = "+33612345678",
            Variables = new Dictionary<string, string>()
            {
                { "order_id", "12345" },
                { "amount", "$49.99" },
            },
            CallbackUrl = "https://your-app.com/webhooks/notify",
            CorrelationID = "order-12345",
            Encoding = Encoding.Gsm7,
            EstimatedSegmentCount = 1,
            From = "YourBrand",
            ScheduleAt = DateTimeOffset.Parse("2025-12-25T08:00:00-05:00"),
        };

        string expectedID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2025-12-25T18:00:00Z");
        string expectedTemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9";
        string expectedTo = "+33612345678";
        Dictionary<string, string> expectedVariables = new()
        {
            { "order_id", "12345" },
            { "amount", "$49.99" },
        };
        string expectedCallbackUrl = "https://your-app.com/webhooks/notify";
        string expectedCorrelationID = "order-12345";
        ApiEnum<string, Encoding> expectedEncoding = Encoding.Gsm7;
        long expectedEstimatedSegmentCount = 1;
        string expectedFrom = "YourBrand";
        DateTimeOffset expectedScheduleAt = DateTimeOffset.Parse("2025-12-25T08:00:00-05:00");

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
        Assert.Equal(expectedEncoding, model.Encoding);
        Assert.Equal(expectedEstimatedSegmentCount, model.EstimatedSegmentCount);
        Assert.Equal(expectedFrom, model.From);
        Assert.Equal(expectedScheduleAt, model.ScheduleAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotifySendResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ExpiresAt = DateTimeOffset.Parse("2025-12-25T18:00:00Z"),
            TemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9",
            To = "+33612345678",
            Variables = new Dictionary<string, string>()
            {
                { "order_id", "12345" },
                { "amount", "$49.99" },
            },
            CallbackUrl = "https://your-app.com/webhooks/notify",
            CorrelationID = "order-12345",
            Encoding = Encoding.Gsm7,
            EstimatedSegmentCount = 1,
            From = "YourBrand",
            ScheduleAt = DateTimeOffset.Parse("2025-12-25T08:00:00-05:00"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotifySendResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotifySendResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ExpiresAt = DateTimeOffset.Parse("2025-12-25T18:00:00Z"),
            TemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9",
            To = "+33612345678",
            Variables = new Dictionary<string, string>()
            {
                { "order_id", "12345" },
                { "amount", "$49.99" },
            },
            CallbackUrl = "https://your-app.com/webhooks/notify",
            CorrelationID = "order-12345",
            Encoding = Encoding.Gsm7,
            EstimatedSegmentCount = 1,
            From = "YourBrand",
            ScheduleAt = DateTimeOffset.Parse("2025-12-25T08:00:00-05:00"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotifySendResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2025-12-25T18:00:00Z");
        string expectedTemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9";
        string expectedTo = "+33612345678";
        Dictionary<string, string> expectedVariables = new()
        {
            { "order_id", "12345" },
            { "amount", "$49.99" },
        };
        string expectedCallbackUrl = "https://your-app.com/webhooks/notify";
        string expectedCorrelationID = "order-12345";
        ApiEnum<string, Encoding> expectedEncoding = Encoding.Gsm7;
        long expectedEstimatedSegmentCount = 1;
        string expectedFrom = "YourBrand";
        DateTimeOffset expectedScheduleAt = DateTimeOffset.Parse("2025-12-25T08:00:00-05:00");

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
        Assert.Equal(expectedEncoding, deserialized.Encoding);
        Assert.Equal(expectedEstimatedSegmentCount, deserialized.EstimatedSegmentCount);
        Assert.Equal(expectedFrom, deserialized.From);
        Assert.Equal(expectedScheduleAt, deserialized.ScheduleAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotifySendResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ExpiresAt = DateTimeOffset.Parse("2025-12-25T18:00:00Z"),
            TemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9",
            To = "+33612345678",
            Variables = new Dictionary<string, string>()
            {
                { "order_id", "12345" },
                { "amount", "$49.99" },
            },
            CallbackUrl = "https://your-app.com/webhooks/notify",
            CorrelationID = "order-12345",
            Encoding = Encoding.Gsm7,
            EstimatedSegmentCount = 1,
            From = "YourBrand",
            ScheduleAt = DateTimeOffset.Parse("2025-12-25T08:00:00-05:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NotifySendResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ExpiresAt = DateTimeOffset.Parse("2025-12-25T18:00:00Z"),
            TemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9",
            To = "+33612345678",
            Variables = new Dictionary<string, string>()
            {
                { "order_id", "12345" },
                { "amount", "$49.99" },
            },
        };

        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
        Assert.Null(model.Encoding);
        Assert.False(model.RawData.ContainsKey("encoding"));
        Assert.Null(model.EstimatedSegmentCount);
        Assert.False(model.RawData.ContainsKey("estimated_segment_count"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.ScheduleAt);
        Assert.False(model.RawData.ContainsKey("schedule_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NotifySendResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ExpiresAt = DateTimeOffset.Parse("2025-12-25T18:00:00Z"),
            TemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9",
            To = "+33612345678",
            Variables = new Dictionary<string, string>()
            {
                { "order_id", "12345" },
                { "amount", "$49.99" },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NotifySendResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ExpiresAt = DateTimeOffset.Parse("2025-12-25T18:00:00Z"),
            TemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9",
            To = "+33612345678",
            Variables = new Dictionary<string, string>()
            {
                { "order_id", "12345" },
                { "amount", "$49.99" },
            },

            // Null should be interpreted as omitted for these properties
            CallbackUrl = null,
            CorrelationID = null,
            Encoding = null,
            EstimatedSegmentCount = null,
            From = null,
            ScheduleAt = null,
        };

        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
        Assert.Null(model.Encoding);
        Assert.False(model.RawData.ContainsKey("encoding"));
        Assert.Null(model.EstimatedSegmentCount);
        Assert.False(model.RawData.ContainsKey("estimated_segment_count"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.ScheduleAt);
        Assert.False(model.RawData.ContainsKey("schedule_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NotifySendResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ExpiresAt = DateTimeOffset.Parse("2025-12-25T18:00:00Z"),
            TemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9",
            To = "+33612345678",
            Variables = new Dictionary<string, string>()
            {
                { "order_id", "12345" },
                { "amount", "$49.99" },
            },

            // Null should be interpreted as omitted for these properties
            CallbackUrl = null,
            CorrelationID = null,
            Encoding = null,
            EstimatedSegmentCount = null,
            From = null,
            ScheduleAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotifySendResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ExpiresAt = DateTimeOffset.Parse("2025-12-25T18:00:00Z"),
            TemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9",
            To = "+33612345678",
            Variables = new Dictionary<string, string>()
            {
                { "order_id", "12345" },
                { "amount", "$49.99" },
            },
            CallbackUrl = "https://your-app.com/webhooks/notify",
            CorrelationID = "order-12345",
            Encoding = Encoding.Gsm7,
            EstimatedSegmentCount = 1,
            From = "YourBrand",
            ScheduleAt = DateTimeOffset.Parse("2025-12-25T08:00:00-05:00"),
        };

        NotifySendResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EncodingTest : TestBase
{
    [Theory]
    [InlineData(Encoding.Gsm7)]
    [InlineData(Encoding.Ucs2)]
    public void Validation_Works(Encoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Encoding> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Encoding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Encoding.Gsm7)]
    [InlineData(Encoding.Ucs2)]
    public void SerializationRoundtrip_Works(Encoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Encoding> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Encoding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Encoding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Encoding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
