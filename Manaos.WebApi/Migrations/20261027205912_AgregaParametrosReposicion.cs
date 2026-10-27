using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manaos.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AgregaParametrosReposicion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockMaximo",
                table: "StocksBodegas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EsPrincipal",
                table: "Bodegas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockMaximo",
                table: "StocksBodegas");

            migrationBuilder.DropColumn(
                name: "EsPrincipal",
                table: "Bodegas");
        }
    }
}
