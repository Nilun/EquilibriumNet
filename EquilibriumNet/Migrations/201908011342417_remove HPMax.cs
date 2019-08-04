namespace EquilibriumNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeHPMax : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FeuillePersonnages", "HPMax");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FeuillePersonnages", "HPMax", c => c.Int(nullable: false));
        }
    }
}
