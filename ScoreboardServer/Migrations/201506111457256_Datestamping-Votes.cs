namespace ScoreboardServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatestampingVotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Votes", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Votes", "CreatedAt");
        }
    }
}
