using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API
{
    public interface IUserDTO
    {
        int userId { get; set; }
        string userName { get; set; }
    }
}
