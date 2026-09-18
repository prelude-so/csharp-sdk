using System.Text.Json;
using PreludeSdk.Exceptions;
using PreludeSdk.Models;
using PreludeSdk.Models.Intel.Kyc;
using PreludeSdk.Models.Notify;
using PreludeSdk.Models.VerificationManagement;
using History = PreludeSdk.Models.Verification.Phone.History;
using Lookup = PreludeSdk.Models.Lookup;
using Transactional = PreludeSdk.Models.Transactional;
using Verification = PreludeSdk.Models.Verification;
using Watch = PreludeSdk.Models.Watch;

namespace PreludeSdk.Core;

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
            new ApiEnumConverter<string, DevicePlatform>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, Lookup::Flag>(),
            new ApiEnumConverter<string, Lookup::LineType>(),
            new ApiEnumConverter<string, Lookup::Type>(),
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
            new ApiEnumConverter<string, Verification::VerificationCreateResponseChannel>(),
            new ApiEnumConverter<string, Verification::Reason>(),
            new ApiEnumConverter<string, Verification::RiskFactor>(),
            new ApiEnumConverter<string, Verification::VerificationCheckResponseStatus>(),
            new ApiEnumConverter<string, Verification::Platform>(),
            new ApiEnumConverter<string, Verification::Channel>(),
            new ApiEnumConverter<string, Verification::Method>(),
            new ApiEnumConverter<string, Verification::PreferredChannel>(),
            new ApiEnumConverter<string, History::HistoryRetrieveResponseStatus>(),
            new ApiEnumConverter<string, History::BlockReason>(),
            new ApiEnumConverter<string, History::HistoryRetrieveResponseDevicePlatform>(),
            new ApiEnumConverter<string, History::Type>(),
            new ApiEnumConverter<string, History::AttemptChannel>(),
            new ApiEnumConverter<string, History::DeliveryEventStatus>(),
            new ApiEnumConverter<string, History::DeliveryStatus>(),
            new ApiEnumConverter<string, History::PreferredChannel>(),
            new ApiEnumConverter<string, History::AttemptStatus>(),
            new ApiEnumConverter<string, History::Trigger>(),
            new ApiEnumConverter<string, History::CheckChannel>(),
            new ApiEnumConverter<string, History::StatusDetail>(),
            new ApiEnumConverter<string, History::SignalsStatus>(),
            new ApiEnumConverter<string, History::PhoneNumberCondition>(),
            new ApiEnumConverter<string, History::PhoneNumberCurrentCondition>(),
            new ApiEnumConverter<string, History::SignalsHashStatus>(),
            new ApiEnumConverter<string, History::HistoryListResponseVerificationChannelChannel>(),
            new ApiEnumConverter<string, History::HistoryListResponseVerificationStatus>(),
            new ApiEnumConverter<string, History::HistoryListResponseVerificationDevicePlatform>(),
            new ApiEnumConverter<
                string,
                History::HistoryListResponseVerificationPhoneNumberCondition
            >(),
            new ApiEnumConverter<
                string,
                History::HistoryListResponseVerificationSignalsHashStatus
            >(),
            new ApiEnumConverter<string, History::Channel>(),
            new ApiEnumConverter<string, History::DevicePlatform>(),
            new ApiEnumConverter<string, History::Status>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, VerificationManagementSubmitSenderIDResponseStatus>(),
            new ApiEnumConverter<string, Action>(),
            new ApiEnumConverter<string, VerificationManagementListPhoneNumbersParamsAction>(),
            new ApiEnumConverter<string, VerificationManagementSetPhoneNumberParamsAction>(),
            new ApiEnumConverter<string, Watch::Action>(),
            new ApiEnumConverter<string, Watch::Outcome>(),
            new ApiEnumConverter<string, Watch::Verdict>(),
            new ApiEnumConverter<string, Watch::WatchEvaluateResponseVerdict>(),
            new ApiEnumConverter<string, Watch::Prediction>(),
            new ApiEnumConverter<string, Watch::RiskFactor>(),
            new ApiEnumConverter<string, Watch::Status>(),
            new ApiEnumConverter<string, Watch::WatchSendFeedbacksResponseStatus>(),
            new ApiEnumConverter<string, Watch::Confidence>(),
            new ApiEnumConverter<string, Watch::Type>(),
            new ApiEnumConverter<string, AddressMatch>(),
            new ApiEnumConverter<string, BirthdateMatch>(),
            new ApiEnumConverter<string, CountryMatch>(),
            new ApiEnumConverter<string, EmailMatch>(),
            new ApiEnumConverter<string, FamilyNameMatch>(),
            new ApiEnumConverter<string, GivenNameMatch>(),
            new ApiEnumConverter<string, LocalityMatch>(),
            new ApiEnumConverter<string, PostalCodeMatch>(),
            new ApiEnumConverter<string, RegionMatch>(),
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
