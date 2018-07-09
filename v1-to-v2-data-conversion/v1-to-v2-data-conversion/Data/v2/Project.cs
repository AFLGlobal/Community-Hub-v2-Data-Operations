using System;
using System.Collections.Generic;

namespace Conversion.Data.v2
{
    public partial class Project
    {
        public Project()
        {
            WorkOpportunity = new HashSet<WorkOpportunity>();
        }

        public int ProjectId { get; set; }
        public int? LocationId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public bool TshirtRequired { get; set; }
        public bool Completed { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DateEmailSent { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? WaiverId { get; set; }
        public int? ServiceTypeId { get; set; }

        public Location Location { get; set; }
        public ServiceType ServiceType { get; set; }
        public Waiver Waiver { get; set; }
        public ICollection<WorkOpportunity> WorkOpportunity { get; set; }
    }
}
