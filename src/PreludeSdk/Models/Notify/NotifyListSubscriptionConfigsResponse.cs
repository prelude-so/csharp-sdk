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
        NotifyListSubscriptionConfigsResponse,
        NotifyListSubscriptionConfigsResponseFromRaw
    >)
)]
public sealed record class NotifyListSubscriptionConfigsResponse : JsonModel
{
    /// <summary>
    /// A list of subscription management configurations.
    /// </summary>
    public required IReadOnlyList<Config> Configs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Config>>("configs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Config>>(
                "configs",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination cursor for the next page of results. Omitted if there are no more pages.
    /// </summary>
    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("next_cursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Configs)
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public NotifyListSubscriptionConfigsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotifyListSubscriptionConfigsResponse(
        NotifyListSubscriptionConfigsResponse notifyListSubscriptionConfigsResponse
    )
        : base(notifyListSubscriptionConfigsResponse) { }
#pragma warning restore CS8618

    public NotifyListSubscriptionConfigsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotifyListSubscriptionConfigsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotifyListSubscriptionConfigsResponseFromRaw.FromRawUnchecked"/>
    public static NotifyListSubscriptionConfigsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NotifyListSubscriptionConfigsResponse(IReadOnlyList<Config> configs)
        : this()
    {
        this.Configs = configs;
    }
}

class NotifyListSubscriptionConfigsResponseFromRaw
    : IFromRawJson<NotifyListSubscriptionConfigsResponse>
{
    /// <inheritdoc/>
    public NotifyListSubscriptionConfigsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotifyListSubscriptionConfigsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Config, ConfigFromRaw>))]
public sealed record class Config : JsonModel
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
    public required ConfigMessages Messages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ConfigMessages>("messages");
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
    public IReadOnlyList<ConfigMoPhoneNumber>? MoPhoneNumbers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ConfigMoPhoneNumber>>(
                "mo_phone_numbers"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ConfigMoPhoneNumber>?>(
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

    public Config() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Config(Config config)
        : base(config) { }
#pragma warning restore CS8618

    public Config(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Config(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConfigFromRaw.FromRawUnchecked"/>
    public static Config FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConfigFromRaw : IFromRawJson<Config>
{
    /// <inheritdoc/>
    public Config FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Config.FromRawUnchecked(rawData);
}

/// <summary>
/// The subscription messages configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConfigMessages, ConfigMessagesFromRaw>))]
public sealed record class ConfigMessages : JsonModel
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

    public ConfigMessages() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConfigMessages(ConfigMessages configMessages)
        : base(configMessages) { }
#pragma warning restore CS8618

    public ConfigMessages(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConfigMessages(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConfigMessagesFromRaw.FromRawUnchecked"/>
    public static ConfigMessages FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConfigMessagesFromRaw : IFromRawJson<ConfigMessages>
{
    /// <inheritdoc/>
    public ConfigMessages FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ConfigMessages.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ConfigMoPhoneNumber, ConfigMoPhoneNumberFromRaw>))]
public sealed record class ConfigMoPhoneNumber : JsonModel
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

    public ConfigMoPhoneNumber() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConfigMoPhoneNumber(ConfigMoPhoneNumber configMoPhoneNumber)
        : base(configMoPhoneNumber) { }
#pragma warning restore CS8618

    public ConfigMoPhoneNumber(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConfigMoPhoneNumber(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConfigMoPhoneNumberFromRaw.FromRawUnchecked"/>
    public static ConfigMoPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConfigMoPhoneNumberFromRaw : IFromRawJson<ConfigMoPhoneNumber>
{
    /// <inheritdoc/>
    public ConfigMoPhoneNumber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ConfigMoPhoneNumber.FromRawUnchecked(rawData);
}
