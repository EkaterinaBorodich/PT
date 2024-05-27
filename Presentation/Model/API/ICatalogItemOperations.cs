using Services.API;
using Presentation.Model.Implementation;

namespace Presentation.Model.API
{
    public interface ICatalogItemOperations
    {
        static ICatalogItemOperations CreateModelOperation(ICatalogItemCRUD? catalogItemCrud = null)
        {
            return new CatalogItemOperations(catalogItemCrud ?? ICatalogItemCRUD.CreateCatalogItemCRUD());
        }
        Task AddCatalogItem(int itemId, string description);
        Task DeleteCatalogItem(int itemId);
        Task UpdateCatalogItem(int itemId, string description);
        Task<ICatalogItemModel> GetCatalogItem(int itemId);
        Task<Dictionary<int, ICatalogItemModel>> GetAllCatalogItems();
    }
}
