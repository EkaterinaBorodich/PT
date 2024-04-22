namespace BusinessProcessLibrary.Data.Implementation
{
    internal class User : IUser
    {
        public int UserId { get; }
        public string UserName { get; set; }

        public User(int userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }
    }
}
