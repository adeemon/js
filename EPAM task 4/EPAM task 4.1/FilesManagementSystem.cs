using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_4._1._1
{
    public static class FilesManagementSystem
    {
        public static void Start()
        {
            Console.WriteLine("Input number 1 for monitoring or number 2 for backuping mode");
            int.TryParse(Console.ReadLine(), out int choose);
            switch(choose)
            {
                case 1:
                    Monitoring();
                    break;
                case 2:
                    Backuping();
                    break;
            }
        }

        private static void Monitoring()
        {
            FileWatcher.WatchOnFolder(@"D:\EPAMtask4");
        }

        private static void Backuping()
        {
            DateTime time = new DateTime(2000, 1, 1, 00, 00, 00);
            Console.WriteLine("You're in the backuping mode. Follow the instructions.");

            BackupEngine.BackupMode(GetBackupTime());
        }

        private static DateTime GetBackupTime()
        {

            Console.WriteLine("Type the year:");
            int.TryParse(Console.ReadLine(), out int year);

            Console.WriteLine("Type the month:");
            int.TryParse(Console.ReadLine(), out int month);

            Console.WriteLine("Type the day:");
            int.TryParse(Console.ReadLine(), out int day);

            Console.WriteLine("Type the hours:");
            int.TryParse(Console.ReadLine(), out int hours);

            Console.WriteLine("Type the minutes:");
            int.TryParse(Console.ReadLine(), out int minutes);

            Console.WriteLine("Type the seconds:");
            int.TryParse(Console.ReadLine(), out int seconds);

            DateTime time = new DateTime(year, day, month, hours, minutes, seconds);

            return time;
        }
    }

    
}
