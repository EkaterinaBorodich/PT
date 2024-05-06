﻿namespace BusinessProcessLibrary.Logic
{
    public interface IBusinessLogic
    {
        void RegisterUser(int userId, string userName);
        void AddCatalogItem(int itemId, string description);
        void UpdateProcessState(int stateId, string description);
        void RentEvent(int eventId, string description, int stateId, int userId);
        void ReturnEvent(int eventId, string description, int stateId, int userId);
    }
}