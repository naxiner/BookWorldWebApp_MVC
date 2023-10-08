using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookWorld.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class addProductsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(24)",
                maxLength: 24,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Артур Конан Дойль", "Збірка захоплюючих детективних розслідувань відомого сищика Шерлока Холмса та його надільного друга Доктора Ватсона.", "978-0486223757", 12.99, 12.99, 10.0, 11.5, "Пригоди Шерлока Холмса" },
                    { 2, "Джордж Орвелл", "Антиутопічний роман, який описує життя в тоталітарному суспільстві, де кожен рух та слово контролюються державою.", "978-0451524935", 14.99, 14.99, 12.0, 13.5, "1984" },
                    { 3, "Джордж Р. Р. Мартін", "Епічна фентезі-сага про боротьбу за владу в країні Вестерос.", "978-0553103540", 18.989999999999998, 18.989999999999998, 15.0, 17.0, "Гра престолів" },
                    { 4, "Дж. К. Роулінг", "Початок пригод молодого чаклуна Гаррі Поттера в чарівному світі.", "978-0590353403", 16.989999999999998, 16.989999999999998, 13.5, 15.0, "Гаррі Поттер і Філософський камінь" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)",
                oldMaxLength: 24);
        }
    }
}
