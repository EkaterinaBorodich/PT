namespace Data.DataLayer.API
{
    public interface IEvent
    {
        int EventId { get; }
        string Description { get; set; }
        int StateId { get; }
        int UserId { get; }
        public string Type { get; set; }
    }
}
