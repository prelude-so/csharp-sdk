using System;
using PreludeSdk.Models.Verification.Phone.History;

namespace PreludeSdk.Tests.Models.Verification.Phone.History;

public class HistoryRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new HistoryRetrieveParams { ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj" };

        string expectedID = "vrf_01jc0t6fwwfgfsq1md24mhyztj";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        HistoryRetrieveParams parameters = new() { ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj" };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.prelude.dev/v2/verification/phone/history/vrf_01jc0t6fwwfgfsq1md24mhyztj"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new HistoryRetrieveParams { ID = "vrf_01jc0t6fwwfgfsq1md24mhyztj" };

        HistoryRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
