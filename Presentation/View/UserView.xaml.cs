using Presentation.Model.Implementation;
using Presentation.ViewModel;
using System.Windows;

namespace Presentation.View
{
    public partial class UserView : Window
    {
        public UserView()
        {
            DataContext = new UserViewModel(new UserOperations());
        }
    }
}