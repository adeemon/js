using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_tasks_1._2
{
    class Program
    {
        //Округляем до 2-х знаков после запятой
        static double averageCalculation (string[] array)
        {
            double average = 0;
            foreach (string i in array)
            {
                int lengthOfWord=0;
                for (int j = 0; j<i.Length;++j)
                {
                    if (Char.IsLetter(i[j]))
                    {
                        lengthOfWord++;
                    }
                }
                average += lengthOfWord;
            }
            average = (double)average / array.Length;
            return Math.Round(average,2);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string inputString = Console.ReadLine();
            string[] inputSplit = inputString.Split(' ');
            Console.Write("Средняя длина слова в введенной строке равна {0}", averageCalculation(inputSplit));
            Console.ReadKey();
        }
    }
}
