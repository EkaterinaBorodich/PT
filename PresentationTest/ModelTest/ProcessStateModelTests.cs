using Presentation.Model.Implementation;

namespace Presentation.Tests
{
    [TestClass]
    public class ProcessStateModelTests
    {
        [TestMethod]
        public void ProcessStateModel_ShouldSetProperties()
        {
            // Arrange
            var stateId = 1;
            var description = "Test State";

            // Act
            var model = new ProcessStateModel(stateId, description);

            // Assert
            Assert.AreEqual(stateId, model.stateId);
            Assert.AreEqual(description, model.description);
        }
    }
}