using System;
using System.Threading;
using System.Threading.Tasks;
using PreludeSdk.Core;
using PreludeSdk.Models.Intel.Kyc;

namespace PreludeSdk.Services.Intel;

/// <summary>
/// Retrieve detailed information about a phone number including carrier data, line
/// type, and portability status.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IKycService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IKycServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IKycService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Verify identity attributes against the subscriber record held by the end-user's
    /// mobile operator. Send a phone number along with the attributes to check; Prelude
    /// resolves the operator internally and returns a per-attribute match. Currently
    /// available for France only (Orange, SFR, Bouygues) and must be enabled for your
    /// account.
    /// </summary>
    Task<KycMatchResponse> Match(
        KycMatchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Match(KycMatchParams, CancellationToken)"/>
    Task<KycMatchResponse> Match(
        string phone,
        KycMatchParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IKycService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IKycServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IKycServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v2/intel/kyc/match/{phone}</c>, but is otherwise the
    /// same as <see cref="IKycService.Match(KycMatchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<KycMatchResponse>> Match(
        KycMatchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Match(KycMatchParams, CancellationToken)"/>
    Task<HttpResponse<KycMatchResponse>> Match(
        string phone,
        KycMatchParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
