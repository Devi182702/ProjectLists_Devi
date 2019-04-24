using System;
using System.ComponentModel.DataAnnotations;

namespace VisaTrackingSystem.Models
{
    public partial class VisaDetails
    {
        public int VisaRequsitionId { get; set; }

        [Display(Name = "Employee ID")]
        [Required]
        public int EmployeeId { get; set; }

        [Display(Name = "Visa For the Country")]
        [Required]
        public string CountryName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Visa Issue Date")]        
        [DisplayFormat(DataFormatString = "{d}", ApplyFormatInEditMode = true)]
        public DateTime? VisaIssueDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? VisaExpiryDate { get; set; }

        public string VisaStatus { get; set; }
    }
}
