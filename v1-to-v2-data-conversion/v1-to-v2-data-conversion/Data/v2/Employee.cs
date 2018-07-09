using System;
using System.Collections.Generic;

namespace Conversion.Data.v2
{
    public partial class Employee
    {
        public Employee()
        {
            WorkOpportunityForEmployee = new HashSet<WorkOpportunityForEmployee>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public int LocationId { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeCellPhone { get; set; }
        public string Title { get; set; }
        public string EmployeeMiddleName { get; set; }
        public string EmployeeAlternateEmail { get; set; }
        public string EmployeeStreet { get; set; }
        public string EmployeeCity { get; set; }
        public string EmployeeState { get; set; }
        public string EmployeeZip { get; set; }
        public int? EmployeePayGroup { get; set; }
        public int? MId { get; set; }
        public bool Deleted { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsLocked { get; set; }
        public DateTime LastAccessDateTime { get; set; }
        public bool CanCreate { get; set; }
        public bool AdminCommunityService { get; set; }
        public bool AdminAssociateManagement { get; set; }
        public bool AdminUnitedWay { get; set; }
        public bool AdminReporting { get; set; }
        public bool UseActiveDirectory { get; set; }
        public string EmployeePassword { get; set; }

        public Location Location { get; set; }
        public ICollection<WorkOpportunityForEmployee> WorkOpportunityForEmployee { get; set; }
    }
}
