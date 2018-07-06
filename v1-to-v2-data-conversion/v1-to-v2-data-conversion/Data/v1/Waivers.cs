using System;
using System.Collections.Generic;

namespace Conversion.Data.v1
{
    public partial class Waivers
    {
        public int WaiverId { get; set; }
        public string WaiverText { get; set; }
        public string WaiverUrl { get; set; }
        public int ProjectId { get; set; }
    }
}
