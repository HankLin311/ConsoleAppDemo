using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDevTools.Helpers.Interface
{
    public interface IFileHelper
    {
        void CopyFiles(string sourceDir = "", string destinationDir = "");
        void DelDirectoryAndFiles(string sourceDir, string[] directoriesToDelete, string[] filesToDelete);
        void FileToZip(string sourceDir, string descFile);
    }
}
