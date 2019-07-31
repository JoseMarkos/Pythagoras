using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ox
{
    class Program
    {
        static void Main(string[] args)
        {
            Box boxOptions = new Box();
            boxOptions.SetBoxTitle("Ox");
            boxOptions.SetDate("29.07.2019");

            string[] options =
            {
                "Calcular Cateto Adyacente",
                "Calcular Cateto Opuesto",
                "Calcular Hipotenusa"
            };

            // Tarea 2

            Queue<double> CatetosOpuestos = new Queue<double>();

            Stack<double> CatetosAdyacentes = new Stack<double>();

            List<double> Hipotenusas = new List<double>();

            List<object> Lista = new List<object>();

            //


            boxOptions.RenderMenu(options);

            SelectOption(options, CatetosOpuestos, CatetosAdyacentes, Hipotenusas, Lista);
            WantContinue("Seguir calculando? ", boxOptions, options, CatetosOpuestos, CatetosAdyacentes, Hipotenusas, Lista);
        }

        
        // Selection 

        public static void SelectOption(string[] options, Queue<double> opuestos, Stack<double> adyacentes, List<double> hi, List<object> lista)
        {
            double input = Utils.AskForDouble("");
            Pythagoras Ox = new Pythagoras();

            switch (input)
            {
                case 1:
                    Ox.AssingLeg("Opuesto");
                    Ox.AssingH();

                    Ox.CalculateA();

                    Console.WriteLine();
                    Console.WriteLine("El cateto Adyacente es: " + Ox.GetA());

                    // Tarea 2
                    opuestos.Enqueue(Ox.GetLeg());
                    adyacentes.Push(Ox.GetA());
                    hi.Add(Ox.GetH());
                    //
                    break;

                case 2:
                    Ox.AssingLeg("Adyacente");
                    Ox.AssingH();

                    Ox.CalculateB();

                    Console.WriteLine();
                    Console.WriteLine("El cateto Opuesto es: " + Ox.GetB());
                    
                    // Tarea 2
                    opuestos.Enqueue(Ox.GetB());
                    adyacentes.Push(Ox.GetLeg());
                    hi.Add(Ox.GetH());
                    // 
                    break;

                case 3:

                    Ox.AssingA();
                    Ox.AssingB();

                    Ox.CalculateH();

                    Console.WriteLine();
                    Console.WriteLine("La Hipotenusa es: " + Ox.GetH());
                  
                    // Tarea 2
                    opuestos.Enqueue(Ox.GetB());
                    adyacentes.Push(Ox.GetA());
                    hi.Add(Ox.GetH());
                    //
                    break;

                default:
                    Console.WriteLine("Ingrese una opcion valida!");
                    SelectOption(options, opuestos, adyacentes, hi, lista);
                    break;
            }

            // Tarea 2
            lista.Add(opuestos);
            lista.Add(adyacentes);
            lista.Add(hi);
            //
        }

        // Continue

        public static void WantContinue(string message, Box boxOp, string[] options, Queue<double> opuestos, Stack<double> adyacentes, List<double> hi, List<object> lista)
        {
            Console.WriteLine("");
            Console.WriteLine(message + "(y / n)");

            if (Console.ReadLine() == "n")
            {
                System.Environment.Exit(1);
            }

            else
            {
                Console.Clear();
                boxOp.RenderMenu(options);
                SelectOption(options, opuestos, adyacentes, hi, lista);
                WantContinue(message, boxOp, options, opuestos, adyacentes, hi, lista);
            }
        }
    }
}
