using System;
using PreludeSdk.Models.Notify;

namespace PreludeSdk.Tests.Models.Notify;

public class NotifyListSubscriptionPhoneNumberEventsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotifyListSubscriptionPhoneNumberEventsParams
        {
            ConfigID = "config_id",
            PhoneNumber = "phone_number",
            Cursor = "cursor",
            Limit = 1,
        };

        string expectedConfigID = "config_id";
        string expectedPhoneNumber = "phone_number";
        string expectedCursor = "cursor";
        long expectedLimit = 1;

        Assert.Equal(expectedConfigID, parameters.ConfigID);
        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotifyListSubscriptionPhoneNumberEventsParams
        {
            ConfigID = "config_id",
            PhoneNumber = "phone_number",
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotifyListSubscriptionPhoneNumberEventsParams
        {
            ConfigID = "config_id",
            PhoneNumber = "phone_number",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        NotifyListSubscriptionPhoneNumberEventsParams parameters = new()
        {
            ConfigID = "config_id",
            PhoneNumber = "phone_number",
            Cursor = "cursor",
            Limit = 1,
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.prelude.dev/v2/notify/management/subscriptions/config_id/phone_numbers/phone_number/events?cursor=cursor&limit=1"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotifyListSubscriptionPhoneNumberEventsParams
        {
            ConfigID = "config_id",
            PhoneNumber = "phone_number",
            Cursor = "cursor",
            Limit = 1,
        };

        NotifyListSubscriptionPhoneNumberEventsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
