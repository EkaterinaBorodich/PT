using Data.DataLayer.API;

namespace Data.DataLayer.Implementation
{
    internal class Event : IEvent
    {
        public Event(int eventId, string description, int stateId, int userId,string type)
        {
            EventId = eventId;
            Description = description;
            StateId = stateId;
            UserId = userId;
            Type = type;
        }
        public int EventId { get; set; }
        public string Description { get; set; }
        public int StateId { get; set; }
        public int UserId { get; set; }

        public string Type { get; set; }
    }
}
