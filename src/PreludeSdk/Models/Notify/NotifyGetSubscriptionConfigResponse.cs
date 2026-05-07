using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;

namespace PreludeSdk.Models.Notify;

[JsonConverter(
    typeof(JsonModelConverter<
        NotifyGetSubscriptionConfigResponse,
        NotifyGetSubscriptionConfigResponseFromRaw
    >)
)]
public sealed record class NotifyGetSubscriptionConfigResponse : JsonModel
{
    /// <summary>
    /// The subscription configuration ID.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The URL to call when subscription status changes.
    /// </summary>
    public required string CallbackUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("callback_url");
        }
        init { this._rawData.Set("callback_url", value); }
    }

    /// <summary>
    /// The date and time when the configuration was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The subscription messages configuration.
    /// </summary>
    public required Messages Messages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Messages>("messages");
        }
        init { this._rawData.Set("messages", value); }
    }

    /// <summary>
    /// The human-readable name for the subscription configuration.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The date and time when the configuration was last updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// A list of phone numbers for receiving inbound messages.
    /// </summary>
    public IReadOnlyList<MoPhoneNumber>? MoPhoneNumbers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MoPhoneNumber>>(
                "mo_phone_numbers"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<MoPhoneNumber>?>(
                "mo_phone_numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CallbackUrl;
        _ = this.CreatedAt;
        this.Messages.Validate();
        _ = this.Name;
        _ = this.UpdatedAt;
        foreach (var item in this.MoPhoneNumbers ?? [])
        {
            item.Validate();
        }
    }

    public NotifyGetSubscriptionConfigResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotifyGetSubscriptionConfigResponse(
        NotifyGetSubscriptionConfigResponse notifyGetSubscriptionConfigResponse
    )
        : base(notifyGetSubscriptionConfigResponse) { }
#pragma warning restore CS8618

    public NotifyGetSubscriptionConfigResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotifyGetSubscriptionConfigResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotifyGetSubscriptionConfigResponseFromRaw.FromRawUnchecked"/>
    public static NotifyGetSubscriptionConfigResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotifyGetSubscriptionConfigResponseFromRaw : IFromRawJson<NotifyGetSubscriptionConfigResponse>
{
    /// <inheritdoc/>
    public NotifyGetSubscriptionConfigResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotifyGetSubscriptionConfigResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The subscription messages configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Messages, MessagesFromRaw>))]
public sealed record class Messages : JsonModel
{
    /// <summary>
    /// Message sent when user requests help.
    /// </summary>
    public string? HelpMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("help_message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("help_message", value);
        }
    }

    /// <summary>
    /// Message sent when user subscribes.
    /// </summary>
    public string? StartMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("start_message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("start_message", value);
        }
    }

    /// <summary>
    /// Message sent when user unsubscribes.
    /// </summary>
    public string? StopMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("stop_message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stop_message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HelpMessage;
        _ = this.StartMessage;
        _ = this.StopMessage;
    }

    public Messages() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Messages(Messages messages)
        : base(messages) { }
#pragma warning restore CS8618

    public Messages(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Messages(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessagesFromRaw.FromRawUnchecked"/>
    public static Messages FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessagesFromRaw : IFromRawJson<Messages>
{
    /// <inheritdoc/>
    public Messages FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Messages.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MoPhoneNumber, MoPhoneNumberFromRaw>))]
public sealed record class MoPhoneNumber : JsonModel
{
    /// <summary>
    /// The ISO 3166-1 alpha-2 country code.
    /// </summary>
    public required string CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("country_code");
        }
        init { this._rawData.Set("country_code", value); }
    }

    /// <summary>
    /// The phone number in E.164 format for long codes, or short code format for
    /// short codes.
    /// </summary>
    public required string PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("phone_number");
        }
        init { this._rawData.Set("phone_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CountryCode;
        _ = this.PhoneNumber;
    }

    public MoPhoneNumber() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MoPhoneNumber(MoPhoneNumber moPhoneNumber)
        : base(moPhoneNumber) { }
#pragma warning restore CS8618

    public MoPhoneNumber(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MoPhoneNumber(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MoPhoneNumberFromRaw.FromRawUnchecked"/>
    public static MoPhoneNumber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MoPhoneNumberFromRaw : IFromRawJson<MoPhoneNumber>
{
    /// <inheritdoc/>
    public MoPhoneNumber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MoPhoneNumber.FromRawUnchecked(rawData);
}
