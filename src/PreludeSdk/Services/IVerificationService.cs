using System;
using System.Threading;
using System.Threading.Tasks;
using PreludeSdk.Core;
using PreludeSdk.Models.Verification;

namespace PreludeSdk.Services;

/// <summary>
/// Verify phone numbers.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVerificationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVerificationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerificationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a new verification for a specific phone number. If another non-expired
    /// verification exists (the request is performed within the verification window),
    /// this endpoint will perform a retry instead.
    /// </summary>
    Task<VerificationCreateResponse> Create(
        VerificationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Check the validity of a verification code.
    /// </summary>
    Task<VerificationCheckResponse> Check(
        VerificationCheckParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IVerificationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVerificationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerificationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v2/verification</c>, but is otherwise the
    /// same as <see cref="IVerificationService.Create(VerificationCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VerificationCreateResponse>> Create(
        VerificationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v2/verification/check</c>, but is otherwise the
    /// same as <see cref="IVerificationService.Check(VerificationCheckParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VerificationCheckResponse>> Check(
        VerificationCheckParams parameters,
        CancellationToken cancellationToken = default
    );
}
