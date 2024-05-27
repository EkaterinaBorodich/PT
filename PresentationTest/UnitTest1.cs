using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Model.API;
using Presentation.ViewModel;
using System.Threading.Tasks;

namespace Presentation.Tests.ViewModel
{
    [TestClass]
    public class CatalogItemViewModelTests
    {
        [TestClass]
        public class EventViewModelTests
        {
            private class MockEventOperations : IEventOperations
            {
                public Task AddEvent(int eventId, string description, int stateId, int userId, string type) => Task.CompletedTask;

                public Task DeleteEvent(int eventId) => Task.CompletedTask;

                public Task<IEventModel> GetEvent(int eventId) => throw new System.NotImplementedException();

                public Task UpdateEvent(int eventId, string description, int stateId, int userId, string type) => Task.CompletedTask;
            }

            private EventViewModel _viewModel;

            [TestInitialize]
            public void Setup()
            {
                _viewModel = new EventViewModel(new MockEventOperations());
            }

            private Mock<ICatalogItemOperations> _mockCatalogItemOperations;
        private CatalogItemViewModel _viewModel;

        [TestInitialize]
        public void Setup()
        {
            _mockCatalogItemOperations = new Mock<ICatalogItemOperations>();
            _viewModel = new CatalogItemViewModel(_mockCatalogItemOperations.Object);
        }

        [TestMethod]
        public async Task AddCatalogItem_ShouldCallAddCatalogItem()
        {
            _viewModel.ItemId = 1;
            _viewModel.Description = "Test Description";

            await _viewModel.AddCatalogItem();

            _mockCatalogItemOperations.Verify(x => x.AddCatalogItem(1, "Test Description"), Times.Once);
        }

        [TestMethod]
        public async Task UpdateCatalogItem_ShouldCallUpdateCatalogItem()
        {
            _viewModel.ItemId = 1;
            _viewModel.Description = "Updated Description";

            await _viewModel.UpdateCatalogItem();

            _mockCatalogItemOperations.Verify(x => x.UpdateCatalogItem(1, "Updated Description"), Times.Once);
        }

        [TestMethod]
        public async Task DeleteCatalogItem_ShouldCallDeleteCatalogItem()
        {
            _viewModel.ItemId = 1;

            await _viewModel.DeleteCatalogItem();

            _mockCatalogItemOperations.Verify(x => x.DeleteCatalogItem(1), Times.Once);
        }

        [TestMethod]
        public async Task LoadCatalogItem_ShouldSetProperties()
        {
            var mockItem = new Mock<ICatalogItemModel>();
            mockItem.SetupGet(x => x.ItemId).Returns(1);
            mockItem.SetupGet(x => x.Description).Returns("Loaded Description");

            _mockCatalogItemOperations.Setup(x => x.GetCatalogItem(1)).ReturnsAsync(mockItem.Object);

            await _viewModel.LoadCatalogItem(1);

            Assert.AreEqual(1, _viewModel.ItemId);
            Assert.AreEqual("Loaded Description", _viewModel.Description);
        }
    }
}