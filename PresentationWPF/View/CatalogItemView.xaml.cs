using Presentation.ViewModel;
using System.Windows;

namespace Presentation.View
{
    public partial class CatalogItemView : Window
    {
        public CatalogItemView()
        {
            InitializeComponent();
            DataContext = new CatalogItemViewModel();
        }
    }
}