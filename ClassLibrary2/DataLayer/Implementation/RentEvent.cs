namespace BusinessProcessLibrary.Data.Implementation
{
    internal class RentEvent : IEvent
    {
        public int EventId { get; }
        public string Description { get; set; }
        public int StateId { get; }
        public int UserId { get; }
        public IDataRepository.EventType Type => IDataRepository.EventType.Rent;

        public RentEvent(int eventId, string description, int stateId, int userId)
        {
            EventId = eventId;
            Description = description;
            StateId = stateId;
            UserId = userId;
        }
    }
}
