using System;
using System.Collections.Generic;

namespace Conversion.Data.v2
{
    public partial class WorkOpportunity
    {
        public WorkOpportunity()
        {
            WorkOpportunityForEmployee = new HashSet<WorkOpportunityForEmployee>();
        }

        public long WorkOpportunityId { get; set; }
        public long ProjectId { get; set; }
        public DateTime WorkOpportunityStartDateTime { get; set; }
        public DateTime WorkOpportunityStopDateTime { get; set; }
        public double WorkOpportunityHours { get; set; }
        public string Description { get; set; }
        public bool LunchAvailable { get; set; }
        public int? MaxVolunteers { get; set; }
        public bool AllowGuests { get; set; }

        public Project Project { get; set; }
        public ICollection<WorkOpportunityForEmployee> WorkOpportunityForEmployee { get; set; }
    }
}
