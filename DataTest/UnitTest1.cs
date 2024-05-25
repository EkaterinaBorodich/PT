using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.DataLayer.API;
using Data.DataLayer.Implementation;

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
            Assert.IsTrue(_databaseFile.Exists,$"{Environment.CurrentDirectory}");
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename={_DBPath};Integrated Security = True;Connect Timeout = 30;";
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