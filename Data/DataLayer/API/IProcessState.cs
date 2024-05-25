namespace Data.DataLayer.API
{
    public interface IProcessState
    {
        int StateId { get; }
        string Description { get; set; }
    }
}
