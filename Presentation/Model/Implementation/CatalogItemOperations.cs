using Presentation.Model.API;
using Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.Implementation
{
    internal class CatalogItemOperations : ICatalogItemOperations
    {
        private ICatalogItemCRUD _catalogItemCRUD;

        public CatalogItemOperations(ICatalogItemCRUD? catalogItemCRUD = null)
        {
            this._catalogItemCRUD = catalogItemCRUD ?? ICatalogItemCRUD.CreateCatalogItemCRUD();
        }

        private ICatalogItemModel Map(ICatalogItemDTO item)
        {
            return new CatalogItemModel(item.itemId, item.description);
        }

        public async Task AddCatalogItem(int itemId, string description)
        {
            await this._catalogItemCRUD.AddCatalogItem(itemId, description);
        }
        public async Task UpdateCatalogItem(int itemId, string description)
        {
            await this._catalogItemCRUD.UpdateCatalogItem(itemId, description);
        }

        public async Task DeleteCatalogItem(int itemId)
        {
            await this._catalogItemCRUD.DeleteCatalogItem(itemId);
        }
        public async Task<ICatalogItemModel> GetCatalogItem(int itemId)
        {
            return this.Map(await this._catalogItemCRUD.GetCatalogItem(itemId));
        }
    }
}
