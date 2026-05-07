using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Prelude.Core;
using Prelude.Exceptions;
using System = System;

namespace Prelude.Models.Watch;

[JsonConverter(
    typeof(JsonModelConverter<WatchSendFeedbacksResponse, WatchSendFeedbacksResponseFromRaw>)
)]
public sealed record class WatchSendFeedbacksResponse : JsonModel
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
    /// The status of the feedbacks sending.
    /// </summary>
    public required ApiEnum<string, WatchSendFeedbacksResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WatchSendFeedbacksResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RequestID;
        this.Status.Validate();
    }

    public WatchSendFeedbacksResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WatchSendFeedbacksResponse(WatchSendFeedbacksResponse watchSendFeedbacksResponse)
        : base(watchSendFeedbacksResponse) { }
#pragma warning restore CS8618

    public WatchSendFeedbacksResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WatchSendFeedbacksResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WatchSendFeedbacksResponseFromRaw.FromRawUnchecked"/>
    public static WatchSendFeedbacksResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WatchSendFeedbacksResponseFromRaw : IFromRawJson<WatchSendFeedbacksResponse>
{
    /// <inheritdoc/>
    public WatchSendFeedbacksResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WatchSendFeedbacksResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the feedbacks sending.
/// </summary>
[JsonConverter(typeof(WatchSendFeedbacksResponseStatusConverter))]
public enum WatchSendFeedbacksResponseStatus
{
    Success,
}

sealed class WatchSendFeedbacksResponseStatusConverter
    : JsonConverter<WatchSendFeedbacksResponseStatus>
{
    public override WatchSendFeedbacksResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => WatchSendFeedbacksResponseStatus.Success,
            _ => (WatchSendFeedbacksResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WatchSendFeedbacksResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WatchSendFeedbacksResponseStatus.Success => "success",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
