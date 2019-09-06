using Microsoft.EntityFrameworkCore.Migrations;

namespace EquilibriumCore.Migrations
{
    public partial class addFroeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComponentForeignKey",
                table: "Component",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Component_ComponentForeignKey",
                table: "Component",
                column: "ComponentForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Component_Spell_ComponentForeignKey",
                table: "Component",
                column: "ComponentForeignKey",
                principalTable: "Spell",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Component_Spell_ComponentForeignKey",
                table: "Component");

            migrationBuilder.DropIndex(
                name: "IX_Component_ComponentForeignKey",
                table: "Component");

            migrationBuilder.DropColumn(
                name: "ComponentForeignKey",
                table: "Component");
        }
    }
}
