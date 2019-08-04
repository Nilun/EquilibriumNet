namespace EquilibriumNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removefocusandaddskills : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeuilleSkills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OneHand = c.Int(nullable: false),
                        LOneHand = c.Int(nullable: false),
                        TwoHand = c.Int(nullable: false),
                        Throw = c.Int(nullable: false),
                        Bow = c.Int(nullable: false),
                        Body = c.Int(nullable: false),
                        Parry = c.Int(nullable: false),
                        Elem = c.Int(nullable: false),
                        Occult = c.Int(nullable: false),
                        Primordial = c.Int(nullable: false),
                        Metamagic = c.Int(nullable: false),
                        Infusion = c.Int(nullable: false),
                        Resist = c.Int(nullable: false),
                        MagicIdentif = c.Int(nullable: false),
                        Stealth = c.Int(nullable: false),
                        Survival = c.Int(nullable: false),
                        Perception = c.Int(nullable: false),
                        Speech = c.Int(nullable: false),
                        History = c.Int(nullable: false),
                        Medic = c.Int(nullable: false),
                        Empath = c.Int(nullable: false),
                        Athletism = c.Int(nullable: false),
                        Acrobatics = c.Int(nullable: false),
                        Craft = c.Int(nullable: false),
                        Intimidation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.FeuillePersonnages", "skills_ID", c => c.Int());
            CreateIndex("dbo.FeuillePersonnages", "skills_ID");
            AddForeignKey("dbo.FeuillePersonnages", "skills_ID", "dbo.FeuilleSkills", "ID");
            DropColumn("dbo.FeuillePersonnages", "Memory");
            DropColumn("dbo.FeuillePersonnages", "Brutality");
            DropColumn("dbo.FeuillePersonnages", "Swiftness");
            DropColumn("dbo.FeuillePersonnages", "Spirit");
            DropColumn("dbo.FeuillePersonnages", "Malice");
            DropColumn("dbo.FeuillePersonnages", "Vitality");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FeuillePersonnages", "Vitality", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Malice", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Spirit", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Swiftness", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Brutality", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Memory", c => c.Int(nullable: false));
            DropForeignKey("dbo.FeuillePersonnages", "skills_ID", "dbo.FeuilleSkills");
            DropIndex("dbo.FeuillePersonnages", new[] { "skills_ID" });
            DropColumn("dbo.FeuillePersonnages", "skills_ID");
            DropTable("dbo.FeuilleSkills");
        }
    }
}
