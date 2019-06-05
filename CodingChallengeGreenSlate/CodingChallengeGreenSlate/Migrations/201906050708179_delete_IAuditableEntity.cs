namespace CodingChallengeGreenSlate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_IAuditableEntity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Project", "CreatedDate");
            DropColumn("dbo.Project", "CreatedBy");
            DropColumn("dbo.Project", "UpdatedDate");
            DropColumn("dbo.Project", "UpdatedBy");
            DropColumn("dbo.UserProject", "CreatedDate");
            DropColumn("dbo.UserProject", "CreatedBy");
            DropColumn("dbo.UserProject", "UpdatedDate");
            DropColumn("dbo.UserProject", "UpdatedBy");
            DropColumn("dbo.User", "CreatedDate");
            DropColumn("dbo.User", "CreatedBy");
            DropColumn("dbo.User", "UpdatedDate");
            DropColumn("dbo.User", "UpdatedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.User", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.User", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserProject", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.UserProject", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserProject", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.UserProject", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Project", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Project", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Project", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Project", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
