using Data.DataLayer.API;
using Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API
{
    public interface IUserCRUD
    {
        static IUserCRUD CreateUserCRUD(IDataRepository? dataRepository = null)
        {
            return new UserCRUD(dataRepository ?? IDataRepository.CreateDatabase());
        }

        Task AddUser(int userId, string userName);
        Task DeleteUser(int userId);
        Task UpdateUser(int userId, string userName);
        Task<IUserDTO> GetUser(int userId);

        Task<Dictionary<int, IUserDTO>> GetAllUsers();
    }
}
