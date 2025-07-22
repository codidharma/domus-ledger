namespace DomainLedger.Budgeting.ArchTests;

public class InfrastructureTests : TestBase
{
    [Fact]
    public void Infrastructure_ShouldNotHave_Entites()
    {
        //Act
        TestResult testResult = Types
            .InAssembly(InfrastructureAssembly)
            .Should()
            .NotInherit(typeof(Entity))
            .GetResult();

        //Assert
        Assert.True(testResult.IsSuccessful);
    }

}
