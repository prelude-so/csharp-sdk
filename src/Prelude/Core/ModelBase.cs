using System.Text.Json;
using Prelude.Exceptions;
using Prelude.Models.Lookup;
using Prelude.Models.Notify;
using Prelude.Models.VerificationManagement;
using Transactional = Prelude.Models.Transactional;
using Verification = Prelude.Models.Verification;
using Watch = Prelude.Models.Watch;

namespace Prelude.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, Flag>(),
            new ApiEnumConverter<string, LineType>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, Source>(),
            new ApiEnumConverter<string, NotifyGetSubscriptionPhoneNumberResponseState>(),
            new ApiEnumConverter<string, EventSource>(),
            new ApiEnumConverter<string, EventState>(),
            new ApiEnumConverter<string, PhoneNumberSource>(),
            new ApiEnumConverter<string, PhoneNumberState>(),
            new ApiEnumConverter<string, Encoding>(),
            new ApiEnumConverter<string, MessageEncoding>(),
            new ApiEnumConverter<string, State>(),
            new ApiEnumConverter<string, PreferredChannel>(),
            new ApiEnumConverter<string, NotifySendBatchParamsPreferredChannel>(),
            new ApiEnumConverter<string, Transactional::PreferredChannel>(),
            new ApiEnumConverter<string, Verification::VerificationCreateResponseMethod>(),
            new ApiEnumConverter<string, Verification::Status>(),
            new ApiEnumConverter<string, Verification::Channel>(),
            new ApiEnumConverter<string, Verification::Reason>(),
            new ApiEnumConverter<string, Verification::RiskFactor>(),
            new ApiEnumConverter<string, Verification::VerificationCheckResponseStatus>(),
            new ApiEnumConverter<string, Verification::Type>(),
            new ApiEnumConverter<string, Verification::Platform>(),
            new ApiEnumConverter<string, Verification::Method>(),
            new ApiEnumConverter<string, Verification::PreferredChannel>(),
            new ApiEnumConverter<string, Verification::DevicePlatform>(),
            new ApiEnumConverter<string, Verification::VerificationCheckParamsTargetType>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, VerificationManagementSubmitSenderIDResponseStatus>(),
            new ApiEnumConverter<string, Action>(),
            new ApiEnumConverter<string, VerificationManagementListPhoneNumbersParamsAction>(),
            new ApiEnumConverter<string, VerificationManagementSetPhoneNumberParamsAction>(),
            new ApiEnumConverter<string, Watch::Prediction>(),
            new ApiEnumConverter<string, Watch::RiskFactor>(),
            new ApiEnumConverter<string, Watch::Status>(),
            new ApiEnumConverter<string, Watch::WatchSendFeedbacksResponseStatus>(),
            new ApiEnumConverter<string, Watch::Type>(),
            new ApiEnumConverter<string, Watch::DevicePlatform>(),
            new ApiEnumConverter<string, Watch::Confidence>(),
            new ApiEnumConverter<string, Watch::EventTargetType>(),
            new ApiEnumConverter<string, Watch::FeedbackTargetType>(),
            new ApiEnumConverter<string, Watch::FeedbackType>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="PreludeInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
