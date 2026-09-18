using System.Threading.Tasks;
using PreludeSdk.Models.Watch;
using Models = PreludeSdk.Models;

namespace PreludeSdk.Tests.Services;

public class WatchServiceTest : TestBase
{
    [Fact]
    public async Task Evaluate_Works()
    {
        var response = await this.client.Watch.Evaluate(
            new()
            {
                FlowID = "flo_01jc0t6fwwfgfsq1md24mhyztj",
                Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Predict_Works()
    {
        var response = await this.client.Watch.Predict(
            new()
            {
                Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task SendEvents_Works()
    {
        var response = await this.client.Watch.SendEvents(
            new()
            {
                Events =
                [
                    new()
                    {
                        Confidence = Confidence.Maximum,
                        Label = "account.banned",
                        Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task SendFeedbacks_Works()
    {
        var response = await this.client.Watch.SendFeedbacks(
            new()
            {
                Feedbacks =
                [
                    new()
                    {
                        Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
                        Type = Type.VerificationStarted,
                        Metadata = new() { CorrelationID = "correlation_id" },
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
