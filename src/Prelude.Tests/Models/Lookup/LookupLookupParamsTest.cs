using System;
using System.Collections.Generic;
using System.Text.Json;
using Prelude.Core;
using Prelude.Exceptions;
using Lookup = Prelude.Models.Lookup;

namespace Prelude.Tests.Models.Lookup;

public class LookupLookupParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Lookup::LookupLookupParams
        {
            PhoneNumber = "+12065550100",
            Type = [Lookup::Type.Cnam],
        };

        string expectedPhoneNumber = "+12065550100";
        List<ApiEnum<string, Lookup::Type>> expectedType = [Lookup::Type.Cnam];

        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
        Assert.NotNull(parameters.Type);
        Assert.Equal(expectedType.Count, parameters.Type.Count);
        for (int i = 0; i < expectedType.Count; i++)
        {
            Assert.Equal(expectedType[i], parameters.Type[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Lookup::LookupLookupParams { PhoneNumber = "+12065550100" };

        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Lookup::LookupLookupParams
        {
            PhoneNumber = "+12065550100",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        Lookup::LookupLookupParams parameters = new()
        {
            PhoneNumber = "+12065550100",
            Type = [Lookup::Type.Cnam],
        };

        var url = parameters.Url(new() { ApiToken = "My API Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.prelude.dev/v2/lookup/+12065550100?type=cnam"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Lookup::LookupLookupParams
        {
            PhoneNumber = "+12065550100",
            Type = [Lookup::Type.Cnam],
        };

        Lookup::LookupLookupParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Lookup::Type.Cnam)]
    public void Validation_Works(Lookup::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Lookup::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Lookup::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Lookup::Type.Cnam)]
    public void SerializationRoundtrip_Works(Lookup::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Lookup::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Lookup::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Lookup::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Lookup::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
