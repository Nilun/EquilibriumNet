using Microsoft.EntityFrameworkCore.Migrations;

namespace EquilibriumCore.Migrations
{
    public partial class ajouttechinvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Stuff",
                table: "Feuilles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "comp",
                table: "Feuilles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stuff",
                table: "Feuilles");

            migrationBuilder.DropColumn(
                name: "comp",
                table: "Feuilles");
        }
    }
}
