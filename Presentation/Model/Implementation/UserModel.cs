using Presentation.Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.Implementation
{
    internal class UserModel : IUserModel
    {
        public int userId { get; set; }
        public string userName { get; set; }

        public UserModel(int userId, string userName)
        {
            this.userId = userId;
            this.userName = userName;
        }
    }
}
