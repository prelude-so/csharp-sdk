using System;
using PreludeSdk.Models.Notify;

namespace PreludeSdk.Tests.Models.Notify;

public class NotifyReplyParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotifyReplyParams
        {
            ReplyTo = "im_01k8aq2zggeyssvt53zgvpx63a",
            Text = "Thanks for reaching out! We'll look into your request.",
            To = "+33612345678",
            CallbackUrl = "https://your-app.com/webhooks/notify",
            CorrelationID = "support-ticket-42",
        };

        string expectedReplyTo = "im_01k8aq2zggeyssvt53zgvpx63a";
        string expectedText = "Thanks for reaching out! We'll look into your request.";
        string expectedTo = "+33612345678";
        string expectedCallbackUrl = "https://your-app.com/webhooks/notify";
        string expectedCorrelationID = "support-ticket-42";

        Assert.Equal(expectedReplyTo, parameters.ReplyTo);
        Assert.Equal(expectedText, parameters.Text);
        Assert.Equal(expectedTo, parameters.To);
        Assert.Equal(expectedCallbackUrl, parameters.CallbackUrl);
        Assert.Equal(expectedCorrelationID, parameters.CorrelationID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotifyReplyParams
        {
            ReplyTo = "im_01k8aq2zggeyssvt53zgvpx63a",
            Text = "Thanks for reaching out! We'll look into your request.",
            To = "+33612345678",
        };

        Assert.Null(parameters.CallbackUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("callback_url"));
        Assert.Null(parameters.CorrelationID);
        Assert.False(parameters.RawBodyData.ContainsKey("correlation_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotifyReplyParams
        {
            ReplyTo = "im_01k8aq2zggeyssvt53zgvpx63a",
            Text = "Thanks for reaching out! We'll look into your request.",
            To = "+33612345678",

            // Null should be interpreted as omitted for these properties
            CallbackUrl = null,
            CorrelationID = null,
        };

        Assert.Null(parameters.CallbackUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("callback_url"));
        Assert.Null(parameters.CorrelationID);
        Assert.False(parameters.RawBodyData.ContainsKey("correlation_id"));
    }

    [Fact]
    public void Url_Works()
    {
        NotifyReplyParams parameters = new()
        {
            ReplyTo = "im_01k8aq2zggeyssvt53zgvpx63a",
            Text = "Thanks for reaching out! We'll look into your request.",
            To = "+33612345678",
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.prelude.dev/v2/notify/reply"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotifyReplyParams
        {
            ReplyTo = "im_01k8aq2zggeyssvt53zgvpx63a",
            Text = "Thanks for reaching out! We'll look into your request.",
            To = "+33612345678",
            CallbackUrl = "https://your-app.com/webhooks/notify",
            CorrelationID = "support-ticket-42",
        };

        NotifyReplyParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
