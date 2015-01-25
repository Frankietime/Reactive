namespace Reactive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Map : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Maps", "ProcessedMap", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Maps", "ProcessedMap");
        }
    }
}
