using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API
{
    public interface IEventDTO
    {
        int eventId { get; set; }
        string description { get; set; }
        int stateId { get; set; }
        int userId { get; set; }
        string Type { get; set; }
    }
}
