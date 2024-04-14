using System;
namespace BusinessProcessLibrary
{
    public class LibraryLogic
    {
        private readonly IDataRepository _dataRepository;

        public LibraryLogic(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // Methods implementing relevant business operations
        public void RegisterUser(int userId, string userName)
        {
            var user = new User { UserId = userId, UserName = userName };
            _dataRepository.AddUser(user);
        }

        public void AddCatalogItem(int itemId, string description)
        {
            var item = new Catalog { ItemId = itemId, Description = description };
            _dataRepository.AddCatalogItem(item);
        }

        public void UpdateProcessState(int stateId, string description)
        {
            var state = new ProcessState { StateId = stateId, Description = description };
            _dataRepository.AddProcessState(state);
        }

        public void RegisterEvent(int eventId, string description, int stateId, int userId)
        {
            var @event = new Event
            {
                EventId = eventId,
                Description = description,
                StateId = stateId,
                UserId = userId
            };
            _dataRepository.AddEvent(@event);
        }
    }
}
