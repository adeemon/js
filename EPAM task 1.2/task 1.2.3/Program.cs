using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//выполнено со *


namespace EPAM_tasks_1._2._3
{
    class Program
    {
        static double calculationOfLowerCase(string[] array)
        {
            double countOfLowerCaseWords = 0;
            foreach (string i in array)
            {
                if (i.Length >= 1)
                {
                    if (Char.IsLower(i[0])) countOfLowerCaseWords++;
                }
                
            }
            return countOfLowerCaseWords;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string inputString = Console.ReadLine();
            string[] inputSplit = inputString.Split(' ',':',';');
            Console.Write("Количество слов, начинающихся с маленькой буквы, равно {0}", calculationOfLowerCase(inputSplit));
            Console.ReadKey();
        }
    }
}
