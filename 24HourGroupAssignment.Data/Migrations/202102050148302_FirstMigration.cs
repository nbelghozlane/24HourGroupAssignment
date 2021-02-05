namespace _24HourGroupAssignment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        LikeId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        NumberOfLikes = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.LikeId)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Like", "PostId", "dbo.Post");
            DropIndex("dbo.Like", new[] { "PostId" });
            DropTable("dbo.Like");
        }
    }
}
