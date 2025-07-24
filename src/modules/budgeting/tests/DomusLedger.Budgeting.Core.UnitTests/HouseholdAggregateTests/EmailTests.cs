using DomusLedger.Budgeting.Core.Domain.HouseholdAggregate;

namespace DomusLedger.Budgeting.Core.UnitTests.HouseholdAggregateTests;

public class EmailTests
{
    [Fact]
    public void Crate_ShouldReturn_SuccessResult()
    {
        //Arrange
        string emailValue = "test@gmail.com";

        //Act
        Result<Email> emailResult = Email.Create(emailValue);

        //Assert
        Assert.True(emailResult.IsSuccess);
        Assert.False(emailResult.IsFailure);

        Email email = emailResult.Value;
        Assert.Equal(emailValue, email.Value);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("abc@")]
    public void ForInvalidEmailValue_Create_ShouldReturn_FailureResult(string emailValue)
    {
        //Arrange
        string expectedErrorMessage = "Email should be in format abc@pqr.com.";
        string expectedErrorCode = "Budgeting.InvalidDomainValue";

        //Act
        Result<Email> emailResult = Email.Create(emailValue);

        //Assert
        Assert.True(emailResult.IsFailure);
        Assert.False(emailResult.IsSuccess);

        Error error = emailResult.Error;

        Assert.Equal(expectedErrorMessage, error.Description);
        Assert.Equal(expectedErrorCode, error.Code);
        Assert.Equal(ErrorType.InvalidDomain, error.ErrorType);
    }
}
