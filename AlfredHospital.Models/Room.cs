using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AlfredHospital.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Room Type")]
        public string RoomType { get; set; }

        [Required]
        
        public int Capacity { get; set; }

        [Required]
        
        public string Status { get; set; }

        [Required]
        public int NurseId { get; set; }

		[ValidateNever]
		public Nurse Nurse { get; set; }
       

    }
}
