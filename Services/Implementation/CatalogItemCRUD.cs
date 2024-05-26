using Data.DataLayer.API;
using Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    internal class CatalogItemCRUD : ICatalogItemCRUD
    {
        private IDataRepository _repository;
        public CatalogItemCRUD(IDataRepository repository)
        {
            _repository = repository;
        }
        private ICatalogItemDTO Map(ICatalogItem item)
        {
            return new CatalogItemDTO(item.ItemId, item.Description);
        }
        public async Task AddCatalogItem(int itemId,string description)
        {
            await this._repository.AddCatalogItem(itemId, description);
        }
        public async Task DeleteCatalogItem(int itemId)
        {
            await this._repository.DeleteCatalogItem(itemId);
        }
        public async Task UpdateCatalogItem(int itemId, string description)
        {
            await this._repository.UpdateCatalogItem(itemId, description);
        }
        public async Task<ICatalogItemDTO> GetCatalogItem(int itemId)
        {
            return this.Map(await this._repository.GetCatalogItem(itemId));
        }
    }
}
