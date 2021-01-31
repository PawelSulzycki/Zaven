namespace ZavenDotNetInterview.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Column_FailureCounter_In_Jobs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "FailureCounter", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "FailureCounter");
        }
    }
}
