using Data.DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTest.MockImplementation
{
    internal class MockCatalogItem : ICatalogItem
    {
        public MockCatalogItem(int itemId, string description)
        {
            ItemId = itemId;
            Description = description;
        }

        public int ItemId { get; set; }
        public string Description { get; set; }
    }
}
