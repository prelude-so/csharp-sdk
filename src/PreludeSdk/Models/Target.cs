using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using System = System;

namespace PreludeSdk.Models;

/// <summary>
/// The operation target. Either a phone number or an email address.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Target, TargetFromRaw>))]
public sealed record class Target : JsonModel
{
    /// <summary>
    /// The type of the target. Either "phone_number" or "email_address".
    /// </summary>
    public required ApiEnum<string, global::PreludeSdk.Models.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, global::PreludeSdk.Models.Type>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// An E.164 formatted phone number or an email address.
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Value;
    }

    public Target() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Target(Target target)
        : base(target) { }
#pragma warning restore CS8618

    public Target(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Target(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TargetFromRaw.FromRawUnchecked"/>
    public static Target FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TargetFromRaw : IFromRawJson<Target>
{
    /// <inheritdoc/>
    public Target FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Target.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the target. Either "phone_number" or "email_address".
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    PhoneNumber,
    EmailAddress,
}

sealed class TypeConverter : JsonConverter<global::PreludeSdk.Models.Type>
{
    public override global::PreludeSdk.Models.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "phone_number" => global::PreludeSdk.Models.Type.PhoneNumber,
            "email_address" => global::PreludeSdk.Models.Type.EmailAddress,
            _ => (global::PreludeSdk.Models.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::PreludeSdk.Models.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::PreludeSdk.Models.Type.PhoneNumber => "phone_number",
                global::PreludeSdk.Models.Type.EmailAddress => "email_address",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
