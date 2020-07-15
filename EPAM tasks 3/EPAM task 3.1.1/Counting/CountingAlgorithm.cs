using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_3._1._1
{
    class CountingAlgorithm
    {

        public static void WeakestLink ()
        {
            OutputHandler.PrintText("Input N");
            int n = 0;
            Int32.TryParse(Console.ReadLine(), out n);
            OutputHandler.PrintText("Input the order of players choosing");
            int orderOfExclusion = 0;
            Int32.TryParse(Console.ReadLine(), out orderOfExclusion);
            OutputHandler.PrinStartGame(orderOfExclusion);

            Engine(n, orderOfExclusion);
        }

        public static void Engine(int n, int orderOfExclusion)
        {
            int round = 1;
            int currentChoose=0;
            if (orderOfExclusion > n)
            {
                throw new ArgumentException("Excluding is impossible becase number of players less than order of excluding", "orderOfExclusion");
            }
            var Players = SetListOfPlayers(n);
            while (Players.Count > orderOfExclusion-1)
            {
                OutputHandler.PrintRound(round);
                currentChoose = (currentChoose + orderOfExclusion) % Players.Count;
                Players.Remove(Players[currentChoose]);
                OutputHandler.PrintNumberPlayersRemaining(Players.Count);
                round++;
            }
            OutputHandler.PrintEndGame();
        }


        public static void RemovePlayerFromList(Player player, List<Player> players)
        {
            players.Remove(player);
        }

        public static List<Player> SetListOfPlayers(int numberOfPlayers)
        {
            var players = new List<Player>();
            for (int i = 0; i < numberOfPlayers; ++i)
            {
                Player tempPlayer = new Player { Position = i };
                players.Add(tempPlayer);
            }
            return players;
        }
    }
}
