using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Prelude.Core;
using Prelude.Models.Watch;

namespace Prelude.Services;

/// <inheritdoc/>
public sealed class WatchService : IWatchService
{
    readonly Lazy<IWatchServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWatchServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPreludeClient _client;

    /// <inheritdoc/>
    public IWatchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WatchService(this._client.WithOptions(modifier));
    }

    public WatchService(IPreludeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WatchServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<WatchPredictResponse> Predict(
        WatchPredictParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Predict(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WatchSendEventsResponse> SendEvents(
        WatchSendEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SendEvents(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WatchSendFeedbacksResponse> SendFeedbacks(
        WatchSendFeedbacksParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SendFeedbacks(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class WatchServiceWithRawResponse : IWatchServiceWithRawResponse
{
    readonly IPreludeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWatchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WatchServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WatchServiceWithRawResponse(IPreludeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WatchPredictResponse>> Predict(
        WatchPredictParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WatchPredictParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<WatchPredictResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WatchSendEventsResponse>> SendEvents(
        WatchSendEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WatchSendEventsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<WatchSendEventsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WatchSendFeedbacksResponse>> SendFeedbacks(
        WatchSendFeedbacksParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WatchSendFeedbacksParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<WatchSendFeedbacksResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
