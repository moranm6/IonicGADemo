namespace ScoreboardServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingVotes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        VoteId = c.Int(nullable: false, identity: true),
                        Player_PlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VoteId)
                .ForeignKey("dbo.Players", t => t.Player_PlayerId, cascadeDelete: true)
                .Index(t => t.Player_PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "Player_PlayerId", "dbo.Players");
            DropIndex("dbo.Votes", new[] { "Player_PlayerId" });
            DropTable("dbo.Votes");
        }
    }
}
