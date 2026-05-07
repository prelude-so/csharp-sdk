using System;
using PreludeSdk.Models.VerificationManagement;

namespace PreludeSdk.Tests.Models.VerificationManagement;

public class VerificationManagementSubmitSenderIDParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VerificationManagementSubmitSenderIDParams { SenderID = "Prelude" };

        string expectedSenderID = "Prelude";

        Assert.Equal(expectedSenderID, parameters.SenderID);
    }

    [Fact]
    public void Url_Works()
    {
        VerificationManagementSubmitSenderIDParams parameters = new() { SenderID = "Prelude" };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.prelude.dev/v2/verification/management/sender-id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VerificationManagementSubmitSenderIDParams { SenderID = "Prelude" };

        VerificationManagementSubmitSenderIDParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
