using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.Verification.Phone.History;

namespace PreludeSdk.Services.Verification.Phone;

/// <inheritdoc/>
public sealed class HistoryService : IHistoryService
{
    readonly Lazy<IHistoryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IHistoryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPreludeClient _client;

    /// <inheritdoc/>
    public IHistoryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new HistoryService(this._client.WithOptions(modifier));
    }

    public HistoryService(IPreludeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new HistoryServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<HistoryRetrieveResponse> Retrieve(
        HistoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<HistoryRetrieveResponse> Retrieve(
        string id,
        HistoryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HistoryListResponse> List(
        HistoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class HistoryServiceWithRawResponse : IHistoryServiceWithRawResponse
{
    readonly IPreludeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IHistoryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new HistoryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public HistoryServiceWithRawResponse(IPreludeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<HistoryRetrieveResponse>> Retrieve(
        HistoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new PreludeInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<HistoryRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var history = await response
                    .Deserialize<HistoryRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    history.Validate();
                }
                return history;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<HistoryRetrieveResponse>> Retrieve(
        string id,
        HistoryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<HistoryListResponse>> List(
        HistoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<HistoryListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var histories = await response
                    .Deserialize<HistoryListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    histories.Validate();
                }
                return histories;
            }
        );
    }
}
