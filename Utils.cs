using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ox
{
    class Utils
    {
        public static double AskForDouble(string message, string specificData = "number")
        {

            Console.WriteLine(message);

            try
            {
                return double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                return AskForDouble("Please ingress a valid " + specificData + ".");
            }
            
        }

        // Beta ask for string :(
        /*
        public static string AskForString(string message, string specificData = "text")
        {
            double tmp;

            Console.WriteLine(message);

            try
            {
                tmp = double.Parse(Console.ReadLine());
                return AskForString("Please ingress a valid " + specificData + ".");
            }
            catch (Exception)
            {
                return Console.ReadLine();
            }

        }

        */

        public static void Exit(string message = "Press any key to exit ...")
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
