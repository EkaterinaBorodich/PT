using Presentation.Model.API;
using Presentation.ViewModel;
using System.Windows;

namespace Presentation.View
{
    public partial class ProcessStateView : Window
    {
        public ProcessStateView()
        {
            InitializeComponent();
            DataContext = new ProcessStateViewModel(IProcessStateOperations.CreateModelOperation());
        }
    }
}