using Presentation.Model.API;

namespace Presentation.Model.Implementation
{
    internal class EventModel : IEventModel
    {
        public int eventId { get; set; }
        public string description { get; set; }
        public int stateId { get; set; }
        public int userId { get; set; }
        public string Type { get; set; }

        public EventModel(int eventId, string description, int stateId, int userId, string type)
        {
            this.eventId = eventId;
            this.description = description;
            this.stateId = stateId;
            this.userId = userId;
            this.Type = type;
        }
    }
}
