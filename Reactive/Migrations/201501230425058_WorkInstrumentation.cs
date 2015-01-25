namespace Reactive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkInstrumentation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Works", "Instrumentation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Works", "Instrumentation");
        }
    }
}
