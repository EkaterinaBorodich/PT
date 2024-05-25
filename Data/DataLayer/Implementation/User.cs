using Data.DataLayer.API;

namespace Data.DataLayer.Implementation
{
    internal class User : IUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public User(int userId, string userName)
        {
            this.UserId = userId;
            this.UserName = userName;
        }
    }
}
