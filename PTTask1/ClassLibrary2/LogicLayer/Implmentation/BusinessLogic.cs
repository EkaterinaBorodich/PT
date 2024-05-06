using BusinessProcessLibrary.Data;
using BusinessProcessLibrary.Data.Implementation;

namespace BusinessProcessLibrary.Logic
{
    public class BusinessLogic : IBusinessLogic
    {
        public BusinessLogic(IDataRepository? dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public void RegisterUser(int userId, string userName)
        {
            _dataRepository?.AddUser(userId, userName);
        }

        public void AddCatalogItem(int itemId, string description)
        {
            _dataRepository?.AddCatalogItem(itemId, description);
        }

        public void UpdateProcessState(int stateId, string description)
        {
            _dataRepository?.AddProcessState(stateId, description);
        }

        public void RentEvent(int eventId, string description, int stateId, int userId)
        {
            _dataRepository?.AddEvent(eventId, description, stateId, userId, IDataRepository.EventType.Rent);
        }

        public void ReturnEvent(int eventId, string description, int stateId, int userId)
        {
            _dataRepository?.AddEvent(eventId, description, stateId, userId, IDataRepository.EventType.Return);
        }

        private IDataRepository? _dataRepository;
    }
}