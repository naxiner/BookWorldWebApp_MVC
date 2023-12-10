using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorld.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[Display(Name = "Назва")]
		public string Title { get; set; }
		[Display(Name = "Опис")]
		public string Description { get; set; }
		[Required]
		public string ISBN {  get; set; }
		[Required]
		[Display(Name = "Автор")]
		public string Author { get; set; }
		[Required]
		[Display(Name = "Рекомендована ціна")]
		[Range(1, 10000)]
		public double ListPrice { get; set; }

		[Required]
		[Display(Name = "Ціна за 1-50")]
		[Range(1, 10000)]
		public double Price { get; set; }

		[Required]
		[Display(Name = "Ціна за 50+")]
		[Range(1, 10000)]
		public double Price50 { get; set; }

		[Required]
		[Display(Name = "Ціна за 100+")]
		[Range(1, 10000)]
		public double Price100 { get; set; }
		[Display(Name = "Категорія")]
		public int CategoryId { get; set; }
		[ForeignKey("CategoryId")]
		[ValidateNever]
        public Category Category { get; set; }
		[ValidateNever]
		[Display(Name = "Обкладинка")]
		public string ImageUrl { get; set; }
    }
}
