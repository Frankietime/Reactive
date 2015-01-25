namespace Reactive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Instruments1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instruments",
                c => new
                    {
                        InstrumentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Family = c.String(),
                        MinRange = c.Int(nullable: false),
                        MaxRange = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InstrumentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Instruments");
        }
    }
}
