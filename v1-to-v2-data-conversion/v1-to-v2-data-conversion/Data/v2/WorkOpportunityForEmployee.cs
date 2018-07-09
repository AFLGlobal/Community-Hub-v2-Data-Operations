using System;
using System.Collections.Generic;

namespace Conversion.Data.v2
{
    public partial class WorkOpportunityForEmployee
    {
        public int WorkOpportunityForEmployeeId { get; set; }
        public int EmployeeId { get; set; }
        public int WorkOpportunityId { get; set; }
        public DateTime EmployeeDateSignedUp { get; set; }
        public double ActualHours { get; set; }
        public string Comments { get; set; }
        public bool WantsLunch { get; set; }
        public string TshirtSize { get; set; }
        public int Guests { get; set; }

        public Employee Employee { get; set; }
        public WorkOpportunity WorkOpportunity { get; set; }
    }
}
