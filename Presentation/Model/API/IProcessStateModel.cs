using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IProcessStateModel
    {
        int stateId { get; set; }
        string description { get; set; }
    }
}
