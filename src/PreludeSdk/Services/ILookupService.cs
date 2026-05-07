using System;
using System.Threading;
using System.Threading.Tasks;
using PreludeSdk.Core;
using PreludeSdk.Models.Lookup;

namespace PreludeSdk.Services;

/// <summary>
/// Retrieve detailed information about a phone number including carrier data, line
/// type, and portability status.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ILookupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILookupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILookupService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve detailed information about a phone number including carrier data, line
    /// type, and portability status.
    /// </summary>
    Task<LookupLookupResponse> Lookup(
        LookupLookupParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Lookup(LookupLookupParams, CancellationToken)"/>
    Task<LookupLookupResponse> Lookup(
        string phoneNumber,
        LookupLookupParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILookupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILookupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILookupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v2/lookup/{phone_number}</c>, but is otherwise the
    /// same as <see cref="ILookupService.Lookup(LookupLookupParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LookupLookupResponse>> Lookup(
        LookupLookupParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Lookup(LookupLookupParams, CancellationToken)"/>
    Task<HttpResponse<LookupLookupResponse>> Lookup(
        string phoneNumber,
        LookupLookupParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
