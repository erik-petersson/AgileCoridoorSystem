namespace CorridorSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmig5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CorrUser", "signature", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CorrUser", "signature");
        }
    }
}
