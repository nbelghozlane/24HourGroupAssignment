namespace _24HourGroupAssignment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Post", "NumbersOfLike");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "NumbersOfLike", c => c.Int(nullable: false));
        }
    }
}
