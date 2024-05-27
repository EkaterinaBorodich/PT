using Presentation.Model.API;

namespace Presentation.Model.Implementation
{
    internal class CatalogItemModel : ICatalogItemModel
    {
        public int ItemId { get; set; }
        public string Description { get; set; }
        public CatalogItemModel(int itemId, string description)
        {
            this.ItemId = itemId;
            this.Description = description;
        }
    }
}
