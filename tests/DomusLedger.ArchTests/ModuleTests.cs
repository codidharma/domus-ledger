using System;

namespace DomusLedger.ArchTests;

public class ModulesTests : TestBase
{
    [Fact]
    public void BudgetingModule_ShouldNotHaveDependenciesOn_OtherModules()
    {
        //Arrange
        string[] otherModules = [AssetAndLiabilityNameSpace];

        //Act
        TestResult testResult = Types
        .InNamespace(BudgetingNameSpace)
        .Should()
        .NotHaveDependencyOnAny(otherModules)
        .GetResult();

        //Assert
        Assert.True(testResult.IsSuccessful);
    }

    [Fact]
    public void AssetAndLiabilityModule_ShouldNotHaveDependenciesOn_OtherModules()
    {
        //Arrange
        string[] otherModules = [BudgetingNameSpace];

        //Act
        TestResult testResult = Types
        .InNamespace(AssetAndLiabilityNameSpace)
        .Should()
        .NotHaveDependencyOnAny(otherModules)
        .GetResult();

        //Assert
        Assert.True(testResult.IsSuccessful);

    }

}
