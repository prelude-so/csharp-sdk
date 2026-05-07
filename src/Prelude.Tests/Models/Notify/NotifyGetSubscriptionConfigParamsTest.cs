using System;
using Prelude.Models.Notify;

namespace Prelude.Tests.Models.Notify;

public class NotifyGetSubscriptionConfigParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotifyGetSubscriptionConfigParams { ConfigID = "config_id" };

        string expectedConfigID = "config_id";

        Assert.Equal(expectedConfigID, parameters.ConfigID);
    }

    [Fact]
    public void Url_Works()
    {
        NotifyGetSubscriptionConfigParams parameters = new() { ConfigID = "config_id" };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.prelude.dev/v2/notify/management/subscriptions/config_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotifyGetSubscriptionConfigParams { ConfigID = "config_id" };

        NotifyGetSubscriptionConfigParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
