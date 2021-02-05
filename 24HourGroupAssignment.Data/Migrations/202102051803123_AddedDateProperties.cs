namespace _24HourGroupAssignment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Comment", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comment", "ModifiedUtc");
            DropColumn("dbo.Comment", "CreatedUtc");
        }
    }
}
