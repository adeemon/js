using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Permissions;

namespace EPAM_task_4._1._1
{
    static class FileWatcher
    {
        public static void WatchOnFolder(string path)
        {
            System.IO.FileSystemWatcher folderWatcher = CreateWatcherTxt(path);
        }

        public static System.IO.FileSystemWatcher CreateWatcherTxt(string path)
        {
            System.IO.FileSystemWatcher watcher = new System.IO.FileSystemWatcher();
            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
            watcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName;

            watcher.Path = path;

            watcher.Created += BackupEngine.OnCreated;
            watcher.Changed += BackupEngine.OnChanged;
            watcher.Deleted += BackupEngine.OnDelete;
            watcher.Renamed += BackupEngine.OnRenamed;

            watcher.EnableRaisingEvents = true;
            return watcher;
        }


    }
}
