using System.Windows;

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