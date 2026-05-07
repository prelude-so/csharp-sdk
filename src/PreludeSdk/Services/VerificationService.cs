using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using PreludeSdk.Core;
using PreludeSdk.Models.Verification;

namespace PreludeSdk.Services;

/// <inheritdoc/>
public sealed class VerificationService : IVerificationService
{
    readonly Lazy<IVerificationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVerificationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPreludeClient _client;

    /// <inheritdoc/>
    public IVerificationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VerificationService(this._client.WithOptions(modifier));
    }

    public VerificationService(IPreludeClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new VerificationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<VerificationCreateResponse> Create(
        VerificationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<VerificationCheckResponse> Check(
        VerificationCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Check(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class VerificationServiceWithRawResponse : IVerificationServiceWithRawResponse
{
    readonly IPreludeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVerificationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VerificationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VerificationServiceWithRawResponse(IPreludeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VerificationCreateResponse>> Create(
        VerificationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VerificationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var verification = await response
                    .Deserialize<VerificationCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    verification.Validate();
                }
                return verification;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VerificationCheckResponse>> Check(
        VerificationCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VerificationCheckParams> request = new()
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
                    .Deserialize<VerificationCheckResponse>(token)
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
