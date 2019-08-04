namespace EquilibriumNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addskillsinfp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FeuillePersonnages", "skills_ID", "dbo.FeuilleSkills");
            DropIndex("dbo.FeuillePersonnages", new[] { "skills_ID" });
            AddColumn("dbo.FeuillePersonnages", "OneHand", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "LOneHand", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "TwoHand", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Throw", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Bow", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Body", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Parry", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Elem", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Occult", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Primordial", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Metamagic", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Infusion", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Resist", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "MagicIdentif", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Stealth", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Survival", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Perception", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Speech", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "History", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Medic", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Empath", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Athletism", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Acrobatics", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Craft", c => c.Int(nullable: false));
            AddColumn("dbo.FeuillePersonnages", "Intimidation", c => c.Int(nullable: false));
            DropColumn("dbo.FeuillePersonnages", "skills_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FeuillePersonnages", "skills_ID", c => c.Int());
            DropColumn("dbo.FeuillePersonnages", "Intimidation");
            DropColumn("dbo.FeuillePersonnages", "Craft");
            DropColumn("dbo.FeuillePersonnages", "Acrobatics");
            DropColumn("dbo.FeuillePersonnages", "Athletism");
            DropColumn("dbo.FeuillePersonnages", "Empath");
            DropColumn("dbo.FeuillePersonnages", "Medic");
            DropColumn("dbo.FeuillePersonnages", "History");
            DropColumn("dbo.FeuillePersonnages", "Speech");
            DropColumn("dbo.FeuillePersonnages", "Perception");
            DropColumn("dbo.FeuillePersonnages", "Survival");
            DropColumn("dbo.FeuillePersonnages", "Stealth");
            DropColumn("dbo.FeuillePersonnages", "MagicIdentif");
            DropColumn("dbo.FeuillePersonnages", "Resist");
            DropColumn("dbo.FeuillePersonnages", "Infusion");
            DropColumn("dbo.FeuillePersonnages", "Metamagic");
            DropColumn("dbo.FeuillePersonnages", "Primordial");
            DropColumn("dbo.FeuillePersonnages", "Occult");
            DropColumn("dbo.FeuillePersonnages", "Elem");
            DropColumn("dbo.FeuillePersonnages", "Parry");
            DropColumn("dbo.FeuillePersonnages", "Body");
            DropColumn("dbo.FeuillePersonnages", "Bow");
            DropColumn("dbo.FeuillePersonnages", "Throw");
            DropColumn("dbo.FeuillePersonnages", "TwoHand");
            DropColumn("dbo.FeuillePersonnages", "LOneHand");
            DropColumn("dbo.FeuillePersonnages", "OneHand");
            CreateIndex("dbo.FeuillePersonnages", "skills_ID");
            AddForeignKey("dbo.FeuillePersonnages", "skills_ID", "dbo.FeuilleSkills", "ID");
        }
    }
}
