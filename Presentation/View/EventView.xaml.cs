using Presentation.Model.Implementation;
using Presentation.ViewModel;
using System.Windows;

namespace Presentation.View
{
    public partial class EventView : Window
    {
        public EventView()
        {
            DataContext = new EventViewModel(new EventOperations());
        }
    }
}