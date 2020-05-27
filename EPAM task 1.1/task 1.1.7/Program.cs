using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._1._7
{
    class Program
    {
        static void massGenerate (ref int[] array, int n)
        {
            int min = 100000;
            int max = -100000;
            Random rnd = new Random();
            for (int i = 0; i < 30; ++i)
            {
                array[i] = rnd.Next(-1000, 1000);
                if (array[i] < min) min = array[i];
                if (array[i] > max) max = array[i];
            }
            Console.Write("{0}Min={1}, Max={2}. {0}", Environment.NewLine, min, max);
        }

        static void massPrint (int[] array)
        {
            for (int i = 0; i < 30; ++i)
            {
                Console.Write("{0} ", array[i]);
            }
        }

        static void bubbleSort (ref int[] array)
        {
            int len = array.Length;
            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j < len - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int[30];
            Console.WriteLine("Изначальный массив{0}", Environment.NewLine);
            massGenerate(ref arr, 30);
            massPrint(arr);
            Console.WriteLine("{0}Отсортированный массив{0}", Environment.NewLine);
            bubbleSort(ref arr);
            massPrint(arr);
            Console.ReadKey();
        }
    }
}
