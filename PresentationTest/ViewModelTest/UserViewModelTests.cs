using Moq;
using Presentation.Model.API;
using Presentation.Model.Implementation;

namespace Presentation.ViewModel.Tests
{
    [TestClass]
    public class UserViewModelTests
    {
        private Mock<IUserOperations> _mockUserOperations;
        private UserViewModel _viewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockUserOperations = new Mock<IUserOperations>();
            _viewModel = new UserViewModel();
            _viewModel.SetOperations(_mockUserOperations.Object);
        }

        [TestMethod]
        public async Task LoadUsersCommand_ShouldLoadUsers()
        {
            // Arrange
            var users = new Dictionary<int, IUserModel>
            {
                { 1, new UserModel(1, "User 1") },
                { 2, new UserModel(2, "User 2") }
            };
            _mockUserOperations.Setup(op => op.GetAllUsers()).ReturnsAsync(users);

            // Act
            await _viewModel.LoadUsers();

            // Assert
            Assert.AreEqual(2, _viewModel.Users.Count);
            Assert.AreEqual("User 1", _viewModel.Users[0].userName);
            Assert.AreEqual("User 2", _viewModel.Users[1].userName);
        }

        [TestMethod]
        public async Task AddUserCommand_ShouldAddUser()
        {
            // Arrange
            var users = new Dictionary<int, IUserModel>
            {
                { 1, new UserModel(1, "User 1") },
                { 2, new UserModel(2, "User 2") }
            };
            _mockUserOperations.Setup(op => op.GetAllUsers()).ReturnsAsync(users);
            _viewModel.UserId = 3;
            _viewModel.UserName = "New User";

            // Act
            await _viewModel.AddUser();

            // Assert
            _mockUserOperations.Verify(op => op.AddUser(3, "New User"), Times.Once);
            _mockUserOperations.Verify(op => op.GetAllUsers(), Times.AtLeastOnce);
        }

        [TestMethod]
        public async Task UpdateUserCommand_ShouldUpdateUser()
        {
            // Arrange
            var users = new Dictionary<int, IUserModel>
            {
                { 1, new UserModel(1, "User 1") },
                { 2, new UserModel(2, "User 2") }
            };
            _mockUserOperations.Setup(op => op.GetAllUsers()).ReturnsAsync(users);
            _viewModel.UserId = 1;
            _viewModel.UserName = "Updated User";

            // Act
            await _viewModel.UpdateUser();

            // Assert
            _mockUserOperations.Verify(op => op.UpdateUser(1, "Updated User"), Times.Once);
            _mockUserOperations.Verify(op => op.GetAllUsers(), Times.AtLeastOnce);
        }

        [TestMethod]
        public async Task DeleteUserCommand_ShouldDeleteUser()
        {
            // Arrange
            var users = new Dictionary<int, IUserModel>
            {
                { 1, new UserModel(1, "User 1") },
                { 2, new UserModel(2, "User 2") }
            };
            _mockUserOperations.Setup(op => op.GetAllUsers()).ReturnsAsync(users);
            _viewModel.UserId = 1;

            // Act
            await _viewModel.DeleteUser();

            // Assert
            _mockUserOperations.Verify(op => op.DeleteUser(1), Times.Once);
            _mockUserOperations.Verify(op => op.GetAllUsers(), Times.AtLeastOnce);
        }
    }
}