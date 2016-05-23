namespace CorridorSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmig3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CorrUser", "schedule_Id", c => c.Int());
            CreateIndex("dbo.CorrUser", "schedule_Id");
            AddForeignKey("dbo.CorrUser", "schedule_Id", "dbo.scheduleModel", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CorrUser", "schedule_Id", "dbo.scheduleModel");
            DropIndex("dbo.CorrUser", new[] { "schedule_Id" });
            DropColumn("dbo.CorrUser", "schedule_Id");
        }
    }
}
