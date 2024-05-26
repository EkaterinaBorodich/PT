using Data.DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTest.MockImplementation
{
    internal class MockProcessState : IProcessState
    {
        public MockProcessState(int stateId, string description)
        {
            StateId = stateId;
            Description = description;
        }
        public int StateId { get; set; }
        public string Description { get; set; }
    }
}
