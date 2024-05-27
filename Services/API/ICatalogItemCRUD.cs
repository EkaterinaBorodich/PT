using Data.DataLayer.API;
using Services.Implementation;

namespace Services.API
{
    public interface ICatalogItemCRUD
    {
        static ICatalogItemCRUD CreateCatalogItemCRUD(IDataRepository? dataRepository = null)
        {
            return new CatalogItemCRUD(dataRepository ?? IDataRepository.CreateDatabase());
        }
        Task AddCatalogItem(int itemId, string description);

        Task DeleteCatalogItem(int itemId);

        Task UpdateCatalogItem(int itemId, string description);
        Task<ICatalogItemDTO> GetCatalogItem(int itemId);

        Task<Dictionary<int, ICatalogItemDTO>> GetAllCatalogItems();

    }
}
