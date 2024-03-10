using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchFolder
{
    internal class FolderWatcher
    {
        public FolderWatcher(string path = "", string filter = "*.*")
        {
            if (path == string.Empty)
            {
                path = System.IO.Directory.GetCurrentDirectory();
            }

            string selectedFolder = path;
            Console.WriteLine($"Watching folder: {selectedFolder}");

            FileSystemWatcher watcher = new FileSystemWatcher($"{selectedFolder}");
            watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
            watcher.Filter = filter;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;
        }

        void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            Console.WriteLine($"Changed: {e.FullPath}");
        }

        void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Created: {e.FullPath}");
        }

        void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Deleted: {e.FullPath}");
        }

        void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Renamed:");
            Console.WriteLine($"    Old: {e.OldFullPath}");
            Console.WriteLine($"    New: {e.FullPath} ");
        }
    }
}
