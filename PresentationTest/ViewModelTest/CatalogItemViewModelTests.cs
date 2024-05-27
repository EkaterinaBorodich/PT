using Moq;
using Presentation.Model.API;
using Presentation.Model.Implementation;

namespace Presentation.ViewModel.Tests
{
    [TestClass]
    public class CatalogItemViewModelTests
    {
        private CatalogItemViewModel _viewModel;
        private Mock<ICatalogItemOperations> _mockCatalogItemOperations;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockCatalogItemOperations = new Mock<ICatalogItemOperations>();
            _viewModel = new CatalogItemViewModel();
            _viewModel.SetOperations(_mockCatalogItemOperations.Object);
        }

        [TestMethod]
        public async Task LoadCatalogItemsCommand_ShouldLoadItems()
        {
            // Arrange
            var items = new Dictionary<int, ICatalogItemModel>
            {
                { 1, new CatalogItemModel(1, "Item 1") },
                { 2, new CatalogItemModel(2, "Item 2") }
            };
            _mockCatalogItemOperations.Setup(op => op.GetAllCatalogItems()).ReturnsAsync(items);

            // Act
            await _viewModel.LoadCatalogItems();

            // Assert
            Assert.AreEqual(2, _viewModel.CatalogItems.Count);
            Assert.AreEqual("Item 1", _viewModel.CatalogItems[0].Description);
            Assert.AreEqual("Item 2", _viewModel.CatalogItems[1].Description);
        }

        [TestMethod]
        public async Task AddCatalogItemCommand_ShouldAddItem()
        {
            // Arrange
            var items = new Dictionary<int, ICatalogItemModel>
            {
                { 1, new CatalogItemModel(1, "Item 1") },
                { 2, new CatalogItemModel(2, "Item 2") }
            };
            _mockCatalogItemOperations.Setup(op => op.GetAllCatalogItems()).ReturnsAsync(items);
            _viewModel.ItemId = 3;
            _viewModel.Description = "New Item";

            // Act
            await _viewModel.AddCatalogItem();

            // Assert
            _mockCatalogItemOperations.Verify(op => op.AddCatalogItem(3, "New Item"), Times.Once);
            _mockCatalogItemOperations.Verify(op => op.GetAllCatalogItems(), Times.AtLeastOnce);
        }

        [TestMethod]
        public async Task UpdateCatalogItemCommand_ShouldUpdateItem()
        {
            // Arrange
            var items = new Dictionary<int, ICatalogItemModel>
            {
                { 1, new CatalogItemModel(1, "Item 1") },
                { 2, new CatalogItemModel(2, "Item 2") }
            };
            _mockCatalogItemOperations.Setup(op => op.GetAllCatalogItems()).ReturnsAsync(items);
            _viewModel.ItemId = 1;
            _viewModel.Description = "Updated Item";

            // Act
            await _viewModel.UpdateCatalogItem();

            // Assert
            _mockCatalogItemOperations.Verify(op => op.UpdateCatalogItem(1, "Updated Item"), Times.Once);
            _mockCatalogItemOperations.Verify(op => op.GetAllCatalogItems(), Times.AtLeastOnce);
        }

        [TestMethod]
        public async Task DeleteCatalogItemCommand_ShouldDeleteItem()
        {
            // Arrange
            var items = new Dictionary<int, ICatalogItemModel>
            {
                { 1, new CatalogItemModel(1, "Item 1") },
                { 2, new CatalogItemModel(2, "Item 2") }
            };
            _mockCatalogItemOperations.Setup(op => op.GetAllCatalogItems()).ReturnsAsync(items);
            _viewModel.ItemId = 1;

            // Act
            await _viewModel.DeleteCatalogItem();

            // Assert
            _mockCatalogItemOperations.Verify(op => op.DeleteCatalogItem(1), Times.Once);
            _mockCatalogItemOperations.Verify(op => op.GetAllCatalogItems(), Times.AtLeastOnce);
        }
    }
    
}