using System;

namespace VisaTrackingSystem.Models
{
    public partial class VisaDetails
    {
        public int VisaRequsitionId { get; set; }
        public int EmployeeId { get; set; }
        public string CountryName { get; set; }
        public DateTime? VisaIssueDate { get; set; }
        public DateTime? VisaExpiryDate { get; set; }
        public string VisaStatus { get; set; }
    }
}
