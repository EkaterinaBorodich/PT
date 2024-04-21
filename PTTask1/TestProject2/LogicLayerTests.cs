using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessProcessLibrary.Data;
using BusinessProcessLibrary.Logic;
using System.Collections.Generic;

namespace BusinessProcessLibrary.Tests.Logic
{
    public class MockDataRepository : IDataRepository
    {
        private readonly List<User> _users = new List<User>();
        private readonly List<CatalogItem> _catalog = new List<CatalogItem>();
        private readonly List<ProcessState> _processStates = new List<ProcessState>();
        private readonly List<Event> _events = new List<Event>();

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void AddCatalogItem(CatalogItem item)
        {
            _catalog.Add(item);
        }

        public void AddProcessState(ProcessState state)
        {
            _processStates.Add(state);
        }

        public void AddEvent(Event @event)
        {
            _events.Add(@event);
        }

        // Methods for accessing added entities for testing
        public List<User> GetUsers() => _users;
        public List<CatalogItem> GetCatalogItems() => _catalog;
        public List<ProcessState> GetProcessStates() => _processStates;
        public List<Event> GetEvents() => _events;
    }

    [TestClass]
    public class BusinessLogicTests
    {
        private BusinessLogic _businessLogic;
        private MockDataRepository _mockDataRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockDataRepository = new MockDataRepository();
            _businessLogic = new BusinessLogic(_mockDataRepository);
        }

        [TestMethod]
        public void RegisterUser_AddsUserToDataRepository()
        {
            // Arrange
            int userId = 1;
            string userName = "TestUser";

            // Act
            _businessLogic.RegisterUser(userId, userName);

            // Assert
            var addedUser = _mockDataRepository.GetUsers().FirstOrDefault(u => u.UserId == userId && u.UserName == userName);
            Assert.IsNotNull(addedUser);
        }

        [TestMethod]
        public void AddCatalogItem_AddsItemToDataRepository()
        {
            // Arrange
            int itemId = 1;
            string description = "TestItem";

            // Act
            _businessLogic.AddCatalogItem(itemId, description);

            // Assert
            var addedItem = _mockDataRepository.GetCatalogItems().FirstOrDefault(item => item.ItemId == itemId && item.Description == description);
            Assert.IsNotNull(addedItem);
        }

        [TestMethod]
        public void UpdateProcessState_AddsStateToDataRepository()
        {
            // Arrange
            int stateId = 1;
            string description = "TestState";

            // Act
            _businessLogic.UpdateProcessState(stateId, description);

            // Assert
            var addedState = _mockDataRepository.GetProcessStates().FirstOrDefault(state => state.StateId == stateId && state.Description == description);
            Assert.IsNotNull(addedState);
        }

        [TestMethod]
        public void RegisterEvent_AddsEventToDataRepository()
        {
            // Arrange
            int eventId = 1;
            string description = "TestEvent";
            int stateId = 1;
            int userId = 1;

            // Act
            _businessLogic.RegisterEvent(eventId, description, stateId, userId);

            // Assert
            var addedEvent = _mockDataRepository.GetEvents().FirstOrDefault(ev => ev.EventId == eventId && ev.Description == description && ev.StateId == stateId && ev.UserId == userId);
            Assert.IsNotNull(addedEvent);
        }
    }
}