using System;
using PreludeSdk.Core;
using PreludeSdk.Services.Verification.Phone;

namespace PreludeSdk.Services.Verification;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPhoneService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPhoneServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IHistoryService History { get; }
}

/// <summary>
/// A view of <see cref="IPhoneService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPhoneServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IHistoryServiceWithRawResponse History { get; }
}
