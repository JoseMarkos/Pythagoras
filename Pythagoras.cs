using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ox
{
    class Pythagoras
    {
        private double a, b, h, leg, tmp;

        // Get all legs
        
        public double GetLeg()
        {
            return leg;
        }

        public double GetA()
        {
            return a;
        }

        public double GetB()
        {
            return b;
        }

        public double GetH()
        {
            return h;
        }

        // Equations

        private double GetCalculateLeg()
        {
            return Math.Sqrt(Math.Pow(h, 2) - Math.Pow(leg, 2));
        }

        public void CalculateH()
        {
            h = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }

        public void CalculateA()
        {
            a = GetCalculateLeg();
        }
        public void CalculateB()
        {
            b = GetCalculateLeg();
        }

        // Ask for legs

        private void AskForLeg(string legName, string message = "Por favor ingrese el cateto ")
        {
            tmp = Utils.AskForDouble($"{message} {legName}:");

            if (tmp == 0)
            {
                NotTriangleSide(legName);
            }

            if (tmp < 0)
            {
                NotPositiveSide(legName);
            }
        }

        private void AskForH(string message = "Por favor ingrese la Hipotenusa:")
        {
            tmp = Utils.AskForDouble(message);

            if (tmp == 0)
            {
                NotTriangleSide();
            }

            if (tmp < 0)
            {
                NotPositiveSide();
            }

            if (tmp < leg)
            {
                NotHypotenuseBiggest();
            }

            if (tmp == leg)
            {
                NotHypotenuseDifferent();
            }
        }

        /*
         * All Validations
         * 1. a, b, h   are zero
         * 2. a, b, h   are negative
         * 3. h         is minor than a leg
         * 4. h         is equal to a leg
         */

        private void NotTriangleSide(string legName)
        {
            Console.WriteLine();
            Console.WriteLine("No es un triangulo.");

            AskForLeg(legName);
        }
        private void NotTriangleSide()
        {
            Console.WriteLine();
            Console.WriteLine("No es un triangulo.");

            AskForH();
        }

        private void NotPositiveSide(string legName)
        {
            Console.WriteLine();
            Console.WriteLine("El lado de un triangulo no puede tener magnitud negativa.");

            AskForLeg(legName);
        }
        private void NotPositiveSide()
        {
            Console.WriteLine();
            Console.WriteLine("La Hipotenusa no puede tener magnitud negativa.");

            AskForH();
        }

        private void NotHypotenuseBiggest()
        {
            Console.WriteLine();
            Console.WriteLine("La Hipotenusa no puede ser menor que un cateto.");

            AskForH();
        }
        private void NotHypotenuseDifferent()
        {
            Console.WriteLine();
            Console.WriteLine("La Hipotenusa no puede medir igual que un cateto.");

            AskForH();
        }

        // Assignation

        public void AssingLeg(string legName)
        {
            AskForLeg(legName);

            leg = tmp;
        }

        public void AssingA()
        {
            AskForLeg("Adyacente");

            a = tmp;
        }

        public void AssingB()
        {
            AskForLeg("Opuesto");

            b = tmp;
        }

        public void AssingH()
        {
            AskForH();

            h = tmp;
        }
    }
}
