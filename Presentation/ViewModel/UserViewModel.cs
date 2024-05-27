using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Model.API;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private readonly IUserOperations _userOperations;

        private int _userId;
        private string _userName;

        public int UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                OnPropertyChanged();
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand LoadUserCommand { get; }

        public UserViewModel(IUserOperations userOperations)
        {
            _userOperations = userOperations;
            AddUserCommand = new RelayCommand(async () => await AddUser());
            UpdateUserCommand = new RelayCommand(async () => await UpdateUser());
            DeleteUserCommand = new RelayCommand(async () => await DeleteUser());
            LoadUserCommand = new RelayCommand<int>(async (userId) => await LoadUser(userId));
        }

        public async Task AddUser()
        {
            await _userOperations.AddUser(UserId, UserName);
        }

        public async Task UpdateUser()
        {
            await _userOperations.UpdateUser(UserId, UserName);
        }

        public async Task DeleteUser()
        {
            await _userOperations.DeleteUser(UserId);
        }

        public async Task LoadUser(int userId)
        {
            var user = await _userOperations.GetUser(userId);
            UserId = user.userId;
            UserName = user.userName;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}