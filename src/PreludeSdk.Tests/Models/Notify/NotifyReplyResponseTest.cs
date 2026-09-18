using System;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Models.Notify;

namespace PreludeSdk.Tests.Models.Notify;

public class NotifyReplyResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotifyReplyResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ReplyTo = "im_01k8aq2zggeyssvt53zgvpx63a",
            Text = "Thanks for reaching out! We'll look into your request.",
            To = "+33612345678",
            CallbackUrl = "https://your-app.com/webhooks/notify",
            CorrelationID = "support-ticket-42",
        };

        string expectedID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z");
        string expectedReplyTo = "im_01k8aq2zggeyssvt53zgvpx63a";
        string expectedText = "Thanks for reaching out! We'll look into your request.";
        string expectedTo = "+33612345678";
        string expectedCallbackUrl = "https://your-app.com/webhooks/notify";
        string expectedCorrelationID = "support-ticket-42";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedReplyTo, model.ReplyTo);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedTo, model.To);
        Assert.Equal(expectedCallbackUrl, model.CallbackUrl);
        Assert.Equal(expectedCorrelationID, model.CorrelationID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotifyReplyResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ReplyTo = "im_01k8aq2zggeyssvt53zgvpx63a",
            Text = "Thanks for reaching out! We'll look into your request.",
            To = "+33612345678",
            CallbackUrl = "https://your-app.com/webhooks/notify",
            CorrelationID = "support-ticket-42",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotifyReplyResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotifyReplyResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ReplyTo = "im_01k8aq2zggeyssvt53zgvpx63a",
            Text = "Thanks for reaching out! We'll look into your request.",
            To = "+33612345678",
            CallbackUrl = "https://your-app.com/webhooks/notify",
            CorrelationID = "support-ticket-42",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotifyReplyResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z");
        string expectedReplyTo = "im_01k8aq2zggeyssvt53zgvpx63a";
        string expectedText = "Thanks for reaching out! We'll look into your request.";
        string expectedTo = "+33612345678";
        string expectedCallbackUrl = "https://your-app.com/webhooks/notify";
        string expectedCorrelationID = "support-ticket-42";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedReplyTo, deserialized.ReplyTo);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedTo, deserialized.To);
        Assert.Equal(expectedCallbackUrl, deserialized.CallbackUrl);
        Assert.Equal(expectedCorrelationID, deserialized.CorrelationID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotifyReplyResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ReplyTo = "im_01k8aq2zggeyssvt53zgvpx63a",
            Text = "Thanks for reaching out! We'll look into your request.",
            To = "+33612345678",
            CallbackUrl = "https://your-app.com/webhooks/notify",
            CorrelationID = "support-ticket-42",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NotifyReplyResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ReplyTo = "im_01k8aq2zggeyssvt53zgvpx63a",
            Text = "Thanks for reaching out! We'll look into your request.",
            To = "+33612345678",
        };

        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NotifyReplyResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ReplyTo = "im_01k8aq2zggeyssvt53zgvpx63a",
            Text = "Thanks for reaching out! We'll look into your request.",
            To = "+33612345678",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NotifyReplyResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ReplyTo = "im_01k8aq2zggeyssvt53zgvpx63a",
            Text = "Thanks for reaching out! We'll look into your request.",
            To = "+33612345678",

            // Null should be interpreted as omitted for these properties
            CallbackUrl = null,
            CorrelationID = null,
        };

        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NotifyReplyResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ReplyTo = "im_01k8aq2zggeyssvt53zgvpx63a",
            Text = "Thanks for reaching out! We'll look into your request.",
            To = "+33612345678",

            // Null should be interpreted as omitted for these properties
            CallbackUrl = null,
            CorrelationID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotifyReplyResponse
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CreatedAt = DateTimeOffset.Parse("2025-10-24T12:00:00Z"),
            ReplyTo = "im_01k8aq2zggeyssvt53zgvpx63a",
            Text = "Thanks for reaching out! We'll look into your request.",
            To = "+33612345678",
            CallbackUrl = "https://your-app.com/webhooks/notify",
            CorrelationID = "support-ticket-42",
        };

        NotifyReplyResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
