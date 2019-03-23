using System.Configuration;
using FolderCleaner.Core;

namespace FolderCleaner.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var folder = ConfigurationManager.AppSettings["folder"];
            var excludeFileExtensions = ConfigurationManager.AppSettings["excludeFileExtensions"].Split(',');
            var excludeSubFolders = ConfigurationManager.AppSettings["excludeSubFolders"].Split(',');
            var deleteSubFolders = bool.Parse(ConfigurationManager.AppSettings["deleteSubFolders"]);

            var clean = new Cleanup(folder, deleteSubFolders, excludeFileExtensions, excludeSubFolders);
            var files = clean.ShowFilesToBeRemoved();

            foreach (var file in files)
            {
                System.Console.WriteLine($"File to be removed: {file}");
            }

            System.Console.WriteLine("Running clean...");
            clean.Run();
            System.Console.WriteLine($"Cleaned folder: {folder}.");
            System.Console.Read();
        }
    }
}
