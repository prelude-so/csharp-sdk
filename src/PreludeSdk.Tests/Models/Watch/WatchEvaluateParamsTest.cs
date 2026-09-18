using System;
using System.Collections.Generic;
using PreludeSdk.Models.Watch;
using Models = PreludeSdk.Models;

namespace PreludeSdk.Tests.Models.Watch;

public class WatchEvaluateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WatchEvaluateParams
        {
            FlowID = "flo_01jc0t6fwwfgfsq1md24mhyztj",
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
            Attributes = new Dictionary<string, string>()
            {
                { "plan_tier", "free" },
                { "account_age_days", "3" },
            },
            DispatchID = "123e4567-e89b-12d3-a456-426614174000",
            Signals = new()
            {
                AppVersion = "1.2.34",
                DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
                DeviceModel = "iPhone17,2",
                DevicePlatform = Models::DevicePlatform.Ios,
                ExistingUser = false,
                IP = "203.0.113.123",
                IsTrustedUser = false,
                Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
                OsVersion = "18.0.1",
                UserAgent =
                    "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
            },
        };

        string expectedFlowID = "flo_01jc0t6fwwfgfsq1md24mhyztj";
        Models::Target expectedTarget = new()
        {
            Type = Models::Type.PhoneNumber,
            Value = "+30123456789",
        };
        Dictionary<string, string> expectedAttributes = new()
        {
            { "plan_tier", "free" },
            { "account_age_days", "3" },
        };
        string expectedDispatchID = "123e4567-e89b-12d3-a456-426614174000";
        Models::Signals expectedSignals = new()
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = Models::DevicePlatform.Ios,
            ExistingUser = false,
            IP = "203.0.113.123",
            IsTrustedUser = false,
            Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
            OsVersion = "18.0.1",
            UserAgent =
                "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
        };

        Assert.Equal(expectedFlowID, parameters.FlowID);
        Assert.Equal(expectedTarget, parameters.Target);
        Assert.NotNull(parameters.Attributes);
        Assert.Equal(expectedAttributes.Count, parameters.Attributes.Count);
        foreach (var item in expectedAttributes)
        {
            Assert.True(parameters.Attributes.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Attributes[item.Key]);
        }
        Assert.Equal(expectedDispatchID, parameters.DispatchID);
        Assert.Equal(expectedSignals, parameters.Signals);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WatchEvaluateParams
        {
            FlowID = "flo_01jc0t6fwwfgfsq1md24mhyztj",
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
        };

        Assert.Null(parameters.Attributes);
        Assert.False(parameters.RawBodyData.ContainsKey("attributes"));
        Assert.Null(parameters.DispatchID);
        Assert.False(parameters.RawBodyData.ContainsKey("dispatch_id"));
        Assert.Null(parameters.Signals);
        Assert.False(parameters.RawBodyData.ContainsKey("signals"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WatchEvaluateParams
        {
            FlowID = "flo_01jc0t6fwwfgfsq1md24mhyztj",
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },

            // Null should be interpreted as omitted for these properties
            Attributes = null,
            DispatchID = null,
            Signals = null,
        };

        Assert.Null(parameters.Attributes);
        Assert.False(parameters.RawBodyData.ContainsKey("attributes"));
        Assert.Null(parameters.DispatchID);
        Assert.False(parameters.RawBodyData.ContainsKey("dispatch_id"));
        Assert.Null(parameters.Signals);
        Assert.False(parameters.RawBodyData.ContainsKey("signals"));
    }

    [Fact]
    public void Url_Works()
    {
        WatchEvaluateParams parameters = new()
        {
            FlowID = "flo_01jc0t6fwwfgfsq1md24mhyztj",
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.prelude.dev/v2/watch/eval"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WatchEvaluateParams
        {
            FlowID = "flo_01jc0t6fwwfgfsq1md24mhyztj",
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
            Attributes = new Dictionary<string, string>()
            {
                { "plan_tier", "free" },
                { "account_age_days", "3" },
            },
            DispatchID = "123e4567-e89b-12d3-a456-426614174000",
            Signals = new()
            {
                AppVersion = "1.2.34",
                DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
                DeviceModel = "iPhone17,2",
                DevicePlatform = Models::DevicePlatform.Ios,
                ExistingUser = false,
                IP = "203.0.113.123",
                IsTrustedUser = false,
                Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
                OsVersion = "18.0.1",
                UserAgent =
                    "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
            },
        };

        WatchEvaluateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
