using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Prelude.Core;
using Prelude.Exceptions;
using System = System;

namespace Prelude.Models.Watch;

[JsonConverter(typeof(JsonModelConverter<WatchSendEventsResponse, WatchSendEventsResponseFromRaw>))]
public sealed record class WatchSendEventsResponse : JsonModel
{
    /// <summary>
    /// A string that identifies this specific request. Report it back to us to help
    /// us diagnose your issues.
    /// </summary>
    public required string RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("request_id");
        }
        init { this._rawData.Set("request_id", value); }
    }

    /// <summary>
    /// The status of the events dispatch.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RequestID;
        this.Status.Validate();
    }

    public WatchSendEventsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WatchSendEventsResponse(WatchSendEventsResponse watchSendEventsResponse)
        : base(watchSendEventsResponse) { }
#pragma warning restore CS8618

    public WatchSendEventsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WatchSendEventsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WatchSendEventsResponseFromRaw.FromRawUnchecked"/>
    public static WatchSendEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WatchSendEventsResponseFromRaw : IFromRawJson<WatchSendEventsResponse>
{
    /// <inheritdoc/>
    public WatchSendEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WatchSendEventsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the events dispatch.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Success,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => Status.Success,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Success => "success",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
