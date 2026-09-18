using System;
using System.Collections.Generic;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.Verification;
using Models = PreludeSdk.Models;

namespace PreludeSdk.Tests.Models.Verification;

public class VerificationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VerificationCreateParams
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
            DispatchID = "123e4567-e89b-12d3-a456-426614174000",
            Metadata = new() { CorrelationID = "correlation_id" },
            Options = new()
            {
                AppRealm = new() { Platform = Platform.Android, Value = "value" },
                CallbackUrl = "callback_url",
                Channels = [Channel.Whatsapp, Channel.Sms],
                CodeSize = 5,
                CustomCode = "123456",
                ForceChallenge = true,
                Locale = "el-GR",
                MaxAutoFallbacks = 0,
                Method = Method.Auto,
                PreferredChannel = PreferredChannel.Sms,
                SenderID = "sender_id",
                TemplateID = "prelude:psd2",
                Variables = new Dictionary<string, string>() { { "foo", "bar" } },
            },
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

        Models::Target expectedTarget = new()
        {
            Type = Models::Type.PhoneNumber,
            Value = "+30123456789",
        };
        string expectedDispatchID = "123e4567-e89b-12d3-a456-426614174000";
        Metadata expectedMetadata = new() { CorrelationID = "correlation_id" };
        Options expectedOptions = new()
        {
            AppRealm = new() { Platform = Platform.Android, Value = "value" },
            CallbackUrl = "callback_url",
            Channels = [Channel.Whatsapp, Channel.Sms],
            CodeSize = 5,
            CustomCode = "123456",
            ForceChallenge = true,
            Locale = "el-GR",
            MaxAutoFallbacks = 0,
            Method = Method.Auto,
            PreferredChannel = PreferredChannel.Sms,
            SenderID = "sender_id",
            TemplateID = "prelude:psd2",
            Variables = new Dictionary<string, string>() { { "foo", "bar" } },
        };
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

        Assert.Equal(expectedTarget, parameters.Target);
        Assert.Equal(expectedDispatchID, parameters.DispatchID);
        Assert.Equal(expectedMetadata, parameters.Metadata);
        Assert.Equal(expectedOptions, parameters.Options);
        Assert.Equal(expectedSignals, parameters.Signals);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VerificationCreateParams
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
        };

        Assert.Null(parameters.DispatchID);
        Assert.False(parameters.RawBodyData.ContainsKey("dispatch_id"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
        Assert.Null(parameters.Signals);
        Assert.False(parameters.RawBodyData.ContainsKey("signals"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VerificationCreateParams
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },

            // Null should be interpreted as omitted for these properties
            DispatchID = null,
            Metadata = null,
            Options = null,
            Signals = null,
        };

        Assert.Null(parameters.DispatchID);
        Assert.False(parameters.RawBodyData.ContainsKey("dispatch_id"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
        Assert.Null(parameters.Signals);
        Assert.False(parameters.RawBodyData.ContainsKey("signals"));
    }

    [Fact]
    public void Url_Works()
    {
        VerificationCreateParams parameters = new()
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.prelude.dev/v2/verification"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VerificationCreateParams
        {
            Target = new() { Type = Models::Type.PhoneNumber, Value = "+30123456789" },
            DispatchID = "123e4567-e89b-12d3-a456-426614174000",
            Metadata = new() { CorrelationID = "correlation_id" },
            Options = new()
            {
                AppRealm = new() { Platform = Platform.Android, Value = "value" },
                CallbackUrl = "callback_url",
                Channels = [Channel.Whatsapp, Channel.Sms],
                CodeSize = 5,
                CustomCode = "123456",
                ForceChallenge = true,
                Locale = "el-GR",
                MaxAutoFallbacks = 0,
                Method = Method.Auto,
                PreferredChannel = PreferredChannel.Sms,
                SenderID = "sender_id",
                TemplateID = "prelude:psd2",
                Variables = new Dictionary<string, string>() { { "foo", "bar" } },
            },
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

        VerificationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class MetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Metadata { CorrelationID = "correlation_id" };

        string expectedCorrelationID = "correlation_id";

        Assert.Equal(expectedCorrelationID, model.CorrelationID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Metadata { CorrelationID = "correlation_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Metadata { CorrelationID = "correlation_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCorrelationID = "correlation_id";

        Assert.Equal(expectedCorrelationID, deserialized.CorrelationID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Metadata { CorrelationID = "correlation_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Metadata { };

        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Metadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Metadata
        {
            // Null should be interpreted as omitted for these properties
            CorrelationID = null,
        };

        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Metadata
        {
            // Null should be interpreted as omitted for these properties
            CorrelationID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Metadata { CorrelationID = "correlation_id" };

        Metadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Options
        {
            AppRealm = new() { Platform = Platform.Android, Value = "value" },
            CallbackUrl = "callback_url",
            Channels = [Channel.Whatsapp, Channel.Sms],
            CodeSize = 5,
            CustomCode = "123456",
            ForceChallenge = true,
            Locale = "el-GR",
            MaxAutoFallbacks = 0,
            Method = Method.Auto,
            PreferredChannel = PreferredChannel.Sms,
            SenderID = "sender_id",
            TemplateID = "prelude:psd2",
            Variables = new Dictionary<string, string>() { { "foo", "bar" } },
        };

        AppRealm expectedAppRealm = new() { Platform = Platform.Android, Value = "value" };
        string expectedCallbackUrl = "callback_url";
        List<ApiEnum<string, Channel>> expectedChannels = [Channel.Whatsapp, Channel.Sms];
        long expectedCodeSize = 5;
        string expectedCustomCode = "123456";
        bool expectedForceChallenge = true;
        string expectedLocale = "el-GR";
        long expectedMaxAutoFallbacks = 0;
        ApiEnum<string, Method> expectedMethod = Method.Auto;
        ApiEnum<string, PreferredChannel> expectedPreferredChannel = PreferredChannel.Sms;
        string expectedSenderID = "sender_id";
        string expectedTemplateID = "prelude:psd2";
        Dictionary<string, string> expectedVariables = new() { { "foo", "bar" } };

        Assert.Equal(expectedAppRealm, model.AppRealm);
        Assert.Equal(expectedCallbackUrl, model.CallbackUrl);
        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedCodeSize, model.CodeSize);
        Assert.Equal(expectedCustomCode, model.CustomCode);
        Assert.Equal(expectedForceChallenge, model.ForceChallenge);
        Assert.Equal(expectedLocale, model.Locale);
        Assert.Equal(expectedMaxAutoFallbacks, model.MaxAutoFallbacks);
        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedPreferredChannel, model.PreferredChannel);
        Assert.Equal(expectedSenderID, model.SenderID);
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.NotNull(model.Variables);
        Assert.Equal(expectedVariables.Count, model.Variables.Count);
        foreach (var item in expectedVariables)
        {
            Assert.True(model.Variables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Variables[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Options
        {
            AppRealm = new() { Platform = Platform.Android, Value = "value" },
            CallbackUrl = "callback_url",
            Channels = [Channel.Whatsapp, Channel.Sms],
            CodeSize = 5,
            CustomCode = "123456",
            ForceChallenge = true,
            Locale = "el-GR",
            MaxAutoFallbacks = 0,
            Method = Method.Auto,
            PreferredChannel = PreferredChannel.Sms,
            SenderID = "sender_id",
            TemplateID = "prelude:psd2",
            Variables = new Dictionary<string, string>() { { "foo", "bar" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Options>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Options
        {
            AppRealm = new() { Platform = Platform.Android, Value = "value" },
            CallbackUrl = "callback_url",
            Channels = [Channel.Whatsapp, Channel.Sms],
            CodeSize = 5,
            CustomCode = "123456",
            ForceChallenge = true,
            Locale = "el-GR",
            MaxAutoFallbacks = 0,
            Method = Method.Auto,
            PreferredChannel = PreferredChannel.Sms,
            SenderID = "sender_id",
            TemplateID = "prelude:psd2",
            Variables = new Dictionary<string, string>() { { "foo", "bar" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Options>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AppRealm expectedAppRealm = new() { Platform = Platform.Android, Value = "value" };
        string expectedCallbackUrl = "callback_url";
        List<ApiEnum<string, Channel>> expectedChannels = [Channel.Whatsapp, Channel.Sms];
        long expectedCodeSize = 5;
        string expectedCustomCode = "123456";
        bool expectedForceChallenge = true;
        string expectedLocale = "el-GR";
        long expectedMaxAutoFallbacks = 0;
        ApiEnum<string, Method> expectedMethod = Method.Auto;
        ApiEnum<string, PreferredChannel> expectedPreferredChannel = PreferredChannel.Sms;
        string expectedSenderID = "sender_id";
        string expectedTemplateID = "prelude:psd2";
        Dictionary<string, string> expectedVariables = new() { { "foo", "bar" } };

        Assert.Equal(expectedAppRealm, deserialized.AppRealm);
        Assert.Equal(expectedCallbackUrl, deserialized.CallbackUrl);
        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedCodeSize, deserialized.CodeSize);
        Assert.Equal(expectedCustomCode, deserialized.CustomCode);
        Assert.Equal(expectedForceChallenge, deserialized.ForceChallenge);
        Assert.Equal(expectedLocale, deserialized.Locale);
        Assert.Equal(expectedMaxAutoFallbacks, deserialized.MaxAutoFallbacks);
        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedPreferredChannel, deserialized.PreferredChannel);
        Assert.Equal(expectedSenderID, deserialized.SenderID);
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.NotNull(deserialized.Variables);
        Assert.Equal(expectedVariables.Count, deserialized.Variables.Count);
        foreach (var item in expectedVariables)
        {
            Assert.True(deserialized.Variables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Variables[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Options
        {
            AppRealm = new() { Platform = Platform.Android, Value = "value" },
            CallbackUrl = "callback_url",
            Channels = [Channel.Whatsapp, Channel.Sms],
            CodeSize = 5,
            CustomCode = "123456",
            ForceChallenge = true,
            Locale = "el-GR",
            MaxAutoFallbacks = 0,
            Method = Method.Auto,
            PreferredChannel = PreferredChannel.Sms,
            SenderID = "sender_id",
            TemplateID = "prelude:psd2",
            Variables = new Dictionary<string, string>() { { "foo", "bar" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Options { };

        Assert.Null(model.AppRealm);
        Assert.False(model.RawData.ContainsKey("app_realm"));
        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.CodeSize);
        Assert.False(model.RawData.ContainsKey("code_size"));
        Assert.Null(model.CustomCode);
        Assert.False(model.RawData.ContainsKey("custom_code"));
        Assert.Null(model.ForceChallenge);
        Assert.False(model.RawData.ContainsKey("force_challenge"));
        Assert.Null(model.Locale);
        Assert.False(model.RawData.ContainsKey("locale"));
        Assert.Null(model.MaxAutoFallbacks);
        Assert.False(model.RawData.ContainsKey("max_auto_fallbacks"));
        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
        Assert.Null(model.PreferredChannel);
        Assert.False(model.RawData.ContainsKey("preferred_channel"));
        Assert.Null(model.SenderID);
        Assert.False(model.RawData.ContainsKey("sender_id"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("template_id"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Options { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Options
        {
            // Null should be interpreted as omitted for these properties
            AppRealm = null,
            CallbackUrl = null,
            Channels = null,
            CodeSize = null,
            CustomCode = null,
            ForceChallenge = null,
            Locale = null,
            MaxAutoFallbacks = null,
            Method = null,
            PreferredChannel = null,
            SenderID = null,
            TemplateID = null,
            Variables = null,
        };

        Assert.Null(model.AppRealm);
        Assert.False(model.RawData.ContainsKey("app_realm"));
        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.CodeSize);
        Assert.False(model.RawData.ContainsKey("code_size"));
        Assert.Null(model.CustomCode);
        Assert.False(model.RawData.ContainsKey("custom_code"));
        Assert.Null(model.ForceChallenge);
        Assert.False(model.RawData.ContainsKey("force_challenge"));
        Assert.Null(model.Locale);
        Assert.False(model.RawData.ContainsKey("locale"));
        Assert.Null(model.MaxAutoFallbacks);
        Assert.False(model.RawData.ContainsKey("max_auto_fallbacks"));
        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
        Assert.Null(model.PreferredChannel);
        Assert.False(model.RawData.ContainsKey("preferred_channel"));
        Assert.Null(model.SenderID);
        Assert.False(model.RawData.ContainsKey("sender_id"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("template_id"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Options
        {
            // Null should be interpreted as omitted for these properties
            AppRealm = null,
            CallbackUrl = null,
            Channels = null,
            CodeSize = null,
            CustomCode = null,
            ForceChallenge = null,
            Locale = null,
            MaxAutoFallbacks = null,
            Method = null,
            PreferredChannel = null,
            SenderID = null,
            TemplateID = null,
            Variables = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Options
        {
            AppRealm = new() { Platform = Platform.Android, Value = "value" },
            CallbackUrl = "callback_url",
            Channels = [Channel.Whatsapp, Channel.Sms],
            CodeSize = 5,
            CustomCode = "123456",
            ForceChallenge = true,
            Locale = "el-GR",
            MaxAutoFallbacks = 0,
            Method = Method.Auto,
            PreferredChannel = PreferredChannel.Sms,
            SenderID = "sender_id",
            TemplateID = "prelude:psd2",
            Variables = new Dictionary<string, string>() { { "foo", "bar" } },
        };

        Options copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AppRealmTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AppRealm { Platform = Platform.Android, Value = "value" };

        ApiEnum<string, Platform> expectedPlatform = Platform.Android;
        string expectedValue = "value";

        Assert.Equal(expectedPlatform, model.Platform);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AppRealm { Platform = Platform.Android, Value = "value" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AppRealm>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AppRealm { Platform = Platform.Android, Value = "value" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AppRealm>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Platform> expectedPlatform = Platform.Android;
        string expectedValue = "value";

        Assert.Equal(expectedPlatform, deserialized.Platform);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AppRealm { Platform = Platform.Android, Value = "value" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AppRealm { Platform = Platform.Android, Value = "value" };

        AppRealm copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlatformTest : TestBase
{
    [Theory]
    [InlineData(Platform.Android)]
    [InlineData(Platform.Web)]
    public void Validation_Works(Platform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Platform> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Platform>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Platform.Android)]
    [InlineData(Platform.Web)]
    public void SerializationRoundtrip_Works(Platform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Platform> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Platform>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Platform>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Platform>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChannelTest : TestBase
{
    [Theory]
    [InlineData(Channel.Sms)]
    [InlineData(Channel.Rcs)]
    [InlineData(Channel.Whatsapp)]
    [InlineData(Channel.Viber)]
    [InlineData(Channel.Zalo)]
    [InlineData(Channel.Telegram)]
    public void Validation_Works(Channel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Channel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Channel.Sms)]
    [InlineData(Channel.Rcs)]
    [InlineData(Channel.Whatsapp)]
    [InlineData(Channel.Viber)]
    [InlineData(Channel.Zalo)]
    [InlineData(Channel.Telegram)]
    public void SerializationRoundtrip_Works(Channel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Channel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MethodTest : TestBase
{
    [Theory]
    [InlineData(Method.Auto)]
    [InlineData(Method.Voice)]
    [InlineData(Method.Message)]
    public void Validation_Works(Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Method> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Method.Auto)]
    [InlineData(Method.Voice)]
    [InlineData(Method.Message)]
    public void SerializationRoundtrip_Works(Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Method> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PreferredChannelTest : TestBase
{
    [Theory]
    [InlineData(PreferredChannel.Sms)]
    [InlineData(PreferredChannel.Rcs)]
    [InlineData(PreferredChannel.Whatsapp)]
    [InlineData(PreferredChannel.Viber)]
    [InlineData(PreferredChannel.Zalo)]
    [InlineData(PreferredChannel.Telegram)]
    public void Validation_Works(PreferredChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreferredChannel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreferredChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PreferredChannel.Sms)]
    [InlineData(PreferredChannel.Rcs)]
    [InlineData(PreferredChannel.Whatsapp)]
    [InlineData(PreferredChannel.Viber)]
    [InlineData(PreferredChannel.Zalo)]
    [InlineData(PreferredChannel.Telegram)]
    public void SerializationRoundtrip_Works(PreferredChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreferredChannel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreferredChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreferredChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreferredChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
