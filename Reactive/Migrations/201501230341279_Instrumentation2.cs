namespace Reactive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Instrumentation2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Maps", "Instrumentation", c => c.String(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Maps", "Instrumentation");
        }
    }
}
