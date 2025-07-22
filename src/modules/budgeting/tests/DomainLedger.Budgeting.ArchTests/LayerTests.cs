
namespace DomainLedger.Budgeting.ArchTests;

public class LayerTests : TestBase
{
    [Fact]
    public void Core_ShouldNotHaveDependenciesOn_Infrastructure()
    {
        //Act
        TestResult testResult = Types
        .InAssembly(CoreAssembly)
        .ShouldNot()
        .HaveDependencyOn(InfrastructureAssembly.GetType().Name)
        .GetResult();

        //Assert
        Assert.True(testResult.IsSuccessful);
    }
}
