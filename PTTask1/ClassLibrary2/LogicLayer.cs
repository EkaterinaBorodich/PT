using System;
using System.Collections.Generic;
using BusinessProcessLibrary.Data;

namespace BusinessProcessLibrary.Logic
{ 
    // Define the BusinessLogic class containing business operations
    public class BusinessLogic
    {
        private readonly IDataRepository _dataRepository;

        public BusinessLogic(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository ?? throw new ArgumentNullException(nameof(dataRepository));
        }

        // Implement relevant business operations
        public void RegisterUser(int userId, string userName)
        {
            var user = new User { UserId = userId, UserName = userName };
            _dataRepository.AddUser(user);
        }

        public void AddCatalogItem(int itemId, string description)
        {
            var item = new CatalogItem { ItemId = itemId, Description = description };
            _dataRepository.AddCatalogItem(item);
        }

        public void UpdateProcessState(int stateId, string description)
        {
            var state = new ProcessState { StateId = stateId, Description = description };
            _dataRepository.AddProcessState(state);
        }

        public void RegisterEvent(int eventId, string description, int stateId, int userId)
        {
            var @event = new Event { EventId = eventId, Description = description, StateId = stateId, UserId = userId };
            _dataRepository.AddEvent(@event);
        }
    }
}