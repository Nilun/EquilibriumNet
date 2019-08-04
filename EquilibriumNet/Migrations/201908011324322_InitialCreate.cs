namespace EquilibriumNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeuillePersonnages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Race = c.String(),
                        Level = c.Int(nullable: false),
                        HPPerLevel = c.Int(nullable: false),
                        HPNow = c.Int(nullable: false),
                        HPMax = c.Int(nullable: false),
                        MemoryBonus = c.Int(nullable: false),
                        Memory = c.Int(nullable: false),
                        Brutality = c.Int(nullable: false),
                        Swiftness = c.Int(nullable: false),
                        Spirit = c.Int(nullable: false),
                        Malice = c.Int(nullable: false),
                        Vitality = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FeuillePersonnages");
        }
    }
}
