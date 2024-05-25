namespace Data.DataLayer.API
{
    public interface IUser
    {
        int UserId { get; }
        string UserName { get; set; }
    }
}