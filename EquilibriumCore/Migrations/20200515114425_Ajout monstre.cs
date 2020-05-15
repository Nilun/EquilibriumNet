using Microsoft.EntityFrameworkCore.Migrations;

namespace EquilibriumCore.Migrations
{
    public partial class Ajoutmonstre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Monster",
                table: "Feuilles",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Monster",
                table: "Feuilles");
        }
    }
}
