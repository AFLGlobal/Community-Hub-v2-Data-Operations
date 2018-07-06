using System;
using System.Collections.Generic;

namespace Conversion.Data.v1
{
    public partial class Employees
    {
        public int EmployeeId { get; set; }
        public string EmpFirst { get; set; }
        public string EmpLast { get; set; }
        public int? LocationId { get; set; }
        public string EmpEmail { get; set; }
        public Guid? EmpGuid { get; set; }
        public string EmpPhone { get; set; }
        public string EmpCell { get; set; }
        public int? SupervisorId { get; set; }
        public string Title { get; set; }
        public string EmpMiddle { get; set; }
        public string EmpAltEmail { get; set; }
        public string EmpStreet { get; set; }
        public string EmpCity { get; set; }
        public string EmpState { get; set; }
        public string EmpPostal { get; set; }
        public int? EmpPayGroup { get; set; }
        public int? BusinessUnitId { get; set; }
        public int? GroupId { get; set; }
        public int? Mid { get; set; }
        public bool Deleted { get; set; }
    }
}
