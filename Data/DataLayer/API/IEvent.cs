namespace Data.DataLayer.API
{
    public interface IEvent
    {
        int EventId { get; set; }
        string Description { get; set; }
        int StateId { get; set; }
        int UserId { get; set; }
        public string Type { get; set; }
    }
}
