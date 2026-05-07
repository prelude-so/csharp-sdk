using System;
using System.Threading;
using System.Threading.Tasks;
using PreludeSdk.Core;
using VerificationManagement = PreludeSdk.Models.VerificationManagement;

namespace PreludeSdk.Services;

/// <summary>
/// Verify phone numbers.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVerificationManagementService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVerificationManagementServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerificationManagementService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Remove a phone number from the allow or block list.
    ///
    /// <para>This operation is idempotent - re-deleting the same phone number will not
    /// result in errors. If the phone number does not exist in the specified list, the
    /// operation will succeed without making any changes.</para>
    ///
    /// <para>In order to get access to this endpoint, contact our support team. </para>
    /// </summary>
    Task<VerificationManagement::VerificationManagementDeletePhoneNumberResponse> DeletePhoneNumber(
        VerificationManagement::VerificationManagementDeletePhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeletePhoneNumber(VerificationManagement::VerificationManagementDeletePhoneNumberParams, CancellationToken)"/>
    Task<VerificationManagement::VerificationManagementDeletePhoneNumberResponse> DeletePhoneNumber(
        ApiEnum<string, VerificationManagement::Action> action,
        VerificationManagement::VerificationManagementDeletePhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the list of phone numbers in the allow or block list.
    ///
    /// <para>In order to get access to this endpoint, contact our support team. </para>
    /// </summary>
    Task<VerificationManagement::VerificationManagementListPhoneNumbersResponse> ListPhoneNumbers(
        VerificationManagement::VerificationManagementListPhoneNumbersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPhoneNumbers(VerificationManagement::VerificationManagementListPhoneNumbersParams, CancellationToken)"/>
    Task<VerificationManagement::VerificationManagementListPhoneNumbersResponse> ListPhoneNumbers(
        ApiEnum<
            string,
            VerificationManagement::VerificationManagementListPhoneNumbersParamsAction
        > action,
        VerificationManagement::VerificationManagementListPhoneNumbersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve sender IDs list.
    ///
    /// <para>In order to get access to this endpoint, contact our support team. </para>
    /// </summary>
    Task<VerificationManagement::VerificationManagementListSenderIdsResponse> ListSenderIds(
        VerificationManagement::VerificationManagementListSenderIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add a phone number to the allow or block list.
    ///
    /// <para>This operation is idempotent - re-adding the same phone number will not
    /// result in duplicate entries or errors. If the phone number already exists in the
    /// specified list, the operation will succeed without making any changes.</para>
    ///
    /// <para>In order to get access to this endpoint, contact our support team. </para>
    /// </summary>
    Task<VerificationManagement::VerificationManagementSetPhoneNumberResponse> SetPhoneNumber(
        VerificationManagement::VerificationManagementSetPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetPhoneNumber(VerificationManagement::VerificationManagementSetPhoneNumberParams, CancellationToken)"/>
    Task<VerificationManagement::VerificationManagementSetPhoneNumberResponse> SetPhoneNumber(
        ApiEnum<
            string,
            VerificationManagement::VerificationManagementSetPhoneNumberParamsAction
        > action,
        VerificationManagement::VerificationManagementSetPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows you to submit a new sender ID for verification purposes.
    ///
    /// <para>In order to get access to this endpoint, contact our support team. </para>
    /// </summary>
    Task<VerificationManagement::VerificationManagementSubmitSenderIDResponse> SubmitSenderID(
        VerificationManagement::VerificationManagementSubmitSenderIDParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IVerificationManagementService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVerificationManagementServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerificationManagementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v2/verification/management/phone-numbers/{action}</c>, but is otherwise the
    /// same as <see cref="IVerificationManagementService.DeletePhoneNumber(VerificationManagement::VerificationManagementDeletePhoneNumberParams, CancellationToken)"/>.
    /// </summary>
    Task<
        HttpResponse<VerificationManagement::VerificationManagementDeletePhoneNumberResponse>
    > DeletePhoneNumber(
        VerificationManagement::VerificationManagementDeletePhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeletePhoneNumber(VerificationManagement::VerificationManagementDeletePhoneNumberParams, CancellationToken)"/>
    Task<
        HttpResponse<VerificationManagement::VerificationManagementDeletePhoneNumberResponse>
    > DeletePhoneNumber(
        ApiEnum<string, VerificationManagement::Action> action,
        VerificationManagement::VerificationManagementDeletePhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v2/verification/management/phone-numbers/{action}</c>, but is otherwise the
    /// same as <see cref="IVerificationManagementService.ListPhoneNumbers(VerificationManagement::VerificationManagementListPhoneNumbersParams, CancellationToken)"/>.
    /// </summary>
    Task<
        HttpResponse<VerificationManagement::VerificationManagementListPhoneNumbersResponse>
    > ListPhoneNumbers(
        VerificationManagement::VerificationManagementListPhoneNumbersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPhoneNumbers(VerificationManagement::VerificationManagementListPhoneNumbersParams, CancellationToken)"/>
    Task<
        HttpResponse<VerificationManagement::VerificationManagementListPhoneNumbersResponse>
    > ListPhoneNumbers(
        ApiEnum<
            string,
            VerificationManagement::VerificationManagementListPhoneNumbersParamsAction
        > action,
        VerificationManagement::VerificationManagementListPhoneNumbersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v2/verification/management/sender-id</c>, but is otherwise the
    /// same as <see cref="IVerificationManagementService.ListSenderIds(VerificationManagement::VerificationManagementListSenderIdsParams?, CancellationToken)"/>.
    /// </summary>
    Task<
        HttpResponse<VerificationManagement::VerificationManagementListSenderIdsResponse>
    > ListSenderIds(
        VerificationManagement::VerificationManagementListSenderIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v2/verification/management/phone-numbers/{action}</c>, but is otherwise the
    /// same as <see cref="IVerificationManagementService.SetPhoneNumber(VerificationManagement::VerificationManagementSetPhoneNumberParams, CancellationToken)"/>.
    /// </summary>
    Task<
        HttpResponse<VerificationManagement::VerificationManagementSetPhoneNumberResponse>
    > SetPhoneNumber(
        VerificationManagement::VerificationManagementSetPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetPhoneNumber(VerificationManagement::VerificationManagementSetPhoneNumberParams, CancellationToken)"/>
    Task<
        HttpResponse<VerificationManagement::VerificationManagementSetPhoneNumberResponse>
    > SetPhoneNumber(
        ApiEnum<
            string,
            VerificationManagement::VerificationManagementSetPhoneNumberParamsAction
        > action,
        VerificationManagement::VerificationManagementSetPhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v2/verification/management/sender-id</c>, but is otherwise the
    /// same as <see cref="IVerificationManagementService.SubmitSenderID(VerificationManagement::VerificationManagementSubmitSenderIDParams, CancellationToken)"/>.
    /// </summary>
    Task<
        HttpResponse<VerificationManagement::VerificationManagementSubmitSenderIDResponse>
    > SubmitSenderID(
        VerificationManagement::VerificationManagementSubmitSenderIDParams parameters,
        CancellationToken cancellationToken = default
    );
}
