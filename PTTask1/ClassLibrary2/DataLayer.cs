using System.Collections.Generic;

namespace BusinessProcessLibrary
{
    public interface IDataRepository
    {
        void AddUser(User user);
        void AddCatalogItem(CatalogItem item);
        void AddProcessState(ProcessState state);
        void AddEvent(Event @event);
    }

    public class DataRepository : IDataRepository
    {
        private readonly List<User> _users = new List<User>();
        private readonly List<CatalogItem> _catalog = new List<CatalogItem>();
        private readonly List<ProcessState> _processStates = new List<ProcessState>();
        private readonly List<Event> _events = new List<Event>();

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void AddCatalogItem(CatalogItem item)
        {
            _catalog.Add(item);
        }

        public void AddProcessState(ProcessState state)
        {
            _processStates.Add(state);
        }

        public void AddEvent(Event @event)
        {
            _events.Add(@event);
        }

        // These methods are added for testing purposes
        public List<User> GetUsers() => _users;
        public List<CatalogItem> GetCatalogItems() => _catalog;
        public List<ProcessState> GetProcessStates() => _processStates;
        public List<Event> GetEvents() => _events;
    }
}