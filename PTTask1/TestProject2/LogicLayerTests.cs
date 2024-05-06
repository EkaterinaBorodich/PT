using BusinessProcessLibrary.Logic;

namespace BusinessProcessLibrary.Tests.Logic
{
    [TestClass]
    public class BusinessLogicTests
    {
        [TestMethod]
        public void RegisterUser_AddsUserToDataRepository()
        {
            // Arrange
            IMockDataRepository dataRepository = new MockDataRepository(); // Using MockDataRepository instead of DataRepository
            IBusinessLogic businessLogic = new BusinessLogic(dataRepository);
            int userId = 1;
            string userName = "John Doe";

            // Act
            businessLogic.RegisterUser(userId, userName);

            // Assert
            IMockUser user = dataRepository.GetUser(userId);
            Assert.IsNotNull(user);
            Assert.AreEqual(userId, user.UserId);
            Assert.AreEqual(userName, user.UserName);
        }

        [TestMethod]
        public void AddCatalogItem_AddsItemToDataRepository()
        {
            // Arrange
            IMockDataRepository dataRepository = new MockDataRepository(); // Using MockDataRepository instead of DataRepository
            IBusinessLogic businessLogic = new BusinessLogic(dataRepository);
            int itemId = 1;
            string description = "Sample Item";

            // Act
            businessLogic.AddCatalogItem(itemId, description);

            // Assert
            IMockCatalogItem item = dataRepository.GetCatalogItem(itemId);
            Assert.IsNotNull(item);
            Assert.AreEqual(itemId, item.ItemId);
            Assert.AreEqual(description, item.Description);
        }

        [TestMethod]
        public void UpdateProcessState_UpdatesStateInDataRepository()
        {
            // Arrange
            IMockDataRepository dataRepository = new MockDataRepository(); // Using MockDataRepository instead of DataRepository
            IBusinessLogic businessLogic = new BusinessLogic(dataRepository);
            int stateId = 1;
            string description = "New Process State";

            // Act
            businessLogic.UpdateProcessState(stateId, description);

            // Assert
            IMockProcessState state = dataRepository.GetProcessState(stateId);
            Assert.IsNotNull(state);
            Assert.AreEqual(stateId, state.StateId);
            Assert.AreEqual(description, state.Description);
        }

        [TestMethod]
        public void RentEvent_AddsRentEventToDataRepository()
        {
            // Arrange
            IMockDataRepository dataRepository = new MockDataRepository(); // Using MockDataRepository instead of DataRepository
            IBusinessLogic businessLogic = new BusinessLogic(dataRepository);
            int eventId = 1;
            string description = "Renting Event";
            int stateId = 1;
            int userId = 1;

            // Act
            businessLogic.RentEvent(eventId, description, stateId, userId);

            // Assert
            IMockEvent @event = dataRepository.GetEvent(eventId);
            Assert.IsNotNull(@event);
            Assert.AreEqual(eventId, @event.EventId);
            Assert.AreEqual(description, @event.Description);
            Assert.AreEqual(stateId, @event.StateId);
            Assert.AreEqual(userId, @event.UserId);
            Assert.AreEqual(EventType.Rent, @event.Type);
        }

        [TestMethod]
        public void ReturnEvent_AddsReturnEventToDataRepository()
        {
            // Arrange
            IMockDataRepository dataRepository = new MockDataRepository(); // Using MockDataRepository instead of DataRepository
            IBusinessLogic businessLogic = new BusinessLogic(dataRepository);
            int eventId = 2;
            string description = "Returning Event";
            int stateId = 1;
            int userId = 1;

            // Act
            businessLogic.ReturnEvent(eventId, description, stateId, userId);

            // Assert
            IMockEvent @event = dataRepository.GetEvent(eventId);
            Assert.IsNotNull(@event);
            Assert.AreEqual(eventId, @event.EventId);
            Assert.AreEqual(description, @event.Description);
            Assert.AreEqual(stateId, @event.StateId);
            Assert.AreEqual(userId, @event.UserId);
            Assert.AreEqual(EventType.Return, @event.Type);
        }
    }
}