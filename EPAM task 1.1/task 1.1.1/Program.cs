using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int a = 0, b = 0;
                Console.Write("Please, input the a. {0}", Environment.NewLine);
                a = Convert.ToInt32(Console.ReadLine());
                if (a <= 0)
                {
                    Console.WriteLine("ERROR! Wrong value of a. {0}", Environment.NewLine);
                    break;
                }
                Console.Write("Please, input the b. {0}", Environment.NewLine);
                b = Convert.ToInt32(Console.ReadLine());
                if (b <= 0)
                {
                    Console.Write("ERROR! Wrong value of b. {0}", Environment.NewLine);
                    break;
                }
                Console.Write("S={0}", a * b);
                break;
            }
            Console.ReadKey();
        }
    }
}
