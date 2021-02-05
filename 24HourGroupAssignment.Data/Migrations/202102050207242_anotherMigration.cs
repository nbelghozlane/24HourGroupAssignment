namespace _24HourGroupAssignment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Like", "NumberOfLikes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Like", "NumberOfLikes", c => c.Int(nullable: false));
        }
    }
}
