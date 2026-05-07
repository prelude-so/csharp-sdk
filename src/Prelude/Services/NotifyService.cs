using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Prelude.Core;
using Prelude.Exceptions;
using Prelude.Models.Notify;

namespace Prelude.Services;

/// <inheritdoc/>
public sealed class NotifyService : INotifyService
{
    readonly Lazy<INotifyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INotifyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPreludeClient _client;

    /// <inheritdoc/>
    public INotifyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NotifyService(this._client.WithOptions(modifier));
    }

    public NotifyService(IPreludeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new NotifyServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<NotifyGetSubscriptionConfigResponse> GetSubscriptionConfig(
        NotifyGetSubscriptionConfigParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetSubscriptionConfig(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<NotifyGetSubscriptionConfigResponse> GetSubscriptionConfig(
        string configID,
        NotifyGetSubscriptionConfigParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetSubscriptionConfig(
            parameters with
            {
                ConfigID = configID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<NotifyGetSubscriptionPhoneNumberResponse> GetSubscriptionPhoneNumber(
        NotifyGetSubscriptionPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetSubscriptionPhoneNumber(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<NotifyGetSubscriptionPhoneNumberResponse> GetSubscriptionPhoneNumber(
        string phoneNumber,
        NotifyGetSubscriptionPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetSubscriptionPhoneNumber(
            parameters with
            {
                PhoneNumber = phoneNumber,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<NotifyListSubscriptionConfigsResponse> ListSubscriptionConfigs(
        NotifyListSubscriptionConfigsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListSubscriptionConfigs(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NotifyListSubscriptionPhoneNumberEventsResponse> ListSubscriptionPhoneNumberEvents(
        NotifyListSubscriptionPhoneNumberEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListSubscriptionPhoneNumberEvents(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<NotifyListSubscriptionPhoneNumberEventsResponse> ListSubscriptionPhoneNumberEvents(
        string phoneNumber,
        NotifyListSubscriptionPhoneNumberEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListSubscriptionPhoneNumberEvents(
            parameters with
            {
                PhoneNumber = phoneNumber,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<NotifyListSubscriptionPhoneNumbersResponse> ListSubscriptionPhoneNumbers(
        NotifyListSubscriptionPhoneNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListSubscriptionPhoneNumbers(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<NotifyListSubscriptionPhoneNumbersResponse> ListSubscriptionPhoneNumbers(
        string configID,
        NotifyListSubscriptionPhoneNumbersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListSubscriptionPhoneNumbers(
            parameters with
            {
                ConfigID = configID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<NotifySendResponse> Send(
        NotifySendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Send(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NotifySendBatchResponse> SendBatch(
        NotifySendBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SendBatch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class NotifyServiceWithRawResponse : INotifyServiceWithRawResponse
{
    readonly IPreludeClientWithRawResponse _client;

    /// <inheritdoc/>
    public INotifyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NotifyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NotifyServiceWithRawResponse(IPreludeClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotifyGetSubscriptionConfigResponse>> GetSubscriptionConfig(
        NotifyGetSubscriptionConfigParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConfigID == null)
        {
            throw new PreludeInvalidDataException("'parameters.ConfigID' cannot be null");
        }

        HttpRequest<NotifyGetSubscriptionConfigParams> request = new()
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
                    .Deserialize<NotifyGetSubscriptionConfigResponse>(token)
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
    public Task<HttpResponse<NotifyGetSubscriptionConfigResponse>> GetSubscriptionConfig(
        string configID,
        NotifyGetSubscriptionConfigParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetSubscriptionConfig(
            parameters with
            {
                ConfigID = configID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<
        HttpResponse<NotifyGetSubscriptionPhoneNumberResponse>
    > GetSubscriptionPhoneNumber(
        NotifyGetSubscriptionPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new PreludeInvalidDataException("'parameters.PhoneNumber' cannot be null");
        }

        HttpRequest<NotifyGetSubscriptionPhoneNumberParams> request = new()
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
                    .Deserialize<NotifyGetSubscriptionPhoneNumberResponse>(token)
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
    public Task<HttpResponse<NotifyGetSubscriptionPhoneNumberResponse>> GetSubscriptionPhoneNumber(
        string phoneNumber,
        NotifyGetSubscriptionPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetSubscriptionPhoneNumber(
            parameters with
            {
                PhoneNumber = phoneNumber,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotifyListSubscriptionConfigsResponse>> ListSubscriptionConfigs(
        NotifyListSubscriptionConfigsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NotifyListSubscriptionConfigsParams> request = new()
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
                    .Deserialize<NotifyListSubscriptionConfigsResponse>(token)
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
        HttpResponse<NotifyListSubscriptionPhoneNumberEventsResponse>
    > ListSubscriptionPhoneNumberEvents(
        NotifyListSubscriptionPhoneNumberEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new PreludeInvalidDataException("'parameters.PhoneNumber' cannot be null");
        }

        HttpRequest<NotifyListSubscriptionPhoneNumberEventsParams> request = new()
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
                    .Deserialize<NotifyListSubscriptionPhoneNumberEventsResponse>(token)
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
        HttpResponse<NotifyListSubscriptionPhoneNumberEventsResponse>
    > ListSubscriptionPhoneNumberEvents(
        string phoneNumber,
        NotifyListSubscriptionPhoneNumberEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListSubscriptionPhoneNumberEvents(
            parameters with
            {
                PhoneNumber = phoneNumber,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<
        HttpResponse<NotifyListSubscriptionPhoneNumbersResponse>
    > ListSubscriptionPhoneNumbers(
        NotifyListSubscriptionPhoneNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConfigID == null)
        {
            throw new PreludeInvalidDataException("'parameters.ConfigID' cannot be null");
        }

        HttpRequest<NotifyListSubscriptionPhoneNumbersParams> request = new()
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
                    .Deserialize<NotifyListSubscriptionPhoneNumbersResponse>(token)
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
        HttpResponse<NotifyListSubscriptionPhoneNumbersResponse>
    > ListSubscriptionPhoneNumbers(
        string configID,
        NotifyListSubscriptionPhoneNumbersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListSubscriptionPhoneNumbers(
            parameters with
            {
                ConfigID = configID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotifySendResponse>> Send(
        NotifySendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<NotifySendParams> request = new()
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
                    .Deserialize<NotifySendResponse>(token)
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
    public async Task<HttpResponse<NotifySendBatchResponse>> SendBatch(
        NotifySendBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<NotifySendBatchParams> request = new()
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
                    .Deserialize<NotifySendBatchResponse>(token)
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
