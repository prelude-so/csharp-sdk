using System;
using PreludeSdk.Core;
using PreludeSdk.Services.Intel;

namespace PreludeSdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IIntelService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IIntelServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntelService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IKycService Kyc { get; }
}

/// <summary>
/// A view of <see cref="IIntelService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IIntelServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntelServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IKycServiceWithRawResponse Kyc { get; }
}
