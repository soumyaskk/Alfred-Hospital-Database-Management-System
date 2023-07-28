using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AlfredHospital.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Appointment Date")]
        public DateTime AppointmentDate { get; set; } = DateTime.Now;

        [Required]
        [DisplayName("Reason")]
        public string Reason { get; set; }


        [Required]
        public int PatientId { get; set; }
        [ValidateNever]
        public Patient Patient { get; set; }

        [Required]
        public int PhysicianId { get; set; }
		[ValidateNever]
		public Physician Physician { get; set; }

        [Required]
        public int ReceptionistId { get; set; }
		[ValidateNever]
		public Receptionist Receptionist { get; set; }

        [Required]
        public int RoomId { get; set; }
		[ValidateNever]
		public Room Room { get; set; }

    }
}
