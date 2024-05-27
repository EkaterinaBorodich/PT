using Presentation.Model.Implementation;
using Presentation.ViewModel;
using System.Windows;

namespace Presentation.View
{
    public partial class ProcessStateView : Window
    {
        public ProcessStateView()
        {
            DataContext = new ProcessStateViewModel(new ProcessStateOperations());
        }
    }
}