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
        public int EventId { get; }
        public string Description { get; set; }
        public int StateId { get; }
        public int UserId { get; }

        public string Type { get; set; }
    }
}
