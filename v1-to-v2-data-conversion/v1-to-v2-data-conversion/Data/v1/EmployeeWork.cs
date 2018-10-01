using System;
using System.Collections.Generic;
using System.Text;

namespace Conversion.Data.v1
{
    public partial class EmployeeWork
    {
        public int EmployeeId { get; set; }
        public int WorkOpportunityID { get; set; }
        public double? ActualHours { get; set; }
        public double ProjectedHours { get; set; }
        public string Comments { get; set; }
        public DateTime EmpSignedUp { get; set; }
        public bool WantsLunch { get; set; }
        public string NeedsTShirt { get; set; }
        public int Guests { get; set; }
    }
}
