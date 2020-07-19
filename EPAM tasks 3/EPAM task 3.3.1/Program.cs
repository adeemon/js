using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM_task_3._3._1.Extentions;

namespace EPAM_task_3._3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = new int[] {1,4,6,8,8,1,1,8,8};

            foreach (var element in testArray)
            {
                Console.WriteLine(element);
            }

            testArray.Modify(a => a * 10);

            foreach (var element in testArray)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine(testArray.Summ());

            Console.WriteLine(testArray.Average());

            Console.WriteLine(testArray.MostOftenElement());

            Console.ReadKey();
        }
    }
}
