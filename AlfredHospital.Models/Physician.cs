using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfredHospital.Models
{
	public class Physician
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
		
		public string Department { get; set; }

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
