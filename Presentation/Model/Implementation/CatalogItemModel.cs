using Presentation.Model.API;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PresentationTest")]

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
