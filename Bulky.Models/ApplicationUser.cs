using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorld.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		[Display(Name = "Ім'я")]
		public string Name { get; set; }
		public string? StreetAdress { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? PostalCode { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
		[ValidateNever]
		public Company? Company { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}
