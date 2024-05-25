using Data.DataLayer.API;

namespace Data.DataLayer.Implementation
{
    internal class CatalogItem : ICatalogItem
    {
        public int ItemId { get; }
        public string Description { get; set; }

        public CatalogItem(int itemId, string description)
        {
            ItemId = itemId;
            Description = description;
        }
    }
}
