using BusinessProcessLibrary.Services.Implmentation;

namespace TestProject2
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void CreateUser_ShouldCallAddUser()
        {
            // Arrange
            var repository = new MockDataRepository();
            var service = new UserService(repository);
            var user = new MockUser { UserId = 1, UserName = "John Doe" };

            // Act
            service.CreateUser(user);

            // Assert
            var retrievedUser = repository.GetUser(1);
            Assert.AreEqual(user, retrievedUser);
        }
    }
}
