namespace PresentationLayer
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IUserService _userService;
        public ObservableCollection<User> Users { get; set; }
        public ICommand AddUserCommand { get; }

        public MainViewModel(IUserService userService)
        {
            _userService = userService;
            Users = new ObservableCollection<User>(_userService.GetAllUsers());
            AddUserCommand = new RelayCommand(AddUser);
        }

        private void AddUser()
        {
            var newUser = new User { UserId = Users.Count + 1, UserName = "New User" };
            _userService.CreateUser(newUser);
            Users.Add(newUser);
        }
    }
}