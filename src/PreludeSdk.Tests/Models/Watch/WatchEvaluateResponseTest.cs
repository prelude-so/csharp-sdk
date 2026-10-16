using System.Collections.Generic;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.Watch;

namespace PreludeSdk.Tests.Models.Watch;

public class WatchEvaluateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WatchEvaluateResponse
        {
            ID = "evl_01jc0t6fwwfgfsq1md24mhyztj",
            Action = Action.Allow,
            Recipes =
            [
                new()
                {
                    PartialEvidence = true,
                    RecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj",
                    Rules =
                    [
                        new()
                        {
                            Outcome = Outcome.Triggered,
                            RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                            Type = RuleType.Managed,
                            Weight = 10,
                            BlockedBy = "missing_data",
                            Name = "high_value_cart_new_account",
                            Unavailable = true,
                            VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
                        },
                    ],
                    Score = 20,
                    Threshold = 30,
                    Verdict = Verdict.Pass,
                    DeterminedBy = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                },
            ],
            Verdict = WatchEvaluateResponseVerdict.Pass,
        };

        string expectedID = "evl_01jc0t6fwwfgfsq1md24mhyztj";
        ApiEnum<string, Action> expectedAction = Action.Allow;
        List<Recipe> expectedRecipes =
        [
            new()
            {
                PartialEvidence = true,
                RecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj",
                Rules =
                [
                    new()
                    {
                        Outcome = Outcome.Triggered,
                        RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                        Type = RuleType.Managed,
                        Weight = 10,
                        BlockedBy = "missing_data",
                        Name = "high_value_cart_new_account",
                        Unavailable = true,
                        VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
                    },
                ],
                Score = 20,
                Threshold = 30,
                Verdict = Verdict.Pass,
                DeterminedBy = "rul_01jc0t6fwwfgfsq1md24mhyztj",
            },
        ];
        ApiEnum<string, WatchEvaluateResponseVerdict> expectedVerdict =
            WatchEvaluateResponseVerdict.Pass;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedRecipes.Count, model.Recipes.Count);
        for (int i = 0; i < expectedRecipes.Count; i++)
        {
            Assert.Equal(expectedRecipes[i], model.Recipes[i]);
        }
        Assert.Equal(expectedVerdict, model.Verdict);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WatchEvaluateResponse
        {
            ID = "evl_01jc0t6fwwfgfsq1md24mhyztj",
            Action = Action.Allow,
            Recipes =
            [
                new()
                {
                    PartialEvidence = true,
                    RecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj",
                    Rules =
                    [
                        new()
                        {
                            Outcome = Outcome.Triggered,
                            RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                            Type = RuleType.Managed,
                            Weight = 10,
                            BlockedBy = "missing_data",
                            Name = "high_value_cart_new_account",
                            Unavailable = true,
                            VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
                        },
                    ],
                    Score = 20,
                    Threshold = 30,
                    Verdict = Verdict.Pass,
                    DeterminedBy = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                },
            ],
            Verdict = WatchEvaluateResponseVerdict.Pass,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WatchEvaluateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WatchEvaluateResponse
        {
            ID = "evl_01jc0t6fwwfgfsq1md24mhyztj",
            Action = Action.Allow,
            Recipes =
            [
                new()
                {
                    PartialEvidence = true,
                    RecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj",
                    Rules =
                    [
                        new()
                        {
                            Outcome = Outcome.Triggered,
                            RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                            Type = RuleType.Managed,
                            Weight = 10,
                            BlockedBy = "missing_data",
                            Name = "high_value_cart_new_account",
                            Unavailable = true,
                            VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
                        },
                    ],
                    Score = 20,
                    Threshold = 30,
                    Verdict = Verdict.Pass,
                    DeterminedBy = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                },
            ],
            Verdict = WatchEvaluateResponseVerdict.Pass,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WatchEvaluateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "evl_01jc0t6fwwfgfsq1md24mhyztj";
        ApiEnum<string, Action> expectedAction = Action.Allow;
        List<Recipe> expectedRecipes =
        [
            new()
            {
                PartialEvidence = true,
                RecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj",
                Rules =
                [
                    new()
                    {
                        Outcome = Outcome.Triggered,
                        RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                        Type = RuleType.Managed,
                        Weight = 10,
                        BlockedBy = "missing_data",
                        Name = "high_value_cart_new_account",
                        Unavailable = true,
                        VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
                    },
                ],
                Score = 20,
                Threshold = 30,
                Verdict = Verdict.Pass,
                DeterminedBy = "rul_01jc0t6fwwfgfsq1md24mhyztj",
            },
        ];
        ApiEnum<string, WatchEvaluateResponseVerdict> expectedVerdict =
            WatchEvaluateResponseVerdict.Pass;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedRecipes.Count, deserialized.Recipes.Count);
        for (int i = 0; i < expectedRecipes.Count; i++)
        {
            Assert.Equal(expectedRecipes[i], deserialized.Recipes[i]);
        }
        Assert.Equal(expectedVerdict, deserialized.Verdict);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WatchEvaluateResponse
        {
            ID = "evl_01jc0t6fwwfgfsq1md24mhyztj",
            Action = Action.Allow,
            Recipes =
            [
                new()
                {
                    PartialEvidence = true,
                    RecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj",
                    Rules =
                    [
                        new()
                        {
                            Outcome = Outcome.Triggered,
                            RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                            Type = RuleType.Managed,
                            Weight = 10,
                            BlockedBy = "missing_data",
                            Name = "high_value_cart_new_account",
                            Unavailable = true,
                            VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
                        },
                    ],
                    Score = 20,
                    Threshold = 30,
                    Verdict = Verdict.Pass,
                    DeterminedBy = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                },
            ],
            Verdict = WatchEvaluateResponseVerdict.Pass,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WatchEvaluateResponse
        {
            ID = "evl_01jc0t6fwwfgfsq1md24mhyztj",
            Action = Action.Allow,
            Recipes =
            [
                new()
                {
                    PartialEvidence = true,
                    RecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj",
                    Rules =
                    [
                        new()
                        {
                            Outcome = Outcome.Triggered,
                            RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                            Type = RuleType.Managed,
                            Weight = 10,
                            BlockedBy = "missing_data",
                            Name = "high_value_cart_new_account",
                            Unavailable = true,
                            VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
                        },
                    ],
                    Score = 20,
                    Threshold = 30,
                    Verdict = Verdict.Pass,
                    DeterminedBy = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                },
            ],
            Verdict = WatchEvaluateResponseVerdict.Pass,
        };

        WatchEvaluateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActionTest : TestBase
{
    [Theory]
    [InlineData(Action.Allow)]
    [InlineData(Action.Block)]
    [InlineData(Action.Challenge)]
    public void Validation_Works(Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Action> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Action.Allow)]
    [InlineData(Action.Block)]
    [InlineData(Action.Challenge)]
    public void SerializationRoundtrip_Works(Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Action> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RecipeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Recipe
        {
            PartialEvidence = true,
            RecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj",
            Rules =
            [
                new()
                {
                    Outcome = Outcome.Triggered,
                    RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                    Type = RuleType.Managed,
                    Weight = 10,
                    BlockedBy = "missing_data",
                    Name = "high_value_cart_new_account",
                    Unavailable = true,
                    VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
                },
            ],
            Score = 20,
            Threshold = 30,
            Verdict = Verdict.Pass,
            DeterminedBy = "rul_01jc0t6fwwfgfsq1md24mhyztj",
        };

        bool expectedPartialEvidence = true;
        string expectedRecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj";
        List<Rule> expectedRules =
        [
            new()
            {
                Outcome = Outcome.Triggered,
                RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                Type = RuleType.Managed,
                Weight = 10,
                BlockedBy = "missing_data",
                Name = "high_value_cart_new_account",
                Unavailable = true,
                VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
            },
        ];
        long expectedScore = 20;
        long expectedThreshold = 30;
        ApiEnum<string, Verdict> expectedVerdict = Verdict.Pass;
        string expectedDeterminedBy = "rul_01jc0t6fwwfgfsq1md24mhyztj";

        Assert.Equal(expectedPartialEvidence, model.PartialEvidence);
        Assert.Equal(expectedRecipeID, model.RecipeID);
        Assert.Equal(expectedRules.Count, model.Rules.Count);
        for (int i = 0; i < expectedRules.Count; i++)
        {
            Assert.Equal(expectedRules[i], model.Rules[i]);
        }
        Assert.Equal(expectedScore, model.Score);
        Assert.Equal(expectedThreshold, model.Threshold);
        Assert.Equal(expectedVerdict, model.Verdict);
        Assert.Equal(expectedDeterminedBy, model.DeterminedBy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Recipe
        {
            PartialEvidence = true,
            RecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj",
            Rules =
            [
                new()
                {
                    Outcome = Outcome.Triggered,
                    RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                    Type = RuleType.Managed,
                    Weight = 10,
                    BlockedBy = "missing_data",
                    Name = "high_value_cart_new_account",
                    Unavailable = true,
                    VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
                },
            ],
            Score = 20,
            Threshold = 30,
            Verdict = Verdict.Pass,
            DeterminedBy = "rul_01jc0t6fwwfgfsq1md24mhyztj",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Recipe>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Recipe
        {
            PartialEvidence = true,
            RecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj",
            Rules =
            [
                new()
                {
                    Outcome = Outcome.Triggered,
                    RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                    Type = RuleType.Managed,
                    Weight = 10,
                    BlockedBy = "missing_data",
                    Name = "high_value_cart_new_account",
                    Unavailable = true,
                    VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
                },
            ],
            Score = 20,
            Threshold = 30,
            Verdict = Verdict.Pass,
            DeterminedBy = "rul_01jc0t6fwwfgfsq1md24mhyztj",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Recipe>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        bool expectedPartialEvidence = true;
        string expectedRecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj";
        List<Rule> expectedRules =
        [
            new()
            {
                Outcome = Outcome.Triggered,
                RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                Type = RuleType.Managed,
                Weight = 10,
                BlockedBy = "missing_data",
                Name = "high_value_cart_new_account",
                Unavailable = true,
                VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
            },
        ];
        long expectedScore = 20;
        long expectedThreshold = 30;
        ApiEnum<string, Verdict> expectedVerdict = Verdict.Pass;
        string expectedDeterminedBy = "rul_01jc0t6fwwfgfsq1md24mhyztj";

        Assert.Equal(expectedPartialEvidence, deserialized.PartialEvidence);
        Assert.Equal(expectedRecipeID, deserialized.RecipeID);
        Assert.Equal(expectedRules.Count, deserialized.Rules.Count);
        for (int i = 0; i < expectedRules.Count; i++)
        {
            Assert.Equal(expectedRules[i], deserialized.Rules[i]);
        }
        Assert.Equal(expectedScore, deserialized.Score);
        Assert.Equal(expectedThreshold, deserialized.Threshold);
        Assert.Equal(expectedVerdict, deserialized.Verdict);
        Assert.Equal(expectedDeterminedBy, deserialized.DeterminedBy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Recipe
        {
            PartialEvidence = true,
            RecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj",
            Rules =
            [
                new()
                {
                    Outcome = Outcome.Triggered,
                    RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                    Type = RuleType.Managed,
                    Weight = 10,
                    BlockedBy = "missing_data",
                    Name = "high_value_cart_new_account",
                    Unavailable = true,
                    VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
                },
            ],
            Score = 20,
            Threshold = 30,
            Verdict = Verdict.Pass,
            DeterminedBy = "rul_01jc0t6fwwfgfsq1md24mhyztj",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Recipe
        {
            PartialEvidence = true,
            RecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj",
            Rules =
            [
                new()
                {
                    Outcome = Outcome.Triggered,
                    RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                    Type = RuleType.Managed,
                    Weight = 10,
                    BlockedBy = "missing_data",
                    Name = "high_value_cart_new_account",
                    Unavailable = true,
                    VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
                },
            ],
            Score = 20,
            Threshold = 30,
            Verdict = Verdict.Pass,
        };

        Assert.Null(model.DeterminedBy);
        Assert.False(model.RawData.ContainsKey("determined_by"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Recipe
        {
            PartialEvidence = true,
            RecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj",
            Rules =
            [
                new()
                {
                    Outcome = Outcome.Triggered,
                    RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                    Type = RuleType.Managed,
                    Weight = 10,
                    BlockedBy = "missing_data",
                    Name = "high_value_cart_new_account",
                    Unavailable = true,
                    VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
                },
            ],
            Score = 20,
            Threshold = 30,
            Verdict = Verdict.Pass,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Recipe
        {
            PartialEvidence = true,
            RecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj",
            Rules =
            [
                new()
                {
                    Outcome = Outcome.Triggered,
                    RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                    Type = RuleType.Managed,
                    Weight = 10,
                    BlockedBy = "missing_data",
                    Name = "high_value_cart_new_account",
                    Unavailable = true,
                    VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
                },
            ],
            Score = 20,
            Threshold = 30,
            Verdict = Verdict.Pass,

            // Null should be interpreted as omitted for these properties
            DeterminedBy = null,
        };

        Assert.Null(model.DeterminedBy);
        Assert.False(model.RawData.ContainsKey("determined_by"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Recipe
        {
            PartialEvidence = true,
            RecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj",
            Rules =
            [
                new()
                {
                    Outcome = Outcome.Triggered,
                    RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                    Type = RuleType.Managed,
                    Weight = 10,
                    BlockedBy = "missing_data",
                    Name = "high_value_cart_new_account",
                    Unavailable = true,
                    VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
                },
            ],
            Score = 20,
            Threshold = 30,
            Verdict = Verdict.Pass,

            // Null should be interpreted as omitted for these properties
            DeterminedBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Recipe
        {
            PartialEvidence = true,
            RecipeID = "rcp_01jc0t6fwwfgfsq1md24mhyztj",
            Rules =
            [
                new()
                {
                    Outcome = Outcome.Triggered,
                    RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
                    Type = RuleType.Managed,
                    Weight = 10,
                    BlockedBy = "missing_data",
                    Name = "high_value_cart_new_account",
                    Unavailable = true,
                    VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
                },
            ],
            Score = 20,
            Threshold = 30,
            Verdict = Verdict.Pass,
            DeterminedBy = "rul_01jc0t6fwwfgfsq1md24mhyztj",
        };

        Recipe copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RuleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Rule
        {
            Outcome = Outcome.Triggered,
            RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
            Type = RuleType.Managed,
            Weight = 10,
            BlockedBy = "missing_data",
            Name = "high_value_cart_new_account",
            Unavailable = true,
            VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
        };

        ApiEnum<string, Outcome> expectedOutcome = Outcome.Triggered;
        string expectedRuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj";
        ApiEnum<string, RuleType> expectedType = RuleType.Managed;
        long expectedWeight = 10;
        string expectedBlockedBy = "missing_data";
        string expectedName = "high_value_cart_new_account";
        bool expectedUnavailable = true;
        string expectedVersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6";

        Assert.Equal(expectedOutcome, model.Outcome);
        Assert.Equal(expectedRuleID, model.RuleID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedWeight, model.Weight);
        Assert.Equal(expectedBlockedBy, model.BlockedBy);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUnavailable, model.Unavailable);
        Assert.Equal(expectedVersionID, model.VersionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Rule
        {
            Outcome = Outcome.Triggered,
            RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
            Type = RuleType.Managed,
            Weight = 10,
            BlockedBy = "missing_data",
            Name = "high_value_cart_new_account",
            Unavailable = true,
            VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rule>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Rule
        {
            Outcome = Outcome.Triggered,
            RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
            Type = RuleType.Managed,
            Weight = 10,
            BlockedBy = "missing_data",
            Name = "high_value_cart_new_account",
            Unavailable = true,
            VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rule>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, Outcome> expectedOutcome = Outcome.Triggered;
        string expectedRuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj";
        ApiEnum<string, RuleType> expectedType = RuleType.Managed;
        long expectedWeight = 10;
        string expectedBlockedBy = "missing_data";
        string expectedName = "high_value_cart_new_account";
        bool expectedUnavailable = true;
        string expectedVersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6";

        Assert.Equal(expectedOutcome, deserialized.Outcome);
        Assert.Equal(expectedRuleID, deserialized.RuleID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedWeight, deserialized.Weight);
        Assert.Equal(expectedBlockedBy, deserialized.BlockedBy);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUnavailable, deserialized.Unavailable);
        Assert.Equal(expectedVersionID, deserialized.VersionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Rule
        {
            Outcome = Outcome.Triggered,
            RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
            Type = RuleType.Managed,
            Weight = 10,
            BlockedBy = "missing_data",
            Name = "high_value_cart_new_account",
            Unavailable = true,
            VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Rule
        {
            Outcome = Outcome.Triggered,
            RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
            Type = RuleType.Managed,
            Weight = 10,
        };

        Assert.Null(model.BlockedBy);
        Assert.False(model.RawData.ContainsKey("blocked_by"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Unavailable);
        Assert.False(model.RawData.ContainsKey("unavailable"));
        Assert.Null(model.VersionID);
        Assert.False(model.RawData.ContainsKey("version_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Rule
        {
            Outcome = Outcome.Triggered,
            RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
            Type = RuleType.Managed,
            Weight = 10,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Rule
        {
            Outcome = Outcome.Triggered,
            RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
            Type = RuleType.Managed,
            Weight = 10,

            // Null should be interpreted as omitted for these properties
            BlockedBy = null,
            Name = null,
            Unavailable = null,
            VersionID = null,
        };

        Assert.Null(model.BlockedBy);
        Assert.False(model.RawData.ContainsKey("blocked_by"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Unavailable);
        Assert.False(model.RawData.ContainsKey("unavailable"));
        Assert.Null(model.VersionID);
        Assert.False(model.RawData.ContainsKey("version_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Rule
        {
            Outcome = Outcome.Triggered,
            RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
            Type = RuleType.Managed,
            Weight = 10,

            // Null should be interpreted as omitted for these properties
            BlockedBy = null,
            Name = null,
            Unavailable = null,
            VersionID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Rule
        {
            Outcome = Outcome.Triggered,
            RuleID = "rul_01jc0t6fwwfgfsq1md24mhyztj",
            Type = RuleType.Managed,
            Weight = 10,
            BlockedBy = "missing_data",
            Name = "high_value_cart_new_account",
            Unavailable = true,
            VersionID = "3sL4kqtJlcpXroDTDmJ.o.Jj7bB5dGH6",
        };

        Rule copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutcomeTest : TestBase
{
    [Theory]
    [InlineData(Outcome.Triggered)]
    [InlineData(Outcome.NotTriggered)]
    [InlineData(Outcome.NotEvaluated)]
    [InlineData(Outcome.Skipped)]
    public void Validation_Works(Outcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Outcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Outcome>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Outcome.Triggered)]
    [InlineData(Outcome.NotTriggered)]
    [InlineData(Outcome.NotEvaluated)]
    [InlineData(Outcome.Skipped)]
    public void SerializationRoundtrip_Works(Outcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Outcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Outcome>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Outcome>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Outcome>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RuleTypeTest : TestBase
{
    [Theory]
    [InlineData(RuleType.Managed)]
    [InlineData(RuleType.Custom)]
    public void Validation_Works(RuleType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RuleType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RuleType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RuleType.Managed)]
    [InlineData(RuleType.Custom)]
    public void SerializationRoundtrip_Works(RuleType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RuleType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RuleType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RuleType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RuleType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VerdictTest : TestBase
{
    [Theory]
    [InlineData(Verdict.Pass)]
    [InlineData(Verdict.Flag)]
    public void Validation_Works(Verdict rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Verdict> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Verdict>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Verdict.Pass)]
    [InlineData(Verdict.Flag)]
    public void SerializationRoundtrip_Works(Verdict rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Verdict> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Verdict>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Verdict>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Verdict>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class WatchEvaluateResponseVerdictTest : TestBase
{
    [Theory]
    [InlineData(WatchEvaluateResponseVerdict.Pass)]
    [InlineData(WatchEvaluateResponseVerdict.Flag)]
    public void Validation_Works(WatchEvaluateResponseVerdict rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WatchEvaluateResponseVerdict> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WatchEvaluateResponseVerdict>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WatchEvaluateResponseVerdict.Pass)]
    [InlineData(WatchEvaluateResponseVerdict.Flag)]
    public void SerializationRoundtrip_Works(WatchEvaluateResponseVerdict rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WatchEvaluateResponseVerdict> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WatchEvaluateResponseVerdict>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WatchEvaluateResponseVerdict>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WatchEvaluateResponseVerdict>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
