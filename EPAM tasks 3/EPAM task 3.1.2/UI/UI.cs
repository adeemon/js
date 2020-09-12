using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_3._1._2.WordsCounter
{
    class UI
    {
        public static void Start ()
        {
            OutputHandler.PrintWelcomeMessage();
            int.TryParse(Console.ReadLine(), out int chooseOfUser);
            ChoosingOfAction(chooseOfUser);
            return;
        }

        public static void ChoosingOfAction (int userChoose)
        {
            switch (userChoose)
            {
                case 1:
                    {
                        OutputHandler.PrintActionMode();
                        WordsCounter.Start();
                        Console.ReadKey();
                        Start();
                        break;
                    }
                case 2:
                    {
                        OutputHandler.PrintDescription();
                        Start();
                        break;
                    }
                case 3:
                    {
                        return;
                    }
            }
        }

    }
}
