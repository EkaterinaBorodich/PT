using Presentation.Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.Implementation
{
    internal class ProcessStateModel : IProcessStateModel
    {
        public int stateId { get; set; }
        public string description { get; set; }
        public ProcessStateModel(int stateId, string description)
        {
            this.stateId = stateId;
            this.description = description;
        }
    }
}
