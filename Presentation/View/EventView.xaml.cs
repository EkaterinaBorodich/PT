using Presentation.Model.API;
using Presentation.ViewModel;
using System.Windows;

namespace Presentation.View
{
    public partial class EventView : Window
    {
        public EventView()
        {
            InitializeComponent();
            DataContext = new EventViewModel(IEventOperations.CreateModelOperation());
        }
    }
}