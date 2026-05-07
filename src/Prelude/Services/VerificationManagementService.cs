using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Prelude.Core;
using Prelude.Exceptions;
using VerificationManagement = Prelude.Models.VerificationManagement;

namespace Prelude.Services;

/// <inheritdoc/>
public sealed class VerificationManagementService : IVerificationManagementService
{
    readonly Lazy<IVerificationManagementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVerificationManagementServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPreludeClient _client;

    /// <inheritdoc/>
    public IVerificationManagementService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VerificationManagementService(this._client.WithOptions(modifier));
    }

    public VerificationManagementService(IPreludeClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new VerificationManagementServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<VerificationManagement::VerificationManagementDeletePhoneNumberResponse> DeletePhoneNumber(
        VerificationManagement::VerificationManagementDeletePhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.DeletePhoneNumber(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<VerificationManagement::VerificationManagementDeletePhoneNumberResponse> DeletePhoneNumber(
        ApiEnum<string, VerificationManagement::Action> action,
        VerificationManagement::VerificationManagementDeletePhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeletePhoneNumber(parameters with { Action = action }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VerificationManagement::VerificationManagementListPhoneNumbersResponse> ListPhoneNumbers(
        VerificationManagement::VerificationManagementListPhoneNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListPhoneNumbers(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<VerificationManagement::VerificationManagementListPhoneNumbersResponse> ListPhoneNumbers(
        ApiEnum<
            string,
            VerificationManagement::VerificationManagementListPhoneNumbersParamsAction
        > action,
        VerificationManagement::VerificationManagementListPhoneNumbersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListPhoneNumbers(parameters with { Action = action }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VerificationManagement::VerificationManagementListSenderIdsResponse> ListSenderIds(
        VerificationManagement::VerificationManagementListSenderIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListSenderIds(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<VerificationManagement::VerificationManagementSetPhoneNumberResponse> SetPhoneNumber(
        VerificationManagement::VerificationManagementSetPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SetPhoneNumber(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<VerificationManagement::VerificationManagementSetPhoneNumberResponse> SetPhoneNumber(
        ApiEnum<
            string,
            VerificationManagement::VerificationManagementSetPhoneNumberParamsAction
        > action,
        VerificationManagement::VerificationManagementSetPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SetPhoneNumber(parameters with { Action = action }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VerificationManagement::VerificationManagementSubmitSenderIDResponse> SubmitSenderID(
        VerificationManagement::VerificationManagementSubmitSenderIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SubmitSenderID(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class VerificationManagementServiceWithRawResponse
    : IVerificationManagementServiceWithRawResponse
{
    readonly IPreludeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVerificationManagementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VerificationManagementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VerificationManagementServiceWithRawResponse(IPreludeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<
        HttpResponse<VerificationManagement::VerificationManagementDeletePhoneNumberResponse>
    > DeletePhoneNumber(
        VerificationManagement::VerificationManagementDeletePhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Action == null)
        {
            throw new PreludeInvalidDataException("'parameters.Action' cannot be null");
        }

        HttpRequest<VerificationManagement::VerificationManagementDeletePhoneNumberParams> request =
            new() { Method = HttpMethod.Delete, Params = parameters };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<VerificationManagement::VerificationManagementDeletePhoneNumberResponse>(
                        token
                    )
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
    public Task<
        HttpResponse<VerificationManagement::VerificationManagementDeletePhoneNumberResponse>
    > DeletePhoneNumber(
        ApiEnum<string, VerificationManagement::Action> action,
        VerificationManagement::VerificationManagementDeletePhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeletePhoneNumber(parameters with { Action = action }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<
        HttpResponse<VerificationManagement::VerificationManagementListPhoneNumbersResponse>
    > ListPhoneNumbers(
        VerificationManagement::VerificationManagementListPhoneNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Action == null)
        {
            throw new PreludeInvalidDataException("'parameters.Action' cannot be null");
        }

        HttpRequest<VerificationManagement::VerificationManagementListPhoneNumbersParams> request =
            new() { Method = HttpMethod.Get, Params = parameters };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<VerificationManagement::VerificationManagementListPhoneNumbersResponse>(
                        token
                    )
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
    public Task<
        HttpResponse<VerificationManagement::VerificationManagementListPhoneNumbersResponse>
    > ListPhoneNumbers(
        ApiEnum<
            string,
            VerificationManagement::VerificationManagementListPhoneNumbersParamsAction
        > action,
        VerificationManagement::VerificationManagementListPhoneNumbersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListPhoneNumbers(parameters with { Action = action }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<
        HttpResponse<VerificationManagement::VerificationManagementListSenderIdsResponse>
    > ListSenderIds(
        VerificationManagement::VerificationManagementListSenderIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<VerificationManagement::VerificationManagementListSenderIdsParams> request =
            new() { Method = HttpMethod.Get, Params = parameters };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<VerificationManagement::VerificationManagementListSenderIdsResponse>(
                        token
                    )
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
    public async Task<
        HttpResponse<VerificationManagement::VerificationManagementSetPhoneNumberResponse>
    > SetPhoneNumber(
        VerificationManagement::VerificationManagementSetPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Action == null)
        {
            throw new PreludeInvalidDataException("'parameters.Action' cannot be null");
        }

        HttpRequest<VerificationManagement::VerificationManagementSetPhoneNumberParams> request =
            new() { Method = HttpMethod.Post, Params = parameters };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<VerificationManagement::VerificationManagementSetPhoneNumberResponse>(
                        token
                    )
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
    public Task<
        HttpResponse<VerificationManagement::VerificationManagementSetPhoneNumberResponse>
    > SetPhoneNumber(
        ApiEnum<
            string,
            VerificationManagement::VerificationManagementSetPhoneNumberParamsAction
        > action,
        VerificationManagement::VerificationManagementSetPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SetPhoneNumber(parameters with { Action = action }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<
        HttpResponse<VerificationManagement::VerificationManagementSubmitSenderIDResponse>
    > SubmitSenderID(
        VerificationManagement::VerificationManagementSubmitSenderIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VerificationManagement::VerificationManagementSubmitSenderIDParams> request =
            new() { Method = HttpMethod.Post, Params = parameters };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<VerificationManagement::VerificationManagementSubmitSenderIDResponse>(
                        token
                    )
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
