using DomusLedger.Budgeting.Core.Domain.Common;
using DomusLedger.Common.Domain;

namespace DomusLedger.Budgeting.Core.UnitTests.Comman;

public class NameTests
{
    [Fact]
    public void Create_ShouldReturn_SuccessResult()
    {
        //Arrange
        string name = "John Wick";

        //Act
        Result<Name> createResult = Name.Create(name);

        //Assert
        Assert.True(createResult.IsSuccess);
        Assert.False(createResult.IsFailure);
        Assert.Equal(name, createResult.Value.Value);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ForInvalidName_Create_ShouldReturn_FailureResult(string name)
    {
        //Arrange
        string expectedErrorMessage = "Name can not be null, empty or whitespace string.";
        string expectedErrorCode = "Membership.InvalidDomainValue";
        //Arrange
        Result<Name> nameResult = Name.Create(name);

        //Assert
        Assert.True(nameResult.IsFailure);
        Assert.False(nameResult.IsSuccess);
        Error error = nameResult.Error;

        Assert.Equal(expectedErrorMessage, error.Description);
        Assert.Equal(expectedErrorCode, error.Code);
        Assert.Equal(ErrorType.InvalidDomain, error.ErrorType);
    }
}
