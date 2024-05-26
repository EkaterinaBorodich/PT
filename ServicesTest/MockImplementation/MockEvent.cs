using Data.DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTest.MockImplementation
{
    internal class MockEvent : IEvent
    {
        public MockEvent(int eventId, string description, int stateId, int userId, string type)
        {
            EventId = eventId;
            Description = description;
            StateId = stateId;
            UserId = userId;
            Type = type;
        }

        public int EventId { get; set; }
        public string Description { get; set; }
        public int StateId { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
    }
}
