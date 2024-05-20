using BusinessProcessLibrary.Data.Implementation;

namespace BusinessProcessLibrary.Tests.Data
{
    [TestClass]
    public class DataRepositoryTests
    {

        [TestMethod]
        public void AddUser_ShouldAddUser()
        {
            // Arrange
            var repository = new DataRepository();
            var user = new User { UserId = 1, UserName = "John Doe" };

            // Act
            repository.AddUser(user);

            // Assert
            var retrievedUser = repository.GetUser(1);
            Assert.AreEqual(user, retrievedUser);
        }
    }
}