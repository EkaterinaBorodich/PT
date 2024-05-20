using static BusinessProcessLibrary.Data.IDataRepository;
using BusinessProcessLibrary.Data;
using BusinessProcessLibrary.Data.Implementation;

namespace TestProject2
{
    public class MockDataRepository : IDataRepository
    {
        private readonly List<IUser> _users = new List<IUser>();
        private readonly List<ICatalogItem> _catalog = new List<ICatalogItem>();
        private readonly List<IProcessState> _processStates = new List<IProcessState>();
        private readonly List<IEvent> _events = new List<IEvent>();

        public void AddUser(IUser user)
        {
            _users.Add(user);
        }

        public void AddCatalogItem(int itemId, string description)
        {
            _catalog[itemId] = new MockCatalogItem(itemId, description);
        }

        public void AddProcessState(int stateId, string description)
        {
            _processStates[stateId] = new MockProcessState(stateId, description);
        }

        public void AddEvent(int eventId, string description, int stateId, int userId, EventType type)
        {
            switch (type)
            {
                case EventType.Rent:
                    _events[eventId] = new MockRentEvent(eventId, description, stateId, userId);
                    break;
                case EventType.Return:
                    _events[eventId] = new MockReturnEvent(eventId, description, stateId, userId);
                    break;
                default:
                    throw new ArgumentException("Unknown event type");
            }
        }

        public void RemoveUser(int userId)
        {
            
        }

        public void RemoveCatalogItem(int itemId)
        {
            
        }

        public void RemoveProcessState(int stateId)
        {

        }

        public void RemoveEvent(int eventId)
        {
            
        }

        public IUser? GetUser(int userId)
        {
            return _users.FirstOrDefault(u => u.UserId == userId);
        }

        public ICatalogItem? GetCatalogItem(int itemId)
        {
            return _catalog.FirstOrDefault(c => c.ItemId == itemId);
        }

        public IProcessState? GetProcessState(int stateId)
        {
            return _processStates.FirstOrDefault(p => p.StateId == stateId);
        }

        public IEvent? GetEvent(int eventId)
        {
            return _events.FirstOrDefault(e => e.EventId == eventId);
        }

        private class MockCatalogItem : ICatalogItem
        {
            public int ItemId { get; }
            public string Description { get; set; }

            public MockCatalogItem(int itemId, string description)
            {
                ItemId = itemId;
                Description = description;
            }
        }

        private class MockProcessState : IProcessState
        {
            public int StateId { get; }
            public string Description { get; set; }

            public MockProcessState(int stateId, string description)
            {
                StateId = stateId;
                Description = description;
            }
        }

        private class MockRentEvent : IEvent
        {
            public int EventId { get; }
            public string Description { get; set; }
            public int StateId { get; }
            public int UserId { get; }
            public EventType Type => EventType.Rent;

            public MockRentEvent(int eventId, string description, int stateId, int userId)
            {
                EventId = eventId;
                Description = description;
                StateId = stateId;
                UserId = userId;
            }
        }

        private class MockReturnEvent : IEvent
        {
            public int EventId { get; }
            public string Description { get; set; }
            public int StateId { get; }
            public int UserId { get; }
            public EventType Type => EventType.Return;

            public MockReturnEvent(int eventId, string description, int stateId, int userId)
            {
                EventId = eventId;
                Description = description;
                StateId = stateId;
                UserId = userId;
            }
        }
    }

    public class MockUser : IUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
