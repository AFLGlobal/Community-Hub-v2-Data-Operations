using System;
using System.Collections.Generic;

namespace Conversion.Data.v1
{
    public partial class Organizations
    {
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public int LocationId { get; set; }
        public bool SpecifyDetails { get; set; }
        public string LinkForCredit { get; set; }
    }
}
