using Data.DataLayer.API;
using Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    internal class EventCRUD : IEventCRUD
    {
        private IDataRepository _repository;

        public EventCRUD(IDataRepository repository)
        {
            this._repository = repository;
        }

        public IEventDTO Map(IEvent even)
        {
            return new EventDTO(even.EventId, even.Description, even.StateId, even.UserId, even.Type);
        }

        public async Task AddEvent(int eventId,string description, int stateId, int userId, string type)
        {
            await this._repository.AddEvent(eventId,description, stateId, userId, type);
        }

        public async Task UpdateEvent(int eventId, string description, int stateId, int userId, string type)
        {
            await this._repository.UpdateEvent(eventId,description, stateId, userId, type);
        }

        public async Task DeleteEvent(int eventId)
        {
            await this._repository.DeleteEvent(eventId);
        }

        public async Task<IEventDTO> GetEvent(int eventId)
        {
            return this.Map(await this._repository.GetEvent(eventId));
        }
        public async Task<Dictionary<int, IEventDTO>> GetAllEvents()
        {
            Dictionary<int, IEventDTO> result = new Dictionary<int, IEventDTO>();

            foreach (IEvent item in (await this._repository.GetAllEvents()).Values)
            {
                result.Add(item.EventId, this.Map(item));
            }

            return result;
        }
    }
}
