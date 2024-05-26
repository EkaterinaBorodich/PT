using Services.API;
using Presentation.Model.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
