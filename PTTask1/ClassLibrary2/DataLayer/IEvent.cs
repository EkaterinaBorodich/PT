namespace BusinessProcessLibrary.Data
{
    public interface IEvent
    {
        int EventId { get; }
        string Description { get; set; }
        int StateId { get; }
        int UserId { get; }
        IDataRepository.EventType Type { get; }
    }
}
