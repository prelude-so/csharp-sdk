using System;
using System.Threading;
using System.Threading.Tasks;
using PreludeSdk.Core;
using PreludeSdk.Models.Notify;

namespace PreludeSdk.Services;

/// <summary>
/// Send transactional and marketing messages with compliance enforcement.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface INotifyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INotifyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotifyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve a specific subscription management configuration by its ID.
    /// </summary>
    Task<NotifyGetSubscriptionConfigResponse> GetSubscriptionConfig(
        NotifyGetSubscriptionConfigParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetSubscriptionConfig(NotifyGetSubscriptionConfigParams, CancellationToken)"/>
    Task<NotifyGetSubscriptionConfigResponse> GetSubscriptionConfig(
        string configID,
        NotifyGetSubscriptionConfigParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the current subscription status for a specific phone number within a
    /// subscription configuration.
    /// </summary>
    Task<NotifyGetSubscriptionPhoneNumberResponse> GetSubscriptionPhoneNumber(
        NotifyGetSubscriptionPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetSubscriptionPhoneNumber(NotifyGetSubscriptionPhoneNumberParams, CancellationToken)"/>
    Task<NotifyGetSubscriptionPhoneNumberResponse> GetSubscriptionPhoneNumber(
        string phoneNumber,
        NotifyGetSubscriptionPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a paginated list of subscription management configurations for your
    /// account.
    ///
    /// <para>Each configuration represents a subscription management setup with phone
    /// numbers for receiving opt-out/opt-in requests and a callback URL for webhook
    /// events. </para>
    /// </summary>
    Task<NotifyListSubscriptionConfigsResponse> ListSubscriptionConfigs(
        NotifyListSubscriptionConfigsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a paginated list of subscription events (status changes) for a specific
    /// phone number within a subscription configuration.
    ///
    /// <para>Events are ordered by timestamp in descending order (most recent first). </para>
    /// </summary>
    Task<NotifyListSubscriptionPhoneNumberEventsResponse> ListSubscriptionPhoneNumberEvents(
        NotifyListSubscriptionPhoneNumberEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListSubscriptionPhoneNumberEvents(NotifyListSubscriptionPhoneNumberEventsParams, CancellationToken)"/>
    Task<NotifyListSubscriptionPhoneNumberEventsResponse> ListSubscriptionPhoneNumberEvents(
        string phoneNumber,
        NotifyListSubscriptionPhoneNumberEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a paginated list of phone numbers and their subscription statuses for a
    /// specific subscription configuration.
    ///
    /// <para>You can optionally filter by subscription state (SUB or UNSUB). </para>
    /// </summary>
    Task<NotifyListSubscriptionPhoneNumbersResponse> ListSubscriptionPhoneNumbers(
        NotifyListSubscriptionPhoneNumbersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListSubscriptionPhoneNumbers(NotifyListSubscriptionPhoneNumbersParams, CancellationToken)"/>
    Task<NotifyListSubscriptionPhoneNumbersResponse> ListSubscriptionPhoneNumbers(
        string configID,
        NotifyListSubscriptionPhoneNumbersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send transactional and marketing messages to your users via SMS, RCS and
    /// WhatsApp with automatic compliance enforcement.
    /// </summary>
    Task<NotifySendResponse> Send(
        NotifySendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send the same message to multiple recipients in a single request.
    /// </summary>
    Task<NotifySendBatchResponse> SendBatch(
        NotifySendBatchParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="INotifyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INotifyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotifyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v2/notify/management/subscriptions/{config_id}</c>, but is otherwise the
    /// same as <see cref="INotifyService.GetSubscriptionConfig(NotifyGetSubscriptionConfigParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotifyGetSubscriptionConfigResponse>> GetSubscriptionConfig(
        NotifyGetSubscriptionConfigParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetSubscriptionConfig(NotifyGetSubscriptionConfigParams, CancellationToken)"/>
    Task<HttpResponse<NotifyGetSubscriptionConfigResponse>> GetSubscriptionConfig(
        string configID,
        NotifyGetSubscriptionConfigParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v2/notify/management/subscriptions/{config_id}/phone_numbers/{phone_number}</c>, but is otherwise the
    /// same as <see cref="INotifyService.GetSubscriptionPhoneNumber(NotifyGetSubscriptionPhoneNumberParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotifyGetSubscriptionPhoneNumberResponse>> GetSubscriptionPhoneNumber(
        NotifyGetSubscriptionPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetSubscriptionPhoneNumber(NotifyGetSubscriptionPhoneNumberParams, CancellationToken)"/>
    Task<HttpResponse<NotifyGetSubscriptionPhoneNumberResponse>> GetSubscriptionPhoneNumber(
        string phoneNumber,
        NotifyGetSubscriptionPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v2/notify/management/subscriptions</c>, but is otherwise the
    /// same as <see cref="INotifyService.ListSubscriptionConfigs(NotifyListSubscriptionConfigsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotifyListSubscriptionConfigsResponse>> ListSubscriptionConfigs(
        NotifyListSubscriptionConfigsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v2/notify/management/subscriptions/{config_id}/phone_numbers/{phone_number}/events</c>, but is otherwise the
    /// same as <see cref="INotifyService.ListSubscriptionPhoneNumberEvents(NotifyListSubscriptionPhoneNumberEventsParams, CancellationToken)"/>.
    /// </summary>
    Task<
        HttpResponse<NotifyListSubscriptionPhoneNumberEventsResponse>
    > ListSubscriptionPhoneNumberEvents(
        NotifyListSubscriptionPhoneNumberEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListSubscriptionPhoneNumberEvents(NotifyListSubscriptionPhoneNumberEventsParams, CancellationToken)"/>
    Task<
        HttpResponse<NotifyListSubscriptionPhoneNumberEventsResponse>
    > ListSubscriptionPhoneNumberEvents(
        string phoneNumber,
        NotifyListSubscriptionPhoneNumberEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v2/notify/management/subscriptions/{config_id}/phone_numbers</c>, but is otherwise the
    /// same as <see cref="INotifyService.ListSubscriptionPhoneNumbers(NotifyListSubscriptionPhoneNumbersParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotifyListSubscriptionPhoneNumbersResponse>> ListSubscriptionPhoneNumbers(
        NotifyListSubscriptionPhoneNumbersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListSubscriptionPhoneNumbers(NotifyListSubscriptionPhoneNumbersParams, CancellationToken)"/>
    Task<HttpResponse<NotifyListSubscriptionPhoneNumbersResponse>> ListSubscriptionPhoneNumbers(
        string configID,
        NotifyListSubscriptionPhoneNumbersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v2/notify</c>, but is otherwise the
    /// same as <see cref="INotifyService.Send(NotifySendParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotifySendResponse>> Send(
        NotifySendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v2/notify/batch</c>, but is otherwise the
    /// same as <see cref="INotifyService.SendBatch(NotifySendBatchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotifySendBatchResponse>> SendBatch(
        NotifySendBatchParams parameters,
        CancellationToken cancellationToken = default
    );
}
