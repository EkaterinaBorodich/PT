using Presentation.Model.API;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Presentation.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private IUserOperations _userOperations;

        public UserViewModel()
        {
            _userOperations = IUserOperations.CreateModelOperation();
            Users = new ObservableCollection<IUserModel>();
            AddUserCommand = new RelayCommand(async () => await AddUser());
            UpdateUserCommand = new RelayCommand(async () => await UpdateUser());
            DeleteUserCommand = new RelayCommand(async () => await DeleteUser());
            LoadUsersCommand = new RelayCommand(async () => await LoadUsers());
            LoadUsersCommand.Execute(null);
        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; OnPropertyChanged(); }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(); }
        }

        private IUserModel _selectedUser;
        public IUserModel SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                if (_selectedUser != null)
                {
                    UserId = _selectedUser.userId;
                    UserName = _selectedUser.userName;
                }
                OnPropertyChanged();
            }
        }

        public ObservableCollection<IUserModel> Users { get; }

        public ICommand AddUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand LoadUsersCommand { get; }

        public async Task AddUser()
        {
            await _userOperations.AddUser(UserId, UserName);
            await LoadUsers();
        }

        public async Task UpdateUser()
        {
            await _userOperations.UpdateUser(UserId, UserName);
            await LoadUsers();
        }

        public async Task DeleteUser()
        {
            await _userOperations.DeleteUser(UserId);
            await LoadUsers();
        }

        public async Task LoadUsers()
        {
            var usersDictionary = await _userOperations.GetAllUsers();

            Users.Clear();

            foreach (var user in usersDictionary.Values)
            {
                Users.Add(user);
            }
        }

        internal void SetOperations(IUserOperations userOperations)
        {
            _userOperations = userOperations;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}