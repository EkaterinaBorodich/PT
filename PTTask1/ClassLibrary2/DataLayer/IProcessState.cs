namespace BusinessProcessLibrary.Data
{
    public interface IProcessState
    {
        int StateId { get; }
        string Description { get; set; }
    }
}
