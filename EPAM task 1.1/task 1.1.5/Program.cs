using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._1._5
{
    class Program
    {
        static int summOfProgression (int first, int n)
        {
            int last = ((n - 1) / first) * first;
            int count = (n - 1) / first;
            return count * (first + last) / 2;
        }


        static void Main(string[] args)
        {
            int summTotal = 0;
            summTotal = summOfProgression(3, 1000) + summOfProgression(5, 1000) - summOfProgression(15, 1000);
            Console.Write("Summ of numbers={0}", summTotal);
            Console.ReadKey();
        }
    }
}
