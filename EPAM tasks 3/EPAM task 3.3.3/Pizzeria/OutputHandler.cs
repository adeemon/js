using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_3._3._3.Pizzeria
{
    static class OutputHandler
    {
        public static void MenuPrint()
        {
            Console.WriteLine("Welcome to the Ade Pizzeria!");
            Console.WriteLine("By typing numbers of pizza via keyboard\n" +
                "place your order.");
            Console.WriteLine("1 number is classic Margherita,\n" +
                "2 number is our best pizza - Pepperoni\n" +
                "3 number is Hawaiian pizza\n" +
                "4 number is a pizza for meat lovers - Meat Bomb!\n" +
                "5 number means that you wanna order 1 more pizze\n" +
                "and number 6 will transmit your order to us :з ");
        }

        public static void ConsolePrint<T> (T message)
        {
            Console.WriteLine(message);
        }
    }
}
