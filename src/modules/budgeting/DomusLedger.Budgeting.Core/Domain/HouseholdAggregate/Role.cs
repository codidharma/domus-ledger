namespace DomusLedger.Budgeting.Core.Domain.HouseholdAggregate;

public sealed record Role : Enumeration
{
    public static readonly Role Admin = new(1, nameof(Admin));
    public static readonly Role Regular = new(2, nameof(Regular));
    private Role(int id, string name) : base(id, name)
    {
    }
}
