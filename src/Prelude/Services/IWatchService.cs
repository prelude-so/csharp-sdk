using System;
using System.Threading;
using System.Threading.Tasks;
using Prelude.Core;
using Prelude.Models.Watch;

namespace Prelude.Services;

/// <summary>
/// Evaluate email addresses and phone numbers for trustworthiness.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IWatchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWatchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWatchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Predict the outcome of a verification based on Prelude’s anti-fraud system.
    /// </summary>
    Task<WatchPredictResponse> Predict(
        WatchPredictParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send real-time event data from end-user interactions within your application.
    /// Events will be analyzed for proactive fraud prevention and risk scoring.
    /// </summary>
    Task<WatchSendEventsResponse> SendEvents(
        WatchSendEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send feedback regarding your end-users verification funnel. Events will be
    /// analyzed for proactive fraud prevention and risk scoring.
    /// </summary>
    Task<WatchSendFeedbacksResponse> SendFeedbacks(
        WatchSendFeedbacksParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWatchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWatchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWatchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v2/watch/predict</c>, but is otherwise the
    /// same as <see cref="IWatchService.Predict(WatchPredictParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WatchPredictResponse>> Predict(
        WatchPredictParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v2/watch/event</c>, but is otherwise the
    /// same as <see cref="IWatchService.SendEvents(WatchSendEventsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WatchSendEventsResponse>> SendEvents(
        WatchSendEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v2/watch/feedback</c>, but is otherwise the
    /// same as <see cref="IWatchService.SendFeedbacks(WatchSendFeedbacksParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WatchSendFeedbacksResponse>> SendFeedbacks(
        WatchSendFeedbacksParams parameters,
        CancellationToken cancellationToken = default
    );
}
