using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_3._1._2.WordsCounter
{
    class OutputHandler
    {
        public static void PrintText (string inputText)
        {
            Console.WriteLine(inputText);
        }

        public static void PrintWelcomeMessage ()
        {
            Console.Clear();
            Console.WriteLine("Choose the action by typing relevant number");
            Console.WriteLine("1. Main Editor.");
            Console.WriteLine("2. Help.");
            Console.WriteLine("3. Exit");
        }

        public static void PrintActionMode()
        {
            Console.Clear();
            Console.WriteLine("Please, type your text by keyboard. ");
        }

        public static void PrintDescription()
        {
            Console.Clear();
            Console.WriteLine("1. Main Editor. It is the general mode of programm. " +
                "Here you can type your text. " +
                "\nYou will get the list of all your words and how often " +
                "\nthey are meets in the text");
            Console.WriteLine("2. Help. Here you can see an information about programm and description of actions.");
            PrintBackToMain();
            Console.WriteLine("\nWordsCounter by Ustimov Ilya \n");

            Console.ReadKey();
        }

        public static void PrintBackToMain ()
        {
            Console.WriteLine("\nPress any button to back in the main menu");
        }
  
    }
}
