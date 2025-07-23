using DomusLedger.Budgeting.Core.Domain.Common;

namespace DomusLedger.Budgeting.Core.Domain.HouseholdAggregate;

public sealed class Household : Entity, IAggregateRoot
{
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    private Household(Name name, Description description)
    {
        Name = name;
        Description = description;
    }
    public static Result<Household> Create(Name name, Description description)
    {
        Household household = new(name, description);
        return Result.Success(household);
    }
}
