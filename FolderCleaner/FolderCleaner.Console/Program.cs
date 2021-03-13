using System;
using System.Configuration;
using System.Diagnostics;
using FolderCleaner.Core;

namespace FolderCleaner.Console
{
    class Program
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            var folder = ConfigurationManager.AppSettings["folder"];
            var excludeFileExtensions = ConfigurationManager.AppSettings["excludeFileExtensions"].Split(new []{','}, StringSplitOptions.RemoveEmptyEntries);
            var excludeSubFolders = ConfigurationManager.AppSettings["excludeSubFolders"].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var deleteSubFolders = bool.Parse(ConfigurationManager.AppSettings["deleteSubFolders"]);

            var clean = new Cleanup(folder, deleteSubFolders, excludeFileExtensions, excludeSubFolders);

            Log.Info("Running clean...");
            var sw = Stopwatch.StartNew();
            clean.Run();
            Log.Info($"Cleaned folder: {folder} in {sw.ElapsedMilliseconds}ms.");
        }
    }
}
