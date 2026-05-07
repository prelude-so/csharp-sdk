using System.Threading.Tasks;

namespace Prelude.Tests.Services;

public class LookupServiceTest : TestBase
{
    [Fact]
    public async Task Lookup_Works()
    {
        var response = await this.client.Lookup.Lookup(
            "+12065550100",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
