namespace CodingChallengeGreenSlate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_Calculated_Columns_Second : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserProject", "StartDate");
            DropColumn("dbo.UserProject", "Status");
            DropColumn("dbo.UserProject", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProject", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserProject", "Status", c => c.String());
            AddColumn("dbo.UserProject", "StartDate", c => c.String());
        }
    }
}
