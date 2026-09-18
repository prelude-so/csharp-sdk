using System.Threading.Tasks;

namespace PreludeSdk.Tests.Services.VerificationManagement;

public class SandboxServiceTest : TestBase
{
    [Fact]
    public async Task AddPhoneNumber_Works()
    {
        var response = await this.client.VerificationManagement.Sandbox.AddPhoneNumber(
            new() { AttemptCode = "123456", PhoneNumber = "+30123456789" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task DeletePhoneNumber_Works()
    {
        var response = await this.client.VerificationManagement.Sandbox.DeletePhoneNumber(
            "+12065550100",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task ListPhoneNumbers_Works()
    {
        var response = await this.client.VerificationManagement.Sandbox.ListPhoneNumbers(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
