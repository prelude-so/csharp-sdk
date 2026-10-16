using System;
using System.Threading;
using System.Threading.Tasks;
using PreludeSdk.Core;
using PreludeSdk.Models.Watch;

namespace PreludeSdk.Services;

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
    /// **Beta.** The request and response shapes may still change. Talk to us before
    /// you build against it. Flows, recipes and rules are authored through the Watch
    /// Management API, or configured by Prelude on your behalf.
    ///
    /// <para>Score a target against the rules configured for one moment in your product
    /// — signup, checkout, password reset. The flow selects which recipes run; each
    /// recipe scores its rules against a threshold and returns its own verdict, and the
    /// evaluation answers with the most severe verdict and action across them. Where
    /// Predict returns a single model-derived outcome, Eval returns the full breakdown,
    /// so you can see which rules fired and which could not run. Scoring-only — it does
    /// not update counters by itself.</para>
    /// </summary>
    Task<WatchEvaluateResponse> Evaluate(
        WatchEvaluateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// At signup, score the user's phone number or email address (target) as legitimate
    /// or suspicious. Scoring-only — does not update counters by itself. When using
    /// Feedback, call predict before verification.started on the same target (and
    /// correlation_id when used) so feedback can warm Watch auth-start counters. Use
    /// Events for product fraud labels; use Feedback only if you run your own phone
    /// verification funnel outside Prelude Verify.
    /// </summary>
    Task<WatchPredictResponse> Predict(
        WatchPredictParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send custom fraud signals from your application (labels and confidence levels).
    /// Events capture product-specific risk patterns and are weighted when scoring
    /// traffic. Use without Predict or Feedback if you only need to report product-side
    /// abuse (for example account.banned). Feedback is a separate, optional endpoint
    /// for self-hosted phone verification funnels.
    /// </summary>
    Task<WatchSendEventsResponse> SendEvents(
        WatchSendEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Optional. Report verification-funnel steps (verification.started,
    /// verification.completed) when you run phone verification outside Prelude Verify.
    /// Feeds Watch abuse-rate counters for your own flow. Call Predict on the same
    /// target before verification.started and reuse metadata.correlation_id so
    /// auth-start counters receive predict signals; without a linked predict, only
    /// attempt-rate counters update on started. Not required if you only use Events
    /// and/or Predict, or if Verify already handles verification for that traffic.
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
    /// Returns a raw HTTP response for <c>post /v2/watch/eval</c>, but is otherwise the
    /// same as <see cref="IWatchService.Evaluate(WatchEvaluateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WatchEvaluateResponse>> Evaluate(
        WatchEvaluateParams parameters,
        CancellationToken cancellationToken = default
    );

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
