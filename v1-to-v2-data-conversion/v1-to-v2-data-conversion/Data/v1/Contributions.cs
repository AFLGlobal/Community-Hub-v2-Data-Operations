using System;
using System.Collections.Generic;

namespace Conversion.Data.v1
{
    public partial class Contributions
    {
        public int ContributionId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ContributionDate { get; set; }
        public string ContributionFrequency { get; set; }
        public decimal ContributionAmount { get; set; }
        public string ContributionMethod { get; set; }
        public string ShirtSize { get; set; }
        public int Year { get; set; }
        public string Organization { get; set; }
        public string Designation { get; set; }
        public string Notes { get; set; }
        public DateTime? ConfirmationEmailSent { get; set; }
        public int? CampaignId { get; set; }
        public bool? GotShirt { get; set; }
        public bool? ShirtEligible { get; set; }
        public decimal? TotalAmount { get; set; }
        public bool? PaperPledge { get; set; }
        public string Uwpsocieties { get; set; }
        public bool? AddedTenPercent { get; set; }
    }
}
