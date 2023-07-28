using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AlfredHospital.Models
{
    public class Nurse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        
        public string Role { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNum { get; set; }

        [Required]

        public string Address { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        // Navigation Property
        /*
                public IEnumerable<Appointment> Appointments { get; set; }
                public IEnumerable<Billing>  Billings { get; set; }
        */

    }
}
