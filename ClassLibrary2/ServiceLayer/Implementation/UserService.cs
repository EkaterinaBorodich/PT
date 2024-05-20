using BusinessProcessLibrary.Data;

namespace BusinessProcessLibrary.Services.Implmentation
{
    public class UserService : IUserService
    {
        private readonly IDataRepository _dataRepository;

        public UserService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public void CreateUser(IUser user)
        {
            _dataRepository.AddUser(user);
        }

        public void DeleteUser(int userId)
        {
            _dataRepository.RemoveUser(userId);
        }

        public IUser GetUser(int userId)
        {
            return _dataRepository.GetUser(userId);
        }
    }
}
