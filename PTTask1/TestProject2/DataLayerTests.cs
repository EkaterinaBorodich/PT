using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessProcessLibrary.Data;
using System.Reflection;

namespace BusinessProcessLibrary.Tests.Data
{
    [TestClass]
    public class DataLayerTests
    {
        [TestMethod]
        public void AddUser_ValidUser_UserAddedToList()
        {
            // Arrange
            var dataRepository = IDataRepository.CreateDataRepository();
            int userId = 1;
            string userName = "John Doe";

            // Act
            dataRepository.AddUser(userId, userName);

            // Assert
            IUser user = dataRepository.GetUser(userId);
            Assert.IsNotNull(user);
            Assert.AreEqual(userId, user.UserId);
            Assert.AreEqual(userName, user.UserName);
        }

        [TestMethod]
        public void AddCatalogItem_ValidItem_ItemAddedToList()
        {
            // Arrange
            var dataRepository = IDataRepository.CreateDataRepository();
            int itemId = 1;
            string description = "Example Item";

            // Act
            dataRepository.AddCatalogItem(itemId, description);

            // Assert
            ICatalogItem item = dataRepository.GetCatalogItem(itemId);
            Assert.IsNotNull(item);
            Assert.AreEqual(itemId, item.ItemId);
            Assert.AreEqual(description, item.Description);
        }

        [TestMethod]
        public void AddProcessState_ValidState_StateAddedToList()
        {
            // Arrange
            var dataRepository = IDataRepository.CreateDataRepository();
            int stateId = 1;
            string description = "Example State";

            // Act
            dataRepository.AddProcessState(stateId, description);

            // Assert
            IProcessState state = dataRepository.GetProcessState(stateId);
            Assert.IsNotNull(state);
            Assert.AreEqual(stateId, state.StateId);
            Assert.AreEqual(description, state.Description);
        }

        [TestMethod]
        public void AddEvent_ValidEvent_EventAddedToList()
        {
            // Arrange
            var dataRepository = IDataRepository.CreateDataRepository();
            int eventId = 1;
            string description = "Example Event";
            int stateId = 1;
            int userId = 1;
            IDataRepository.EventType type = IDataRepository.EventType.Rent;

            // Act
            dataRepository.AddEvent(eventId, description, stateId, userId, type);

            // Assert
            IEvent @event = dataRepository.GetEvent(eventId);
            Assert.IsNotNull(@event);
            Assert.AreEqual(eventId, @event.EventId);
            Assert.AreEqual(description, @event.Description);
            Assert.AreEqual(stateId, @event.StateId);
            Assert.AreEqual(userId, @event.UserId);
            Assert.AreEqual(type, @event.Type);
        }

        [TestMethod]
        public void RemoveUser_ExistingUser_UserRemovedFromList()
        {
            // Arrange
            var dataRepository = IDataRepository.CreateDataRepository();
            int userId = 1;
            string userName = "John Doe";
            dataRepository.AddUser(userId, userName);

            // Act
            dataRepository.RemoveUser(userId);

            // Assert
            IUser user = dataRepository.GetUser(userId);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void RemoveCatalogItem_ExistingItem_ItemRemovedFromList()
        {
            // Arrange
            var dataRepository = IDataRepository.CreateDataRepository();
            int itemId = 1;
            string description = "Example Item";
            dataRepository.AddCatalogItem(itemId, description);

            // Act
            dataRepository.RemoveCatalogItem(itemId);

            // Assert
            ICatalogItem item = dataRepository.GetCatalogItem(itemId);
            Assert.IsNull(item);
        }

        [TestMethod]
        public void RemoveProcessState_ExistingState_StateRemovedFromList()
        {
            // Arrange
            var dataRepository = IDataRepository.CreateDataRepository();
            int stateId = 1;
            string description = "Example State";
            dataRepository.AddProcessState(stateId, description);

            // Act
            dataRepository.RemoveProcessState(stateId);

            // Assert
            IProcessState state = dataRepository.GetProcessState(stateId);
            Assert.IsNull(state);
        }

        [TestMethod]
        public void RemoveEvent_ExistingEvent_EventRemovedFromList()
        {
            // Arrange
            var dataRepository = IDataRepository.CreateDataRepository();
            int eventId = 1;
            string description = "Example Event";
            int stateId = 1;
            int userId = 1;
            IDataRepository.EventType type = IDataRepository.EventType.Rent;
            dataRepository.AddEvent(eventId, description, stateId, userId, type);

            // Act
            dataRepository.RemoveEvent(eventId);

            // Assert
            IEvent @event = dataRepository.GetEvent(eventId);
            Assert.IsNull(@event);
        }

        [TestMethod]
        public void GetUser_NonExistentUser_ReturnsNull()
        {
            // Arrange
            var dataRepository = IDataRepository.CreateDataRepository();
            int userId = 999; // Assuming this user does not exist

            // Act
            IUser user = dataRepository.GetUser(userId);

            // Assert
            Assert.IsNull(user);
        }

        [TestMethod]
        public void GetCatalogItem_NonExistentItem_ReturnsNull()
        {
            // Arrange
            var dataRepository = IDataRepository.CreateDataRepository();
            int itemId = 999; // Assuming this item does not exist

            // Act
            ICatalogItem item = dataRepository.GetCatalogItem(itemId);

            // Assert
            Assert.IsNull(item);
        }

        [TestMethod]
        public void GetProcessState_NonExistentState_ReturnsNull()
        {
            // Arrange
            var dataRepository = IDataRepository.CreateDataRepository();
            int stateId = 999; // Assuming this state does not exist

            // Act
            IProcessState state = dataRepository.GetProcessState(stateId);

            // Assert
            Assert.IsNull(state);
        }

        [TestMethod]
        public void GetEvent_NonExistentEvent_ReturnsNull()
        {
            // Arrange
            var dataRepository = IDataRepository.CreateDataRepository();
            int eventId = 999; // Assuming this event does not exist

            // Act
            IEvent @event = dataRepository.GetEvent(eventId);

            // Assert
            Assert.IsNull(@event);
        }
    }
}