using System;
using PreludeSdk.Models.Notify;

namespace PreludeSdk.Tests.Models.Notify;

public class NotifyGetSubscriptionPhoneNumberParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotifyGetSubscriptionPhoneNumberParams
        {
            ConfigID = "config_id",
            PhoneNumber = "phone_number",
        };

        string expectedConfigID = "config_id";
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedConfigID, parameters.ConfigID);
        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
    }

    [Fact]
    public void Url_Works()
    {
        NotifyGetSubscriptionPhoneNumberParams parameters = new()
        {
            ConfigID = "config_id",
            PhoneNumber = "phone_number",
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.prelude.dev/v2/notify/management/subscriptions/config_id/phone_numbers/phone_number"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotifyGetSubscriptionPhoneNumberParams
        {
            ConfigID = "config_id",
            PhoneNumber = "phone_number",
        };

        NotifyGetSubscriptionPhoneNumberParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
