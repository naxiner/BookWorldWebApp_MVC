using BookWorld.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookWorld.DataAcess.Data
{
	public class ApplicationDbContext : IdentityDbContext<IdentityUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<ApplicationUser> ApplicationUser { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Detective", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Пригоди Шерлока Холмса",
                    Description = "Збірка захоплюючих детективних розслідувань відомого " +
					"сищика Шерлока Холмса та його надільного друга Доктора Ватсона.",
                    ISBN = "978-0486223757",
                    Author = "Артур Конан Дойль",
                    ListPrice = 12.99,
                    Price = 12.99,
                    Price50 = 11.5,
                    Price100 = 10,
					CategoryId = 2,
					ImageUrl = ""
                },
				new Product
				{
					Id = 2,
					Title = "1984",
					Description = "Антиутопічний роман, який описує життя в тоталітарному " +
					"суспільстві, де кожен рух та слово контролюються державою.",
					ISBN = "978-0451524935",
					Author = "Джордж Орвелл",
					ListPrice = 14.99,
					Price = 14.99,
					Price50 = 13.5,
					Price100 = 12.0,
					CategoryId = 1,
					ImageUrl = ""
				},
				new Product
				{
					Id = 3,
					Title = "Гра престолів",
					Description = "Епічна фентезі-сага про боротьбу за владу в країні Вестерос.",
					ISBN = "978-0553103540",
					Author = "Джордж Р. Р. Мартін",
					ListPrice = 18.99,
					Price = 18.99,
					Price50 = 17.0,
					Price100 = 15.0,
					CategoryId = 1,
					ImageUrl = ""
				},
				new Product
				{
					Id = 4,
					Title = "Гаррі Поттер і Філософський камінь",
					Description = "Початок пригод молодого чаклуна Гаррі Поттера в чарівному світі.",
					ISBN = "978-0590353403",
					Author = "Дж. К. Роулінг",
					ListPrice = 16.99,
					Price = 16.99,
					Price50 = 15.0,
					Price100 = 13.5,
					CategoryId = 1,
					ImageUrl = ""
				}
				);
        }
    }
}
