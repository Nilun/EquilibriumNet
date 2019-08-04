using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EquilibriumCore.Migrations
{
    public partial class Initiali : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feuilles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    HPPerLevel = table.Column<int>(nullable: false),
                    HPNow = table.Column<int>(nullable: false),
                    MemoryBonus = table.Column<int>(nullable: false),
                    OneHand = table.Column<int>(nullable: false),
                    LOneHand = table.Column<int>(nullable: false),
                    TwoHand = table.Column<int>(nullable: false),
                    Throw = table.Column<int>(nullable: false),
                    Bow = table.Column<int>(nullable: false),
                    Body = table.Column<int>(nullable: false),
                    Parry = table.Column<int>(nullable: false),
                    Elem = table.Column<int>(nullable: false),
                    Occult = table.Column<int>(nullable: false),
                    Primordial = table.Column<int>(nullable: false),
                    Metamagic = table.Column<int>(nullable: false),
                    Infusion = table.Column<int>(nullable: false),
                    Resist = table.Column<int>(nullable: false),
                    MagicIdentif = table.Column<int>(nullable: false),
                    Stealth = table.Column<int>(nullable: false),
                    Survival = table.Column<int>(nullable: false),
                    Perception = table.Column<int>(nullable: false),
                    Speech = table.Column<int>(nullable: false),
                    History = table.Column<int>(nullable: false),
                    Medic = table.Column<int>(nullable: false),
                    Empath = table.Column<int>(nullable: false),
                    Athletism = table.Column<int>(nullable: false),
                    Acrobatics = table.Column<int>(nullable: false),
                    Craft = table.Column<int>(nullable: false),
                    Intimidation = table.Column<int>(nullable: false),
                    passive = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feuilles", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feuilles");
        }
    }
}
