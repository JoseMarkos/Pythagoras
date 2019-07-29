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
            Menu menu = new Menu();
            menu.SetAppName("Ox");
            menu.SetDate("22.07.2019");

            string[] options =
            {
                "Calcular Cateto Adyacente",
                "Calcular Cateto Opuesto",
                "Calcular Hipotenusa"
            };

            menu.RenderMenu(options);

            selectOption(options);
            WantContinue("Seguir calculando ", menu, options);

        }

        // Pythagorean theorem

        public static void calculateC()
        {
            double a, b, c;

            a = Utils.AskForDouble("Ingrese Cateto Adyacente (a): ");
            b = Utils.AskForDouble("Ingrese Cateto Opuesto (b): ");

            c = Math.Sqrt((Math.Pow(a, 2) + Math.Pow(b, 2)));

            Console.WriteLine("La Hipotenusa es: " + c);
        }

        public static void calculateA()
        {
            double a, b, c;

            c = Utils.AskForDouble("Ingrese Hipotenusa (c): ");
            b = Utils.AskForDouble("Ingrese el Cateto Opuesto (b): ");

            a = Math.Sqrt((Math.Pow(c, 2) - Math.Pow(b, 2)));

            if (b < 1 || c < 0)
            {
                Console.WriteLine("No es un triangulo.");
            }
            else
            {
                Console.WriteLine("El Cateto Adyasente es: " + a);
            }

        }

        public static void calculateB()
        {
            double a, b, c; 

            c = Utils.AskForDouble("Ingrese Hipotenusa (c): ");
            a = Utils.AskForDouble("Ingrese Cateto Adyacente (a): ");

            b = Math.Sqrt((Math.Pow(c, 2) - Math.Pow(a, 2)));

            if (a < 1 || c < 0)
            {
                Console.WriteLine("No es un triangulo.");
            }
            else
            {
                Console.WriteLine("El Cateto Opuesto es: " + b);
            }
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

        public static void WantContinue(string message, Menu menu, string[] options)
        {
            Console.WriteLine("");
            Console.WriteLine(message + "(y / other key)");

            if (Console.ReadLine() == "y")
            {
                Console.Clear();
                menu.RenderMenu(options);
                selectOption(options);
                WantContinue(message, menu, options);
            }

            else
            {
                System.Environment.Exit(1);
            }
        }
    }
}
