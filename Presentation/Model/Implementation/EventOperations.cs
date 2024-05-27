using Presentation.Model.API;
using Services.API;

namespace Presentation.Model.Implementation
{
    internal class EventOperations : IEventOperations
    {
        private IEventCRUD _eventCRUD;
        public EventOperations(IEventCRUD? eventCrud = null)
        {
            this._eventCRUD = eventCrud ?? IEventCRUD.CreateEventCRUD();
        }
        private IEventModel Map(IEventDTO even)
        {
            return new EventModel(even.eventId,even.description, even.stateId, even.userId,even.Type);
        }
        public async Task AddEvent(int eventId, string description, int stateId, int userId, string type)
        {
            await this._eventCRUD.AddEvent(eventId, description, stateId, userId, type);
        }
        public async Task UpdateEvent(int eventId, string description, int stateId, int userId, string type)
        {
            await this._eventCRUD.UpdateEvent(eventId, description, stateId, userId, type);
        }

        public async Task DeleteEvent(int eventId)
        {
            await this._eventCRUD.DeleteEvent(eventId);
        }

        public async Task<IEventModel> GetEvent(int eventId)
        {
            return this.Map(await this._eventCRUD.GetEvent(eventId));
        }

    }
}
