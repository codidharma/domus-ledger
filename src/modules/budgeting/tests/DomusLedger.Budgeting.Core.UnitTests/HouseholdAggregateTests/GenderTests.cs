using DomusLedger.Budgeting.Core.Domain.HouseholdAggregate;

namespace DomusLedger.Budgeting.Core.UnitTests.HouseholdAggregateTests;

public class GenderTests
{
    [Theory]
    [InlineData("Male")]
    [InlineData("Female")]
    public void Create_ShouldReturn_SuccessResult(string genderValue)
    {

        //Act
        Result<Gender> genderResult = Gender.Create(genderValue);

        //Assert
        Assert.True(genderResult.IsSuccess);
        Assert.False(genderResult.IsFailure);
        Gender gender = genderResult.Value;
        Assert.Equal(genderValue, gender.Value);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ForInvalidGenderValue_Create_ShouldReturn_FailureResut(string genderValue)
    {
        //Arrange
        string expectedErrorMessage = "Gender value cannot be null, empty or whitespace string.";
        string expectedErrorCode = "Budgeting.InvalidDomainValue";

        //Act
        Result<Gender> genderResult = Gender.Create(genderValue);

        //Assert
        Assert.True(genderResult.IsFailure);
        Assert.False(genderResult.IsSuccess);

        Error error = genderResult.Error;
        Assert.Equal(expectedErrorMessage, error.Description);
        Assert.Equal(expectedErrorCode, error.Code);
        Assert.Equal(ErrorType.InvalidDomain, error.ErrorType);

    }
}
