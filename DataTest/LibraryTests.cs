using Data.DataLayer.API;

namespace DataTest
{
    [TestClass]
    [DeploymentItem("LibraryTest.mdf")]
    public class DataTest
    {
        private static string connectionString;
        private readonly IDataRepository _dataRepository = IDataRepository.CreateDatabase(IDataContext.CreateContext(connectionString));

        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext context)
        {
            string _DBRelativePath = @"LibraryTest.mdf";
            string _TestingWorkingFolder = Environment.CurrentDirectory;
            string _DBPath = Path.Combine(_TestingWorkingFolder, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists, $"{Environment.CurrentDirectory}");
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename={_DBPath};Integrated Security = True;Connect Timeout = 30;";
        }

        [TestMethod]
        public async Task UserTests()
        {
            int userId = 1;

            await _dataRepository.AddUser(userId, "John");

            IUser user = await _dataRepository.GetUser(userId);

            Assert.IsNotNull(user);
            Assert.AreEqual(userId, user.UserId);
            Assert.AreEqual("John", user.UserName);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetUser(userId + 2));

            await _dataRepository.UpdateUser(userId, "Jack");

            IUser userUpdate = await _dataRepository.GetUser(userId);

            Assert.IsNotNull(userUpdate);
            Assert.AreEqual(userId, userUpdate.UserId);
            Assert.AreEqual("Jack", userUpdate.UserName);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.UpdateUser(userId + 2, "Jack"));

            await _dataRepository.DeleteUser(userId);
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetUser(userId));
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.DeleteUser(userId));
        }

        [TestMethod]
        public async Task CatalogItemTests()
        {
            int itemId = 2;

            await _dataRepository.AddCatalogItem(itemId, "description");

            ICatalogItem item = await _dataRepository.GetCatalogItem(itemId);

            Assert.IsNotNull(item);
            Assert.AreEqual(itemId, item.ItemId);
            Assert.AreEqual("description", item.Description);
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetCatalogItem(3));

            await _dataRepository.UpdateCatalogItem(itemId, "other");

            ICatalogItem itemUpdate = await _dataRepository.GetCatalogItem(itemId);

            Assert.IsNotNull(itemUpdate);
            Assert.AreEqual(itemId, itemUpdate.ItemId);
            Assert.AreEqual("other", itemUpdate.Description);
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.UpdateCatalogItem(3, "other"));

            await _dataRepository.DeleteCatalogItem(itemId);
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetCatalogItem(itemId));
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.DeleteCatalogItem(itemId));
        }

        [TestMethod]
        public async Task ProcessStateTests()
        {
            int stateId = 3;

            await _dataRepository.AddProcessState(stateId, "description");

            IProcessState state = await _dataRepository.GetProcessState(stateId);

            Assert.IsNotNull(state);
            Assert.AreEqual(stateId, state.StateId);
            Assert.AreEqual("description", state.Description);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetProcessState(stateId + 2));

            await _dataRepository.UpdateProcessState(stateId, "other");

            IProcessState stateUpdate = await _dataRepository.GetProcessState(stateId);

            Assert.IsNotNull(stateUpdate);
            Assert.AreEqual(stateId, stateUpdate.StateId);
            Assert.AreEqual("other", stateUpdate.Description);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.UpdateProcessState(stateId + 2, "other"));

            await _dataRepository.DeleteProcessState(stateId);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetProcessState(stateId));
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.DeleteProcessState(stateId));
        }
    }
}