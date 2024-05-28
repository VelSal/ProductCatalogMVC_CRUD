using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductCatalog.Migrations
{
    /// <inheritdoc />
    public partial class AddedcurrencyDatatypeforPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreateProductViewModel",
                columns: table => new
                {
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreateProductViewModel");
        }
    }
}
