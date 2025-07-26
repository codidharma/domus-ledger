using DomusLedger.Budgeting.Core.Domain.Common;
using DomusLedger.Budgeting.Core.Domain.HouseholdAggregate;

namespace DomusLedger.Budgeting.Core.UnitTests.HouseholdAggregateTests;

public class UserTests
{
    [Fact]
    public void Create_Returns_SuccessResultWithUser()
    {
        //Arrange
        Name name = Name.Create("John Wick").Value;
        Email email = Email.Create("john.wick@testserver.com").Value;
        Gender gender = Gender.Create("Male").Value;
        Role role = Role.Admin;
        string imagePath = Path.GetFullPath("..\\..\\..\\Common\\TestImage.jpg");
        byte[] imageBytes = File.ReadAllBytes(imagePath);
        Avatar avatar = Avatar.Create(imageBytes).Value;


        //Act
        Result<User> createResult = User.Create(name, email, gender, role, avatar);

        //Assert
        Assert.True(createResult.IsSuccess);
        Assert.False(createResult.IsFailure);

        User user = createResult.Value;
        Assert.Equal(name, user.Name);
        Assert.Equal(email, user.Email);
        Assert.Equal(gender, user.Gender);
        Assert.Equal(role, user.Role);
        Assert.Equal(avatar, user.Avatar);
    }
}
