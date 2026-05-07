using System.Threading.Tasks;

namespace Prelude.Tests.Services;

public class NotifyServiceTest : TestBase
{
    [Fact]
    public async Task GetSubscriptionConfig_Works()
    {
        var response = await this.client.Notify.GetSubscriptionConfig(
            "config_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task GetSubscriptionPhoneNumber_Works()
    {
        var response = await this.client.Notify.GetSubscriptionPhoneNumber(
            "phone_number",
            new() { ConfigID = "config_id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task ListSubscriptionConfigs_Works()
    {
        var response = await this.client.Notify.ListSubscriptionConfigs(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task ListSubscriptionPhoneNumberEvents_Works()
    {
        var response = await this.client.Notify.ListSubscriptionPhoneNumberEvents(
            "phone_number",
            new() { ConfigID = "config_id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task ListSubscriptionPhoneNumbers_Works()
    {
        var response = await this.client.Notify.ListSubscriptionPhoneNumbers(
            "config_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Send_Works()
    {
        var response = await this.client.Notify.Send(
            new() { TemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9", To = "+33612345678" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task SendBatch_Works()
    {
        var response = await this.client.Notify.SendBatch(
            new()
            {
                TemplateID = "template_01k8ap1btqf5r9fq2c8ax5fhc9",
                To = ["+33612345678", "+15551234567"],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
