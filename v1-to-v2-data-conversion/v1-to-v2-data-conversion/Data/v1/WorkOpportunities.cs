using System;
using System.Collections.Generic;

namespace Conversion.Data.v1
{
    public partial class WorkOpportunities
    {
        public int WorkOpportunityId { get; set; }
        public int ProjectId { get; set; }
        public DateTime? WostartDateTime { get; set; }
        public DateTime? WoendDateTime { get; set; }
        public double? Wohours { get; set; }
        public string Description { get; set; }
        public bool LunchAvailable { get; set; }
        public int MaxVolunteers { get; set; }
        public bool AllowGuests { get; set; }
    }
}
