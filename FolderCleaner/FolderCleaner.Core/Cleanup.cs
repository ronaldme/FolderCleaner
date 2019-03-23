using System.Collections.Generic;

namespace FolderCleaner.Core
{
    public class Cleanup
    {
        private readonly string _folder;
        private readonly bool _deleteSubFolders;
        private readonly string[] _excludeExtensions;
        private readonly string[] _excludeSubFolders;

        public Cleanup(string folder, bool deleteSubFolders = true, 
            string[] excludeExtensions = null, string[] excludeSubFolders = null)
        {
            _folder = folder;
            _deleteSubFolders = deleteSubFolders;
            _excludeExtensions = excludeExtensions;
            _excludeSubFolders = excludeSubFolders;
        }

        public void Run()
        {
            // todo: Clean folder
        }

        public List<string> ShowFilesToBeRemoved()
        {
            // todo: Return files which will be removed when executing Run
            return new List<string>();
        }
    }
}
