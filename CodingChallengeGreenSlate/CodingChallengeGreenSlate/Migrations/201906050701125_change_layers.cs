namespace CodingChallengeGreenSlate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_layers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProject", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.UserProject", "UserId", "dbo.User");
            AddColumn("dbo.Project", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Project", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Project", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Project", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.UserProject", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserProject", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.UserProject", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserProject", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.User", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.User", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "UpdatedBy", c => c.String(maxLength: 256));
            AddForeignKey("dbo.UserProject", "ProjectId", "dbo.Project", "Id");
            AddForeignKey("dbo.UserProject", "UserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProject", "UserId", "dbo.User");
            DropForeignKey("dbo.UserProject", "ProjectId", "dbo.Project");
            DropColumn("dbo.User", "UpdatedBy");
            DropColumn("dbo.User", "UpdatedDate");
            DropColumn("dbo.User", "CreatedBy");
            DropColumn("dbo.User", "CreatedDate");
            DropColumn("dbo.UserProject", "UpdatedBy");
            DropColumn("dbo.UserProject", "UpdatedDate");
            DropColumn("dbo.UserProject", "CreatedBy");
            DropColumn("dbo.UserProject", "CreatedDate");
            DropColumn("dbo.Project", "UpdatedBy");
            DropColumn("dbo.Project", "UpdatedDate");
            DropColumn("dbo.Project", "CreatedBy");
            DropColumn("dbo.Project", "CreatedDate");
            AddForeignKey("dbo.UserProject", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserProject", "ProjectId", "dbo.Project", "Id", cascadeDelete: true);
        }
    }
}
