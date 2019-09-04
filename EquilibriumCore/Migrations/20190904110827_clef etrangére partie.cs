using Microsoft.EntityFrameworkCore.Migrations;

namespace EquilibriumCore.Migrations
{
    public partial class clefetrangérepartie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "partie",
                table: "Feuilles");

            migrationBuilder.AddColumn<int>(
                name: "IDPartie",
                table: "Feuilles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDPartie",
                table: "Feuilles");

            migrationBuilder.AddColumn<string>(
                name: "partie",
                table: "Feuilles",
                nullable: true);
        }
    }
}
