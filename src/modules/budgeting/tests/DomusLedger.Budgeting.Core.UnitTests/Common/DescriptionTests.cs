using DomusLedger.Budgeting.Core.Domain.Common;
using DomusLedger.Common.Domain;

namespace DomusLedger.Budgeting.Core.UnitTests.Common;

public class DescriptionTests
{
    [Fact]
    public void Create_ShouldReturn_SuccessResult()
    {
        //Arrange
        string description = "John Wick Hlousehold.";

        //Act
        Result<Description> createResult = Description.Create(description);

        //Assert
        Assert.True(createResult.IsSuccess);
        Assert.False(createResult.IsFailure);
        Assert.Equal(description, createResult.Value.Value);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ForInvalidDescription_Create_ShouldReturn_FailureResult(string description)
    {
        //Arrange
        string expectedErrorMessage = "Description can not be null, empty or whitespace string.";
        string expectedErrorCode = "Budgeting.InvalidDomainValue";
        //Arrange
        Result<Description> nameResult = Description.Create(description);

        //Assert
        Assert.True(nameResult.IsFailure);
        Assert.False(nameResult.IsSuccess);
        Error error = nameResult.Error;

        Assert.Equal(expectedErrorMessage, error.Description);
        Assert.Equal(expectedErrorCode, error.Code);
        Assert.Equal(ErrorType.InvalidDomain, error.ErrorType);
    }
}
