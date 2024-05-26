using Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    internal class CatalogItemDTO : ICatalogItemDTO
    {
        public int itemId {  get; set; }
        public string description { get; set; }
        public CatalogItemDTO(int itemId, string description)
        {
            this.itemId = itemId;
            this.description = description;
        }
    }
}
