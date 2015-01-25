using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Reactive.Models
{
   class ReactiveContext : DbContext
    {
        public ReactiveContext() : base("DefaultConnection")
        {

        }

        public DbSet<Note> Notes { get; set;}
        public DbSet<Map> Maps { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Instrument> Instruments { get; set; }

    }
}
