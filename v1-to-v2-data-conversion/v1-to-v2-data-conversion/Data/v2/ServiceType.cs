using System;
using System.Collections.Generic;

namespace Conversion.Data.v2
{
    public partial class ServiceType
    {
        public ServiceType()
        {
            Project = new HashSet<Project>();
        }

        public int ServiceTypeId { get; set; }
        public string ServiceTypeValue { get; set; }

        public ICollection<Project> Project { get; set; }
    }
}
