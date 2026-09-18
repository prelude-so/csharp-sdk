using System.Threading.Tasks;

namespace PreludeSdk.Tests.Services.Verification.Phone;

public class HistoryServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var history = await this.client.Verification.Phone.History.Retrieve(
            "vrf_01jc0t6fwwfgfsq1md24mhyztj",
            new(),
            TestContext.Current.CancellationToken
        );
        history.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var histories = await this.client.Verification.Phone.History.List(
            new(),
            TestContext.Current.CancellationToken
        );
        histories.Validate();
    }
}
