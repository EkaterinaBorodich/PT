﻿using Presentation.Model.API;
using Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.Implementation
{
    internal class UserOperations : IUserOperations
    {
        private IUserCRUD _userCRUD;

        public UserOperations(IUserCRUD? userCrud)
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
    }
}
