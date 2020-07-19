using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM_task_3._3._2.Extentions;

namespace EPAM_task_3._3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "word тест";

            Console.WriteLine(test.Language());

            Console.ReadKey();
        }
    }
}
