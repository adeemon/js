using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._1._6
{
    class Program
    {     
        static void printInfo (int currentOptions)
        {
            Console.Write("Параметры надписи: ");
            if (currentOptions ==0 ) Console.Write("None");
            if ((currentOptions % 10) == 1) { 
                Console.Write("Bold");
                if (currentOptions / 10 > 0) Console.Write(", ");
            }
            if (((currentOptions / 10) % 10) == 1)
            {
                Console.Write("Italic");
                if (currentOptions / 100 > 0) Console.Write(", ");
            }
            if (((currentOptions / 100) % 10) == 1)
            {
                Console.Write("Underline");
            }
            Console.Write("{0}Введите: {0} \t 1: bold {0} \t 2: italic {0} \t 3: underline{0}", Environment.NewLine);
        }

        static void chooseChange(ref int currentOptions)
        {
            var userChoose = Convert.ToInt32(Console.ReadLine());
            if (userChoose==1)
            {
                if (currentOptions % 10 == 1) currentOptions = currentOptions - 1;
                else currentOptions += 1;
            }
            if (userChoose==2)
            {
                if (((currentOptions / 10) % 10) == 1) currentOptions -= 10;
                else currentOptions += 10;
            }
            if (userChoose==3)
            {
                if (((currentOptions / 100) % 10) == 1) currentOptions -= 100;
                else currentOptions += 100;
            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int currentOptions = 0;
            while (true)
            {
                printInfo(currentOptions);
                chooseChange(ref currentOptions);
            }
        }
    }
}
