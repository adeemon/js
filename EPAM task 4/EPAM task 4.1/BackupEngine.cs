using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Permissions;
using System.Threading;


namespace EPAM_task_4._1._1
{
    class BackupEngine
    {

        static DateTime lastRead = DateTime.MinValue;

        //public static List<RenameNotes> RenameNote;

        public static void OnCreated(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

            var directory = @"D:\EPAMtask4";
            var pathForBackups = directory + "backups";
            var name = e.Name;
            DirectoryInfo diMain = new DirectoryInfo(pathForBackups);

            Console.WriteLine(e.FullPath);

            if (!diMain.Exists)
            {
                diMain.Create();
                Console.WriteLine("The directory was created successfully at {0}.", pathForBackups);
            }

            string newDir = e.FullPath.Substring(directory.Length + 1);

            var tempMore = e.Name.Length;
            var tempLess = NameOfTxt(e.Name).Length;
            newDir = newDir.Substring(0, tempMore - tempLess);
            newDir = Path.Combine(pathForBackups, newDir);

            DirectoryInfo diSub = new DirectoryInfo(newDir);
            diSub.Create();
            StringBuilder sb = new StringBuilder("Created");
            sb.Append("|");
            DateTime timeNow = DateTime.Now;
            sb.Append(timeNow.ToString());
            sb.Append("|");
            Thread.Sleep(10);
            string[] lines = File.ReadAllLines(e.FullPath);
            foreach (string s in lines)
            {
                sb.Append(s);
                sb.Append("|");
            }


            Console.WriteLine(e.Name.Length);
            Console.WriteLine(pathForBackups.Length - (directory.Length));
            StreamWriter f = new StreamWriter(pathForBackups + @"\" + e.Name);
            f.WriteLine(sb.ToString());
            f.Close();
        }

        public static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

            var directory = @"D:\EPAMtask4";
            var pathForBackups = directory + "backups";
            var name = e.Name;
            DirectoryInfo di = new DirectoryInfo(pathForBackups);

            StringBuilder sb = new StringBuilder("\nRenamed");
            sb.Append("|");
            DateTime timeNow = DateTime.Now;
            sb.Append(timeNow.ToString());
            sb.Append("|");
            sb.Append(e.OldFullPath);
            sb.Append("|");
            sb.Append(e.FullPath);

            Thread.Sleep(10);
            string[] lines = File.ReadAllLines(e.FullPath);
            foreach (string s in lines)
            {
                sb.Append(s);
                sb.Append("|");
            }

            //RenameNotes newNote = new RenameNotes();
            //newNote.TimeOfRename = DateTime.Now;
            //newNote.OldPath = e.OldFullPath;
            //newNote.NewPath = e.FullPath;

            //RenameNote.Add(newNote);

            StreamWriter f = new StreamWriter(pathForBackups + @"\" + e.OldName, true);
            Console.WriteLine("Old path = {0}", pathForBackups + @"\" + e.OldName);
            f.WriteLine(sb.ToString());
            f.Close();
        }

        public static void OnChanged(object source, FileSystemEventArgs e)
        {
            DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
            if (lastWriteTime != lastRead)
            {
                Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

                var directory = @"D:\EPAMtask4";
                var pathForBackups = directory + "backups";
                var name = e.Name;
                DirectoryInfo di = new DirectoryInfo(pathForBackups);

                StringBuilder sb = new StringBuilder("\nChanged");
                sb.Append("|");

                DateTime timeNow = DateTime.Now;
                sb.Append(timeNow.ToString());
                sb.Append("|");

                Thread.Sleep(10);
                string[] lines = File.ReadAllLines(e.FullPath);
                foreach (string s in lines)
                {
                    sb.Append(s);
                    sb.Append("|");
                }

                Console.WriteLine(e.Name.Length);
                Console.WriteLine(pathForBackups.Length - (directory.Length));
                StreamWriter f = new StreamWriter(pathForBackups + @"\" + e.Name, true);
                f.WriteLine(sb.ToString());
                f.Close();
                lastRead = lastWriteTime;
            }
        }

        public static void OnDelete(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

            var directory = @"D:\EPAMtask4";
            var pathForBackups = directory + "backups";
            var name = e.Name;
            DirectoryInfo di = new DirectoryInfo(pathForBackups);

            StringBuilder sb = new StringBuilder("\nDeleted");
            sb.Append("|");
            DateTime timeNow = DateTime.Now;
            sb.Append(timeNow.ToString());
            sb.Append("|");

            StreamWriter f = new StreamWriter(pathForBackups + @"\" + e.Name, true);
            f.WriteLine(sb.ToString());
            f.Close();
        }

        private static string NameOfTxt(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            var counter = inputString.Length;
            string symbol = inputString.Substring(counter - 1, 1);
            while (symbol != "\\")
            {
                sb.Insert(0, symbol);
                if (counter - 1 < 1)
                {
                    break;
                }
                else
                {
                    counter--;
                }
                symbol = inputString.Substring(counter - 1, 1);
            }
            return sb.ToString();
        }

        public static void BackupMode(DateTime inputTime)
        {
            var directory = @"D:\EPAMtask4";
            var pathForBackups = directory;
            var files = Directory.GetFiles(pathForBackups,"*", SearchOption.AllDirectories);

            foreach (string s in files)
            {
                BackupFile(inputTime, new FileInfo(s), directory);
            }
        }

        private static string[] GetBackupData(string inputString)
        {
            var info = inputString.Split('|');

            return info;
        }

        private static void BackupFile(DateTime timeOfBackup, FileInfo inputFile, string directory)
        {

            string backupTxt = inputFile.FullName.Insert(directory.Length, "backups");
            string[] lines = File.ReadAllLines(backupTxt);

            DateTime time = new DateTime(2000, 1, 1, 00, 00, 00);
            List<string> newArray = new List<string>();

            foreach (string s in lines)
            {
                Console.WriteLine(s);
                if (s.Length > 6)
                {
                    var backupData = GetBackupData(s);
                    DateTime tempTime = DateTime.Parse(backupData[1],
                              System.Globalization.CultureInfo.InvariantCulture);

                    if (tempTime > time && tempTime < timeOfBackup)
                    {
                        Console.WriteLine(tempTime < timeOfBackup);
                        newArray.RemoveRange(0, newArray.Count);
                        time = tempTime;
                        foreach (var el in backupData)
                        {
                            newArray.Add(el);
                        }
                    }
                }

            }

            foreach (var el in newArray)
            {
                Console.WriteLine(el);
            }

            switch (newArray[0])
            {
                case "Changed":
                    BackupChanged(inputFile.FullName, newArray);
                    break;
                case "Deleted":
                    BackupDeleted(inputFile.FullName, newArray);
                    break;
                case "Renamed":
                    BackupRenamed(inputFile.FullName, newArray, directory, timeOfBackup);
                    break;
            }
        }

        private static void BackupChanged(string originalFilePath, List<string> backupData)
        {
                StreamWriter f = new StreamWriter(originalFilePath);
                for (int i = 2; i < backupData.Count; ++i)
                {
                    f.WriteLine(backupData[i]);
                }
                f.Close();
        }

        private static void BackupDeleted(string originalFilePath, List<string> backupData)
        {
            StreamWriter f = new StreamWriter(originalFilePath);
            f.WriteLine(Environment.NewLine);
            f.Close();
        }

        private static void BackupRenamed (string originalFilePath, List<string> backupData, string directory, DateTime timeOfBackup)
        {

            string backupTxt = backupData[2].Insert(directory.Length, "backups");
            string[] lines = File.ReadAllLines(backupTxt);

            DateTime time = DateTime.Parse(backupData[1],
                          System.Globalization.CultureInfo.InvariantCulture);
            List<string> newArray = new List<string>();

            foreach (string s in lines)
            {
                var backupDataTemp = GetBackupData(s);

                DateTime tempTime = DateTime.Parse(backupData[1],
                          System.Globalization.CultureInfo.InvariantCulture);
                if (tempTime > time && tempTime < timeOfBackup)
                {
                    newArray.RemoveRange(0, newArray.Count);
                    time = tempTime;
                    foreach (var el in backupData)
                    {
                        newArray.Add(el);
                    }
                }

            }
            BackupChanged(originalFilePath, newArray);
        }
    }
}
