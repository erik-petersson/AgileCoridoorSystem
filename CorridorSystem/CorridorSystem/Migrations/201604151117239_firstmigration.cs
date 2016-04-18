namespace CorridorSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserType = c.Int(nullable: false),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }

        public override void Down()
        {
            DropTable("dbo.User");
        }
    }
}
