using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API
{
    public interface ICatalogItemDTO
    {
        int itemId {  get; set; }
        string description { get; set; }
    }
}
