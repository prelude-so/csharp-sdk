using System;
using System.Threading;
using System.Threading.Tasks;
using PreludeSdk.Core;
using PreludeSdk.Models.Verification.Phone.History;

namespace PreludeSdk.Services.Verification.Phone;

/// <summary>
/// Verify phone numbers.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IHistoryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IHistoryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IHistoryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve everything Prelude recorded for one phone verification: its outcome and
    /// the device, network and anti-fraud context it was created in, the chronological
    /// timeline of every message attempt and code check, and the anti-fraud signals you
    /// forwarded.
    ///
    /// <para>The identifier is the `id` returned by [Create or retry a
    /// verification](/verify/v2/api-reference/create-or-retry-a-verification) or the
    /// `verification_id` of the verification webhooks. Both `lifecycle` and `signals`
    /// are optional: a verification can resolve with its top-level fields alone. </para>
    /// </summary>
    Task<HistoryRetrieveResponse> Retrieve(
        HistoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(HistoryRetrieveParams, CancellationToken)"/>
    Task<HistoryRetrieveResponse> Retrieve(
        string id,
        HistoryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List your phone verifications, most recent first, one entry per verification
    /// with its outcome, channels, attempts and cost. Every filter is optional and they
    /// combine with AND.
    ///
    /// <para>Use it to find every verification a phone number went through from your
    /// support tooling, then [Get a phone
    /// verification](/verify/v2/api-reference/history/get-a-phone-verification) for the
    /// full timeline of one of them. A cursor is bound to the filters that produced it:
    /// pass `next_cursor` back with the exact same query parameters. </para>
    /// </summary>
    Task<HistoryListResponse> List(
        HistoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IHistoryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IHistoryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IHistoryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v2/verification/phone/history/{id}</c>, but is otherwise the
    /// same as <see cref="IHistoryService.Retrieve(HistoryRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<HistoryRetrieveResponse>> Retrieve(
        HistoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(HistoryRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<HistoryRetrieveResponse>> Retrieve(
        string id,
        HistoryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v2/verification/phone/history</c>, but is otherwise the
    /// same as <see cref="IHistoryService.List(HistoryListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<HistoryListResponse>> List(
        HistoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
