using Moq;
using Presentation.Model.API;
using Presentation.Model.Implementation;

namespace Presentation.ViewModel.Tests
{
    [TestClass]
    public class ProcessStateViewModelTests
    {
        private Mock<IProcessStateOperations> _mockProcessStateOperations;
        private ProcessStateViewModel _viewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockProcessStateOperations = new Mock<IProcessStateOperations>();
            _viewModel = new ProcessStateViewModel();
            _viewModel.SetOperations(_mockProcessStateOperations.Object);
        }

        [TestMethod]
        public async Task LoadProcessStatesCommand_ShouldLoadProcessStates()
        {
            // Arrange
            var states = new Dictionary<int, IProcessStateModel>
            {
                { 1, new ProcessStateModel(1, "State 1") },
                { 2, new ProcessStateModel(2, "State 2") }
            };
            _mockProcessStateOperations.Setup(op => op.GetAllProcessStates()).ReturnsAsync(states);

            // Act
            await _viewModel.LoadProcessStates();

            // Assert
            Assert.AreEqual(2, _viewModel.ProcessStates.Count);
            Assert.AreEqual("State 1", _viewModel.ProcessStates[0].description);
            Assert.AreEqual("State 2", _viewModel.ProcessStates[1].description);
        }

        [TestMethod]
        public async Task AddProcessStateCommand_ShouldAddProcessState()
        {
            // Arrange
            var states = new Dictionary<int, IProcessStateModel>
            {
                { 1, new ProcessStateModel(1, "State 1") },
                { 2, new ProcessStateModel(2, "State 2") }
            };
            _mockProcessStateOperations.Setup(op => op.GetAllProcessStates()).ReturnsAsync(states);
            _viewModel.StateId = 3;
            _viewModel.ProcessStateDescription = "New State";

            // Act
            await _viewModel.AddProcessState();

            // Assert
            _mockProcessStateOperations.Verify(op => op.AddProcessState(3, "New State"), Times.Once);
            _mockProcessStateOperations.Verify(op => op.GetAllProcessStates(), Times.AtLeastOnce);
        }

        [TestMethod]
        public async Task UpdateProcessStateCommand_ShouldUpdateProcessState()
        {
            // Arrange
            var states = new Dictionary<int, IProcessStateModel>
            {
                { 1, new ProcessStateModel(1, "State 1") },
                { 2, new ProcessStateModel(2, "State 2") }
            };
            _mockProcessStateOperations.Setup(op => op.GetAllProcessStates()).ReturnsAsync(states);
            _viewModel.StateId = 1;
            _viewModel.ProcessStateDescription = "Updated State";

            // Act
            await _viewModel.UpdateProcessState();

            // Assert
            _mockProcessStateOperations.Verify(op => op.UpdateProcessState(1, "Updated State"), Times.Once);
            _mockProcessStateOperations.Verify(op => op.GetAllProcessStates(), Times.AtLeastOnce);
        }

        [TestMethod]
        public async Task DeleteProcessStateCommand_ShouldDeleteProcessState()
        {
            // Arrange
            var states = new Dictionary<int, IProcessStateModel>
            {
                { 1, new ProcessStateModel(1, "State 1") },
                { 2, new ProcessStateModel(2, "State 2") }
            };
            _mockProcessStateOperations.Setup(op => op.GetAllProcessStates()).ReturnsAsync(states);
            _viewModel.StateId = 1;

            // Act
            await _viewModel.DeleteProcessState();

            // Assert
            _mockProcessStateOperations.Verify(op => op.DeleteProcessState(1), Times.Once);
            _mockProcessStateOperations.Verify(op => op.GetAllProcessStates(), Times.AtLeastOnce);
        }
    }
}