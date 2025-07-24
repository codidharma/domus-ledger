using DomusLedger.Budgeting.Core.Domain.HouseholdAggregate;

namespace DomusLedger.Budgeting.Core.UnitTests.HouseholdAggregateTests;

public class DateOfBirthTests
{
    [Fact]
    public void Create_ShouldReturn_SuccessResult()
    {
        //Arrange
        DateTime dateOfBirthValue = DateTime.UtcNow.AddMonths(-240);

        //Act
        Result<DateOfBirth> dobResult = DateOfBirth.Create(dateOfBirthValue);

        //Assert
        Assert.True(dobResult.IsSuccess);
        Assert.False(dobResult.IsFailure);

        DateOfBirth dateOfBirth = dobResult.Value;

        Assert.Equal(dateOfBirthValue, dateOfBirth.Value);
    }

    [Fact]
    public void ForFutureDateOfBirth_Create_ShouldReturn_FailureResult()
    {
        //Arrange
        string expectedExceptionMessage = "Date of birth cannot be in future or today.";
        string expectedErrorCode = "Budgeting.InvalidDomainValue";
        DateTime futureDateOfBirthValue = DateTime.UtcNow.AddYears(1000);

        //Act
        Result<DateOfBirth> dobResult = DateOfBirth.Create(futureDateOfBirthValue);

        //Assert
        Assert.True(dobResult.IsFailure);
        Assert.False(dobResult.IsSuccess);

        Error error = dobResult.Error;

        Assert.Equal(expectedErrorCode, error.Code);
        Assert.Equal(expectedExceptionMessage, error.Description);
        Assert.Equal(ErrorType.InvalidDomain, error.ErrorType);
    }

    [Fact]
    public void ForTodaysDateOfBirth_Create_ShouldReturn_FailureResult()
    {
        //Arrange
        string expectedExceptionMessage = "Date of birth cannot be in future or today.";
        string expectedErrorCode = "Budgeting.InvalidDomainValue";
        DateTime futureDateOfBirthValue = DateTime.Now;

        //Act
        Result<DateOfBirth> dobResult = DateOfBirth.Create(futureDateOfBirthValue);

        //Assert
        Assert.True(dobResult.IsFailure);
        Assert.False(dobResult.IsSuccess);

        Error error = dobResult.Error;

        Assert.Equal(expectedErrorCode, error.Code);
        Assert.Equal(expectedExceptionMessage, error.Description);
        Assert.Equal(ErrorType.InvalidDomain, error.ErrorType);
    }
}
