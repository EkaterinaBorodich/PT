using Data.DataLayer.API;
using Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API
{
    public interface IEventCRUD
    {
        static IEventCRUD CreateEventCRUD(IDataRepository? dataRepository = null)
        {
            return new EventCRUD(dataRepository ?? IDataRepository.CreateDatabase());
        }

        Task AddEvent(int eventId, string description, int stateId, int userId, string type);
        Task DeleteEvent(int eventId);
        Task UpdateEvent(int eventId, string description, int stateId, int userId, string type);
        Task<IEventDTO> GetEvent(int eventId);
    }
}
