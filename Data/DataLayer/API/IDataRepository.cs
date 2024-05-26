﻿using Data.DataLayer.Implementation;
using System.Collections.Generic;

namespace Data.DataLayer.API
{
    public interface IDataRepository
    { 
        static IDataRepository CreateDatabase(IDataContext? dataContext = null)
        {

            return new DataRepository(dataContext ?? new DataContext());

        } 
    
       

        Task AddUser(int userId, string userName);
        Task AddCatalogItem(int itemId, string description);
        Task AddProcessState(int stateId, string description);
        Task AddEvent(int eventId, string description, int stateId, int userId, string type);

        Task DeleteUser(int userId);
        Task DeleteCatalogItem(int itemId);
        Task DeleteProcessState(int stateId);
        Task DeleteEvent(int eventId);

        Task UpdateUser(int userId, string userName);
        Task UpdateCatalogItem(int itemId, string description);
        Task UpdateProcessState(int stateId, string description);
        Task UpdateEvent(int eventId, string description, int stateId, int userId, string type);

        Task <IUser> GetUser(int userId);
        Task <ICatalogItem> GetCatalogItem(int itemId);
        Task<IProcessState> GetProcessState(int stateId);
        Task<IEvent> GetEvent(int eventId);
    }
}