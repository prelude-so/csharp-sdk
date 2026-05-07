using System;
using System.Collections.Generic;
using System.Text.Json;
using Prelude.Core;
using Prelude.Exceptions;
using Prelude.Models.Notify;

namespace Prelude.Tests.Models.Notify;

public class NotifySendBatchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotifySendBatchResponse
        {
            ErrorCount = 0,
            Results =
            [
                new()
                {
                    PhoneNumber = "+33612345678",
                    Success = true,
                    Error = new()
                    {
                        Code = "invalid_phone_number",
                        Message =
                            "The provided phone number is invalid. Provide a valid E.164 phone number.",
                    },
                    Message = new()
                    {
                        ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
                        CorrelationID = "correlation_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Encoding = MessageEncoding.Gsm7,
                        EstimatedSegmentCount = 1,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        From = "YourBrand",
                        Locale = "locale",
                        ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        To = "+33612345678",
                    },
                },
            ],
            SuccessCount = 0,
            TotalCount = 0,
            CallbackUrl = "callback_url",
            RequestID = "request_id",
            TemplateID = "template_id",
            Variables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        long expectedErrorCount = 0;
        List<Result> expectedResults =
        [
            new()
            {
                PhoneNumber = "+33612345678",
                Success = true,
                Error = new()
                {
                    Code = "invalid_phone_number",
                    Message =
                        "The provided phone number is invalid. Provide a valid E.164 phone number.",
                },
                Message = new()
                {
                    ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
                    CorrelationID = "correlation_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Encoding = MessageEncoding.Gsm7,
                    EstimatedSegmentCount = 1,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    From = "YourBrand",
                    Locale = "locale",
                    ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    To = "+33612345678",
                },
            },
        ];
        long expectedSuccessCount = 0;
        long expectedTotalCount = 0;
        string expectedCallbackUrl = "callback_url";
        string expectedRequestID = "request_id";
        string expectedTemplateID = "template_id";
        Dictionary<string, string> expectedVariables = new() { { "foo", "string" } };

        Assert.Equal(expectedErrorCount, model.ErrorCount);
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
        Assert.Equal(expectedSuccessCount, model.SuccessCount);
        Assert.Equal(expectedTotalCount, model.TotalCount);
        Assert.Equal(expectedCallbackUrl, model.CallbackUrl);
        Assert.Equal(expectedRequestID, model.RequestID);
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.NotNull(model.Variables);
        Assert.Equal(expectedVariables.Count, model.Variables.Count);
        foreach (var item in expectedVariables)
        {
            Assert.True(model.Variables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Variables[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotifySendBatchResponse
        {
            ErrorCount = 0,
            Results =
            [
                new()
                {
                    PhoneNumber = "+33612345678",
                    Success = true,
                    Error = new()
                    {
                        Code = "invalid_phone_number",
                        Message =
                            "The provided phone number is invalid. Provide a valid E.164 phone number.",
                    },
                    Message = new()
                    {
                        ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
                        CorrelationID = "correlation_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Encoding = MessageEncoding.Gsm7,
                        EstimatedSegmentCount = 1,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        From = "YourBrand",
                        Locale = "locale",
                        ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        To = "+33612345678",
                    },
                },
            ],
            SuccessCount = 0,
            TotalCount = 0,
            CallbackUrl = "callback_url",
            RequestID = "request_id",
            TemplateID = "template_id",
            Variables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotifySendBatchResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotifySendBatchResponse
        {
            ErrorCount = 0,
            Results =
            [
                new()
                {
                    PhoneNumber = "+33612345678",
                    Success = true,
                    Error = new()
                    {
                        Code = "invalid_phone_number",
                        Message =
                            "The provided phone number is invalid. Provide a valid E.164 phone number.",
                    },
                    Message = new()
                    {
                        ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
                        CorrelationID = "correlation_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Encoding = MessageEncoding.Gsm7,
                        EstimatedSegmentCount = 1,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        From = "YourBrand",
                        Locale = "locale",
                        ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        To = "+33612345678",
                    },
                },
            ],
            SuccessCount = 0,
            TotalCount = 0,
            CallbackUrl = "callback_url",
            RequestID = "request_id",
            TemplateID = "template_id",
            Variables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotifySendBatchResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedErrorCount = 0;
        List<Result> expectedResults =
        [
            new()
            {
                PhoneNumber = "+33612345678",
                Success = true,
                Error = new()
                {
                    Code = "invalid_phone_number",
                    Message =
                        "The provided phone number is invalid. Provide a valid E.164 phone number.",
                },
                Message = new()
                {
                    ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
                    CorrelationID = "correlation_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Encoding = MessageEncoding.Gsm7,
                    EstimatedSegmentCount = 1,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    From = "YourBrand",
                    Locale = "locale",
                    ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    To = "+33612345678",
                },
            },
        ];
        long expectedSuccessCount = 0;
        long expectedTotalCount = 0;
        string expectedCallbackUrl = "callback_url";
        string expectedRequestID = "request_id";
        string expectedTemplateID = "template_id";
        Dictionary<string, string> expectedVariables = new() { { "foo", "string" } };

        Assert.Equal(expectedErrorCount, deserialized.ErrorCount);
        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
        Assert.Equal(expectedSuccessCount, deserialized.SuccessCount);
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
        Assert.Equal(expectedCallbackUrl, deserialized.CallbackUrl);
        Assert.Equal(expectedRequestID, deserialized.RequestID);
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.NotNull(deserialized.Variables);
        Assert.Equal(expectedVariables.Count, deserialized.Variables.Count);
        foreach (var item in expectedVariables)
        {
            Assert.True(deserialized.Variables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Variables[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotifySendBatchResponse
        {
            ErrorCount = 0,
            Results =
            [
                new()
                {
                    PhoneNumber = "+33612345678",
                    Success = true,
                    Error = new()
                    {
                        Code = "invalid_phone_number",
                        Message =
                            "The provided phone number is invalid. Provide a valid E.164 phone number.",
                    },
                    Message = new()
                    {
                        ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
                        CorrelationID = "correlation_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Encoding = MessageEncoding.Gsm7,
                        EstimatedSegmentCount = 1,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        From = "YourBrand",
                        Locale = "locale",
                        ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        To = "+33612345678",
                    },
                },
            ],
            SuccessCount = 0,
            TotalCount = 0,
            CallbackUrl = "callback_url",
            RequestID = "request_id",
            TemplateID = "template_id",
            Variables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NotifySendBatchResponse
        {
            ErrorCount = 0,
            Results =
            [
                new()
                {
                    PhoneNumber = "+33612345678",
                    Success = true,
                    Error = new()
                    {
                        Code = "invalid_phone_number",
                        Message =
                            "The provided phone number is invalid. Provide a valid E.164 phone number.",
                    },
                    Message = new()
                    {
                        ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
                        CorrelationID = "correlation_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Encoding = MessageEncoding.Gsm7,
                        EstimatedSegmentCount = 1,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        From = "YourBrand",
                        Locale = "locale",
                        ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        To = "+33612345678",
                    },
                },
            ],
            SuccessCount = 0,
            TotalCount = 0,
        };

        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("template_id"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NotifySendBatchResponse
        {
            ErrorCount = 0,
            Results =
            [
                new()
                {
                    PhoneNumber = "+33612345678",
                    Success = true,
                    Error = new()
                    {
                        Code = "invalid_phone_number",
                        Message =
                            "The provided phone number is invalid. Provide a valid E.164 phone number.",
                    },
                    Message = new()
                    {
                        ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
                        CorrelationID = "correlation_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Encoding = MessageEncoding.Gsm7,
                        EstimatedSegmentCount = 1,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        From = "YourBrand",
                        Locale = "locale",
                        ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        To = "+33612345678",
                    },
                },
            ],
            SuccessCount = 0,
            TotalCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NotifySendBatchResponse
        {
            ErrorCount = 0,
            Results =
            [
                new()
                {
                    PhoneNumber = "+33612345678",
                    Success = true,
                    Error = new()
                    {
                        Code = "invalid_phone_number",
                        Message =
                            "The provided phone number is invalid. Provide a valid E.164 phone number.",
                    },
                    Message = new()
                    {
                        ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
                        CorrelationID = "correlation_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Encoding = MessageEncoding.Gsm7,
                        EstimatedSegmentCount = 1,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        From = "YourBrand",
                        Locale = "locale",
                        ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        To = "+33612345678",
                    },
                },
            ],
            SuccessCount = 0,
            TotalCount = 0,

            // Null should be interpreted as omitted for these properties
            CallbackUrl = null,
            RequestID = null,
            TemplateID = null,
            Variables = null,
        };

        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("template_id"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NotifySendBatchResponse
        {
            ErrorCount = 0,
            Results =
            [
                new()
                {
                    PhoneNumber = "+33612345678",
                    Success = true,
                    Error = new()
                    {
                        Code = "invalid_phone_number",
                        Message =
                            "The provided phone number is invalid. Provide a valid E.164 phone number.",
                    },
                    Message = new()
                    {
                        ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
                        CorrelationID = "correlation_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Encoding = MessageEncoding.Gsm7,
                        EstimatedSegmentCount = 1,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        From = "YourBrand",
                        Locale = "locale",
                        ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        To = "+33612345678",
                    },
                },
            ],
            SuccessCount = 0,
            TotalCount = 0,

            // Null should be interpreted as omitted for these properties
            CallbackUrl = null,
            RequestID = null,
            TemplateID = null,
            Variables = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotifySendBatchResponse
        {
            ErrorCount = 0,
            Results =
            [
                new()
                {
                    PhoneNumber = "+33612345678",
                    Success = true,
                    Error = new()
                    {
                        Code = "invalid_phone_number",
                        Message =
                            "The provided phone number is invalid. Provide a valid E.164 phone number.",
                    },
                    Message = new()
                    {
                        ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
                        CorrelationID = "correlation_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Encoding = MessageEncoding.Gsm7,
                        EstimatedSegmentCount = 1,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        From = "YourBrand",
                        Locale = "locale",
                        ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        To = "+33612345678",
                    },
                },
            ],
            SuccessCount = 0,
            TotalCount = 0,
            CallbackUrl = "callback_url",
            RequestID = "request_id",
            TemplateID = "template_id",
            Variables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        NotifySendBatchResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            PhoneNumber = "+33612345678",
            Success = true,
            Error = new()
            {
                Code = "invalid_phone_number",
                Message =
                    "The provided phone number is invalid. Provide a valid E.164 phone number.",
            },
            Message = new()
            {
                ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
                CorrelationID = "correlation_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Encoding = MessageEncoding.Gsm7,
                EstimatedSegmentCount = 1,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                From = "YourBrand",
                Locale = "locale",
                ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                To = "+33612345678",
            },
        };

        string expectedPhoneNumber = "+33612345678";
        bool expectedSuccess = true;
        Error expectedError = new()
        {
            Code = "invalid_phone_number",
            Message = "The provided phone number is invalid. Provide a valid E.164 phone number.",
        };
        Message expectedMessage = new()
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CorrelationID = "correlation_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Encoding = MessageEncoding.Gsm7,
            EstimatedSegmentCount = 1,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            From = "YourBrand",
            Locale = "locale",
            ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            To = "+33612345678",
        };

        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Result
        {
            PhoneNumber = "+33612345678",
            Success = true,
            Error = new()
            {
                Code = "invalid_phone_number",
                Message =
                    "The provided phone number is invalid. Provide a valid E.164 phone number.",
            },
            Message = new()
            {
                ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
                CorrelationID = "correlation_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Encoding = MessageEncoding.Gsm7,
                EstimatedSegmentCount = 1,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                From = "YourBrand",
                Locale = "locale",
                ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                To = "+33612345678",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            PhoneNumber = "+33612345678",
            Success = true,
            Error = new()
            {
                Code = "invalid_phone_number",
                Message =
                    "The provided phone number is invalid. Provide a valid E.164 phone number.",
            },
            Message = new()
            {
                ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
                CorrelationID = "correlation_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Encoding = MessageEncoding.Gsm7,
                EstimatedSegmentCount = 1,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                From = "YourBrand",
                Locale = "locale",
                ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                To = "+33612345678",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedPhoneNumber = "+33612345678";
        bool expectedSuccess = true;
        Error expectedError = new()
        {
            Code = "invalid_phone_number",
            Message = "The provided phone number is invalid. Provide a valid E.164 phone number.",
        };
        Message expectedMessage = new()
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CorrelationID = "correlation_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Encoding = MessageEncoding.Gsm7,
            EstimatedSegmentCount = 1,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            From = "YourBrand",
            Locale = "locale",
            ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            To = "+33612345678",
        };

        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Result
        {
            PhoneNumber = "+33612345678",
            Success = true,
            Error = new()
            {
                Code = "invalid_phone_number",
                Message =
                    "The provided phone number is invalid. Provide a valid E.164 phone number.",
            },
            Message = new()
            {
                ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
                CorrelationID = "correlation_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Encoding = MessageEncoding.Gsm7,
                EstimatedSegmentCount = 1,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                From = "YourBrand",
                Locale = "locale",
                ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                To = "+33612345678",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Result { PhoneNumber = "+33612345678", Success = true };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Result { PhoneNumber = "+33612345678", Success = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Result
        {
            PhoneNumber = "+33612345678",
            Success = true,

            // Null should be interpreted as omitted for these properties
            Error = null,
            Message = null,
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Result
        {
            PhoneNumber = "+33612345678",
            Success = true,

            // Null should be interpreted as omitted for these properties
            Error = null,
            Message = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Result
        {
            PhoneNumber = "+33612345678",
            Success = true,
            Error = new()
            {
                Code = "invalid_phone_number",
                Message =
                    "The provided phone number is invalid. Provide a valid E.164 phone number.",
            },
            Message = new()
            {
                ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
                CorrelationID = "correlation_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Encoding = MessageEncoding.Gsm7,
                EstimatedSegmentCount = 1,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                From = "YourBrand",
                Locale = "locale",
                ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                To = "+33612345678",
            },
        };

        Result copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Error
        {
            Code = "invalid_phone_number",
            Message = "The provided phone number is invalid. Provide a valid E.164 phone number.",
        };

        string expectedCode = "invalid_phone_number";
        string expectedMessage =
            "The provided phone number is invalid. Provide a valid E.164 phone number.";

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Error
        {
            Code = "invalid_phone_number",
            Message = "The provided phone number is invalid. Provide a valid E.164 phone number.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Error
        {
            Code = "invalid_phone_number",
            Message = "The provided phone number is invalid. Provide a valid E.164 phone number.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCode = "invalid_phone_number";
        string expectedMessage =
            "The provided phone number is invalid. Provide a valid E.164 phone number.";

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Error
        {
            Code = "invalid_phone_number",
            Message = "The provided phone number is invalid. Provide a valid E.164 phone number.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Error { };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Error { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Error
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            Message = null,
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Error
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            Message = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Error
        {
            Code = "invalid_phone_number",
            Message = "The provided phone number is invalid. Provide a valid E.164 phone number.",
        };

        Error copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Message
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CorrelationID = "correlation_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Encoding = MessageEncoding.Gsm7,
            EstimatedSegmentCount = 1,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            From = "YourBrand",
            Locale = "locale",
            ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            To = "+33612345678",
        };

        string expectedID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9";
        string expectedCorrelationID = "correlation_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, MessageEncoding> expectedEncoding = MessageEncoding.Gsm7;
        long expectedEstimatedSegmentCount = 1;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFrom = "YourBrand";
        string expectedLocale = "locale";
        DateTimeOffset expectedScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTo = "+33612345678";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCorrelationID, model.CorrelationID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEncoding, model.Encoding);
        Assert.Equal(expectedEstimatedSegmentCount, model.EstimatedSegmentCount);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedFrom, model.From);
        Assert.Equal(expectedLocale, model.Locale);
        Assert.Equal(expectedScheduleAt, model.ScheduleAt);
        Assert.Equal(expectedTo, model.To);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Message
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CorrelationID = "correlation_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Encoding = MessageEncoding.Gsm7,
            EstimatedSegmentCount = 1,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            From = "YourBrand",
            Locale = "locale",
            ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            To = "+33612345678",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Message>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Message
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CorrelationID = "correlation_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Encoding = MessageEncoding.Gsm7,
            EstimatedSegmentCount = 1,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            From = "YourBrand",
            Locale = "locale",
            ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            To = "+33612345678",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Message>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9";
        string expectedCorrelationID = "correlation_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, MessageEncoding> expectedEncoding = MessageEncoding.Gsm7;
        long expectedEstimatedSegmentCount = 1;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFrom = "YourBrand";
        string expectedLocale = "locale";
        DateTimeOffset expectedScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTo = "+33612345678";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCorrelationID, deserialized.CorrelationID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEncoding, deserialized.Encoding);
        Assert.Equal(expectedEstimatedSegmentCount, deserialized.EstimatedSegmentCount);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedFrom, deserialized.From);
        Assert.Equal(expectedLocale, deserialized.Locale);
        Assert.Equal(expectedScheduleAt, deserialized.ScheduleAt);
        Assert.Equal(expectedTo, deserialized.To);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Message
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CorrelationID = "correlation_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Encoding = MessageEncoding.Gsm7,
            EstimatedSegmentCount = 1,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            From = "YourBrand",
            Locale = "locale",
            ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            To = "+33612345678",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Message { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Encoding);
        Assert.False(model.RawData.ContainsKey("encoding"));
        Assert.Null(model.EstimatedSegmentCount);
        Assert.False(model.RawData.ContainsKey("estimated_segment_count"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.Locale);
        Assert.False(model.RawData.ContainsKey("locale"));
        Assert.Null(model.ScheduleAt);
        Assert.False(model.RawData.ContainsKey("schedule_at"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Message { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Message
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CorrelationID = null,
            CreatedAt = null,
            Encoding = null,
            EstimatedSegmentCount = null,
            ExpiresAt = null,
            From = null,
            Locale = null,
            ScheduleAt = null,
            To = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Encoding);
        Assert.False(model.RawData.ContainsKey("encoding"));
        Assert.Null(model.EstimatedSegmentCount);
        Assert.False(model.RawData.ContainsKey("estimated_segment_count"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.Locale);
        Assert.False(model.RawData.ContainsKey("locale"));
        Assert.Null(model.ScheduleAt);
        Assert.False(model.RawData.ContainsKey("schedule_at"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Message
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CorrelationID = null,
            CreatedAt = null,
            Encoding = null,
            EstimatedSegmentCount = null,
            ExpiresAt = null,
            From = null,
            Locale = null,
            ScheduleAt = null,
            To = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Message
        {
            ID = "tx_01k8ap1btqf5r9fq2c8ax5fhc9",
            CorrelationID = "correlation_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Encoding = MessageEncoding.Gsm7,
            EstimatedSegmentCount = 1,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            From = "YourBrand",
            Locale = "locale",
            ScheduleAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            To = "+33612345678",
        };

        Message copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MessageEncodingTest : TestBase
{
    [Theory]
    [InlineData(MessageEncoding.Gsm7)]
    [InlineData(MessageEncoding.Ucs2)]
    public void Validation_Works(MessageEncoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageEncoding> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessageEncoding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PreludeInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MessageEncoding.Gsm7)]
    [InlineData(MessageEncoding.Ucs2)]
    public void SerializationRoundtrip_Works(MessageEncoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageEncoding> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessageEncoding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessageEncoding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessageEncoding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
