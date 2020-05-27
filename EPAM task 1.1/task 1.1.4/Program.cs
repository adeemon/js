using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_1._4
{
    class Program
    {
        static void printStars(int numberOfStars, int gap)
        {
            for (int i = 0; i < numberOfStars; ++i)
            {
                var tempString = new StringBuilder(new string(' ', numberOfStars - i - 1+gap));
                tempString.Append(new string('*', 1 + i * 2));
                Console.Write("{0} {1}", tempString, Environment.NewLine);

            }
        }

        static void printXmasTree (int numberOfTriangles)
        {
            for (int i=0; i<numberOfTriangles;++i)
            {
                printStars(i, numberOfTriangles-i);
            }
        }
        static void Main(string[] args)
        {
            int countOfTriangles;
            Console.Write("Please, input the N. {0}", Environment.NewLine);
            countOfTriangles = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            printXmasTree(countOfTriangles);
            Console.ReadKey();
        }
    }
}
