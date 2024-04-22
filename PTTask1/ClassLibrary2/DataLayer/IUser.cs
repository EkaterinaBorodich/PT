namespace BusinessProcessLibrary.Data
{
    public interface IUser
    {
        int UserId { get; }
        string UserName { get; set; }
    }
}