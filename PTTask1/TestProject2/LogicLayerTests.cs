using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessProcessLibrary;

namespace BusinessProcessLibraryTests
{
    [TestClass]
    public class LogicLayerTests
    {
        private IDataRepository _dataRepository;
        private BusinessLogic _businessLogic;

        [TestInitialize]
        public void Setup()
        {
            _dataRepository = new DataRepository();
            _businessLogic = new BusinessLogic(_dataRepository);

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
            Assert.AreEqual(1, (_dataRepository as DataRepository).GetUsers().Count);
            Assert.AreEqual("John Doe", (_dataRepository as DataRepository).GetUsers()[0].UserName);
        }

        [TestMethod]
        public void TestCatalogItemAddition()
        {
            Assert.AreEqual(1, (_dataRepository as DataRepository).GetCatalogItems().Count);
            Assert.AreEqual("Book", (_dataRepository as DataRepository).GetCatalogItems()[0].Description);
        }

        [TestMethod]
        public void TestProcessStateUpdate()
        {
            Assert.AreEqual(1, (_dataRepository as DataRepository).GetProcessStates().Count);
            Assert.AreEqual("Available", (_dataRepository as DataRepository).GetProcessStates()[0].Description);
        }

        [TestMethod]
        public void TestEventRegistration()
        {
            _businessLogic.RegisterEvent(1, "Item added to catalog", 1, 1);
            Assert.AreEqual(1, (_dataRepository as DataRepository).GetEvents().Count);
            Assert.AreEqual("Item added to catalog", (_dataRepository as DataRepository).GetEvents()[0].Description);
        }
    }
}
