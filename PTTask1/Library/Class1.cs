using System.Collections.Generic;

namespace BusinessProcessLibrary
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        // Other relevant user data
    }
    public class Catalog
    {
        public int ItemId { get; set; }
        public string Description { get; set; }
        // Other relevant item data
    }
    public class ProcessState
    {
        public int StateId { get; set; }
        public string Description { get; set; }
        // Other relevant state data
    }
    public class Event
    {
        public int EventId { get; set; }
        public string Description { get; set; }
        // Other relevant event data

        public int StateId { get; set; }
        public ProcessState State { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }

    public interface IDataRepository
    {
        void AddUser(User user);
        void AddCatalogItem(Catalog item);
        void AddProcessState(ProcessState state);
        void AddEvent(Event @event);
    }
    public class DataRepository : IDataRepository
    {
        private readonly List<User> _users = new List<User>();
        private readonly List<Catalog> _catalog = new List<Catalog>();
        private readonly List<ProcessState> _processStates = new List<ProcessState>();
        private readonly List<Event> _events = new List<Event>();

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void AddCatalogItem(Catalog item)
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
    }
}
