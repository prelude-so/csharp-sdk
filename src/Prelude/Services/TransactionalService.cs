using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Prelude.Core;
using Prelude.Models.Transactional;

namespace Prelude.Services;

/// <inheritdoc/>
public sealed class TransactionalService : ITransactionalService
{
    readonly Lazy<ITransactionalServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITransactionalServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPreludeClient _client;

    /// <inheritdoc/>
    public ITransactionalService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TransactionalService(this._client.WithOptions(modifier));
    }

    public TransactionalService(IPreludeClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new TransactionalServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<TransactionalSendResponse> Send(
        TransactionalSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Send(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TransactionalServiceWithRawResponse : ITransactionalServiceWithRawResponse
{
    readonly IPreludeClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITransactionalServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TransactionalServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TransactionalServiceWithRawResponse(IPreludeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<TransactionalSendResponse>> Send(
        TransactionalSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TransactionalSendParams> request = new()
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
                    .Deserialize<TransactionalSendResponse>(token)
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
