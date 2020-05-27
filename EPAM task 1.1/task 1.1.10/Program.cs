using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._1._10
{
    class Program
    {
        static void massGenerate(ref int[,] array, int n)
        {
            Random rnd = new Random();
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    array[i,j] = rnd.Next(-1000, 1000);
                }
            }
        }

        static void massPrint(int[,] array, int n)
        {
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    Console.Write("{0} ", array[i,j]);
                }
                Console.Write(Environment.NewLine);
            }

        }

        static int summOfEven(int[,] array, int n)
        {
            int summOfEven = 0;
            for (int i = 0; i < n; ++i)
            {
               for (int j=i%2;j<n;j+=2)
                {
                    summOfEven += array[i, j];
                    Console.WriteLine("Добавили ячейку {0}{1}={2}, текущая сумма равна: {3}", i, j,array[i,j], summOfEven);
                }
            }
            return summOfEven;
        }

        static void Main(string[] args)
        {
            int n = 6;
            int[,] arr = new int[n, n];
            Console.WriteLine("Изначальный массив{0}", Environment.NewLine);
            massGenerate(ref arr, n);
            massPrint(arr,n);
            Console.WriteLine("{0}Сумма четных элементов массива равна: {1}", Environment.NewLine, summOfEven(arr,n));
            Console.ReadKey();
        }
    }
}
