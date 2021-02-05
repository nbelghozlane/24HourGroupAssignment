namespace _24HourGroupAssignment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "NumbersOfLike", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Post", "NumbersOfLike");
        }
    }
}
