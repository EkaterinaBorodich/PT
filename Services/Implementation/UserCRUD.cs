using Data.DataLayer.API;
using Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    internal class UserCRUD : IUserCRUD
    {
        private IDataRepository _repository;

        public UserCRUD(IDataRepository repository)
        {
            _repository = repository;
        }
        private IUserDTO Map(IUser user)
        { 
            return new UserDTO(user.UserId, user.UserName);
        }
        public async Task AddUser(int userId,string userName)
        {
            await this._repository.AddUser(userId,userName);
        }
        public async Task DeleteUser(int userId)
        {
            await this._repository.DeleteUser(userId);
        }
        public async Task UpdateUser(int userId,string userName)
        {
            await this._repository.UpdateUser(userId,userName);
        }
        public async Task<IUserDTO> GetUser(int userId)
        {
            return this.Map(await this._repository.GetUser(userId));
        }
    }
}
