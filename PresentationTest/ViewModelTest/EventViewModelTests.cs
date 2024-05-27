using Moq;
using Presentation.Model.API;
using Presentation.Model.Implementation;

namespace Presentation.ViewModel.Tests
{
    [TestClass]
    public class EventViewModelTests
    {
        private Mock<IEventOperations> _mockEventOperations;
        private EventViewModel _viewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockEventOperations = new Mock<IEventOperations>();
            _viewModel = new EventViewModel();
            _viewModel.SetOperations(_mockEventOperations.Object);
        }

        [TestMethod]
        public async Task LoadEventsCommand_ShouldLoadEvents()
        {
            // Arrange
            var events = new Dictionary<int, IEventModel>
            {
                { 1, new EventModel(1, "Event 1", 1, 1, "Type 1") },
                { 2, new EventModel(2, "Event 2", 2, 2, "Type 2") }
            };
            _mockEventOperations.Setup(op => op.GetAllEvents()).ReturnsAsync(events);

            // Act
            await _viewModel.LoadEvents();

            // Assert
            Assert.AreEqual(2, _viewModel.Events.Count);
            Assert.AreEqual("Event 1", _viewModel.Events[0].description);
            Assert.AreEqual("Event 2", _viewModel.Events[1].description);
        }

        [TestMethod]
        public async Task AddEventCommand_ShouldAddEvent()
        {
            // Arrange
            var events = new Dictionary<int, IEventModel>
            {
                { 1, new EventModel(1, "Event 1", 1, 1, "Type 1") },
                { 2, new EventModel(2, "Event 2", 2, 2, "Type 2") }
            };
            _mockEventOperations.Setup(op => op.GetAllEvents()).ReturnsAsync(events);
            _viewModel.EventId = 3;
            _viewModel.EventDescription = "New Event";
            _viewModel.StateId = 1;
            _viewModel.UserId = 1;
            _viewModel.Type = "Type";

            // Act
            await _viewModel.AddEvent();

            // Assert
            _mockEventOperations.Verify(op => op.AddEvent(3, "New Event", 1, 1, "Type"), Times.Once);
            _mockEventOperations.Verify(op => op.GetAllEvents(), Times.AtLeastOnce);
        }

        [TestMethod]
        public async Task UpdateEventCommand_ShouldUpdateEvent()
        {
            // Arrange
            var events = new Dictionary<int, IEventModel>
            {
                { 1, new EventModel(1, "Event 1", 1, 1, "Type 1") },
                { 2, new EventModel(2, "Event 2", 2, 2, "Type 2") }
            };
            _mockEventOperations.Setup(op => op.GetAllEvents()).ReturnsAsync(events);
            _viewModel.EventId = 1;
            _viewModel.EventDescription = "Updated Event";
            _viewModel.StateId = 1;
            _viewModel.UserId = 1;
            _viewModel.Type = "Updated Type";

            // Act
            await _viewModel.UpdateEvent();

            // Assert
            _mockEventOperations.Verify(op => op.UpdateEvent(1, "Updated Event", 1, 1, "Updated Type"), Times.Once);
            _mockEventOperations.Verify(op => op.GetAllEvents(), Times.AtLeastOnce);
        }

        [TestMethod]
        public async Task DeleteEventCommand_ShouldDeleteEvent()
        {
            // Arrange
            var events = new Dictionary<int, IEventModel>
            {
                { 1, new EventModel(1, "Event 1", 1, 1, "Type 1") },
                { 2, new EventModel(2, "Event 2", 2, 2, "Type 2") }
            };
            _mockEventOperations.Setup(op => op.GetAllEvents()).ReturnsAsync(events);
            _viewModel.EventId = 1;

            // Act
            await _viewModel.DeleteEvent();

            // Assert
            _mockEventOperations.Verify(op => op.DeleteEvent(1), Times.Once);
            _mockEventOperations.Verify(op => op.GetAllEvents(), Times.AtLeastOnce);
        }
    }
}