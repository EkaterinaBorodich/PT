using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessProcessLibrary.Logic;
using BusinessProcessLibrary.Data;
using BusinessProcessLibrary.Data.Implementation;

namespace BusinessProcessLibrary.Tests.Logic
{
    [TestClass]
    public class BusinessLogicTests
    {

        [TestMethod]
        public void RegisterUser_AddsUserToDataRepository()
        {
            // Arrange
            IDataRepository dataRepository = new DataRepository();
            IBusinessLogic businessLogic = new BusinessLogic(dataRepository);
            int userId = 1;
            string userName = "John Doe";

            // Act
            businessLogic.RegisterUser(userId, userName);

            // Assert
            IUser user = dataRepository.GetUser(userId);
            Assert.IsNotNull(user);
            Assert.AreEqual(userId, user.UserId);
            Assert.AreEqual(userName, user.UserName);
        }

        [TestMethod]
        public void AddCatalogItem_AddsItemToDataRepository()
        {
            // Arrange
            IDataRepository dataRepository = new DataRepository();
            IBusinessLogic businessLogic = new BusinessLogic(dataRepository);
            int itemId = 1;
            string description = "Sample Item";

            // Act
            businessLogic.AddCatalogItem(itemId, description);

            // Assert
            ICatalogItem item = dataRepository.GetCatalogItem(itemId);
            Assert.IsNotNull(item);
            Assert.AreEqual(itemId, item.ItemId);
            Assert.AreEqual(description, item.Description);
        }

        [TestMethod]
        public void UpdateProcessState_UpdatesStateInDataRepository()
        {
            // Arrange
            IDataRepository dataRepository = new DataRepository();
            IBusinessLogic businessLogic = new BusinessLogic(dataRepository);
            int stateId = 1;
            string description = "New Process State";

            // Act
            businessLogic.UpdateProcessState(stateId, description);

            // Assert
            IProcessState state = dataRepository.GetProcessState(stateId);
            Assert.IsNotNull(state);
            Assert.AreEqual(stateId, state.StateId);
            Assert.AreEqual(description, state.Description);
        }

        [TestMethod]
        public void RentEvent_AddsRentEventToDataRepository()
        {
            // Arrange
            IDataRepository dataRepository = new DataRepository();
            IBusinessLogic businessLogic = new BusinessLogic(dataRepository);
            int eventId = 1;
            string description = "Renting Event";
            int stateId = 1;
            int userId = 1;

            // Act
            businessLogic.RentEvent(eventId, description, stateId, userId);

            // Assert
            IEvent @event = dataRepository.GetEvent(eventId);
            Assert.IsNotNull(@event);
            Assert.AreEqual(eventId, @event.EventId);
            Assert.AreEqual(description, @event.Description);
            Assert.AreEqual(stateId, @event.StateId);
            Assert.AreEqual(userId, @event.UserId);
            Assert.AreEqual(IDataRepository.EventType.Rent, @event.Type);
        }

        [TestMethod]
        public void ReturnEvent_AddsReturnEventToDataRepository()
        {
            // Arrange
            IDataRepository dataRepository = new DataRepository();
            IBusinessLogic businessLogic = new BusinessLogic(dataRepository);
            int eventId = 2;
            string description = "Returning Event";
            int stateId = 1;
            int userId = 1;

            // Act
            businessLogic.ReturnEvent(eventId, description, stateId, userId);

            // Assert
            IEvent @event = dataRepository.GetEvent(eventId);
            Assert.IsNotNull(@event);
            Assert.AreEqual(eventId, @event.EventId);
            Assert.AreEqual(description, @event.Description);
            Assert.AreEqual(stateId, @event.StateId);
            Assert.AreEqual(userId, @event.UserId);
            Assert.AreEqual(IDataRepository.EventType.Return, @event.Type);
        }
    }
}