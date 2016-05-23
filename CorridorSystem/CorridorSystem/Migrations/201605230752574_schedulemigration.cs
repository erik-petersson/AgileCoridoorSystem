namespace CorridorSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schedulemigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.eventModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DTEnd = c.DateTime(nullable: false),
                        DTStart = c.DateTime(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        DTStamp = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        Summary = c.String(),
                        Location = c.String(),
                        externalId = c.String(),
                        scheduleModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.scheduleModel", t => t.scheduleModel_Id)
                .Index(t => t.scheduleModel_Id);
            
            CreateTable(
                "dbo.scheduleModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        signature = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CorrUser", "signature", c => c.String(nullable: false));
            AddColumn("dbo.CorrUser", "schedule_Id", c => c.Int());
            CreateIndex("dbo.CorrUser", "schedule_Id");
            AddForeignKey("dbo.CorrUser", "schedule_Id", "dbo.scheduleModel", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CorrUser", "schedule_Id", "dbo.scheduleModel");
            DropForeignKey("dbo.eventModel", "scheduleModel_Id", "dbo.scheduleModel");
            DropIndex("dbo.CorrUser", new[] { "schedule_Id" });
            DropIndex("dbo.eventModel", new[] { "scheduleModel_Id" });
            DropColumn("dbo.CorrUser", "schedule_Id");
            DropColumn("dbo.CorrUser", "signature");
            DropTable("dbo.scheduleModel");
            DropTable("dbo.eventModel");
        }
    }
}
