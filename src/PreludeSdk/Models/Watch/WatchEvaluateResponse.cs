using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using System = System;

namespace PreludeSdk.Models.Watch;

[JsonConverter(typeof(JsonModelConverter<WatchEvaluateResponse, WatchEvaluateResponseFromRaw>))]
public sealed record class WatchEvaluateResponse : JsonModel
{
    /// <summary>
    /// The evaluation identifier.
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
    /// What the evaluation suggests you do, being the most severe action across
    /// the recipes that ran. Advisory: enforcement is yours.  * `ALLOW` - Let the
    /// request through.  * `BLOCK` - Refuse the request.  * `CHALLENGE` - Let the
    /// request through behind an additional check.
    /// </summary>
    public required ApiEnum<string, Action> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Action>>("action");
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// One result per recipe that ran. A recipe the flow names but that is not in
    /// service is absent rather than reported as having passed.
    /// </summary>
    public required IReadOnlyList<Recipe> Recipes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Recipe>>("recipes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Recipe>>(
                "recipes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The evaluation-level verdict, being the most severe verdict across the recipes
    /// that ran.  * `PASS` - No recipe flagged.  * `FLAG` - At least one recipe
    /// flagged.
    /// </summary>
    public required ApiEnum<string, WatchEvaluateResponseVerdict> Verdict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WatchEvaluateResponseVerdict>>(
                "verdict"
            );
        }
        init { this._rawData.Set("verdict", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Action.Validate();
        foreach (var item in this.Recipes)
        {
            item.Validate();
        }
        this.Verdict.Validate();
    }

    public WatchEvaluateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WatchEvaluateResponse(WatchEvaluateResponse watchEvaluateResponse)
        : base(watchEvaluateResponse) { }
#pragma warning restore CS8618

    public WatchEvaluateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WatchEvaluateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WatchEvaluateResponseFromRaw.FromRawUnchecked"/>
    public static WatchEvaluateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WatchEvaluateResponseFromRaw : IFromRawJson<WatchEvaluateResponse>
{
    /// <inheritdoc/>
    public WatchEvaluateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WatchEvaluateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// What the evaluation suggests you do, being the most severe action across the recipes
/// that ran. Advisory: enforcement is yours.  * `ALLOW` - Let the request through.
///  * `BLOCK` - Refuse the request.  * `CHALLENGE` - Let the request through behind
/// an additional check.
/// </summary>
[JsonConverter(typeof(ActionConverter))]
public enum Action
{
    Allow,
    Block,
    Challenge,
}

sealed class ActionConverter : JsonConverter<Action>
{
    public override Action Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ALLOW" => Action.Allow,
            "BLOCK" => Action.Block,
            "CHALLENGE" => Action.Challenge,
            _ => (Action)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Action value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Action.Allow => "ALLOW",
                Action.Block => "BLOCK",
                Action.Challenge => "CHALLENGE",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Recipe, RecipeFromRaw>))]
public sealed record class Recipe : JsonModel
{
    /// <summary>
    /// At least one rule could not be evaluated, so the score rests on less than
    /// the whole recipe. The score is still returned — a partial verdict is more
    /// useful than none — but it is labeled rather than passed off as whole.
    /// </summary>
    public required bool PartialEvidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("partial_evidence");
        }
        init { this._rawData.Set("partial_evidence", value); }
    }

    /// <summary>
    /// The recipe that produced this result.
    /// </summary>
    public required string RecipeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("recipe_id");
        }
        init { this._rawData.Set("recipe_id", value); }
    }

    /// <summary>
    /// One result per rule in the recipe, in membership order. Every rule runs —
    /// a score is only meaningful when complete, so there is no short-circuit on
    /// the first trigger. The exception is a recipe whose verdict a preempting rule
    /// has already determined, where a rule that could no longer change it may report
    /// `SKIPPED` instead.
    /// </summary>
    public required IReadOnlyList<Rule> Rules
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Rule>>("rules");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Rule>>(
                "rules",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The sum of the weights of the rules that triggered, clamped to the range
    /// -100 to 100. Two scores at a bound are not comparable.
    /// </summary>
    public required long Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    /// <summary>
    /// The score at or above which this recipe flags.
    /// </summary>
    public required long Threshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("threshold");
        }
        init { this._rawData.Set("threshold", value); }
    }

    /// <summary>
    /// This recipe's own verdict. Normally the score against the threshold, unless
    /// a preempting rule fired — see `determined_by`.
    /// </summary>
    public required ApiEnum<string, Verdict> Verdict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Verdict>>("verdict");
        }
        init { this._rawData.Set("verdict", value); }
    }

    /// <summary>
    /// The preempting rule that set `verdict`, present only when a rule rather than
    /// the score decided it. Without it a recipe can report a score under its threshold
    /// and still flag, with nothing in the payload accounting for the difference.
    /// </summary>
    public string? DeterminedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("determined_by");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("determined_by", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PartialEvidence;
        _ = this.RecipeID;
        foreach (var item in this.Rules)
        {
            item.Validate();
        }
        _ = this.Score;
        _ = this.Threshold;
        this.Verdict.Validate();
        _ = this.DeterminedBy;
    }

    public Recipe() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Recipe(Recipe recipe)
        : base(recipe) { }
