using System;
using System.Collections.Generic;

namespace Conversion.Data.v1
{
    public partial class FriendWork
    {
        public int Ffid { get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeWorkId { get; set; }
        public string Name { get; set; }
        public double WorkHours { get; set; }
    }
}
