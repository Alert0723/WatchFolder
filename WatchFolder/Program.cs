namespace WatchFolder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"args:\n1.Absolute file path.\n2.Filter(example: \"*.txt\")\n");
            new FolderWatcher(args);
            Console.ReadKey();
        }
    }
}
