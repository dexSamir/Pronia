using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProniaProject.Migrations
{
    /// <inheritdoc />
    public partial class ProductSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ESize",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ESize",
                table: "Products");
        }
    }
}
