using Microsoft.EntityFrameworkCore.Migrations;

namespace EquilibriumCore.Migrations
{
    public partial class addnameforspell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Spell",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Spell");
        }
    }
}
