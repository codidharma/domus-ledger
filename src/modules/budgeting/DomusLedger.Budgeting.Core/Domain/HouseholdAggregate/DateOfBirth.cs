﻿namespace DomusLedger.Budgeting.Core.Domain.HouseholdAggregate;

public sealed record DateOfBirth : ValueObject
{
    public DateTime Value { get; }
    private DateOfBirth(DateTime value)
    {
        Value = value;
    }

    public static Result<DateOfBirth> Create(DateTime value)
    {
        if (IsDateOfBirthInFutureorToday(value))
        {
            Error error = Error.InvalidDomain(
                "Budgeting.InvalidDomainValue",
                "Date of birth cannot be in future or today.");

            return Result.Failure<DateOfBirth>(error);
        }

        DateOfBirth dateOfBirth = new(value);

        return Result.Success(dateOfBirth);
    }

    private static bool IsDateOfBirthInFutureorToday(DateTime value)
    {

        return value.Date >= DateTime.Today.Date;
    }
}
