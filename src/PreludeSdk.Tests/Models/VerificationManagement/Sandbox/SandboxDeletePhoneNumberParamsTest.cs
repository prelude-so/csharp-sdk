using System;
using PreludeSdk.Models.VerificationManagement.Sandbox;

namespace PreludeSdk.Tests.Models.VerificationManagement.Sandbox;

public class SandboxDeletePhoneNumberParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SandboxDeletePhoneNumberParams { PhoneNumber = "+12065550100" };

        string expectedPhoneNumber = "+12065550100";

        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
    }

    [Fact]
    public void Url_Works()
    {
        SandboxDeletePhoneNumberParams parameters = new() { PhoneNumber = "+12065550100" };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.prelude.dev/v2/verification/management/phone-numbers/sandbox/+12065550100"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SandboxDeletePhoneNumberParams { PhoneNumber = "+12065550100" };

        SandboxDeletePhoneNumberParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
