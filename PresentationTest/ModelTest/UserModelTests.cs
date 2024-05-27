using Presentation.Model.Implementation;

namespace Presentation.Tests
{
    [TestClass]
    public class UserModelTests
    {
        [TestMethod]
        public void UserModel_ShouldSetProperties()
        {
            // Arrange
            var userId = 1;
            var userName = "Test User";

            // Act
            var model = new UserModel(userId, userName);

            // Assert
            Assert.AreEqual(userId, model.userId);
            Assert.AreEqual(userName, model.userName);
        }
    }
}