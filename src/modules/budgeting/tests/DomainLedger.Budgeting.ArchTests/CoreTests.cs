using System.Reflection;

namespace DomainLedger.Budgeting.ArchTests;

public class CoreTests : TestBase
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

    [Fact]
    public void Entities_ShouldOnlyHave_PrivateConstructor()
    {
        //Arrange
        IEnumerable<Type> entities = Types
            .InAssembly(CoreAssembly)
            .That()
            .Inherit(typeof(Entity))
            .GetTypes();

        List<Type> failingTypes = [];

        foreach (Type entity in entities)
        {
            ConstructorInfo[] constructorInfos = entity.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            if (constructorInfos.Any())
            {
                failingTypes.Add(entity);
            }
        }

        //Assert
        Assert.Empty(failingTypes);


    }

    [Fact]
    public void Aggregates_ShouldBe_SealedClasses()
    {
        //Act
        TestResult testResult = Types
            .InAssembly(CoreAssembly)
            .That()
            .ImplementInterface(typeof(IAggregateRoot))
            .Should()
            .BeSealed()
            .And()
            .BeClasses()
            .GetResult();

        //Assert
        Assert.True(testResult.IsSuccessful);
    }
}
