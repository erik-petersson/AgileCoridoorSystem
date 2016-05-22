namespace CorridorSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.eventModel", "externalId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.eventModel", "externalId");
        }
    }
}
