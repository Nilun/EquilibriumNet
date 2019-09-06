using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EquilibriumCore.Migrations
{
    public partial class multtomult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "SpellLinkComponent",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpellID = table.Column<int>(nullable: true),
                    ComponentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellLinkComponent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SpellLinkComponent_Component_ComponentID",
                        column: x => x.ComponentID,
                        principalTable: "Component",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpellLinkComponent_Spell_SpellID",
                        column: x => x.SpellID,
                        principalTable: "Spell",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpellLinkComponent_ComponentID",
                table: "SpellLinkComponent",
                column: "ComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_SpellLinkComponent_SpellID",
                table: "SpellLinkComponent",
                column: "SpellID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpellLinkComponent");

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
    }
}
