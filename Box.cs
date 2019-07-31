using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ox
{
    class Box
    {
        private string boxTitle;
        private string author = "@joomlergt";

        private string version = "1.1.1";
        private char borderChar = '*';
        private string date;

        public int limitWidth = 50;

        public void SetLimitWidth(int limit)
        {
            this.limitWidth = limit;
        }
        public void SetBoxTitle(string title)
        {
            this.boxTitle = title;
        }
        public void SetDate(string date)
        {
            this.date = date;
        }

        public void SetBorderChar(char character)
        {
            this.borderChar = character;
        }

        public void WriteHorizontalBorder()
        {
            for (int i = limitWidth; i > 0; i--)
            {
                Console.Write(borderChar);
            }

            Console.WriteLine("");
        }

        // Beta centerText 
        public void CenterText(int limit, string message)
        {
            int center = limit / 2;
            int tab =  center - (message.Length / 2);

            for (int i = tab; i > 0; i--)
            {
                Console.Write(" ");
            }

            Console.Write(message);
            Console.WriteLine("");
        }

        public void RenderMenu(string[] items)
        {

            WriteHorizontalBorder();

            Console.WriteLine(boxTitle + " " + version);
            Console.WriteLine(date);
            Console.WriteLine(author);
            Console.WriteLine();

            for (int i = 0; i < items.Length; i++)
            {
                Console.Write(i + 1 + ". ");
                Console.WriteLine(items[i]);
            }

            Console.WriteLine();
            WriteHorizontalBorder();
        }
    }
}
