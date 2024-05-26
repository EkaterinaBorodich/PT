using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IUserModel
    {
        int userId { get; set; }
        string userName { get; set; }
    }
}
