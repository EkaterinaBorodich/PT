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
            string _projectRootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string _DBPath = Path.Combine(_projectRootDir, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists,$"{Environment.CurrentDirectory}");
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachFilename={_DBPath};Integrated Security = True;Connect Timeout = 30;";
        }
        [TestMethod]
        public async Task UserTests()
        {
            int userId = 1;

            await _dataRepository.AddUser(userId, "John");

            IUser user = await _dataRepository.GetUser(userId);

            Assert.IsNotNull(user);
        }
    }
}