using System;
using System.Collections.Generic;

namespace Conversion.Data.v1
{
    public partial class GivingCampaigns
    {
        public int CampaignId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public decimal? PrizeQualifier { get; set; }
        public bool? HasPrize { get; set; }
    }
}
