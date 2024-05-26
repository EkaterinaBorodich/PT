using Data.DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTest.MockImplementation
{
    internal class MockUser : IUser
    {
        public MockUser(int userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
