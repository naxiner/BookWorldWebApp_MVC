using System.ComponentModel.DataAnnotations;

namespace BookWorld.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
		[Display(Name = "Назва")]
		public string Name { get; set; }
        [Display(Name = "Адреса")]
        public string? StreetAdress { get; set; }
		[Display(Name = "Місто")]
		public string? City { get; set; }
		[Display(Name = "Країна")]
		public string? State { get; set; }
        [Display(Name = "Поштовий індекс")]
        public string? PostalCode { get; set; }
        [Display(Name = "Номер телефону")]
        public string? PhoneNumber { get; set; }
    }
}