#pragma warning restore CS8618

    public Recipe(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Recipe(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecipeFromRaw.FromRawUnchecked"/>
    public static Recipe FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecipeFromRaw : IFromRawJson<Recipe>
{
    /// <inheritdoc/>
    public Recipe FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Recipe.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Rule, RuleFromRaw>))]
public sealed record class Rule : JsonModel
{
    /// <summary>
    /// What the rule concluded.  * `TRIGGERED` - The condition held; `weight` was
    /// added to the score.  * `NOT_TRIGGERED` - The condition did not hold.  * `NOT_EVALUATED`
    /// - The rule could not run, because something it reads never arrived. This is
    /// not a quieter `NOT_TRIGGERED`: it contributed nothing either way, and it is
    /// why `partial_evidence` is set on the recipe.  * `SKIPPED` - The rule was not
    /// run, because another rule had already determined the recipe's verdict — see
    /// `determined_by`. Nothing was missing and nothing failed, so `partial_evidence`
    /// is not set: `determined_by` is what accounts for the recipe's score resting
    /// on fewer rules.
    /// </summary>
    public required ApiEnum<string, Outcome> Outcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Outcome>>("outcome");
        }
        init { this._rawData.Set("outcome", value); }
    }

    /// <summary>
    /// The rule that produced this result. Present whatever the rule's visibility,
    /// so a rule you cannot see the condition of is still one you can reweight,
    /// switch off, or ask us about.
    /// </summary>
    public required string RuleID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("rule_id");
        }
        init { this._rawData.Set("rule_id", value); }
    }

    /// <summary>
    /// Who authored the rule, which is what says how much of the rest of this result
    /// you get.  * `MANAGED` - Prelude-owned, shared with customers: `name` and `version_id`
    /// are omitted, and `blocked_by` reports only `missing_data`.  * `CUSTOM` -
    /// Yours: every field is returned.
    /// </summary>
    public required ApiEnum<string, RuleType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RuleType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// What this rule contributes to the recipe's score when it triggers.
    /// </summary>
    public required long Weight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("weight");
        }
        init { this._rawData.Set("weight", value); }
    }

    /// <summary>
    /// Why the rule could not run, set only when `outcome` is `NOT_EVALUATED`.
    ///
    /// <para>A rule you authored names the signal or attribute it waited on, since
    /// you wrote the expression that reads it. A Prelude-managed rule reports `missing_data`
    /// and nothing more: the signal it waited on is part of a condition that is
    /// not disclosed. </para>
    /// </summary>
    public string? BlockedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("blocked_by");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("blocked_by", value);
        }
    }

    /// <summary>
    /// The rule's name, present for a rule you authored and omitted for a Prelude-managed
    /// one. A managed rule's name describes what it looks for, which is as much
    /// of the condition as the expression is.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The rule could not run for a reason on our side rather than anything about
    /// your request. `outcome` is `NOT_EVALUATED` and the failure is ours to fix.
    /// </summary>
    public bool? Unavailable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("unavailable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unavailable", value);
        }
    }

    /// <summary>
    /// The version of the rule that scored — the one this recipe is pinned to, or
    /// the version current at evaluation time when it is not pinned. Present for
    /// a rule you authored, and omitted for a Prelude-managed one.
    /// </summary>
    public string? VersionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Outcome.Validate();
        _ = this.RuleID;
        this.Type.Validate();
        _ = this.Weight;
        _ = this.BlockedBy;
        _ = this.Name;
        _ = this.Unavailable;
        _ = this.VersionID;
    }

    public Rule() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Rule(Rule rule)
        : base(rule) { }
