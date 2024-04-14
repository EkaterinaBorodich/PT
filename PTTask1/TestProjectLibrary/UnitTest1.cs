using System;
using BusinessProcessLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProjectLibrary
{
    [TestClass]
    public class BusinessLogicTests
    {
        private IDataRepository _dataRepository;
        private LibraryLogic _libraryLogic;
        [TestInitialize]
        public void Setup()
        {
            // Initialize mock IDataRepository and LibraryLogic
            _dataRepository = new MockDataRepository();
            _libraryLogic = new LibraryLogic(_dataRepository);

            // Initialize test data
            InitializeTestData();
        }

        private void InitializeTestData()
        {
            _libraryLogic.RegisterUser(1, "John Doe");
            _libraryLogic.AddCatalogItem(1, "Book");
            _libraryLogic.UpdateProcessState(1, "Available");
        }

        [TestMethod]
        public void TestUserRegistration()
        {
            Assert.AreEqual(1, ((MockDataRepository)_dataRepository).Users.Count);
            Assert.AreEqual("John Doe", ((MockDataRepository)_dataRepository).Users[0].UserName);
        }
        [TestMethod]
        public void TestCatalogItemAddition()
        {
            Assert.AreEqual(1, ((MockDataRepository)_dataRepository).Catalog.Count);
            Assert.AreEqual("Book", ((MockDataRepository)_dataRepository).Catalog[0].Description);
        }
        [TestMethod]
        public void TestProcessStateUpdate()
        {
            Assert.AreEqual(1, ((MockDataRepository)_dataRepository).ProcessStates.Count);
            Assert.AreEqual("Available", ((MockDataRepository)_dataRepository).ProcessStates[0].Description);
        }
        [TestMethod]
        public void TestEventRegistration()
        {
            _libraryLogic.RegisterEvent(1, "Item added to catalog", 1, 1);
            Assert.AreEqual(1, ((MockDataRepository)_dataRepository).Events.Count);
            Assert.AreEqual("Item added to catalog", ((MockDataRepository)_dataRepository).Events[0].Description);
        }
    }
    public class MockDataRepository : IDataRepository
    {
        public List<User> Users { get; } = new List<User>();
        public List<Catalog> Catalog { get; } = new List<Catalog>();
        public List<ProcessState> ProcessStates { get; } = new List<ProcessState>();
        public List<Event> Events { get; } = new List<Event>();

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void AddCatalogItem(Catalog item)
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