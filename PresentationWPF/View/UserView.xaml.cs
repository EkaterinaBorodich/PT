using Presentation.ViewModel;
using System.Windows;

namespace Presentation.View
{
    public partial class UserView : Window
    {
        public UserView()
        {
            InitializeComponent();
            DataContext = new UserViewModel();
        }
    }
}