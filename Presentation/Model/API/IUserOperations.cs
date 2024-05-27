using Services.API;
using Presentation.Model.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IUserOperations
    {
        static IUserOperations CreateModelOperation(IUserCRUD? userCrud = null)
        {
            return new UserOperations(userCrud);
        }
        Task AddUser(int userId, string userName);
        Task DeleteUser(int userId);
        Task UpdateUser(int userId, string userName);
        Task<IUserModel> GetUser(int userId);
        Task<Dictionary<int, IUserModel>> GetAllUsers();
    }
}
