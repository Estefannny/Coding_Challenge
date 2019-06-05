namespace CodingChallengeGreenSlate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Calculated_Columns_Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProject", "StartDate", c => c.String());
            AddColumn("dbo.UserProject", "Status", c => c.String());
            AddColumn("dbo.UserProject", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProject", "EndDate");
            DropColumn("dbo.UserProject", "Status");
            DropColumn("dbo.UserProject", "StartDate");
        }
    }
}
