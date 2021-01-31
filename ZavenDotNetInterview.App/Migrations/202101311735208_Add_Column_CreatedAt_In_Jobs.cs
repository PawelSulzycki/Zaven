﻿namespace ZavenDotNetInterview.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Column_CreatedAt_In_Jobs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "CreatedAt");
        }
    }
}
