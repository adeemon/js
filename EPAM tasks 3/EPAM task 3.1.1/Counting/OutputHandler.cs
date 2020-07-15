using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_3._1._1
{
    class OutputHandler
    {
        public static void PrintRound(int round)
        {
            Console.WriteLine("Round {0}. The player was excluded.", round);
        }

        public static void PrintNumberPlayersRemaining(int number)
        {
            Console.WriteLine("There are {0} players remaining.", number);
        }

        public static void PrinStartGame(int orderOfExclusion)
        {
            Console.WriteLine("The list of players was generated. Lets exclude every {0} player!", orderOfExclusion);
        }

        public static void PrintEndGame ()
        {
            Console.WriteLine("The game is finished. A remaining players cant be excluded.");
        }

        public static void PrintText(string inputText)
        {
            Console.WriteLine(inputText);
        }
    }
}
