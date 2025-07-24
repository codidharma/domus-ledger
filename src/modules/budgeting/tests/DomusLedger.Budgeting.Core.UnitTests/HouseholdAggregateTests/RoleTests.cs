using DomusLedger.Budgeting.Core.Domain.HouseholdAggregate;

namespace DomusLedger.Budgeting.Core.UnitTests.HouseholdAggregateTests;

public class RoleTests
{
    [Fact]
    public void New_Returns_AdminRole()
    {
        //Arrange
        Role admin1 = Role.Admin;
        Role admin2 = Role.Admin;

        //Assert
        Assert.Equal(admin1, admin2);
    }

    [Fact]
    public void New_Returns_RegularRole()
    {
        //Act
        Role regular1 = Role.Regular;
        Role regular2 = Role.Regular;

        //Assert
        Assert.Equal(regular1, regular2);
    }
}
