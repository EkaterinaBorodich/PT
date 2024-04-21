using System;
using System.Collections.Generic;

namespace BusinessProcessLibrary.Data
{
    // Define the User class representing actors relevant to the business process
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        // Other relevant user data
    }

    // Define the CatalogItem class representing goods descriptions
    public class CatalogItem
    {
        public int ItemId { get; set; }
        public string Description { get; set; }
        // Other relevant item data
    }

    // Define the ProcessState class representing the current process state
    public class ProcessState
    {
        public int StateId { get; set; }
        public string Description { get; set; }
        // Other relevant state data
    }

    // Define the Event class representing events contributing to the process state change
    public class Event
    {
        public int EventId { get; set; }
        public string Description { get; set; }
        // Other relevant event data

        public int StateId { get; set; }
        public int UserId { get; set; }
    }

    // Define the IDataRepository interface representing data operations
    public interface IDataRepository
    {
        void AddUser(User user);
        void AddCatalogItem(CatalogItem item);
        void AddProcessState(ProcessState state);
        void AddEvent(Event @event);

        List<User> GetUsers();
        List<CatalogItem> GetCatalogItems();
        List<ProcessState> GetProcessStates();
        List<Event> GetEvents();
    }

    // Define the DataRepository class implementing IDataRepository interface
    public class DataRepository : IDataRepository
    {
        private readonly List<User> _users = new List<User>();
        private readonly List<CatalogItem> _catalog = new List<CatalogItem>();
        private readonly List<ProcessState> _processStates = new List<ProcessState>();
        private readonly List<Event> _events = new List<Event>();

        public void AddUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            _users.Add(user);
        }

        public void AddCatalogItem(CatalogItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            _catalog.Add(item);
        }

        public void AddProcessState(ProcessState state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));
            _processStates.Add(state);
        }

        public void AddEvent(Event @event)
        {
            if (@event == null)
                throw new ArgumentNullException(nameof(@event));
            _events.Add(@event);
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public List<CatalogItem> GetCatalogItems()
        {
            return _catalog;
        }

        public List<ProcessState> GetProcessStates()
        {
            return _processStates;
        }

        public List<Event> GetEvents()
        {
            return _events;
        }
    }
}