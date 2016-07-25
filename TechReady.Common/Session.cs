using System;
using System.Collections.Generic;
using System.Linq;

namespace TechReady.API.Models
{
    public class Session
    {
        public string Day { get; set;  }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Code { get; set; }

        public string Title { get; set;  }

        public string Room { get; set; }

        public string PrimarySpeaker { get; set; }

        public string PrimaryTrack { get; set; }

        public string VirtualTrack { get; set; }
    }
}