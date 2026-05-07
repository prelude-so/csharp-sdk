using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Prelude.Core;
using Prelude.Exceptions;
using Prelude.Models.Lookup;

namespace Prelude.Services;

/// <inheritdoc/>
public sealed class LookupService : ILookupService
{
    readonly Lazy<ILookupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILookupServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPreludeClient _client;

    /// <inheritdoc/>
    public ILookupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LookupService(this._client.WithOptions(modifier));
    }

    public LookupService(IPreludeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LookupServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<LookupLookupResponse> Lookup(
        LookupLookupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Lookup(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LookupLookupResponse> Lookup(
        string phoneNumber,
        LookupLookupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Lookup(parameters with { PhoneNumber = phoneNumber }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class LookupServiceWithRawResponse : ILookupServiceWithRawResponse
{
    readonly IPreludeClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILookupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LookupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LookupServiceWithRawResponse(IPreludeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LookupLookupResponse>> Lookup(
        LookupLookupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new PreludeInvalidDataException("'parameters.PhoneNumber' cannot be null");
        }

        HttpRequest<LookupLookupParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<LookupLookupResponse>(token)
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
    public Task<HttpResponse<LookupLookupResponse>> Lookup(
        string phoneNumber,
        LookupLookupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Lookup(parameters with { PhoneNumber = phoneNumber }, cancellationToken);
    }
}
