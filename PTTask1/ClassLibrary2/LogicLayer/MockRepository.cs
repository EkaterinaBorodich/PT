namespace BusinessProcessLibrary.Logic
{
    public interface IMockDataRepository
    {
        public void AddUser(int userId, string userName);
        public void AddCatalogItem(int itemId, string description);
        public void AddProcessState(int stateId, string description);
        public void AddEvent(int eventId, string description, int stateId, int userId, EventType type);

        public IMockUser GetUser(int userId);
        public IMockCatalogItem GetCatalogItem(int itemId);
        public IMockProcessState GetProcessState(int stateId);
        public IMockEvent GetEvent(int eventId);
    }
    public class MockDataRepository : IMockDataRepository
    {
        private readonly Dictionary<int, IMockUser> _users = new Dictionary<int, IMockUser>();
        private readonly Dictionary<int, IMockCatalogItem> _catalog = new Dictionary<int, IMockCatalogItem>();
        private readonly Dictionary<int, IMockProcessState> _processStates = new Dictionary<int, IMockProcessState>();
        private readonly Dictionary<int, IMockEvent> _events = new Dictionary<int, IMockEvent>();

        public void AddUser(int userId, string userName)
        {
            _users[userId] = new MockUser(userId, userName);
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

        public IMockUser? GetUser(int userId)
        {
            return _users.TryGetValue(userId, out var user) ? user : null;
        }

        public IMockCatalogItem? GetCatalogItem(int itemId)
        {
            return _catalog.TryGetValue(itemId, out var item) ? item : null;
        }

        public IMockProcessState? GetProcessState(int stateId)
        {
            return _processStates.TryGetValue(stateId, out var state) ? state : null;
        }

        public IMockEvent? GetEvent(int eventId)
        {
            return _events.TryGetValue(eventId, out var @event) ? @event : null;
        }

        private class MockUser : IMockUser
        {
            public int UserId { get; }
            public string UserName { get; set; }

            public MockUser(int userId, string userName)
            {
                UserId = userId;
                UserName = userName;
            }
        }

        private class MockCatalogItem : IMockCatalogItem
        {
            public int ItemId { get; }
            public string Description { get; set; }

            public MockCatalogItem(int itemId, string description)
            {
                ItemId = itemId;
                Description = description;
            }
        }

        private class MockProcessState : IMockProcessState
        {
            public int StateId { get; }
            public string Description { get; set; }

            public MockProcessState(int stateId, string description)
            {
                StateId = stateId;
                Description = description;
            }
        }

        private class MockRentEvent : IMockEvent
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

        private class MockReturnEvent : IMockEvent
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

    public interface IMockUser
    {
        int UserId { get; }
        string UserName { get; set; }
    }

    public interface IMockCatalogItem
    {
        int ItemId { get; }
        string Description { get; set; }
    }

    public interface IMockProcessState
    {
        int StateId { get; }
        string Description { get; set; }
    }

    public interface IMockEvent
    {
        int EventId { get; }
        string Description { get; set; }
        int StateId { get; }
        int UserId { get; }
        EventType Type { get; }
    }

    public enum EventType
    {
        Rent,
        Return
    }
}
