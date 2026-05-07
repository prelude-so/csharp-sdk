using System.Threading.Tasks;
using Prelude.Models.Verification;

namespace Prelude.Tests.Services;

public class VerificationServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var verification = await this.client.Verification.Create(
            new()
            {
                Target = new() { Type = Type.PhoneNumber, Value = "+30123456789" },
            },
            TestContext.Current.CancellationToken
        );
        verification.Validate();
    }

    [Fact]
    public async Task Check_Works()
    {
        var response = await this.client.Verification.Check(
            new()
            {
                Code = "12345",
                Target = new()
                {
                    Type = VerificationCheckParamsTargetType.PhoneNumber,
                    Value = "+30123456789",
                },
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
