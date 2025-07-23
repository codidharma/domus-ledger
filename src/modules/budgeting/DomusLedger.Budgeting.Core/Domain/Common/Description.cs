namespace DomusLedger.Budgeting.Core.Domain.Common;

public sealed record Description : ValueObject
{
    private Description(string value)
    {
        Value = value;
    }

    public static Result<Description> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            var InvalidNameError = Error.InvalidDomain("Budgeting.InvalidDomainValue", "Name can not be null, empty or whitespace string.");
            return Result.Failure<Description>(InvalidNameError);

        }
        Description description = new(value);
        return Result.Success(description);
    }
    public string Value { get; }
}
