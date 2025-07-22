namespace DomainLedger.Budgeting.ArchTests;

public class EntityTests : TestBase
{
    [Fact]
    public void Entities_ShouldBe_SealedClasses()
    {
        //Act
        TestResult testResult = Types
            .InAssembly(CoreAssembly)
            .That()
            .Inherit(typeof(Entity))
            .Should()
            .BeSealed()
            .And()
            .BeClasses()
            .GetResult();

        //Assert
        Assert.True(testResult.IsSuccessful);
    }

}