#pragma warning restore CS8618

    public Rule(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Rule(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RuleFromRaw.FromRawUnchecked"/>
    public static Rule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RuleFromRaw : IFromRawJson<Rule>
{
    /// <inheritdoc/>
    public Rule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Rule.FromRawUnchecked(rawData);
}

/// <summary>
/// What the rule concluded.  * `TRIGGERED` - The condition held; `weight` was added
/// to the score.  * `NOT_TRIGGERED` - The condition did not hold.  * `NOT_EVALUATED`
/// - The rule could not run, because something it reads never arrived. This is not
/// a quieter `NOT_TRIGGERED`: it contributed nothing either way, and it is why `partial_evidence`
/// is set on the recipe.  * `SKIPPED` - The rule was not run, because another rule
/// had already determined the recipe's verdict — see `determined_by`. Nothing was
/// missing and nothing failed, so `partial_evidence` is not set: `determined_by`
/// is what accounts for the recipe's score resting on fewer rules.
/// </summary>
[JsonConverter(typeof(OutcomeConverter))]
public enum Outcome
{
    Triggered,
    NotTriggered,
    NotEvaluated,
    Skipped,
}

sealed class OutcomeConverter : JsonConverter<Outcome>
{
    public override Outcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "TRIGGERED" => Outcome.Triggered,
            "NOT_TRIGGERED" => Outcome.NotTriggered,
            "NOT_EVALUATED" => Outcome.NotEvaluated,
            "SKIPPED" => Outcome.Skipped,
            _ => (Outcome)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Outcome value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Outcome.Triggered => "TRIGGERED",
                Outcome.NotTriggered => "NOT_TRIGGERED",
                Outcome.NotEvaluated => "NOT_EVALUATED",
                Outcome.Skipped => "SKIPPED",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Who authored the rule, which is what says how much of the rest of this result
/// you get.  * `MANAGED` - Prelude-owned, shared with customers: `name` and `version_id`
/// are omitted, and `blocked_by` reports only `missing_data`.  * `CUSTOM` - Yours:
/// every field is returned.
/// </summary>
[JsonConverter(typeof(RuleTypeConverter))]
public enum RuleType
{
    Managed,
    Custom,
}

sealed class RuleTypeConverter : JsonConverter<RuleType>
{
    public override RuleType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MANAGED" => RuleType.Managed,
            "CUSTOM" => RuleType.Custom,
            _ => (RuleType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, RuleType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RuleType.Managed => "MANAGED",
                RuleType.Custom => "CUSTOM",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// This recipe's own verdict. Normally the score against the threshold, unless a
/// preempting rule fired — see `determined_by`.
/// </summary>
[JsonConverter(typeof(VerdictConverter))]
public enum Verdict
{
    Pass,
    Flag,
}

sealed class VerdictConverter : JsonConverter<Verdict>
{
    public override Verdict Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PASS" => Verdict.Pass,
            "FLAG" => Verdict.Flag,
            _ => (Verdict)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Verdict value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Verdict.Pass => "PASS",
                Verdict.Flag => "FLAG",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The evaluation-level verdict, being the most severe verdict across the recipes
/// that ran.  * `PASS` - No recipe flagged.  * `FLAG` - At least one recipe flagged.
/// </summary>
[JsonConverter(typeof(WatchEvaluateResponseVerdictConverter))]
public enum WatchEvaluateResponseVerdict
{
    Pass,
    Flag,
}

sealed class WatchEvaluateResponseVerdictConverter : JsonConverter<WatchEvaluateResponseVerdict>
{
    public override WatchEvaluateResponseVerdict Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PASS" => WatchEvaluateResponseVerdict.Pass,
            "FLAG" => WatchEvaluateResponseVerdict.Flag,
            _ => (WatchEvaluateResponseVerdict)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WatchEvaluateResponseVerdict value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WatchEvaluateResponseVerdict.Pass => "PASS",
                WatchEvaluateResponseVerdict.Flag => "FLAG",
                _ => throw new PreludeInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
