using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Reactive.Models
{
    public class Note   // Notas con valores en escala 0 a 127 obtenidos del analisis de una melodía MIDI
    {
        [Key]
        public int NoteID { get; set; }
        public int WorkID { get; set; }
        public int Pitch { get; set; }
        public int Velocity { get; set; }
        public int Rhythm { get; set; }
        public int Start { get; set; }  // Tiempo en el que se ataca la nota
        public int InstrumentID { get; set; }
    }
}

