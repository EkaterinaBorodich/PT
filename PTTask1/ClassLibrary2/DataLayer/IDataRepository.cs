using BusinessProcessLibrary.Data.Implementation;
using System.Collections.Generic;

namespace BusinessProcessLibrary.Data
{
    public interface IDataRepository
    {
        enum EventType
        {
            Rent,
            Return
        }

        public void AddUser(int userId, string userName);
        public void AddCatalogItem(int itemId, string description);
        public void AddProcessState(int stateId, string description);
        public void AddEvent(int eventId, string description, int stateId, int userId, EventType type);

        public void RemoveUser(int userId);
        public void RemoveCatalogItem(int itemId);
        public void RemoveProcessState(int stateId);
        public void RemoveEvent(int eventId);

        public IUser GetUser(int userId);
        public ICatalogItem GetCatalogItem(int itemId);
        public IProcessState GetProcessState(int stateId);
        public IEvent GetEvent(int eventId);

        public static IDataRepository CreateDataRepository()
        {
            return new DataRepository();
        }
    }
}