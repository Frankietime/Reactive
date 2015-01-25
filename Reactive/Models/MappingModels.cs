using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Reactive.Models
{
    // Define las caracteristicas generales del mapa para el proyecto actual.
    public class Map
    {
        public int MapID { get; set; }
        public int Length { get; set; }
        public string Type { get; set; }
        public string Instrumentation { get; set; }
        public bool ProcessedMap { get; set; }
        public string WorkID { get; set; } // ID de la obra con la que trabaja este Mapa. El ID esta almacenado en la tabala Works
    }
    public class Instrument
    {
        public int InstrumentID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
    }
    public interface IEvent
    {
        int Start { get; set; }
        int End { get; set; }
        int Hierarchy { get; set; }
    }
//    public class Case : IEvent
//    {
            
//    }
}

