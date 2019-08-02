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

            // Set limitWidth as the potencial of base 2
            // 2 ^ 3 = 8 characters

            string renderHorizontalBorder(int start, int limitWidth, string border)
            {
                if (start > limitWidth)
                {
                    return border;
                }

                return renderHorizontalBorder(start + 1, limitWidth, $"{border}{border}");
            }

            // E. G.

            double regSum(double start, double end, double acc)
            {
                if (start > end)
                {
                    return acc;
                }

                return regSum(start + 1, end, acc + start);
            }


            List<string> Options = new List<string>();


            Options.Add($"{regSum(2, 4, 0)}");

            Console.WriteLine(renderHorizontalBorder(0, 4, "*"));
            Console.WriteLine();

            Console.WriteLine("Ox");
            Console.WriteLine("1.2.0");
            Console.WriteLine("31.07.2019");

            Console.WriteLine();

            Console.WriteLine("Escoge una opcion:");
            Console.WriteLine();
            Console.WriteLine("1. Calcular Cateto Adyacente");
            Console.WriteLine("2. Calcular Cateto Opuesto");
            Console.WriteLine("3. Calcular Cateto Hipotenusa");

            Console.WriteLine();
            Console.WriteLine(renderHorizontalBorder(0, 4, "*"));

            SelectOption();
        }


        private static double PythagorasH(double a, double b) => Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

        private static double PythagorasLeg(double h, double leg) => Math.Sqrt(Math.Pow(h, 2) - Math.Pow(leg, 2));

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
            if (leg == h)
            {
                return 0;
            }

            return h;
        }

        private static double FinallyValidation(int num, double leg)
        {
            Console.WriteLine(num / leg);

            return leg;
        }

        private static double AskForLeg(string catetoName)
        {
            Console.WriteLine(catetoName);
            var input = Console.ReadLine();

            try
            {
                return FinallyValidation(2, NotPositive(int.Parse(input)));
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

            var input = Console.ReadLine();

            try
            {
                return FinallyValidation(2, NotHypotenuseDifferent(NotHypotenuseBiggest(NotPositive(int.Parse(input)), leg), leg));
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return AskForH(catetoName, leg);
            }
        }


        private static void SelectOption()
        {
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Console.WriteLine();

                    double h = AskForH("Ingresa  H ", 6);
                    Console.WriteLine(h);

                    double b = AskForLeg("Ingresa un cateto opuesto ");
                    Console.WriteLine(b);

                    double a = PythagorasLeg(h, b);

                    Console.WriteLine(a);
                    Console.WriteLine();
                    break;

                default:
                    break;
            }
        }
    }
}
