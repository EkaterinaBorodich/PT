using Presentation.Model.API;

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
