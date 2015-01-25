namespace Reactive.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Reactive.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Reactive.Models.ReactiveContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Reactive.Models.ReactiveContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Notes.AddOrUpdate(
            new Note { Pitch = 122, Rhythm = 1, Start = 0, Velocity = 127, InstrumentID = 0},
            new Note { Pitch = 87, Rhythm = 2, Start = 1, Velocity = 68, InstrumentID = 0 },
            new Note { Pitch = 70, Rhythm = 4 , Start = 3, Velocity = 80, InstrumentID = 0},
            new Note { Pitch = 21, Rhythm = 2, Start = 7, Velocity = 42, InstrumentID = 0}
            );
            
        }
    }
}
