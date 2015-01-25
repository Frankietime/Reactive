namespace Reactive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Maps",
                c => new
                    {
                        MapID = c.Int(nullable: false, identity: true),
                        Length = c.Int(nullable: false),
                        Type = c.String(),
                        WorkID = c.String(),
                    })
                .PrimaryKey(t => t.MapID);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteID = c.Int(nullable: false, identity: true),
                        Pitch = c.Int(nullable: false),
                        Velocity = c.Int(nullable: false),
                        Rhythm = c.Int(nullable: false),
                        Start = c.Int(nullable: false),
                        InstrumentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NoteID);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        WorkID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author = c.String(),
                        Style = c.String(),
                        Length = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Works");
            DropTable("dbo.Notes");
            DropTable("dbo.Maps");
        }
    }
}
