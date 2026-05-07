using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Prelude.Core;
using Prelude.Services;

namespace Prelude;

/// <summary>
/// A client for interacting with the Prelude REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPreludeClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Bearer token for authorizing API requests.
    /// </summary>
    string ApiToken { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPreludeClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPreludeClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ILookupService Lookup { get; }

    INotifyService Notify { get; }

    ITransactionalService Transactional { get; }

    IVerificationService Verification { get; }

    IVerificationManagementService VerificationManagement { get; }

    IWatchService Watch { get; }
}

/// <summary>
/// A view of <see cref="IPreludeClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IPreludeClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Bearer token for authorizing API requests.
    /// </summary>
    string ApiToken { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPreludeClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ILookupServiceWithRawResponse Lookup { get; }

    INotifyServiceWithRawResponse Notify { get; }

    ITransactionalServiceWithRawResponse Transactional { get; }

    IVerificationServiceWithRawResponse Verification { get; }

    IVerificationManagementServiceWithRawResponse VerificationManagement { get; }

    IWatchServiceWithRawResponse Watch { get; }

    /// <summary>
    /// Sends a request to the Prelude REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
