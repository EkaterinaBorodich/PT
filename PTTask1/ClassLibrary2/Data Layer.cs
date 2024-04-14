using System.Collections.Generic;

namespace BusinessProcessLibrary
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        // Other relevant user data
    }

    public class CatalogItem
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

    public class DataContext
    {
        public List<User> Users { get; } = new List<User>();
        public List<CatalogItem> Catalog { get; } = new List<CatalogItem>();
        public List<ProcessState> ProcessStates { get; } = new List<ProcessState>();
        public List<Event> Events { get; } = new List<Event>();
    }

    public class DataRepository
    {
        private readonly DataContext _dataContext;

        public DataRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddUser(User user)
        {
            _dataContext.Users.Add(user);
        }

        public void AddCatalogItem(CatalogItem item)
        {
            _dataContext.Catalog.Add(item);
        }

        public void AddProcessState(ProcessState state)
        {
            _dataContext.ProcessStates.Add(state);
        }

        public void AddEvent(Event @event)
        {
            _dataContext.Events.Add(@event);
        }
    }
}
