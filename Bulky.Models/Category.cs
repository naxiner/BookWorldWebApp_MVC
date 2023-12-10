using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookWorld.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(24)]
        [DisplayName("Назва категорії")]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "Позиція може бути в діапазоні: 1-100.")]
        [DisplayName("Позиція відображення")]
        public int DisplayOrder { get; set; }
    }
}
