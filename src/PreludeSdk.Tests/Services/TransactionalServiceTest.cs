using System.Threading.Tasks;

namespace PreludeSdk.Tests.Services;

public class TransactionalServiceTest : TestBase
{
    [Fact]
    public async Task Send_Works()
    {
        var response = await this.client.Transactional.Send(
            new() { TemplateID = "template_01hynf45qvevj844m9az2x2f3c", To = "+30123456789" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
