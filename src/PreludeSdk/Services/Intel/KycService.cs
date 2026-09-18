using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.Intel.Kyc;

namespace PreludeSdk.Services.Intel;

/// <inheritdoc/>
public sealed class KycService : IKycService
{
    readonly Lazy<IKycServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IKycServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPreludeClient _client;

    /// <inheritdoc/>
    public IKycService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new KycService(this._client.WithOptions(modifier));
    }

    public KycService(IPreludeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new KycServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<KycMatchResponse> Match(
        KycMatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Match(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<KycMatchResponse> Match(
        string phone,
        KycMatchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Match(parameters with { Phone = phone }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class KycServiceWithRawResponse : IKycServiceWithRawResponse
{
    readonly IPreludeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IKycServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new KycServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public KycServiceWithRawResponse(IPreludeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<KycMatchResponse>> Match(
        KycMatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Phone == null)
        {
            throw new PreludeInvalidDataException("'parameters.Phone' cannot be null");
        }

        HttpRequest<KycMatchParams> request = new()
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
                    .Deserialize<KycMatchResponse>(token)
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
    public Task<HttpResponse<KycMatchResponse>> Match(
        string phone,
        KycMatchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Match(parameters with { Phone = phone }, cancellationToken);
    }
}
