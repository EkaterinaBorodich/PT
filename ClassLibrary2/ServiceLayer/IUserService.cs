using BusinessProcessLibrary.Data;

namespace BusinessProcessLibrary.Services
{
    public interface IUserService
    {
        void CreateUser(IUser user);
        void DeleteUser(int userId);
        IUser GetUser(int userId);
    }
}