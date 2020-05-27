using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую строку");
            string firstInputString = Console.ReadLine();
            Console.WriteLine("Введите вторую строку");
            string secondInputString = Console.ReadLine();
            StringBuilder outputString = new StringBuilder();
            for (int i = 0 ; i < firstInputString.Length; ++i )
            {
                if (secondInputString.Contains(firstInputString[i]))
                {
                    outputString.Append(firstInputString[i]);
                    outputString.Append(firstInputString[i]);
                }
                else
                    outputString.Append(firstInputString[i]);
            }
            Console.WriteLine(outputString);
            Console.ReadKey();
        }
    }
}
