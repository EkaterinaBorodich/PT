using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Model.API;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class ProcessStateViewModel : INotifyPropertyChanged
    {
        private readonly IProcessStateOperations _processStateOperations;

        private int _stateId;
        private string _description;

        public int StateId
        {
            get => _stateId;
            set
            {
                _stateId = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddProcessStateCommand { get; }
        public ICommand UpdateProcessStateCommand { get; }
        public ICommand DeleteProcessStateCommand { get; }
        public ICommand LoadProcessStateCommand { get; }

        public ProcessStateViewModel(IProcessStateOperations processStateOperations)
        {
            _processStateOperations = processStateOperations;
            AddProcessStateCommand = new RelayCommand(async () => await AddProcessState());
            UpdateProcessStateCommand = new RelayCommand(async () => await UpdateProcessState());
            DeleteProcessStateCommand = new RelayCommand(async () => await DeleteProcessState());
            LoadProcessStateCommand = new RelayCommand<int>(async (stateId) => await LoadProcessState(stateId));
        }

        public async Task AddProcessState()
        {
            await _processStateOperations.AddProcessState(StateId, Description);
        }

        public async Task UpdateProcessState()
        {
            await _processStateOperations.UpdateProcessState(StateId, Description);
        }

        public async Task DeleteProcessState()
        {
            await _processStateOperations.DeleteProcessState(StateId);
        }

        public async Task LoadProcessState(int stateId)
        {
            var state = await _processStateOperations.GetProcessState(stateId);
            StateId = state.stateId;
            Description = state.description;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}