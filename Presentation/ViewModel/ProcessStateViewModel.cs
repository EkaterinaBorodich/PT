using Data.Database;
using Presentation.Model.API;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class ProcessStateViewModel : INotifyPropertyChanged
    {
        private IProcessStateOperations _processStateOperations;

        public ProcessStateViewModel()
        {
            _processStateOperations = IProcessStateOperations.CreateModelOperation();
            ProcessStates = new ObservableCollection<IProcessStateModel>();
            AddProcessStateCommand = new RelayCommand(async () => await AddProcessState());
            UpdateProcessStateCommand = new RelayCommand(async () => await UpdateProcessState());
            DeleteProcessStateCommand = new RelayCommand(async () => await DeleteProcessState());
            LoadProcessStatesCommand = new RelayCommand(async () => await LoadProcessStates());
            LoadProcessStatesCommand.Execute(null);
        }

        private int _stateId;
        public int StateId
        {
            get { return _stateId; }
            set { _stateId = value; OnPropertyChanged(); }
        }

        private string _description;
        public string ProcessStateDescription
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        }

        private IProcessStateModel _selectedProcessState;
        public IProcessStateModel SelectedProcessState
        {
            get { return _selectedProcessState; }
            set
            {
                _selectedProcessState = value;
                if (_selectedProcessState != null)
                {
                    StateId = _selectedProcessState.stateId;
                    ProcessStateDescription = _selectedProcessState.description;
                }
                OnPropertyChanged();
            }
        }

        public ObservableCollection<IProcessStateModel> ProcessStates { get; }

        public ICommand AddProcessStateCommand { get; }
        public ICommand UpdateProcessStateCommand { get; }
        public ICommand DeleteProcessStateCommand { get; }
        public ICommand LoadProcessStatesCommand { get; }

        public async Task AddProcessState()
        {
            await _processStateOperations.AddProcessState(StateId, ProcessStateDescription);
            await LoadProcessStates();
        }

        public async Task UpdateProcessState()
        {
            await _processStateOperations.UpdateProcessState(StateId, ProcessStateDescription);
            await LoadProcessStates();
        }

        public async Task DeleteProcessState()
        {
            await _processStateOperations.DeleteProcessState(StateId);
            await LoadProcessStates();
        }

        public async Task LoadProcessStates()
        {
            var processStatesDictionary = await _processStateOperations.GetAllProcessStates();

            ProcessStates.Clear();

            foreach (var catalogItem in processStatesDictionary.Values)
            {
                ProcessStates.Add(catalogItem);
            }
        }

        internal void SetOperations(IProcessStateOperations processStateOperations)
        {
            _processStateOperations = processStateOperations;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}