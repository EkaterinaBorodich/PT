using Presentation.ViewModel;
using System.Windows;

namespace Presentation.View
{
    public partial class EventView : Window
    {
        public EventView()
        {
            InitializeComponent();
            var eventViewModel = new EventViewModel();
            DataContext = eventViewModel;

            // Load initial data
            eventViewModel.LoadEventsCommand.Execute(null);
        }
    }
}