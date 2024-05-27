using Presentation.Model.Implementation;
using Presentation.ViewModel;
using Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation.View
{
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
        }

        private void OpenCatalogItemView(object sender, RoutedEventArgs e)
        {
            CatalogItemView catalogItemView = new CatalogItemView();
            catalogItemView.Show();
        }

        private void OpenEventView(object sender, RoutedEventArgs e)
        {
            EventView eventView = new EventView();
            eventView.Show();
        }

        private void OpenProcessStateView(object sender, RoutedEventArgs e)
        {
            ProcessStateView processStateView = new ProcessStateView();
            processStateView.Show();
        }

        private void OpenUserView(object sender, RoutedEventArgs e)
        {
            UserView userView = new UserView();
            userView.Show();
        }
    }
}