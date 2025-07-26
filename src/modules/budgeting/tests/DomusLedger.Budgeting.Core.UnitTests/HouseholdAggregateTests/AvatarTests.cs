using DomusLedger.Budgeting.Core.Domain.HouseholdAggregate;

namespace DomusLedger.Budgeting.Core.UnitTests.HouseholdAggregateTests;

public class AvatarTests
{
    [Fact]
    public void Create_ShouldReturn_SuccessResult()
    {
        //Arrange
        string imagePath = Path.GetFullPath("..\\..\\..\\Common\\TestImage.jpg");
        byte[] imageBytes = File.ReadAllBytes(imagePath);

        //Act
        Result<Avatar> createResult = Avatar.Create(imageBytes);

        //Assert
        Assert.True(createResult.IsSuccess);
        Assert.False(createResult.IsFailure);

        Avatar avatar = createResult.Value;
        Assert.Equal(imageBytes, avatar.Value);
    }

    [Fact]
    public void ForEmptyArray_Create_ShouldReturn_FailureResult()
    {

        //Arrange
        byte[] imageBytes = [];
        Error expected = Error.InvalidDomain("Budgeting.InvalidDomainValue", "Image can not be empty.");
        //Act
        Result<Avatar> createResult = Avatar.Create(imageBytes);

        //Assert
        Assert.True(createResult.IsFailure);
        Assert.False(createResult.IsSuccess);
        Error actual = createResult.Error;
        Assert.Equal(expected, actual);
    }
}
