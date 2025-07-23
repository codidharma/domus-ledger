using DomusLedger.Budgeting.Core.Domain.Common;
using DomusLedger.Budgeting.Core.Domain.HouseholdAggregate;
using DomusLedger.Common.Domain;
namespace DomusLedger.Budgeting.Core.UnitTests.HouseholdAggregateTests;

public class HouseholdTests
{
    [Fact]
    public void Create_ShouldRetrun_HouseholdAggregateInSuccessResult()
    {
        //Arrange
        Name name = Name.Create("John Wick").Value;
        Description description = Description.Create("John Wick Household").Value;
        Result<Household> createResult = Household.Create(name, description);

        //Assert
        Assert.True(createResult.IsSuccess);
        Assert.False(createResult.IsFailure);

        Household household = createResult.Value;

        Assert.NotNull(household.Id);
        Assert.Equal(name, household.Name);
        Assert.Equal(description, household.Description);
    }
}
