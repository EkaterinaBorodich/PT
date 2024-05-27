using Presentation.Model.Implementation;

namespace Presentation.Tests
{
    [TestClass]
    public class EventModelTests
    {
        [TestMethod]
        public void EventModel_ShouldSetProperties()
        {
            // Arrange
            var eventId = 1;
            var description = "Test Event";
            var stateId = 1;
            var userId = 1;
            var type = "Type1";

            // Act
            var model = new EventModel(eventId, description, stateId, userId, type);

            // Assert
            Assert.AreEqual(eventId, model.eventId);
            Assert.AreEqual(description, model.description);
            Assert.AreEqual(stateId, model.stateId);
            Assert.AreEqual(userId, model.userId);
            Assert.AreEqual(type, model.Type);
        }
    }
}