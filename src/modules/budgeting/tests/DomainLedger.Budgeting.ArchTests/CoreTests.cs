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

    [Fact]
    public void StronglyTypedEnumerations_shouldBe_Sealed()
    {
        TestResult result = Types
            .InAssembly(CoreAssembly)
            .That()
            .Inherit(typeof(Enumeration))
            .Should()
            .BeSealed()
            .GetResult();

        Assert.True(result.IsSuccessful);

    }

    [Fact]
    public void StronglyTypedEnumerations_ShouldOnlyHve_PrivateConstructors()
    {
        //Arrange
        IEnumerable<Type> enumerationTypes = Types
            .InAssembly(CoreAssembly)
            .That()
            .Inherit(typeof(Enumeration))
            .GetTypes();

        List<Type> failingTypes = [];

        foreach (Type enumerationType in enumerationTypes)
        {
            ConstructorInfo[] infos = enumerationType.GetConstructors(BindingFlags.Instance | BindingFlags.Public);

            if (infos.Any())
            {
                failingTypes.Add(enumerationType);

            }
        }

        Assert.Empty(failingTypes);
    }
}
