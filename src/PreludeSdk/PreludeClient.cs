using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Services;

namespace PreludeSdk;

/// <inheritdoc/>
public sealed class PreludeClient : IPreludeClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiToken
    {
        get { return this._options.ApiToken; }
        init { this._options.ApiToken = value; }
    }

    readonly Lazy<IPreludeClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPreludeClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public IPreludeClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PreludeClient(modifier(this._options));
    }

    readonly Lazy<ILookupService> _lookup;
    public ILookupService Lookup
    {
        get { return _lookup.Value; }
    }

    readonly Lazy<INotifyService> _notify;
    public INotifyService Notify
    {
        get { return _notify.Value; }
    }

    readonly Lazy<ITransactionalService> _transactional;
    public ITransactionalService Transactional
    {
        get { return _transactional.Value; }
    }

    readonly Lazy<IVerificationService> _verification;
    public IVerificationService Verification
    {
        get { return _verification.Value; }
    }

    readonly Lazy<IVerificationManagementService> _verificationManagement;
    public IVerificationManagementService VerificationManagement
    {
        get { return _verificationManagement.Value; }
    }

    readonly Lazy<IWatchService> _watch;
    public IWatchService Watch
    {
        get { return _watch.Value; }
    }

    public void Dispose() => this.HttpClient.Dispose();

    public PreludeClient()
    {
        _options = new();

        _withRawResponse = new(() => new PreludeClientWithRawResponse(this._options));
        _lookup = new(() => new LookupService(this));
        _notify = new(() => new NotifyService(this));
        _transactional = new(() => new TransactionalService(this));
        _verification = new(() => new VerificationService(this));
        _verificationManagement = new(() => new VerificationManagementService(this));
        _watch = new(() => new WatchService(this));
    }

    public PreludeClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class PreludeClientWithRawResponse : IPreludeClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiToken
    {
        get { return this._options.ApiToken; }
        init { this._options.ApiToken = value; }
    }

    /// <inheritdoc/>
    public IPreludeClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PreludeClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<ILookupServiceWithRawResponse> _lookup;
    public ILookupServiceWithRawResponse Lookup
    {
        get { return _lookup.Value; }
    }

    readonly Lazy<INotifyServiceWithRawResponse> _notify;
    public INotifyServiceWithRawResponse Notify
    {
        get { return _notify.Value; }
    }

    readonly Lazy<ITransactionalServiceWithRawResponse> _transactional;
    public ITransactionalServiceWithRawResponse Transactional
    {
        get { return _transactional.Value; }
    }

    readonly Lazy<IVerificationServiceWithRawResponse> _verification;
    public IVerificationServiceWithRawResponse Verification
    {
        get { return _verification.Value; }
    }

    readonly Lazy<IVerificationManagementServiceWithRawResponse> _verificationManagement;
    public IVerificationManagementServiceWithRawResponse VerificationManagement
    {
        get { return _verificationManagement.Value; }
    }

    readonly Lazy<IWatchServiceWithRawResponse> _watch;
    public IWatchServiceWithRawResponse Watch
    {
        get { return _watch.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, retries, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw PreludeExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new PreludeIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new PreludeIOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (
            apiBackoff != null
            && apiBackoff > TimeSpan.Zero
            && apiBackoff < TimeSpan.FromMinutes(1)
        )
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is PreludeIOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public PreludeClientWithRawResponse()
    {
        _options = new();

        _lookup = new(() => new LookupServiceWithRawResponse(this));
        _notify = new(() => new NotifyServiceWithRawResponse(this));
        _transactional = new(() => new TransactionalServiceWithRawResponse(this));
        _verification = new(() => new VerificationServiceWithRawResponse(this));
        _verificationManagement = new(() => new VerificationManagementServiceWithRawResponse(this));
        _watch = new(() => new WatchServiceWithRawResponse(this));
    }

    public PreludeClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
