using DomusLedger.Budgeting.Core.Domain.Common;

namespace DomusLedger.Budgeting.Core.Domain.HouseholdAggregate;

public sealed class User : Entity
{
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Gender Gender { get; private set; }
    public Role Role { get; private set; }
    public Avatar Avatar { get; private set; }

    private User(Name name, Email email, Gender gender, Role role, Avatar avatar)
    {
        Name = name;
        Email = email;
        Gender = gender;
        Role = role;
        Avatar = avatar;
    }

    public static Result<User> Create(Name name, Email email, Gender gender, Role role, Avatar avatar)
    {
        User user = new(name, email, gender, role, avatar);
        return Result.Success(user);
    }
}
