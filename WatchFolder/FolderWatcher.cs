using System.Drawing;

namespace WatchFolder
{
    internal class FolderWatcher
    {
        public FolderWatcher(params string[] args)
        {
            string path = args[0] ?? "";
            string filter = args[1] ?? "*.*";

            if (path == string.Empty || path == null)
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
            Console.WriteLine($"Changed: {e.FullPath}", Color.Yellow);
        }

        void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Created: {e.FullPath}", Color.Green);
        }

        void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Deleted: {e.FullPath}", Color.Red);
        }

        void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Renamed:", Color.OrangeRed);
            Console.WriteLine($"    Old: {e.OldFullPath}", Color.Gray);
            Console.WriteLine($"    New: {e.FullPath}", Color.Gray);
        }
    }
}
