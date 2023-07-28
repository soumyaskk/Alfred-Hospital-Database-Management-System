using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AlfredHospital.Models
{
    public class Receptionist
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
        [DisplayName("Receptionist Counter")]
        public string ReceptionistCounter { get; set; }

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

       
    }
}
