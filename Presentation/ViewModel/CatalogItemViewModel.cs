using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentation.Model.API;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class CatalogItemViewModel : INotifyPropertyChanged
    {
        private readonly ICatalogItemOperations _catalogItemOperations;

        private int _itemId;
        private string _description;

        public int ItemId
        {
            get => _itemId;
            set
            {
                _itemId = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCatalogItemCommand { get; }
        public ICommand UpdateCatalogItemCommand { get; }
        public ICommand DeleteCatalogItemCommand { get; }
        public ICommand LoadCatalogItemCommand { get; }

        public CatalogItemViewModel(ICatalogItemOperations catalogItemOperations)
        {
            _catalogItemOperations = catalogItemOperations;
            AddCatalogItemCommand = new RelayCommand(async () => await AddCatalogItem());
            UpdateCatalogItemCommand = new RelayCommand(async () => await UpdateCatalogItem());
            DeleteCatalogItemCommand = new RelayCommand(async () => await DeleteCatalogItem());
            LoadCatalogItemCommand = new RelayCommand<int>(async (itemId) => await LoadCatalogItem(itemId));
        }

        public async Task AddCatalogItem()
        {
            await _catalogItemOperations.AddCatalogItem(ItemId, Description);
        }

        public async Task UpdateCatalogItem()
        {
            await _catalogItemOperations.UpdateCatalogItem(ItemId, Description);
        }

        public async Task DeleteCatalogItem()
        {
            await _catalogItemOperations.DeleteCatalogItem(ItemId);
        }

        public async Task LoadCatalogItem(int itemId)
        {
            var item = await _catalogItemOperations.GetCatalogItem(itemId);
            ItemId = item.ItemId;
            Description = item.Description;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}