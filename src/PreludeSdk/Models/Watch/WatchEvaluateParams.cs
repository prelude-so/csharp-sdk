using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using PreludeSdk.Core;

namespace PreludeSdk.Models.Watch;

/// <summary>
/// **Beta.** The request and response shapes may still change. Talk to us before
/// you build against it. Flows, recipes and rules are authored through the Watch
/// Management API, or configured by Prelude on your behalf.
///
/// <para>Score a target against the rules configured for one moment in your product
/// — signup, checkout, password reset. The flow selects which recipes run; each recipe
/// scores its rules against a threshold and returns its own verdict, and the evaluation
/// answers with the most severe verdict and action across them. Where Predict returns
/// a single model-derived outcome, Eval returns the full breakdown, so you can see
/// which rules fired and which could not run. Scoring-only — it does not update
/// counters by itself.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WatchEvaluateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The flow to evaluate. A flow names the moment you are guarding and selects
    /// the recipes that run.
    /// </summary>
    public required string FlowID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("flow_id");
        }
        init { this._rawBodyData.Set("flow_id", value); }
    }

    /// <summary>
    /// The identifier to score — a phone number or email address.
    /// </summary>
    public required Target Target
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Target>("target");
        }
        init { this._rawBodyData.Set("target", value); }
    }

    /// <summary>
    /// Values for the attributes the flow's recipes declare, keyed without the `attr.`
    /// namespace a rule uses to reference them.
    ///
    /// <para>An attribute a recipe declares and this request omits is treated as
    /// missing evidence, not as an empty value: the rules reading it report `NOT_EVALUATED`
    /// rather than being scored as though the condition were false. A key no recipe
    /// in the flow declares is ignored rather than rejected, so one payload can
    /// serve flows that read different attributes. </para>
    /// </summary>
    public IReadOnlyDictionary<string, string>? Attributes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>(
                "attributes"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "attributes",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The identifier of the dispatch that came from the front-end SDK. Signals
    /// it carries fill in anything the request did not state; the request wins where
    /// both supply a value.
    /// </summary>
    public string? DispatchID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("dispatch_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("dispatch_id", value);
        }
    }

    /// <summary>
    /// The signals used for anti-fraud. For more details, refer to [Signals](/verify/v2/documentation/prevent-fraud#signals).
    /// </summary>
    public Signals? Signals
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Signals>("signals");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("signals", value);
        }
    }

    public WatchEvaluateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WatchEvaluateParams(WatchEvaluateParams watchEvaluateParams)
        : base(watchEvaluateParams)
    {
        this._rawBodyData = new(watchEvaluateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WatchEvaluateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WatchEvaluateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WatchEvaluateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(WatchEvaluateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v2/watch/eval")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
