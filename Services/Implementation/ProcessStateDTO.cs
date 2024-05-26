using Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    internal class ProcessStateDTO : IProcessStateDTO
    {
        public int stateId { get; set; }
        public string description { get; set; }
        public ProcessStateDTO(int stateId,string description) 
        { 
            this.stateId = stateId;
            this.description = description;
        }
    }
}
