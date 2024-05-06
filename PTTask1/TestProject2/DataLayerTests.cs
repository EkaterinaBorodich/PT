using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessProcessLibrary.Data;
using BusinessProcessLibrary.Data.Implementation;

namespace BusinessProcessLibrary.Tests.Data
{
    [TestClass]
    public class DataRepositoryTests
    {

        [TestMethod]
        public void AddUser_ValidUser_UserAddedToList()
        {
            // Arrange
            IDataRepository _dataRepository = new DataRepository(); 
            int userId = 1;
            string userName = "John Doe";

            // Act
            _dataRepository.AddUser(userId, userName);

            // Assert
            IUser user = _dataRepository.GetUser(userId);
            Assert.IsNotNull(user);
            Assert.AreEqual(userId, user.UserId);
            Assert.AreEqual(userName, user.UserName);
        }

        [TestMethod]
        public void AddCatalogItem_ValidItem_ItemAddedToList()
        {
            // Arrange
            IDataRepository _dataRepository = new DataRepository();
            int itemId = 1;
            string description = "Example Item";

            // Act
            _dataRepository.AddCatalogItem(itemId, description);

            // Assert
            ICatalogItem item = _dataRepository.GetCatalogItem(itemId);
            Assert.IsNotNull(item);
            Assert.AreEqual(itemId, item.ItemId);
            Assert.AreEqual(description, item.Description);
        }

        [TestMethod]
        public void AddProcessState_ValidState_StateAddedToList()
        {
            // Arrange
            IDataRepository _dataRepository = new DataRepository();
            int stateId = 1;
            string description = "Example State";

            // Act
            _dataRepository.AddProcessState(stateId, description);

            // Assert
            IProcessState state = _dataRepository.GetProcessState(stateId);
            Assert.IsNotNull(state);
            Assert.AreEqual(stateId, state.StateId);
            Assert.AreEqual(description, state.Description);
        }

        [TestMethod]
        public void AddEvent_ValidEvent_EventAddedToList()
        {
            // Arrange
            IDataRepository _dataRepository = new DataRepository();
            int eventId = 1;
            string description = "Example Event";
            int stateId = 1;
            int userId = 1;
            IDataRepository.EventType type = IDataRepository.EventType.Rent;

            // Act
            _dataRepository.AddEvent(eventId, description, stateId, userId, type);

            // Assert
            IEvent @event = _dataRepository.GetEvent(eventId);
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
            IDataRepository _dataRepository = new DataRepository();
            int userId = 1;
            string userName = "John Doe";
            _dataRepository.AddUser(userId, userName);

            // Act
            _dataRepository.RemoveUser(userId);

            // Assert
            IUser user = _dataRepository.GetUser(userId);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void RemoveCatalogItem_ExistingItem_ItemRemovedFromList()
        {
            // Arrange
            IDataRepository _dataRepository = new DataRepository();
            int itemId = 1;
            string description = "Example Item";
            _dataRepository.AddCatalogItem(itemId, description);

            // Act
            _dataRepository.RemoveCatalogItem(itemId);

            // Assert
            ICatalogItem item = _dataRepository.GetCatalogItem(itemId);
            Assert.IsNull(item);
        }

        [TestMethod]
        public void RemoveProcessState_ExistingState_StateRemovedFromList()
        {
            // Arrange
            IDataRepository _dataRepository = new DataRepository();
            int stateId = 1;
            string description = "Example State";
            _dataRepository.AddProcessState(stateId, description);

            // Act
            _dataRepository.RemoveProcessState(stateId);

            // Assert
            IProcessState state = _dataRepository.GetProcessState(stateId);
            Assert.IsNull(state);
        }

        [TestMethod]
        public void RemoveEvent_ExistingEvent_EventRemovedFromList()
        {
            // Arrange
            IDataRepository _dataRepository = new DataRepository();
            int eventId = 1;
            string description = "Example Event";
            int stateId = 1;
            int userId = 1;
            IDataRepository.EventType type = IDataRepository.EventType.Rent;
            _dataRepository.AddEvent(eventId, description, stateId, userId, type);

            // Act
            _dataRepository.RemoveEvent(eventId);

            // Assert
            IEvent @event = _dataRepository.GetEvent(eventId);
            Assert.IsNull(@event);
        }

        [TestMethod]
        public void GetUser_NonExistentUser_ReturnsNull()
        {
            // Arrange
            IDataRepository _dataRepository = new DataRepository();
            int userId = 999; // Assuming this user does not exist

            // Act
            IUser user = _dataRepository.GetUser(userId);

            // Assert
            Assert.IsNull(user);
        }

        [TestMethod]
        public void GetCatalogItem_NonExistentItem_ReturnsNull()
        {
            // Arrange
            IDataRepository _dataRepository = new DataRepository();
            int itemId = 999; // Assuming this item does not exist

            // Act
            ICatalogItem item = _dataRepository.GetCatalogItem(itemId);

            // Assert
            Assert.IsNull(item);
        }

        [TestMethod]
        public void GetProcessState_NonExistentState_ReturnsNull()
        {
            // Arrange
            IDataRepository _dataRepository = new DataRepository();
            int stateId = 999; // Assuming this state does not exist

            // Act
            IProcessState state = _dataRepository.GetProcessState(stateId);

            // Assert
            Assert.IsNull(state);
        }

        [TestMethod]
        public void GetEvent_NonExistentEvent_ReturnsNull()
        {
            // Arrange
            IDataRepository _dataRepository = new DataRepository();
            int eventId = 999; // Assuming this event does not exist

            // Act
            IEvent @event = _dataRepository.GetEvent(eventId);

            // Assert
            Assert.IsNull(@event);
        }
    }
}