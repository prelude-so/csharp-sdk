using System;
using System.Collections.Generic;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using Verification = PreludeSdk.Models.Verification;

namespace PreludeSdk.Tests.Models.Verification;

public class VerificationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Verification::VerificationCreateParams
        {
            Target = new() { Type = Verification::Type.PhoneNumber, Value = "+30123456789" },
            DispatchID = "123e4567-e89b-12d3-a456-426614174000",
            Metadata = new() { CorrelationID = "correlation_id" },
            Options = new()
            {
                AppRealm = new() { Platform = Verification::Platform.Android, Value = "value" },
                CallbackUrl = "callback_url",
                Channels = [Verification::Channel.Whatsapp, Verification::Channel.Sms],
                CodeSize = 5,
                CustomCode = "123456",
                ForceChallenge = true,
                Locale = "el-GR",
                MaxAutoFallbacks = 0,
                Method = Verification::Method.Auto,
                PreferredChannel = Verification::PreferredChannel.Sms,
                SenderID = "sender_id",
                TemplateID = "prelude:psd2",
                Variables = new Dictionary<string, string>() { { "foo", "bar" } },
            },
            Signals = new()
            {
                AppVersion = "1.2.34",
                DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
                DeviceModel = "iPhone17,2",
                DevicePlatform = Verification::DevicePlatform.Ios,
                ExistingUser = false,
                IP = "203.0.113.123",
                IsTrustedUser = false,
                Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
                OsVersion = "18.0.1",
                UserAgent =
                    "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
            },
        };

        Verification::Target expectedTarget = new()
        {
            Type = Verification::Type.PhoneNumber,
            Value = "+30123456789",
        };
        string expectedDispatchID = "123e4567-e89b-12d3-a456-426614174000";
        Verification::Metadata expectedMetadata = new() { CorrelationID = "correlation_id" };
        Verification::Options expectedOptions = new()
        {
            AppRealm = new() { Platform = Verification::Platform.Android, Value = "value" },
            CallbackUrl = "callback_url",
            Channels = [Verification::Channel.Whatsapp, Verification::Channel.Sms],
            CodeSize = 5,
            CustomCode = "123456",
            ForceChallenge = true,
            Locale = "el-GR",
            MaxAutoFallbacks = 0,
            Method = Verification::Method.Auto,
            PreferredChannel = Verification::PreferredChannel.Sms,
            SenderID = "sender_id",
            TemplateID = "prelude:psd2",
            Variables = new Dictionary<string, string>() { { "foo", "bar" } },
        };
        Verification::Signals expectedSignals = new()
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = Verification::DevicePlatform.Ios,
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
        var parameters = new Verification::VerificationCreateParams
        {
            Target = new() { Type = Verification::Type.PhoneNumber, Value = "+30123456789" },
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
        var parameters = new Verification::VerificationCreateParams
        {
            Target = new() { Type = Verification::Type.PhoneNumber, Value = "+30123456789" },

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
        Verification::VerificationCreateParams parameters = new()
        {
            Target = new() { Type = Verification::Type.PhoneNumber, Value = "+30123456789" },
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.prelude.dev/v2/verification"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Verification::VerificationCreateParams
        {
            Target = new() { Type = Verification::Type.PhoneNumber, Value = "+30123456789" },
            DispatchID = "123e4567-e89b-12d3-a456-426614174000",
            Metadata = new() { CorrelationID = "correlation_id" },
            Options = new()
            {
                AppRealm = new() { Platform = Verification::Platform.Android, Value = "value" },
                CallbackUrl = "callback_url",
                Channels = [Verification::Channel.Whatsapp, Verification::Channel.Sms],
                CodeSize = 5,
                CustomCode = "123456",
                ForceChallenge = true,
                Locale = "el-GR",
                MaxAutoFallbacks = 0,
                Method = Verification::Method.Auto,
                PreferredChannel = Verification::PreferredChannel.Sms,
                SenderID = "sender_id",
                TemplateID = "prelude:psd2",
                Variables = new Dictionary<string, string>() { { "foo", "bar" } },
            },
            Signals = new()
            {
                AppVersion = "1.2.34",
                DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
                DeviceModel = "iPhone17,2",
                DevicePlatform = Verification::DevicePlatform.Ios,
                ExistingUser = false,
                IP = "203.0.113.123",
                IsTrustedUser = false,
                Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
                OsVersion = "18.0.1",
                UserAgent =
                    "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
            },
        };

        Verification::VerificationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TargetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Verification::Target
        {
            Type = Verification::Type.PhoneNumber,
            Value = "+30123456789",
        };

        ApiEnum<string, Verification::Type> expectedType = Verification::Type.PhoneNumber;
        string expectedValue = "+30123456789";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Verification::Target
        {
            Type = Verification::Type.PhoneNumber,
            Value = "+30123456789",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Verification::Target>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Verification::Target
        {
            Type = Verification::Type.PhoneNumber,
            Value = "+30123456789",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Verification::Target>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Verification::Type> expectedType = Verification::Type.PhoneNumber;
        string expectedValue = "+30123456789";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Verification::Target
        {
            Type = Verification::Type.PhoneNumber,
            Value = "+30123456789",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Verification::Target
        {
            Type = Verification::Type.PhoneNumber,
            Value = "+30123456789",
        };

        Verification::Target copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Verification::Type.PhoneNumber)]
    [InlineData(Verification::Type.EmailAddress)]
    public void Validation_Works(Verification::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Verification::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Verification::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Verification::Type.PhoneNumber)]
    [InlineData(Verification::Type.EmailAddress)]
    public void SerializationRoundtrip_Works(Verification::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Verification::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Verification::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Verification::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Verification::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Verification::Metadata { CorrelationID = "correlation_id" };

        string expectedCorrelationID = "correlation_id";

        Assert.Equal(expectedCorrelationID, model.CorrelationID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Verification::Metadata { CorrelationID = "correlation_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Verification::Metadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Verification::Metadata { CorrelationID = "correlation_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Verification::Metadata>(
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
        var model = new Verification::Metadata { CorrelationID = "correlation_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Verification::Metadata { };

        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Verification::Metadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Verification::Metadata
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
        var model = new Verification::Metadata
        {
            // Null should be interpreted as omitted for these properties
            CorrelationID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Verification::Metadata { CorrelationID = "correlation_id" };

        Verification::Metadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Verification::Options
        {
            AppRealm = new() { Platform = Verification::Platform.Android, Value = "value" },
            CallbackUrl = "callback_url",
            Channels = [Verification::Channel.Whatsapp, Verification::Channel.Sms],
            CodeSize = 5,
            CustomCode = "123456",
            ForceChallenge = true,
            Locale = "el-GR",
            MaxAutoFallbacks = 0,
            Method = Verification::Method.Auto,
            PreferredChannel = Verification::PreferredChannel.Sms,
            SenderID = "sender_id",
            TemplateID = "prelude:psd2",
            Variables = new Dictionary<string, string>() { { "foo", "bar" } },
        };

        Verification::AppRealm expectedAppRealm = new()
        {
            Platform = Verification::Platform.Android,
            Value = "value",
        };
        string expectedCallbackUrl = "callback_url";
        List<ApiEnum<string, Verification::Channel>> expectedChannels =
        [
            Verification::Channel.Whatsapp,
            Verification::Channel.Sms,
        ];
        long expectedCodeSize = 5;
        string expectedCustomCode = "123456";
        bool expectedForceChallenge = true;
        string expectedLocale = "el-GR";
        long expectedMaxAutoFallbacks = 0;
        ApiEnum<string, Verification::Method> expectedMethod = Verification::Method.Auto;
        ApiEnum<string, Verification::PreferredChannel> expectedPreferredChannel =
            Verification::PreferredChannel.Sms;
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
        var model = new Verification::Options
        {
            AppRealm = new() { Platform = Verification::Platform.Android, Value = "value" },
            CallbackUrl = "callback_url",
            Channels = [Verification::Channel.Whatsapp, Verification::Channel.Sms],
            CodeSize = 5,
            CustomCode = "123456",
            ForceChallenge = true,
            Locale = "el-GR",
            MaxAutoFallbacks = 0,
            Method = Verification::Method.Auto,
            PreferredChannel = Verification::PreferredChannel.Sms,
            SenderID = "sender_id",
            TemplateID = "prelude:psd2",
            Variables = new Dictionary<string, string>() { { "foo", "bar" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Verification::Options>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Verification::Options
        {
            AppRealm = new() { Platform = Verification::Platform.Android, Value = "value" },
            CallbackUrl = "callback_url",
            Channels = [Verification::Channel.Whatsapp, Verification::Channel.Sms],
            CodeSize = 5,
            CustomCode = "123456",
            ForceChallenge = true,
            Locale = "el-GR",
            MaxAutoFallbacks = 0,
            Method = Verification::Method.Auto,
            PreferredChannel = Verification::PreferredChannel.Sms,
            SenderID = "sender_id",
            TemplateID = "prelude:psd2",
            Variables = new Dictionary<string, string>() { { "foo", "bar" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Verification::Options>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Verification::AppRealm expectedAppRealm = new()
        {
            Platform = Verification::Platform.Android,
            Value = "value",
        };
        string expectedCallbackUrl = "callback_url";
        List<ApiEnum<string, Verification::Channel>> expectedChannels =
        [
            Verification::Channel.Whatsapp,
            Verification::Channel.Sms,
        ];
        long expectedCodeSize = 5;
        string expectedCustomCode = "123456";
        bool expectedForceChallenge = true;
        string expectedLocale = "el-GR";
        long expectedMaxAutoFallbacks = 0;
        ApiEnum<string, Verification::Method> expectedMethod = Verification::Method.Auto;
        ApiEnum<string, Verification::PreferredChannel> expectedPreferredChannel =
            Verification::PreferredChannel.Sms;
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
        var model = new Verification::Options
        {
            AppRealm = new() { Platform = Verification::Platform.Android, Value = "value" },
            CallbackUrl = "callback_url",
            Channels = [Verification::Channel.Whatsapp, Verification::Channel.Sms],
            CodeSize = 5,
            CustomCode = "123456",
            ForceChallenge = true,
            Locale = "el-GR",
            MaxAutoFallbacks = 0,
            Method = Verification::Method.Auto,
            PreferredChannel = Verification::PreferredChannel.Sms,
            SenderID = "sender_id",
            TemplateID = "prelude:psd2",
            Variables = new Dictionary<string, string>() { { "foo", "bar" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Verification::Options { };

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
        var model = new Verification::Options { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Verification::Options
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
        var model = new Verification::Options
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
        var model = new Verification::Options
        {
            AppRealm = new() { Platform = Verification::Platform.Android, Value = "value" },
            CallbackUrl = "callback_url",
            Channels = [Verification::Channel.Whatsapp, Verification::Channel.Sms],
            CodeSize = 5,
            CustomCode = "123456",
            ForceChallenge = true,
            Locale = "el-GR",
            MaxAutoFallbacks = 0,
            Method = Verification::Method.Auto,
            PreferredChannel = Verification::PreferredChannel.Sms,
            SenderID = "sender_id",
            TemplateID = "prelude:psd2",
            Variables = new Dictionary<string, string>() { { "foo", "bar" } },
        };

        Verification::Options copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AppRealmTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Verification::AppRealm
        {
            Platform = Verification::Platform.Android,
            Value = "value",
        };

        ApiEnum<string, Verification::Platform> expectedPlatform = Verification::Platform.Android;
        string expectedValue = "value";

        Assert.Equal(expectedPlatform, model.Platform);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Verification::AppRealm
        {
            Platform = Verification::Platform.Android,
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Verification::AppRealm>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Verification::AppRealm
        {
            Platform = Verification::Platform.Android,
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Verification::AppRealm>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Verification::Platform> expectedPlatform = Verification::Platform.Android;
        string expectedValue = "value";

        Assert.Equal(expectedPlatform, deserialized.Platform);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Verification::AppRealm
        {
            Platform = Verification::Platform.Android,
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Verification::AppRealm
        {
            Platform = Verification::Platform.Android,
            Value = "value",
        };

        Verification::AppRealm copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlatformTest : TestBase
{
    [Theory]
    [InlineData(Verification::Platform.Android)]
    [InlineData(Verification::Platform.Web)]
    public void Validation_Works(Verification::Platform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Verification::Platform> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Verification::Platform>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Verification::Platform.Android)]
    [InlineData(Verification::Platform.Web)]
    public void SerializationRoundtrip_Works(Verification::Platform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Verification::Platform> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Verification::Platform>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Verification::Platform>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Verification::Platform>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChannelTest : TestBase
{
    [Theory]
    [InlineData(Verification::Channel.Sms)]
    [InlineData(Verification::Channel.Rcs)]
    [InlineData(Verification::Channel.Whatsapp)]
    [InlineData(Verification::Channel.Viber)]
    [InlineData(Verification::Channel.Zalo)]
    [InlineData(Verification::Channel.Telegram)]
    public void Validation_Works(Verification::Channel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Verification::Channel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Verification::Channel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Verification::Channel.Sms)]
    [InlineData(Verification::Channel.Rcs)]
    [InlineData(Verification::Channel.Whatsapp)]
    [InlineData(Verification::Channel.Viber)]
    [InlineData(Verification::Channel.Zalo)]
    [InlineData(Verification::Channel.Telegram)]
    public void SerializationRoundtrip_Works(Verification::Channel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Verification::Channel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Verification::Channel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Verification::Channel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Verification::Channel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MethodTest : TestBase
{
    [Theory]
    [InlineData(Verification::Method.Auto)]
    [InlineData(Verification::Method.Voice)]
    [InlineData(Verification::Method.Message)]
    public void Validation_Works(Verification::Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Verification::Method> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Verification::Method>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Verification::Method.Auto)]
    [InlineData(Verification::Method.Voice)]
    [InlineData(Verification::Method.Message)]
    public void SerializationRoundtrip_Works(Verification::Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Verification::Method> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Verification::Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Verification::Method>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Verification::Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PreferredChannelTest : TestBase
{
    [Theory]
    [InlineData(Verification::PreferredChannel.Sms)]
    [InlineData(Verification::PreferredChannel.Rcs)]
    [InlineData(Verification::PreferredChannel.Whatsapp)]
    [InlineData(Verification::PreferredChannel.Viber)]
    [InlineData(Verification::PreferredChannel.Zalo)]
    [InlineData(Verification::PreferredChannel.Telegram)]
    public void Validation_Works(Verification::PreferredChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Verification::PreferredChannel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Verification::PreferredChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Verification::PreferredChannel.Sms)]
    [InlineData(Verification::PreferredChannel.Rcs)]
    [InlineData(Verification::PreferredChannel.Whatsapp)]
    [InlineData(Verification::PreferredChannel.Viber)]
    [InlineData(Verification::PreferredChannel.Zalo)]
    [InlineData(Verification::PreferredChannel.Telegram)]
    public void SerializationRoundtrip_Works(Verification::PreferredChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Verification::PreferredChannel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Verification::PreferredChannel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Verification::PreferredChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Verification::PreferredChannel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SignalsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Verification::Signals
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = Verification::DevicePlatform.Ios,
            ExistingUser = false,
            IP = "203.0.113.123",
            IsTrustedUser = false,
            Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
            OsVersion = "18.0.1",
            UserAgent =
                "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
        };

        string expectedAppVersion = "1.2.34";
        string expectedDeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2";
        string expectedDeviceModel = "iPhone17,2";
        ApiEnum<string, Verification::DevicePlatform> expectedDevicePlatform =
            Verification::DevicePlatform.Ios;
        bool expectedExistingUser = false;
        string expectedIP = "203.0.113.123";
        bool expectedIsTrustedUser = false;
        string expectedJa4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1";
        string expectedOsVersion = "18.0.1";
        string expectedUserAgent =
            "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1";

        Assert.Equal(expectedAppVersion, model.AppVersion);
        Assert.Equal(expectedDeviceID, model.DeviceID);
        Assert.Equal(expectedDeviceModel, model.DeviceModel);
        Assert.Equal(expectedDevicePlatform, model.DevicePlatform);
        Assert.Equal(expectedExistingUser, model.ExistingUser);
        Assert.Equal(expectedIP, model.IP);
        Assert.Equal(expectedIsTrustedUser, model.IsTrustedUser);
        Assert.Equal(expectedJa4Fingerprint, model.Ja4Fingerprint);
        Assert.Equal(expectedOsVersion, model.OsVersion);
        Assert.Equal(expectedUserAgent, model.UserAgent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Verification::Signals
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = Verification::DevicePlatform.Ios,
            ExistingUser = false,
            IP = "203.0.113.123",
            IsTrustedUser = false,
            Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
            OsVersion = "18.0.1",
            UserAgent =
                "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Verification::Signals>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Verification::Signals
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = Verification::DevicePlatform.Ios,
            ExistingUser = false,
            IP = "203.0.113.123",
            IsTrustedUser = false,
            Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
            OsVersion = "18.0.1",
            UserAgent =
                "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Verification::Signals>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAppVersion = "1.2.34";
        string expectedDeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2";
        string expectedDeviceModel = "iPhone17,2";
        ApiEnum<string, Verification::DevicePlatform> expectedDevicePlatform =
            Verification::DevicePlatform.Ios;
        bool expectedExistingUser = false;
        string expectedIP = "203.0.113.123";
        bool expectedIsTrustedUser = false;
        string expectedJa4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1";
        string expectedOsVersion = "18.0.1";
        string expectedUserAgent =
            "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1";

        Assert.Equal(expectedAppVersion, deserialized.AppVersion);
        Assert.Equal(expectedDeviceID, deserialized.DeviceID);
        Assert.Equal(expectedDeviceModel, deserialized.DeviceModel);
        Assert.Equal(expectedDevicePlatform, deserialized.DevicePlatform);
        Assert.Equal(expectedExistingUser, deserialized.ExistingUser);
        Assert.Equal(expectedIP, deserialized.IP);
        Assert.Equal(expectedIsTrustedUser, deserialized.IsTrustedUser);
        Assert.Equal(expectedJa4Fingerprint, deserialized.Ja4Fingerprint);
        Assert.Equal(expectedOsVersion, deserialized.OsVersion);
        Assert.Equal(expectedUserAgent, deserialized.UserAgent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Verification::Signals
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = Verification::DevicePlatform.Ios,
            ExistingUser = false,
            IP = "203.0.113.123",
            IsTrustedUser = false,
            Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
            OsVersion = "18.0.1",
            UserAgent =
                "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Verification::Signals { };

        Assert.Null(model.AppVersion);
        Assert.False(model.RawData.ContainsKey("app_version"));
        Assert.Null(model.DeviceID);
        Assert.False(model.RawData.ContainsKey("device_id"));
        Assert.Null(model.DeviceModel);
        Assert.False(model.RawData.ContainsKey("device_model"));
        Assert.Null(model.DevicePlatform);
        Assert.False(model.RawData.ContainsKey("device_platform"));
        Assert.Null(model.ExistingUser);
        Assert.False(model.RawData.ContainsKey("existing_user"));
        Assert.Null(model.IP);
        Assert.False(model.RawData.ContainsKey("ip"));
        Assert.Null(model.IsTrustedUser);
        Assert.False(model.RawData.ContainsKey("is_trusted_user"));
        Assert.Null(model.Ja4Fingerprint);
        Assert.False(model.RawData.ContainsKey("ja4_fingerprint"));
        Assert.Null(model.OsVersion);
        Assert.False(model.RawData.ContainsKey("os_version"));
        Assert.Null(model.UserAgent);
        Assert.False(model.RawData.ContainsKey("user_agent"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Verification::Signals { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Verification::Signals
        {
            // Null should be interpreted as omitted for these properties
            AppVersion = null,
            DeviceID = null,
            DeviceModel = null,
            DevicePlatform = null,
            ExistingUser = null,
            IP = null,
            IsTrustedUser = null,
            Ja4Fingerprint = null,
            OsVersion = null,
            UserAgent = null,
        };

        Assert.Null(model.AppVersion);
        Assert.False(model.RawData.ContainsKey("app_version"));
        Assert.Null(model.DeviceID);
        Assert.False(model.RawData.ContainsKey("device_id"));
        Assert.Null(model.DeviceModel);
        Assert.False(model.RawData.ContainsKey("device_model"));
        Assert.Null(model.DevicePlatform);
        Assert.False(model.RawData.ContainsKey("device_platform"));
        Assert.Null(model.ExistingUser);
        Assert.False(model.RawData.ContainsKey("existing_user"));
        Assert.Null(model.IP);
        Assert.False(model.RawData.ContainsKey("ip"));
        Assert.Null(model.IsTrustedUser);
        Assert.False(model.RawData.ContainsKey("is_trusted_user"));
        Assert.Null(model.Ja4Fingerprint);
        Assert.False(model.RawData.ContainsKey("ja4_fingerprint"));
        Assert.Null(model.OsVersion);
        Assert.False(model.RawData.ContainsKey("os_version"));
        Assert.Null(model.UserAgent);
        Assert.False(model.RawData.ContainsKey("user_agent"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Verification::Signals
        {
            // Null should be interpreted as omitted for these properties
            AppVersion = null,
            DeviceID = null,
            DeviceModel = null,
            DevicePlatform = null,
            ExistingUser = null,
            IP = null,
            IsTrustedUser = null,
            Ja4Fingerprint = null,
            OsVersion = null,
            UserAgent = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Verification::Signals
        {
            AppVersion = "1.2.34",
            DeviceID = "8F0B8FDD-C2CB-4387-B20A-56E9B2E5A0D2",
            DeviceModel = "iPhone17,2",
            DevicePlatform = Verification::DevicePlatform.Ios,
            ExistingUser = false,
            IP = "203.0.113.123",
            IsTrustedUser = false,
            Ja4Fingerprint = "t13d1516h2_8daaf6152771_e5627efa2ab1",
            OsVersion = "18.0.1",
            UserAgent =
                "Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Mobile/15E148 Safari/604.1",
        };

        Verification::Signals copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DevicePlatformTest : TestBase
{
    [Theory]
    [InlineData(Verification::DevicePlatform.Android)]
    [InlineData(Verification::DevicePlatform.Ios)]
    [InlineData(Verification::DevicePlatform.Ipados)]
    [InlineData(Verification::DevicePlatform.Tvos)]
    [InlineData(Verification::DevicePlatform.Web)]
    public void Validation_Works(Verification::DevicePlatform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Verification::DevicePlatform> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Verification::DevicePlatform>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Verification::DevicePlatform.Android)]
    [InlineData(Verification::DevicePlatform.Ios)]
    [InlineData(Verification::DevicePlatform.Ipados)]
    [InlineData(Verification::DevicePlatform.Tvos)]
    [InlineData(Verification::DevicePlatform.Web)]
    public void SerializationRoundtrip_Works(Verification::DevicePlatform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Verification::DevicePlatform> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Verification::DevicePlatform>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Verification::DevicePlatform>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Verification::DevicePlatform>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
