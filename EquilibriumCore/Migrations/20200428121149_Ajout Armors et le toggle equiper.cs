using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EquilibriumCore.Migrations
{
    public partial class AjoutArmorsetletoggleequiper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Equiper",
                table: "ObjetInventaire",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ArmorPhysical = table.Column<int>(nullable: false),
                    ArmorMagical = table.Column<int>(nullable: false),
                    Special = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.DropColumn(
                name: "Equiper",
                table: "ObjetInventaire");
        }
    }
}
