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
            ShowBox();

            SelectOption();
            WantContinue("Do you want to continue? ");

            Console.ReadKey();
        }

        // Equations

        private static double PythagorasH(double a, double b) => Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

        private static double PythagorasLeg(double h, double leg) => Math.Sqrt(Math.Pow(h, 2) - Math.Pow(leg, 2));

        // Validations

        private static double NotPositive(double leg)
        {
            if (leg < 0)
            {
                return 0;
            }

            return leg;
        }

        private static double NotHypotenuseBiggest(double h, double leg)
        {
            if (leg > h)
            {
                return 0;
            }

            return h;
        }

        private static double NotHypotenuseDifferent(double h, double leg)
        {
            if (h - leg <= 0)
            {
                return 0;
            }

            return h;
        }

        private static double FinallyValidation(int num, double leg)
        {
            if (leg < 1)
            {
                Console.WriteLine(num / 0);
            }

            return leg;
        }


        // Asking sides

        private static double AskForLeg(string catetoName)
        {
            Console.WriteLine(catetoName);
            string input = Console.ReadLine();

            try
            {
                return FinallyValidation(2, NotPositive(double.Parse(input)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return AskForLeg(catetoName);
            }
        }

        private static double AskForH(string catetoName, double leg)
        {
            Console.WriteLine(catetoName);
            string input = Console.ReadLine();

            try
            {
                return FinallyValidation(2, NotHypotenuseDifferent(NotHypotenuseBiggest(NotPositive(double.Parse(input)), leg), leg));
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return AskForH(catetoName, leg);
            }
        }

        // Set limitWidth as the potencial of base 2
        // 2 ^ 3 = 8 characters

        private static string RenderHorizontalBorder(int start, int limitWidth, string border)
        {
            if (start > limitWidth)
            {
                return border;
            }

            return RenderHorizontalBorder(start + 1, limitWidth, $"{border}{border}");
        }

        private static void SelectOption()
        {
            double input = Utils.AskForDouble("");
            double a, b, h;

            switch (input)
            {
                case 1:
                    Console.WriteLine();

                    b = AskForLeg("Ingresa Cateto Opuesto");
                    h = AskForH("Ingresa la Hiputenusa", b);
                    a = PythagorasLeg(h, b);

                    Console.WriteLine("El cateto adyacente es: " + a);
                    break;

                case 2:
                    Console.WriteLine();

                    a = AskForLeg("Ingresa Cateto Adyacente");
                    h = AskForH("Ingresa la Hiputenusa", a);
                    b = PythagorasLeg(h, a);

                    Console.WriteLine("El cateto adyacente es: " + b);
                    break;

                case 3:
                    Console.WriteLine();

                    a = AskForLeg("Ingresa Cateto Adyacente");
                    b = AskForLeg("Ingresa Cateto Opuesto");
                    h = PythagorasH(a, b);

                    Console.WriteLine("La Hipotenusa es: " + h);
                    break;

                default:
                    Console.WriteLine("Ingrese una opcion valida!");
                    SelectOption();
                    break;
            }
        }

        private static void ShowBox()
        {
            Console.WriteLine(RenderHorizontalBorder(0, 4, "*"));
            Console.WriteLine();

            Console.WriteLine("Ox");
            Console.WriteLine("2.0.0");
            Console.WriteLine("01.08.2019");

            Console.WriteLine();

            Console.WriteLine("Escoge una opcion:");
            Console.WriteLine();
            Console.WriteLine("1. Calcular Cateto Adyacente");
            Console.WriteLine("2. Calcular Cateto Opuesto");
            Console.WriteLine("3. Calcular Cateto Hipotenusa");

            Console.WriteLine();
            Console.WriteLine(RenderHorizontalBorder(0, 4, "*"));
        }

        // Continue

        private static void WantContinue(string message)
        {
            Console.WriteLine("");
            Console.WriteLine(message + "[Y / n]");

            if (Console.ReadLine() == "n")
            {
                System.Environment.Exit(1);
            }

            else
            {
                Console.Clear();
                ShowBox();

                SelectOption();
                WantContinue(message);
            }
        }
    }
}
