using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfLines;
            Console.Write("Please, input the N. {0}", Environment.NewLine);
            countOfLines = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Environment.NewLine);
            for (int i=0; i<countOfLines;++i)
            {
                string tempString = new string('*', i + 1);
                Console.Write("{0} {1}", tempString, Environment.NewLine);
            }
            Console.ReadKey();
        }
    }
}
