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

            boxOptions.RenderMenu(options);

            SelectOption(options);
            WantContinue("Seguir calculando? ", boxOptions, options);
        }

        // Selection 

        public static void SelectOption(string[] options)
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
                    break;

                case 2:
                    Ox.AssingLeg("Adyacente");
                    Ox.AssingH();

                    Ox.CalculateB();

                    Console.WriteLine();
                    Console.WriteLine("El cateto Opuesto es: " + Ox.GetB());
                    break;

                case 3:

                    Ox.AssingA();
                    Ox.AssingB();

                    Ox.CalculateH();

                    Console.WriteLine();
                    Console.WriteLine("La Hipotenusa es: " + Ox.GetH());
                    break;

                default:
                    Console.WriteLine("Ingrese una opcion valida!");
                    SelectOption(options);
                    break;
            }
        }

        // Continue

        public static void WantContinue(string message, Box menu, string[] options)
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
                menu.RenderMenu(options);
                SelectOption(options);
                WantContinue(message, menu, options);
            }
        }
    }
}
