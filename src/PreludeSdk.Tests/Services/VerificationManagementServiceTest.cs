using System.Threading.Tasks;
using PreludeSdk.Models.VerificationManagement;

namespace PreludeSdk.Tests.Services;

public class VerificationManagementServiceTest : TestBase
{
    [Fact]
    public async Task DeletePhoneNumber_Works()
    {
        var response = await this.client.VerificationManagement.DeletePhoneNumber(
            Action.Allow,
            new() { PhoneNumber = "+30123456789" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task ListPhoneNumbers_Works()
    {
        var response = await this.client.VerificationManagement.ListPhoneNumbers(
            VerificationManagementListPhoneNumbersParamsAction.Allow,
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task ListSenderIds_Works()
    {
        var response = await this.client.VerificationManagement.ListSenderIds(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task SetPhoneNumber_Works()
    {
        var response = await this.client.VerificationManagement.SetPhoneNumber(
            VerificationManagementSetPhoneNumberParamsAction.Allow,
            new() { PhoneNumber = "+30123456789" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task SubmitSenderID_Works()
    {
        var response = await this.client.VerificationManagement.SubmitSenderID(
            new() { SenderID = "Prelude" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
