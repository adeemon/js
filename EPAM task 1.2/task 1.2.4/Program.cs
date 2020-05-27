using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._2._4
{
    class Program
    {
        static bool ifEndSymbol (char symbol)
        {
            if (symbol == '.' || symbol == '?' || symbol == '!') return true;
            else
                return false;
        }
        static string swapLowerToUpper(string inputString)
        {
            StringBuilder outputString = new StringBuilder();
            bool flag = false;
            if (Char.IsLower(inputString[0]))
            {
                outputString.Append(Char.ToUpper(inputString[0]));
            }
            for (int i = 1; i < inputString.Length; ++i)
            {
                if (Char.IsLetter(inputString[i])&&flag==true)
                {
                    outputString.Append(Char.ToUpper(inputString[i]));
                    flag = false;
                }
                else if (ifEndSymbol(inputString[i]))
                {
                    outputString.Append(inputString[i]);
                    flag = true;
                }
                else
                {
                    outputString.Append(inputString[i]);
                }
            }
            return outputString.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string inputString = Console.ReadLine();
            string[] inputSplit = inputString.Split(' ');
            Console.WriteLine(swapLowerToUpper(inputString));
            Console.ReadKey();
        }
    }
}
