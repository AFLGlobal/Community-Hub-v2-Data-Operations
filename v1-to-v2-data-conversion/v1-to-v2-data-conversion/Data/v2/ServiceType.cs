﻿using System;
using System.Collections.Generic;

namespace Conversion.Data.v2
{
    public partial class ServiceType
    {
        public ServiceType()
        {
            Project = new HashSet<Project>();
        }

        public long ServiceTypeId { get; set; }
        public string ServiceType1 { get; set; }

        public ICollection<Project> Project { get; set; }
    }
}
