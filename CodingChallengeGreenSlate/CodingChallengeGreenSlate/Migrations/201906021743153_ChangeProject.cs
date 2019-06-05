namespace CodingChallengeGreenSlate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProject : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Project", "Credits", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Project", "Credits", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
    }
}
