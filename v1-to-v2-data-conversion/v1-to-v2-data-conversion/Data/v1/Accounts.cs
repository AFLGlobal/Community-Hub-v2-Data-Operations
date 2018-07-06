using System;
using System.Collections.Generic;

namespace Conversion.Data.v1
{
    public partial class Accounts
    {
        public int AccountId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsAdmin { get; set; }
        public string Hash { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? LastAccess { get; set; }
        public string LastIp { get; set; }
        public Guid? ResetGuid { get; set; }
        public bool CanCreate { get; set; }
    }
}
