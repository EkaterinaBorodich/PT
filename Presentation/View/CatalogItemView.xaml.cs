using Presentation.Model.Implementation;
using Presentation.ViewModel;
using System.Windows;

namespace Presentation.View
{
    public partial class CatalogItemView : Window
    {
        public CatalogItemView()
        {
            DataContext = new CatalogItemViewModel(new CatalogItemOperations());
        }
    }
}