﻿using Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    internal class EventDTO : IEventDTO
    {
        public int eventId {  get; set; }
        public string description { get; set; }
        public int stateId { get; set; }
        public int userId { get; set; }
        public string Type { get; set; }

        public EventDTO(int eventId, string description, int stateId, int userId,string type)
        {
            this.eventId = eventId;
            this.description = description;
            this.stateId = stateId;
            this.userId = userId;
            this.Type = type;
        }
    }
}
