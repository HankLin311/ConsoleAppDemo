using ConsoleAppDevTools.Helpers.Interface;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDevTools.Helpers
{
    public class FileHelper : IFileHelper
    {
        /// <summary>
        /// 複製檔案
        /// </summary>
        public void CopyFiles(string sourceDir = "", string destinationDir = "")
        {
            string[] files = Directory.GetFiles(sourceDir);
            string[] dirs = Directory.GetDirectories(sourceDir);

            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destinationDir, fileName);
                File.Copy(file, destFile, true);
            }

            foreach (string subdir in dirs)
            {
                string dirName = Path.GetFileName(subdir);
                string destDir = Path.Combine(destinationDir, dirName);
                CopyFiles(subdir, destDir);
            }
        }

        /// <summary>
        /// 刪除資料夾和檔案
        /// </summary>
        public void DelDirectoryAndFiles(string sourceDir, string[] directoriesToDelete, string[] filesToDelete)
        {
            foreach (var directory in directoriesToDelete)
            {
                string directoryPath = Path.Combine(sourceDir, directory);
                if (Directory.Exists(directoryPath))
                {
                    Directory.Delete(directoryPath, true);
                }
            }

            foreach (var file in filesToDelete)
            {
                string filePath = Path.Combine(sourceDir, file);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }

        /// <summary>
        /// 壓縮檔案
        /// </summary>
        public void FileToZip(string sourceDir, string descFile)
        {
            ZipFile.CreateFromDirectory(sourceDir, descFile, CompressionLevel.Optimal, true);
        }
    }
}
