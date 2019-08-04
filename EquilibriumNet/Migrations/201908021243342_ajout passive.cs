namespace EquilibriumNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajoutpassive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeuillePersonnages", "passive", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FeuillePersonnages", "passive");
        }
    }
}
