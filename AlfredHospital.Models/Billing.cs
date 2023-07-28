using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AlfredHospital.Models
{
    public class Billing
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Billing Counter")]
        public string BillingCounter { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }


        [Required]
        [DisplayName("Billing Date")]
        public DateTime BillingDate { get; set; } = DateTime.Now;

        [Required]
        [DisplayName("Billing Amount")]
        public double BillingAmount { get; set; }


        [Required]
        public int PatientId { get; set; }
		[ValidateNever]
		public Patient Patient { get; set; }


  
    }
}
