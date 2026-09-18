using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.VerificationManagement.Sandbox;

namespace PreludeSdk.Services.VerificationManagement;

/// <inheritdoc/>
public sealed class SandboxService : ISandboxService
{
    readonly Lazy<ISandboxServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISandboxServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPreludeClient _client;

    /// <inheritdoc/>
    public ISandboxService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SandboxService(this._client.WithOptions(modifier));
    }

    public SandboxService(IPreludeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SandboxServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<SandboxAddPhoneNumberResponse> AddPhoneNumber(
        SandboxAddPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.AddPhoneNumber(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SandboxDeletePhoneNumberResponse> DeletePhoneNumber(
        SandboxDeletePhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.DeletePhoneNumber(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SandboxDeletePhoneNumberResponse> DeletePhoneNumber(
        string phoneNumber,
        SandboxDeletePhoneNumberParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DeletePhoneNumber(
            parameters with
            {
                PhoneNumber = phoneNumber,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<SandboxListPhoneNumbersResponse> ListPhoneNumbers(
        SandboxListPhoneNumbersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListPhoneNumbers(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SandboxServiceWithRawResponse : ISandboxServiceWithRawResponse
{
    readonly IPreludeClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISandboxServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SandboxServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SandboxServiceWithRawResponse(IPreludeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SandboxAddPhoneNumberResponse>> AddPhoneNumber(
        SandboxAddPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SandboxAddPhoneNumberParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SandboxAddPhoneNumberResponse>(token)
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
    public async Task<HttpResponse<SandboxDeletePhoneNumberResponse>> DeletePhoneNumber(
        SandboxDeletePhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new PreludeInvalidDataException("'parameters.PhoneNumber' cannot be null");
        }

        HttpRequest<SandboxDeletePhoneNumberParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SandboxDeletePhoneNumberResponse>(token)
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
    public Task<HttpResponse<SandboxDeletePhoneNumberResponse>> DeletePhoneNumber(
        string phoneNumber,
        SandboxDeletePhoneNumberParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DeletePhoneNumber(
            parameters with
            {
                PhoneNumber = phoneNumber,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SandboxListPhoneNumbersResponse>> ListPhoneNumbers(
        SandboxListPhoneNumbersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SandboxListPhoneNumbersParams> request = new()
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
                    .Deserialize<SandboxListPhoneNumbersResponse>(token)
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
