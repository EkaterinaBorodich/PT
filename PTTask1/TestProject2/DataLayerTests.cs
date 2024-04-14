using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessProcessLibrary;

namespace BusinessProcessLibraryTests
{
    [TestClass]
    public class DataLayerTests
    {
        private IDataRepository _dataRepository;

        [TestInitialize]
        public void Setup()
        {
            _dataRepository = new DataRepository();
        }

        [TestMethod]
        public void TestUserRegistration()
        {
            _dataRepository.AddUser(new User { UserId = 1, UserName = "John Doe" });
            Assert.AreEqual(1, (_dataRepository as DataRepository).GetUsers().Count);
        }

        [TestMethod]
        public void TestCatalogItemAddition()
        {
            _dataRepository.AddCatalogItem(new CatalogItem { ItemId = 1, Description = "Book" });
            Assert.AreEqual(1, (_dataRepository as DataRepository).GetCatalogItems().Count);
        }

        [TestMethod]
        public void TestProcessStateUpdate()
        {
            _dataRepository.AddProcessState(new ProcessState { StateId = 1, Description = "Available" });
            Assert.AreEqual(1, (_dataRepository as DataRepository).GetProcessStates().Count);
        }

        [TestMethod]
        public void TestEventRegistration()
        {
            _dataRepository.AddEvent(new Event { EventId = 1, Description = "Item added to catalog", StateId = 1, UserId = 1 });
            Assert.AreEqual(1, (_dataRepository as DataRepository).GetEvents().Count);
        }
    }
}