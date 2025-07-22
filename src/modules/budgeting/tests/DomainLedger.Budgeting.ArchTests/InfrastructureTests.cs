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

    [Fact]
    public void Infrastructure_ShouldNotHave_Aggregates()
    {
        //Act
        TestResult testResult = Types
            .InAssembly(InfrastructureAssembly)
            .Should()
            .NotImplementInterface(typeof(IAggregateRoot))
            .GetResult();

        //Assert
        Assert.True(testResult.IsSuccessful);
    }

}
