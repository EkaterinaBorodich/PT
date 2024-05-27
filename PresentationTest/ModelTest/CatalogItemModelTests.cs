using Presentation.Model.Implementation;

namespace Presentation.Tests
{
    [TestClass]
    public class CatalogItemModelTests
    {
        [TestMethod]
        public void CatalogItemModel_ShouldSetProperties()
        {
            // Arrange
            var itemId = 1;
            var description = "Test Description";

            // Act
            var model = new CatalogItemModel(itemId, description);

            // Assert
            Assert.AreEqual(itemId, model.ItemId);
            Assert.AreEqual(description, model.Description);
        }
    }
}