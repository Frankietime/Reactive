using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Reactive.Models;

namespace Reactive.ConsoleInterface
{
    class ConsoleApp
    {

        public ConsoleApp()
        {

        }
        
        
        // Métodos que organizan visualmente la aplicación
        public void LongHr()
        {
            Console.WriteLine("------------------------------------------------");
        }
        public void ShortHr()
        {
            Console.WriteLine("--------------------------");
        }
        public void Br()
        {
            Console.WriteLine("");
        }
        public void ReactiveMelody()
        {
            Dictionary<int, int> Melo = new Dictionary<int, int>();
            Melo.Add(1000,500);
            Melo.Add(38, 500);
            Melo.Add(350,400);
            Melo.Add(570,200);
            Melo.Add(810,200);
            Melo.Add(921,500);
            Melo.Add(37, 500);
            Melo.Add(250,200);
            Melo.Add(251,200);

            foreach (var m in Melo)
            {
                Console.Beep(m.Key, m.Value);
            }
        }
        public void Title0(string title0)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.LongHr();
            int n = 48 - title0.Length;
            string spaces = "";
            for (int i = 0; i < n; i++)
            {
                spaces += " ";
            }
                Console.WriteLine(title0 + spaces);
                this.LongHr();
                Console.ResetColor();
                this.Br();
        }
        public void Title1(string title1)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Red;
            this.LongHr();
            int n = 48 - title1.Length;
            string spaces = "";
            for (int i = 0; i < n; i++)
            {
                spaces += " ";
            }
                Console.WriteLine(title1 + spaces);
                this.LongHr();
                Console.ResetColor();
                this.Br();
        }
        public void Title2(string title2)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Magenta;
            this.LongHr();
            int n = 48 - title2.Length;
            string spaces = "";
            for (int i = 0; i < n; i++)
            {
                spaces += " ";
            }
                Console.WriteLine(title2 + spaces);
                this.LongHr();
                Console.ResetColor();
                this.Br();
        }
        public void Run() // Menú principal
        {
            ReactiveContext reactiveDB = new ReactiveContext();
            this.ReactiveMelody();
            this.Title0("Reactive: IA para composición");
            Console.ForegroundColor = ConsoleColor.Yellow;
            this.Br();
            this.Br();
            this.Br();
            this.Br();
            this.Br();
            this.Br();
            this.Br();
            this.Br();
            this.Br();
            Console.WriteLine("Menú Principal");
            Console.ResetColor();
            this.Br();
            this.ShortHr();
            Console.WriteLine("Seleccione una opción...");
            this.ShortHr();
            Console.WriteLine("1. Reactive Manual");
            Console.WriteLine("2. Comenzar Composición");
            Console.WriteLine("3. Configuración");
            Console.WriteLine("4. Correr Programa Predeterminado");
            Console.WriteLine("5. Terminar Aplicación");
            this.ShortHr();

            switch (this.OptionCheck(1, 5))
            {
                case 1:
                    Console.WriteLine("TO MANUAL");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("TO COMPOSE");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("TO CONFIG");
                    Console.ReadKey();
                    break;
                case 4:
                    this.Br();
                    this.RunDefault();
                    break;
                case 5:
                    Console.WriteLine("Presione cualquier tecla para finalizar la aplicación");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }

        private void RunDefault()
        {
            this.Title1("Inicializando Programa Predeterminado...");
            Console.WriteLine("Este programa trabajara con:\n Obra => WorkID = 1, Nombre = Secuencia_1\n Mapa => MapID = 1");
            this.Br();
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            this.Br();
            Console.Beep(800, 300);
            this.Title1("Etapa 1: VALIDACIÓN DEL INPUT");
            this.DefaultInputValidation(1);
        }

        private void DefaultInputValidation(int WorkID)
        {
            ReactiveContext reactiveDB = new ReactiveContext();
            List<string> errors = new List<string>(); // Almacena los errores obtenidos durante la validación
            this.Br();
            this.Title2("Obteniendo tablas...");
            this.Br();
            // Obra
            var Work = (from w in reactiveDB.Works
                       where w.WorkID == WorkID
                       select w).First();
            Console.WriteLine(">>> " + Work.Name);
            // Instrumentacion
            string[] Instr = Work.Instrumentation.Split('|');
            List<int> Instrumentation = new List<int>();

            foreach(var instr in Instr)
            {
                Instrumentation.Add(Convert.ToInt32(instr));
                Console.WriteLine(">>> " + instr);
            }
            // Recursos (por ahora los instrumentos solo generan Notas)
            var Notes = from n in reactiveDB.Notes
                       where n.WorkID == Work.WorkID
                       select n;
            Console.WriteLine(">>> Notas");
            // Rutina de Validación Instrumento | Recursos
            this.Br();
            foreach (int id in Instrumentation)
            {
                var CurrentInstrument = (from ci in reactiveDB.Instruments
                                         where ci.InstrumentID == id
                                         select ci).First();
                // Primero validamos aquellas propiedades comunes a todos los instrumentos
                this.Br();
                this.Title2("Validando Pitch para instrumento " + CurrentInstrument.InstrumentID + "...");
                foreach (var n in Notes)
                {
                    if (n.Pitch < CurrentInstrument.MinRange)
                    {
                        string error = "La nota [" + n.NoteID + "] del instrumento [" + CurrentInstrument.Name + "-" + CurrentInstrument.InstrumentID + "] no respeta el rango mínimo disponible";
                        errors.Add(error);
                    }
                    if (n.Pitch > CurrentInstrument.MaxRange)
                    {
                        string error = "La nota [" + n.NoteID + "] del instrumento [" + CurrentInstrument.Name + "-" + CurrentInstrument.InstrumentID + "] no respeta el rango máximo disponible";
                        errors.Add(error);
                    }
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Listo");
                Console.ResetColor();

                // Luego llamamos a los metodos de validación especificos de cada tipo de instrumento
                this.Title2("Validando recursos para instrumento " + CurrentInstrument.InstrumentID + "...");
                switch (CurrentInstrument.InstrumentID)
                {
                    case 1: // Metodo de validacion de recursos especificos, requiere pasar errors
                    case 2: // Metodo de validacion de recursos especificos, requiere pasar errors
                    case 3: // Metodo de validacion de recursos especificos, requiere pasar errors
                    case 4: // Metodo de validacion de recursos especificos, requiere pasar errors
                    case 5: // Metodo de validacion de recursos especificos, requiere pasar errors
                    case 6: // Metodo de validacion de recursos especificos, requiere pasar errors
                    default:
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Listo");
                Console.ResetColor();

                this.Br();
                if (errors.Count() > 0)
                {
                    Console.WriteLine("Presione ENTER para ver el sumario de errores");
                    Console.ReadKey();
                    this.Br();
                    foreach (var e in errors)
                    {
                        Console.WriteLine(e);
                    }
                    this.LongHr();
                    Console.WriteLine("Presione cualquier tecla para volver al menú principal");
                    Console.ReadKey();
                    this.Run();
                }
                else
                {
                    Console.WriteLine("No se han encontrado errores, presione cualquier tecla para continuar");
                    Console.ReadKey();
                    this.LongHr();
                    this.Br();
                    this.Analysis();
                }
            }
        }

        private void Analysis()
        {
            this.Title1("Etapa 2: ANALISIS");
            this.Br();

        }

        // Chequea que el valor no supere la cantidad de opciones ni 
        private int OptionCheck(int min, int max)
        {
            try
            {
                int input = Convert.ToInt16(Console.ReadLine());
                if (input < min || input > max)
                {
                    Console.WriteLine("El valor ingresado no es válido, vuelva a ingresar un valor");
                    this.OptionCheck(min, max);
                    return input;
                }
                else
                {
                    return input;
                }
            }
            catch
            {
               return this.OptionCheck(min, max);
            }
        }
    }
}
