namespace CorridorSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigagain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.eventModel", "scheduleModel_Id", c => c.Int());
            AddColumn("dbo.scheduleModel", "signature", c => c.String());
            CreateIndex("dbo.eventModel", "scheduleModel_Id");
            AddForeignKey("dbo.eventModel", "scheduleModel_Id", "dbo.scheduleModel", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.eventModel", "scheduleModel_Id", "dbo.scheduleModel");
            DropIndex("dbo.eventModel", new[] { "scheduleModel_Id" });
            DropColumn("dbo.scheduleModel", "signature");
            DropColumn("dbo.eventModel", "scheduleModel_Id");
        }
    }
}
