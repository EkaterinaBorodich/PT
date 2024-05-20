using BusinessProcessLibrary.Services.Implmentation;
using PresentationLayer;

namespace TestProject2
{
    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void AddUserCommand_ShouldAddUser()
        {
            // Arrange
            var userRepository = new MockDataRepository(); // Use the actual data repository
            var userService = new UserService(userRepository); // Use the actual user service
            var viewModel = new MainViewModel(userService);

            // Act
            viewModel.AddUserCommand.Execute(null);

            // Assert
            Assert.IsTrue(viewModel.Users.Count == 1); // Assuming initial count is 0
            Assert.AreEqual("New User", viewModel.Users[0].UserName);
        }
    }
}
