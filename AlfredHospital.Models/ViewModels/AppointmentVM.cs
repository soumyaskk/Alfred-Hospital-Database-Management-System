using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfredHospital.Models.ViewModels
{
	public class AppointmentVM
	{
		public Appointment Appointment { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> PatientList { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> PhysicianList { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> ReceptionistList { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> RoomList { get; set; }
	}
}
