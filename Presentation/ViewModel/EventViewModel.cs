using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentation.Model.API;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class EventViewModel : INotifyPropertyChanged
    {
        private readonly IEventOperations _eventOperations;

        private int _eventId;
        private string _description;
        private int _stateId;
        private int _userId;
        private string _type;

        public int EventId
        {
            get => _eventId;
            set
            {
                _eventId = value;
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

        public int StateId
        {
            get => _stateId;
            set
            {
                _stateId = value;
                OnPropertyChanged();
            }
        }

        public int UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                OnPropertyChanged();
            }
        }

        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddEventCommand { get; }
        public ICommand UpdateEventCommand { get; }
        public ICommand DeleteEventCommand { get; }
        public ICommand LoadEventCommand { get; }

        public EventViewModel(IEventOperations eventOperations)
        {
            _eventOperations = eventOperations;
            AddEventCommand = new RelayCommand(async () => await AddEvent());
            UpdateEventCommand = new RelayCommand(async () => await UpdateEvent());
            DeleteEventCommand = new RelayCommand(async () => await DeleteEvent());
            LoadEventCommand = new RelayCommand<int>(async (eventId) => await LoadEvent(eventId));
        }

        public async Task AddEvent()
        {
            await _eventOperations.AddEvent(EventId, Description, StateId, UserId, Type);
        }

        public async Task UpdateEvent()
        {
            await _eventOperations.UpdateEvent(EventId, Description, StateId, UserId, Type);
        }

        public async Task DeleteEvent()
        {
            await _eventOperations.DeleteEvent(EventId);
        }

        public async Task LoadEvent(int eventId)
        {
            var eventItem = await _eventOperations.GetEvent(eventId);
            EventId = eventItem.eventId;
            Description = eventItem.description;
            StateId = eventItem.stateId;
            UserId = eventItem.userId;
            Type = eventItem.Type;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
