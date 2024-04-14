using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessProcessLibrary;
using System;

namespace BusinessProcessLibraryTests
{
    [TestClass]
    public class BusinessLogicTests
    {
        private IDataRepository _dataRepository;
        private BusinessLogic _businessLogic;

        [TestInitialize]
        public void Setup()
        {
            // Initialize mock IDataRepository and BusinessLogic
            _dataRepository = new MockDataRepository();
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
            Assert.AreEqual(1, (_dataRepository as MockDataRepository).Users.Count);
            Assert.AreEqual("John Doe", (_dataRepository as MockDataRepository).Users[0].UserName);
        }

        [TestMethod]
        public void TestCatalogItemAddition()
        {
            Assert.AreEqual(1, (_dataRepository as MockDataRepository).Catalog.Count);
            Assert.AreEqual("Book", (_dataRepository as MockDataRepository).Catalog[0].Description);
        }

        [TestMethod]
        public void TestProcessStateUpdate()
        {
            Assert.AreEqual(1, (_dataRepository as MockDataRepository).ProcessStates.Count);
            Assert.AreEqual("Available", (_dataRepository as MockDataRepository).ProcessStates[0].Description);
        }

        [TestMethod]
        public void TestEventRegistration()
        {
            _businessLogic.RegisterEvent(1, "Item added to catalog", 1, 1);
            Assert.AreEqual(1, (_dataRepository as MockDataRepository).Events.Count);
            Assert.AreEqual("Item added to catalog", (_dataRepository as MockDataRepository).Events[0].Description);
        }
    }

    // Mock implementation of IDataRepository for testing
    public class MockDataRepository : IDataRepository
    {
        public List<User> Users { get; } = new List<User>();
        public List<CatalogItem> Catalog { get; } = new List<CatalogItem>();
        public List<ProcessState> ProcessStates { get; } = new List<ProcessState>();
        public List<Event> Events { get; } = new List<Event>();

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void AddCatalogItem(CatalogItem item)
        {
            Catalog.Add(item);
        }

        public void AddProcessState(ProcessState state)
        {
            ProcessStates.Add(state);
        }

        public void AddEvent(Event @event)
        {
            Events.Add(@event);
        }
    }
}