using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FolderCleaner.Core
{
    public class Cleanup
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string _folder;
        private readonly bool _deleteSubFolders;
        private readonly string[] _excludeExtensions;
        private readonly string[] _excludeSubFolders;

        public Cleanup(string folder,
            bool deleteSubFolders = true,
            string[] excludeExtensions = null,
            string[] excludeSubFolders = null)
        {
            _folder = folder;
            _deleteSubFolders = deleteSubFolders;
            _excludeExtensions = excludeExtensions;
            _excludeSubFolders = excludeSubFolders;
        }

        public void Run()
        {
            var files = GetFiles();
            foreach (var file in files)
            {
                Log.Debug($"Deleting file: {file}");
                File.Delete(file);
            }

            if (_deleteSubFolders)
            {
                var directories = GetDirectories();
                foreach (var directory in directories)
                    if (Directory.Exists(directory))
                    {
                        Log.Debug($"Deleting directory: {directory}");
                        Directory.Delete(directory, true);
                    }
            }
        }

        private IEnumerable<string> GetFiles()
        {
            return Directory
                .GetFiles(_folder, ".", SearchOption.TopDirectoryOnly)
                .Where(file => !_excludeExtensions.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase)));
        }

        private IEnumerable<string> GetDirectories()
        {
            return Directory
                .GetDirectories(_folder, ".", SearchOption.AllDirectories)
                .Where(folder => _excludeSubFolders.All(exclude => !folder.StartsWith(Path.Combine(_folder, exclude),
                StringComparison.OrdinalIgnoreCase)));
        }
    }
}
