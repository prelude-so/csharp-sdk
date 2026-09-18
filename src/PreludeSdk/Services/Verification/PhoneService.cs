using System;
using PreludeSdk.Core;
using PreludeSdk.Services.Verification.Phone;

namespace PreludeSdk.Services.Verification;

/// <inheritdoc/>
public sealed class PhoneService : IPhoneService
{
    readonly Lazy<IPhoneServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPhoneServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPreludeClient _client;

    /// <inheritdoc/>
    public IPhoneService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PhoneService(this._client.WithOptions(modifier));
    }

    public PhoneService(IPreludeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PhoneServiceWithRawResponse(client.WithRawResponse));
        _history = new(() => new HistoryService(client));
    }

    readonly Lazy<IHistoryService> _history;
    public IHistoryService History
    {
        get { return _history.Value; }
    }
}

/// <inheritdoc/>
public sealed class PhoneServiceWithRawResponse : IPhoneServiceWithRawResponse
{
    readonly IPreludeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPhoneServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PhoneServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PhoneServiceWithRawResponse(IPreludeClientWithRawResponse client)
    {
        _client = client;

        _history = new(() => new HistoryServiceWithRawResponse(client));
    }

    readonly Lazy<IHistoryServiceWithRawResponse> _history;
    public IHistoryServiceWithRawResponse History
    {
        get { return _history.Value; }
    }
}
