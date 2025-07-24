﻿namespace DomusLedger.Budgeting.Core.Domain.HouseholdAggregate;

public sealed record Gender : ValueObject
{
    public string Value { get; }
    private Gender(string value)
    {
        Value = value;
    }

    public static Result<Gender> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            Error error = Error.InvalidDomain(
                "Budgeting.InvalidDomainValue",
                "Gender value cannot be null, empty or whitespace string.");

            return Result.Failure<Gender>(error);
        }
        Gender gender = new(value);
        return Result.Success<Gender>(gender);
    }
}
