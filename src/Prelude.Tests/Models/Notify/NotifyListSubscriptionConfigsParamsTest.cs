using System;
using Prelude.Models.Notify;

namespace Prelude.Tests.Models.Notify;

public class NotifyListSubscriptionConfigsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotifyListSubscriptionConfigsParams { Cursor = "cursor", Limit = 1 };

        string expectedCursor = "cursor";
        long expectedLimit = 1;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotifyListSubscriptionConfigsParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotifyListSubscriptionConfigsParams
        {
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
        NotifyListSubscriptionConfigsParams parameters = new() { Cursor = "cursor", Limit = 1 };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.prelude.dev/v2/notify/management/subscriptions?cursor=cursor&limit=1"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotifyListSubscriptionConfigsParams { Cursor = "cursor", Limit = 1 };

        NotifyListSubscriptionConfigsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
