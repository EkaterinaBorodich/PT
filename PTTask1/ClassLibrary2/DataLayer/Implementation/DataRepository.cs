using System.Collections.Generic;
using static BusinessProcessLibrary.Data.IDataRepository;

namespace BusinessProcessLibrary.Data.Implementation
{
    internal class DataRepository : IDataRepository
    {

        private readonly List<IUser> _users = new List<IUser>();
        private readonly List<ICatalogItem> _catalog = new List<ICatalogItem>();
        private readonly List<IProcessState> _processStates = new List<IProcessState>();
        private readonly List<IEvent> _events = new List<IEvent>();

        public void AddUser(int userId, string userName)
        {
            _users.Add(new User(userId, userName));
        }

        public void AddCatalogItem(int itemId, string description)
        {
            _catalog.Add(new CatalogItem(itemId, description));
        }

        public void AddProcessState(int stateId, string description)
        {
            _processStates.Add(new ProcessState(stateId, description));
        }

        public void AddEvent(int eventId, string description, int stateId, int userId, EventType type)
        {
            IEvent @event;

            switch (type)
            {
                case EventType.Rent:
                    @event = new RentEvent(eventId, description, stateId, userId);
                    break;
                case EventType.Return:
                    @event = new ReturnEvent(eventId, description, stateId, userId);
                    break;
                default:
                    throw new System.ArgumentException("Unknown event type");
            }


            _events.Add(@event);
        }
        public void RemoveUser(int userId)
        {
            var userToRemove = _users.Find(u => u.UserId == userId);
            if (userToRemove != null)
                _users.Remove(userToRemove);
        }

        public void RemoveCatalogItem(int itemId)
        {
            var itemToRemove = _catalog.Find(c => c.ItemId == itemId);
            if (itemToRemove != null)
                _catalog.Remove(itemToRemove);
        }

        public void RemoveProcessState(int stateId)
        {
            var stateToRemove = _processStates.Find(p => p.StateId == stateId);
            if (stateToRemove != null)
                _processStates.Remove(stateToRemove);
        }

        public void RemoveEvent(int eventId)
        {
            var eventToRemove = _events.Find(e => e.EventId == eventId);
            if (eventToRemove != null)
                _events.Remove(eventToRemove);
        }

        public IUser GetUser(int userId)
        {
            return _users.Find(user => user.UserId == userId);
        }

        public ICatalogItem GetCatalogItem(int itemId)
        {
            return _catalog.Find(item => item.ItemId == itemId);
        }

        public IProcessState GetProcessState(int stateId)
        {
            return _processStates.Find(state => state.StateId == stateId);
        }

        public IEvent GetEvent(int eventId)
        {
            return _events.Find(ev => ev.EventId == eventId);
        }
    }
}