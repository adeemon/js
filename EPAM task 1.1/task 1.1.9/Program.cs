using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._1._9
{
    class Program
    {
        static void massGenerate(ref int[] array, int n)
        {
            int min = 100000;
            int max = -100000;
            Random rnd = new Random();
            for (int i = 0; i < 30; ++i)
            {
                array[i] = rnd.Next(-1000, 1000);
            }
        }

        static void massPrint(int[] array)
        {
            for (int i = 0; i < 30; ++i)
            {
                Console.Write("{0} ", array[i]);
            }
        }

        static int summOfNonNegative(int[] array)
        {
            int summOfNonNegative = 0;
            foreach (int i in array)
            {
                if (i >= 0) summOfNonNegative += i;
            }
            return summOfNonNegative;
        }

        static void Main(string[] args)
        {
            int[] arr = new int[30];
            Console.WriteLine("Изначальный массив{0}", Environment.NewLine);
            massGenerate(ref arr, 30);
            massPrint(arr);
            Console.WriteLine("{0}Сумма неотрицательных элементов массива равна {1}", Environment.NewLine, summOfNonNegative(arr));
            Console.ReadKey();
        }
    }
}
