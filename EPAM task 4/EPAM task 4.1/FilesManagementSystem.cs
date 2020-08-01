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
            int choose;
            Int32.TryParse(Console.ReadLine(), out choose);
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
            int year, month, day, hours, minutes, seconds;

            Console.WriteLine("Type the year:");
            Int32.TryParse(Console.ReadLine(), out year);

            Console.WriteLine("Type the month:");
            Int32.TryParse(Console.ReadLine(), out month);

            Console.WriteLine("Type the day:");
            Int32.TryParse(Console.ReadLine(), out day);

            Console.WriteLine("Type the hours:");
            Int32.TryParse(Console.ReadLine(), out hours);

            Console.WriteLine("Type the minutes:");
            Int32.TryParse(Console.ReadLine(), out minutes);

            Console.WriteLine("Type the seconds:");
            Int32.TryParse(Console.ReadLine(), out seconds);

            DateTime time = new DateTime(year, day, month, hours, minutes, seconds);

            return time;
        }
    }

    
}
