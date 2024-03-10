namespace WatchFolder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"args:\n1.absulute folder path.\n2.filter(for example \"*.txt\")\n");
            new FolderWatcher();
            Console.ReadKey();
        }
    }
}
