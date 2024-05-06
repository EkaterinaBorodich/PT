using BusinessProcessLibrary.Data;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestProject2")]

namespace BusinessProcessLibrary.Logic
{
    internal class BusinessLogic : IBusinessLogic
    {
        public BusinessLogic(IDataRepository? dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public void RegisterUser(int userId, string userName)
        {
            _dataRepository?.AddUser(userId, userName);
            _mockDataRepository?.AddUser(userId, userName);
        }

        public void AddCatalogItem(int itemId, string description)
        {
            _dataRepository?.AddCatalogItem(itemId, description);
            _mockDataRepository?.AddCatalogItem(itemId, description);
        }

        public void UpdateProcessState(int stateId, string description)
        {
            _dataRepository?.AddProcessState(stateId, description);
            _mockDataRepository?.AddProcessState(stateId, description);
        }

        public void RentEvent(int eventId, string description, int stateId, int userId)
        {
            _dataRepository?.AddEvent(eventId, description, stateId, userId, IDataRepository.EventType.Rent);
            _mockDataRepository?.AddEvent(eventId, description, stateId, userId, EventType.Rent);
        }

        public void ReturnEvent(int eventId, string description, int stateId, int userId)
        {
            _dataRepository?.AddEvent(eventId, description, stateId, userId, IDataRepository.EventType.Return);
            _mockDataRepository?.AddEvent(eventId, description, stateId, userId, EventType.Return);
        }

        private IDataRepository? _dataRepository;

        public BusinessLogic(IMockDataRepository? mockDataRepository)
        {
            _mockDataRepository = mockDataRepository;
        }


        private IMockDataRepository? _mockDataRepository;

    }
}