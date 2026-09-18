using System.Threading.Tasks;

namespace PreludeSdk.Tests.Services.Intel;

public class KycServiceTest : TestBase
{
    [Fact]
    public async Task Match_Works()
    {
        var response = await this.client.Intel.Kyc.Match(
            "+12065550100",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
