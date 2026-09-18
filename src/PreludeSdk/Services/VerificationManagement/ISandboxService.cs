using System;
using System.Threading;
using System.Threading.Tasks;
using PreludeSdk.Core;
using PreludeSdk.Models.VerificationManagement.Sandbox;

namespace PreludeSdk.Services.VerificationManagement;

/// <summary>
/// Verify phone numbers.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISandboxService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISandboxServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISandboxService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Register a phone number as a sandbox number and associate it with a fixed
    /// attempt code. Subsequent verification attempts against this number will not
    /// trigger a real SMS/call and will validate against the configured attempt code.
    ///
    /// <para>This operation is idempotent - re-adding the same phone number will
    /// overwrite the existing attempt code.</para>
    ///
    /// <para>In order to get access to this endpoint, contact our support team. </para>
    /// </summary>
    Task<SandboxAddPhoneNumberResponse> AddPhoneNumber(
        SandboxAddPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a phone number from the sandbox list.
    ///
    /// <para>This operation is idempotent - deleting a phone number that is not in the
    /// sandbox list will succeed without making any changes.</para>
    ///
    /// <para>In order to get access to this endpoint, contact our support team. </para>
    /// </summary>
    Task<SandboxDeletePhoneNumberResponse> DeletePhoneNumber(
        SandboxDeletePhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeletePhoneNumber(SandboxDeletePhoneNumberParams, CancellationToken)"/>
    Task<SandboxDeletePhoneNumberResponse> DeletePhoneNumber(
        string phoneNumber,
        SandboxDeletePhoneNumberParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the list of sandbox phone numbers for the account. Sandbox numbers are
    /// test numbers that bypass the real verification flow and return a fixed attempt
    /// code.
    ///
    /// <para>In order to get access to this endpoint, contact our support team. </para>
    /// </summary>
    Task<SandboxListPhoneNumbersResponse> ListPhoneNumbers(
        SandboxListPhoneNumbersParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISandboxService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISandboxServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISandboxServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v2/verification/management/phone-numbers/sandbox</c>, but is otherwise the
    /// same as <see cref="ISandboxService.AddPhoneNumber(SandboxAddPhoneNumberParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SandboxAddPhoneNumberResponse>> AddPhoneNumber(
        SandboxAddPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v2/verification/management/phone-numbers/sandbox/{phone_number}</c>, but is otherwise the
    /// same as <see cref="ISandboxService.DeletePhoneNumber(SandboxDeletePhoneNumberParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SandboxDeletePhoneNumberResponse>> DeletePhoneNumber(
        SandboxDeletePhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeletePhoneNumber(SandboxDeletePhoneNumberParams, CancellationToken)"/>
    Task<HttpResponse<SandboxDeletePhoneNumberResponse>> DeletePhoneNumber(
        string phoneNumber,
        SandboxDeletePhoneNumberParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v2/verification/management/phone-numbers/sandbox</c>, but is otherwise the
    /// same as <see cref="ISandboxService.ListPhoneNumbers(SandboxListPhoneNumbersParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SandboxListPhoneNumbersResponse>> ListPhoneNumbers(
        SandboxListPhoneNumbersParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
