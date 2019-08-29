using Microsoft.EntityFrameworkCore.Migrations;

namespace EquilibriumCore.Migrations
{
    public partial class splicecraft : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Craft",
                table: "Feuilles",
                newName: "CraftSW");

            migrationBuilder.AddColumn<int>(
                name: "CraftB",
                table: "Feuilles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CraftM",
                table: "Feuilles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CraftS",
                table: "Feuilles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CraftB",
                table: "Feuilles");

            migrationBuilder.DropColumn(
                name: "CraftM",
                table: "Feuilles");

            migrationBuilder.DropColumn(
                name: "CraftS",
                table: "Feuilles");

            migrationBuilder.RenameColumn(
                name: "CraftSW",
                table: "Feuilles",
                newName: "Craft");
        }
    }
}
