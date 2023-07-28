using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AlfredHospital.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public int PatientId { get; set; }
        [ValidateNever]
        public Patient Patient { get; set; }

        [Required]
        public int PhysicianId { get; set; }
		[ValidateNever]
		public Physician Physician { get; set; }

        [Required]
        public int AppointmentId { get; set; }
		[ValidateNever]
		public Appointment Appointment { get; set; }

        public string Treatment { get; set; }

        
       

    }
}
