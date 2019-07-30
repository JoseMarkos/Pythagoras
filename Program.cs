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


            selectOption(options);
            WantContinue("Seguir calculando ", boxOptions, options);
        }

        // Pythagorean theorem

        public static void calculateC()
        {
           

        }

        public static void calculateA()
        {
            
        }

        public static void calculateB()
        {
           
        }

        // Selection 

        public static void selectOption(string[] options)
        {
            double input = Utils.AskForDouble("");

            switch (input)
            {
                case 1:

                    calculateA();
                    
                    break;

                case 2:

                    calculateB();
                    break;

                case 3:

                    calculateC();
                    break;
                default:
                    Console.WriteLine("Ingrese una opcion valida!");
                    selectOption(options);
                    break;
            }
        }

        // Continue

        public static void WantContinue(string message, Box menu, string[] options)
        {
            Console.WriteLine("");
            Console.WriteLine(message + "(y / other key)");

            if (Console.ReadLine() == "n")
            {
                System.Environment.Exit(1);
            }

            else
            {
                Console.Clear();
                menu.RenderMenu(options);
                selectOption(options);
                WantContinue(message, menu, options);
            }
        }
    }
}
