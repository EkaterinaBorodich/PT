using Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    internal class UserDTO : IUserDTO
    {
        public int userId {  get; set; }
        public string userName { get; set; }

        public UserDTO(int userId, string userName)
        {
            this.userId = userId;
            this.userName = userName;
        }
    }
}
