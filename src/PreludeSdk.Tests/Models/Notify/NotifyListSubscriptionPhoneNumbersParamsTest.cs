using System;
using System.Text.Json;
using PreludeSdk.Core;
using PreludeSdk.Exceptions;
using PreludeSdk.Models.Notify;

namespace PreludeSdk.Tests.Models.Notify;

public class NotifyListSubscriptionPhoneNumbersParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotifyListSubscriptionPhoneNumbersParams
        {
            ConfigID = "config_id",
            Cursor = "cursor",
            Limit = 1,
            State = State.Sub,
        };

        string expectedConfigID = "config_id";
        string expectedCursor = "cursor";
        long expectedLimit = 1;
        ApiEnum<string, State> expectedState = State.Sub;

        Assert.Equal(expectedConfigID, parameters.ConfigID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedState, parameters.State);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotifyListSubscriptionPhoneNumbersParams { ConfigID = "config_id" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawQueryData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotifyListSubscriptionPhoneNumbersParams
        {
            ConfigID = "config_id",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
            State = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawQueryData.ContainsKey("state"));
    }

    [Fact]
    public void Url_Works()
    {
        NotifyListSubscriptionPhoneNumbersParams parameters = new()
        {
            ConfigID = "config_id",
            Cursor = "cursor",
            Limit = 1,
            State = State.Sub,
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.prelude.dev/v2/notify/management/subscriptions/config_id/phone_numbers?cursor=cursor&limit=1&state=SUB"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotifyListSubscriptionPhoneNumbersParams
        {
            ConfigID = "config_id",
            Cursor = "cursor",
            Limit = 1,
            State = State.Sub,
        };

        NotifyListSubscriptionPhoneNumbersParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StateTest : TestBase
{
    [Theory]
    [InlineData(State.Sub)]
    [InlineData(State.Unsub)]
    public void Validation_Works(State rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, State> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(State.Sub)]
    [InlineData(State.Unsub)]
    public void SerializationRoundtrip_Works(State rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, State> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
