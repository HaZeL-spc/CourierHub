﻿using System.ComponentModel.DataAnnotations;

namespace CourierAPI.Helpers;

public class RequiredEnumAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return false;
        }

        var type = value.GetType();
        return type.IsEnum && Enum.IsDefined(type, value);
    }
}

public enum InquiryStatus
{
    NotConsidered = 0,
    Accepted = 1,
    Rejected = 2
}
public enum DeliveryStatus
{
    NotPickedUp = 0,
    PickedUp = 1,
    Delivered = 2,
    Cancelled = 3
}

public class Result
{
    public bool Success { get; set; }
    public string Error { get; private set; }
    public bool isFailure => !Success;

    protected Result(bool success, string error)
    {
        if (success && error != string.Empty)
            throw new InvalidOperationException();
        if (!success && error == string.Empty)
            throw new InvalidOperationException();
        Success = success;
        Error = error;
    }

    public static Result Fail(string message)
    {
        return new Result(false, message);
    }
    public static Result<T> Fail<T>(string message)
    {
        return new Result<T>(default(T)!, false, message);
    }
    public static Result Ok()
    {
        return new Result(true, string.Empty);
    }
    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>(value, true, string.Empty);
    }
}

public class Result<T> : Result
{
    public T Value { get; set; }

    protected internal Result(T value, bool success, string error)
        : base(success, error)
    {
        Value = value;
    }
}