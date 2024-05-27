using Services.API;
using Presentation.Model.Implementation;

namespace Presentation.Model.API
{
    public interface IEventOperations
    {
        static IEventOperations CreateModelOperation(IEventCRUD? eventCrud = null)
        {
            return new EventOperations(eventCrud ?? IEventCRUD.CreateEventCRUD());
        }
        Task AddEvent(int eventId, string description, int stateId, int userId, string type);
        Task DeleteEvent(int eventId);
        Task UpdateEvent(int eventId, string description, int stateId, int userId, string type);
        Task<IEventModel> GetEvent(int eventId);
        Task<Dictionary<int, IEventModel>> GetAllEvents();
    }
}
