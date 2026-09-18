using System;
using PreludeSdk.Core;
using PreludeSdk.Services.Intel;

namespace PreludeSdk.Services;

/// <inheritdoc/>
public sealed class IntelService : IIntelService
{
    readonly Lazy<IIntelServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IIntelServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPreludeClient _client;

    /// <inheritdoc/>
    public IIntelService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IntelService(this._client.WithOptions(modifier));
    }

    public IntelService(IPreludeClient client)
    {
        _client = client;

        _withRawResponse = new(() => new IntelServiceWithRawResponse(client.WithRawResponse));
        _kyc = new(() => new KycService(client));
    }

    readonly Lazy<IKycService> _kyc;
    public IKycService Kyc
    {
        get { return _kyc.Value; }
    }
}

/// <inheritdoc/>
public sealed class IntelServiceWithRawResponse : IIntelServiceWithRawResponse
{
    readonly IPreludeClientWithRawResponse _client;

    /// <inheritdoc/>
    public IIntelServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IntelServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public IntelServiceWithRawResponse(IPreludeClientWithRawResponse client)
    {
        _client = client;

        _kyc = new(() => new KycServiceWithRawResponse(client));
    }

    readonly Lazy<IKycServiceWithRawResponse> _kyc;
    public IKycServiceWithRawResponse Kyc
    {
        get { return _kyc.Value; }
    }
}
