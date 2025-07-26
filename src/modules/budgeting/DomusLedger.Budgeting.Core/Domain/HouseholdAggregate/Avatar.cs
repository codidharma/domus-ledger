namespace DomusLedger.Budgeting.Core.Domain.HouseholdAggregate;

public sealed record Avatar : ValueObject
{
    public byte[] Value { get; init; }

    private Avatar(byte[] value)
    {
        Value = value;
    }

    public static Result<Avatar> Create(byte[] value)
    {
        Error error = Error.InvalidDomain("Budgeting.InvalidDomainValue", "Image can not be empty.");

        if (value.Length == 0)
        {
            return Result.Failure<Avatar>(error);
        }

        Avatar avatar = new(value);
        return Result.Success(avatar);
    }
}
