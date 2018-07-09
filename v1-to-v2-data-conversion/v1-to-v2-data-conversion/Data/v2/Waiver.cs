using System;
using System.Collections.Generic;

namespace Conversion.Data.v2
{
    public partial class Waiver
    {
        public Waiver()
        {
            Project = new HashSet<Project>();
        }

        public int WaiverId { get; set; }
        public string WaiverText { get; set; }
        public string WaiverUrl { get; set; }

        public ICollection<Project> Project { get; set; }
    }
}
