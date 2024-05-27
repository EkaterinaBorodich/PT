using Presentation.Model.API;
using Services.API;

namespace Presentation.Model.Implementation
{
    internal class UserOperations : IUserOperations
    {
        private IUserCRUD _userCRUD;

        public UserOperations(IUserCRUD? userCrud = null)
        {
            this._userCRUD = userCrud ?? IUserCRUD.CreateUserCRUD();
        }

        private IUserModel Map(IUserDTO user)
        {
            return new UserModel(user.userId, user.userName);
        }

        public async Task AddUser(int userId, string userName)
        {
            await this._userCRUD.AddUser(userId, userName);
        }
        public async Task UpdateUser(int userId, string userName)
        {
            await this._userCRUD.UpdateUser(userId, userName);
        }
        public async Task DeleteUser(int userId)
        {
            await this._userCRUD.DeleteUser(userId);
        }
        public async Task<IUserModel> GetUser(int userId)
        {
            return this.Map(await this._userCRUD.GetUser(userId));
        }
        public async Task<Dictionary<int, IUserModel>> GetAllUsers()
        {
            Dictionary<int, IUserModel> result = new Dictionary<int, IUserModel>();

            foreach (IUserDTO item in (await this._userCRUD.GetAllUsers()).Values)
            {
                result.Add(item.userId, this.Map(item));
            }

            return result;
        }
    }
}
