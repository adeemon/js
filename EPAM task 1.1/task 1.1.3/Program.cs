using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_1._3
{
    class Program
    {
        static void printStars (int numberOfStars)
        {
            for (int i=0;i< numberOfStars;++i)
            {
                var tempString = new StringBuilder(new string(' ', numberOfStars-i-1));
                tempString.Append(new string('*', 1+i*2));
                Console.Write("{0} {1}", tempString, Environment.NewLine);

            }
        }
        static void Main(string[] args)
        {
            int countOfLines;
            Console.Write("Please, input the N. {0}", Environment.NewLine);
            countOfLines = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            printStars(countOfLines);
            Console.ReadKey();
        }
    }
}
