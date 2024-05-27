using Presentation.Model.API;
using Presentation.Model.Implementation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class EventViewModel : INotifyPropertyChanged
    {
        private IEventOperations _eventOperations;

        public EventViewModel()
        {
            _eventOperations = IEventOperations.CreateModelOperation(); // Correctly initialize the private field
            Events = new ObservableCollection<IEventModel>();
            AddEventCommand = new RelayCommand(async () => await AddEvent());
            UpdateEventCommand = new RelayCommand(async () => await UpdateEvent());
            DeleteEventCommand = new RelayCommand(async () => await DeleteEvent());
            LoadEventsCommand = new RelayCommand(async () => await LoadEvents());
            LoadEventsCommand.Execute(null); // Load events initially
        }

        private int _eventId;
        public int EventId
        {
            get { return _eventId; }
            set { _eventId = value; OnPropertyChanged(); }
        }

        private string _description;
        public string EventDescription
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        }

        private int _stateId;
        public int StateId
        {
            get { return _stateId; }
            set { _stateId = value; OnPropertyChanged(); }
        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; OnPropertyChanged(); }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged(); }
        }

        private IEventModel _selectedEvent;
        public IEventModel SelectedEvent
        {
            get { return _selectedEvent; }
            set
            {
                _selectedEvent = value;
                if (_selectedEvent != null)
                {
                    EventId = _selectedEvent.eventId;
                    EventDescription = _selectedEvent.description;
                    StateId = _selectedEvent.stateId;
                    UserId = _selectedEvent.userId;
                    Type = _selectedEvent.Type;
                }
                OnPropertyChanged();
            }
        }

        public ObservableCollection<IEventModel> Events { get; }

        public ICommand AddEventCommand { get; }
        public ICommand UpdateEventCommand { get; }
        public ICommand DeleteEventCommand { get; }
        public ICommand LoadEventsCommand { get; }

        public async Task AddEvent()
        {
            await _eventOperations.AddEvent(EventId, EventDescription, StateId, UserId, Type);
            await LoadEvents();
        }

        public async Task UpdateEvent()
        {
            await _eventOperations.UpdateEvent(EventId, EventDescription, StateId, UserId, Type);
            await LoadEvents();
        }

        public async Task DeleteEvent()
        {
            await _eventOperations.DeleteEvent(EventId);
            await LoadEvents();
        }

        public async Task LoadEvents()
        {
            var events = await _eventOperations.GetAllEvents();

            Events.Clear();

            foreach (var ev in events.Values)
            {
                Events.Add(ev);
            }
        }

        internal void SetOperations(IEventOperations eventOperations)
        {
            _eventOperations = eventOperations;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
