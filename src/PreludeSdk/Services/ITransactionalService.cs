using System;
using System.Threading;
using System.Threading.Tasks;
using PreludeSdk.Core;
using PreludeSdk.Models.Transactional;

namespace PreludeSdk.Services;

/// <summary>
/// Send transactional messages (deprecated - use Notify API instead).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITransactionalService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITransactionalServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITransactionalService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Legacy route maintained for backward compatibility. Migrate to `/v2/notify`
    /// instead.
    /// </summary>
    [Obsolete("deprecated")]
    Task<TransactionalSendResponse> Send(
        TransactionalSendParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITransactionalService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITransactionalServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITransactionalServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v2/transactional</c>, but is otherwise the
    /// same as <see cref="ITransactionalService.Send(TransactionalSendParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<TransactionalSendResponse>> Send(
        TransactionalSendParams parameters,
        CancellationToken cancellationToken = default
    );
}
