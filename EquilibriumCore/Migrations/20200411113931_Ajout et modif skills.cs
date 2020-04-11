using Microsoft.EntityFrameworkCore.Migrations;

namespace EquilibriumCore.Migrations
{
    public partial class Ajoutetmodifskills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Metamagic",
                table: "Feuilles");

            migrationBuilder.AddColumn<int>(
                name: "AnimalH",
                table: "Feuilles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Art",
                table: "Feuilles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disrupt",
                table: "Feuilles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MageWeap",
                table: "Feuilles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShadowCraft",
                table: "Feuilles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Teaching",
                table: "Feuilles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalH",
                table: "Feuilles");

            migrationBuilder.DropColumn(
                name: "Art",
                table: "Feuilles");

            migrationBuilder.DropColumn(
                name: "Disrupt",
                table: "Feuilles");

            migrationBuilder.DropColumn(
                name: "MageWeap",
                table: "Feuilles");

            migrationBuilder.DropColumn(
                name: "ShadowCraft",
                table: "Feuilles");

            migrationBuilder.DropColumn(
                name: "Teaching",
                table: "Feuilles");

            migrationBuilder.AddColumn<int>(
                name: "Metamagic",
                table: "Feuilles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
