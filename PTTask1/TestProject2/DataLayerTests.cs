using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessProcessLibrary.Data;

namespace BusinessProcessLibrary.Tests.Data
{
    [TestClass]
    public class DataRepositoryTests
    {
        private IDataRepository _dataRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _dataRepository = new DataRepository();
        }

        [TestMethod]
        public void AddUser_AddsUserToList()
        {
            // Arrange
            var user = new User { UserId = 1, UserName = "TestUser" };

            // Act
            _dataRepository.AddUser(user);

            // Assert
            CollectionAssert.Contains(_dataRepository.GetUsers(), user);

        }

        [TestMethod]
        public void AddCatalogItem_AddsItemToList()
        {
            // Arrange
            var item = new CatalogItem { ItemId = 1, Description = "TestItem" };

            // Act
            _dataRepository.AddCatalogItem(item);

            // Assert
            CollectionAssert.Contains(_dataRepository.GetCatalogItems(), item);
        }

        [TestMethod]
        public void AddProcessState_AddsStateToList()
        {
            // Arrange
            var state = new ProcessState { StateId = 1, Description = "TestState" };

            // Act
            _dataRepository.AddProcessState(state);

            // Assert
            CollectionAssert.Contains(_dataRepository.GetProcessStates(), state);
        }

        [TestMethod]
        public void AddEvent_AddsEventToList()
        {
            // Arrange
            var @event = new Event { EventId = 1, Description = "TestEvent", StateId = 1, UserId = 1 };

            // Act
            _dataRepository.AddEvent(@event);

            // Assert
            CollectionAssert.Contains(_dataRepository.GetEvents(), @event);
        }
    }
}
