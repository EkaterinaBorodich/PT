using Presentation.Model.API;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class CatalogItemViewModel : INotifyPropertyChanged
    {

        private ICatalogItemOperations _catalogItemOperations;

        public CatalogItemViewModel()
        {
            _catalogItemOperations = ICatalogItemOperations.CreateModelOperation();
            CatalogItems = new ObservableCollection<ICatalogItemModel>();
            AddCatalogItemCommand = new RelayCommand(async () => await AddCatalogItem());
            UpdateCatalogItemCommand = new RelayCommand(async () => await UpdateCatalogItem());
            DeleteCatalogItemCommand = new RelayCommand(async () => await DeleteCatalogItem());
            LoadCatalogItemsCommand = new RelayCommand(async () => await LoadCatalogItems());
            LoadCatalogItemsCommand.Execute(null);
        }

        private int _itemId;
        public int ItemId
        {
            get { return _itemId; }
            set { _itemId = value; OnPropertyChanged(); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        }

        private ICatalogItemModel _selectedCatalogItem;
        public ICatalogItemModel SelectedCatalogItem
        {
            get { return _selectedCatalogItem; }
            set
            {
                _selectedCatalogItem = value;
                if (_selectedCatalogItem != null)
                {
                    ItemId = _selectedCatalogItem.ItemId;
                    Description = _selectedCatalogItem.Description;
                }
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ICatalogItemModel> CatalogItems { get; }

        public ICommand AddCatalogItemCommand { get; }
        public ICommand UpdateCatalogItemCommand { get; }
        public ICommand DeleteCatalogItemCommand { get; }
        public ICommand LoadCatalogItemsCommand { get; }

        public async Task AddCatalogItem()
        {
            await _catalogItemOperations.AddCatalogItem(ItemId, Description);
            await LoadCatalogItems();
        }

        public async Task UpdateCatalogItem()
        {
            await _catalogItemOperations.UpdateCatalogItem(ItemId, Description);
            await LoadCatalogItems();
        }

        public async Task DeleteCatalogItem()
        {
            await _catalogItemOperations.DeleteCatalogItem(ItemId);
            await LoadCatalogItems();
        }

        public async Task LoadCatalogItems()
        {
            var catalogItemsDictionary = await _catalogItemOperations.GetAllCatalogItems();

            CatalogItems.Clear();

            foreach (var catalogItem in catalogItemsDictionary.Values)
            {
                CatalogItems.Add(catalogItem);
            }
        }

        internal void SetOperations(ICatalogItemOperations catalogItemOperations)
        {
            _catalogItemOperations = catalogItemOperations;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();
        public void Execute(object parameter) => _execute();

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute((T)parameter);
        public void Execute(object parameter) => _execute((T)parameter);

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}