using System;
using PreludeSdk.Models.VerificationManagement.Sandbox;

namespace PreludeSdk.Tests.Models.VerificationManagement.Sandbox;

public class SandboxAddPhoneNumberParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SandboxAddPhoneNumberParams
        {
            AttemptCode = "123456",
            PhoneNumber = "+30123456789",
        };

        string expectedAttemptCode = "123456";
        string expectedPhoneNumber = "+30123456789";

        Assert.Equal(expectedAttemptCode, parameters.AttemptCode);
        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
    }

    [Fact]
    public void Url_Works()
    {
        SandboxAddPhoneNumberParams parameters = new()
        {
            AttemptCode = "123456",
            PhoneNumber = "+30123456789",
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.prelude.dev/v2/verification/management/phone-numbers/sandbox"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SandboxAddPhoneNumberParams
        {
            AttemptCode = "123456",
            PhoneNumber = "+30123456789",
        };

        SandboxAddPhoneNumberParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
