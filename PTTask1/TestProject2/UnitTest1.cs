using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessProcessLibrary;
using System;


namespace BusinessProcessLibraryTests
{
    [TestClass]
    public class BusinessLogicTests
    {
        private DataContext _dataContext;
        private DataRepository _dataRepository;
        private BusinessLogic _businessLogic;

        [TestInitialize]
        public void Setup()
        {
            // Initialize DataContext, DataRepository, and BusinessLogic
            _dataContext = new DataContext();
            _dataRepository = new DataRepository(_dataContext);
            _businessLogic = new BusinessLogic(_dataRepository);

            // Initialize test data
            InitializeTestData();
        }

        private void InitializeTestData()
        {
            _businessLogic.RegisterUser(1, "John Doe");
            _businessLogic.AddCatalogItem(1, "Book");
            _businessLogic.UpdateProcessState(1, "Available");
        }

        [TestMethod]
        public void TestUserRegistration()
        {
            Assert.AreEqual(1, _dataContext.Users.Count);
            Assert.AreEqual("John Doe", _dataContext.Users[0].UserName);
        }

        [TestMethod]
        public void TestCatalogItemAddition()
        {
            Assert.AreEqual(1, _dataContext.Catalog.Count);
            Assert.AreEqual("Book", _dataContext.Catalog[0].Description);
        }

        [TestMethod]
        public void TestProcessStateUpdate()
        {
            Assert.AreEqual(1, _dataContext.ProcessStates.Count);
            Assert.AreEqual("Available", _dataContext.ProcessStates[0].Description);
        }

        [TestMethod]
        public void TestEventRegistration()
        {
            _businessLogic.RegisterEvent(1, "Item added to catalog", 1, 1);
            Assert.AreEqual(1, _dataContext.Events.Count);
            Assert.AreEqual("Item added to catalog", _dataContext.Events[0].Description);
        }
    }
}