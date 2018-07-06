using System;
using System.Collections.Generic;

namespace Conversion.Data.v1
{
    public partial class Projects
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectLocation { get; set; }
        public int? LocationId { get; set; }
        public int? ServiceTypeId { get; set; }
        public string WaiverLink { get; set; }
        public bool? TshirtRequired { get; set; }
        public bool Completed { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DateEmailSent { get; set; }
    }
}
