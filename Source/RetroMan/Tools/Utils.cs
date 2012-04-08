using System;
using System.IO;

namespace RetroMan.Tools
{
    public static class Utils
    {
        public static string GetTempFolderName()
        {
            string tempPath;
            do
            {
                tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
            } while (Directory.Exists(tempPath));
            Directory.CreateDirectory(tempPath);
            return tempPath;
        }

        public static void SafeMoveFile(string oldPath, string newPath)
        {
            // Make sure that the Directories all exist
            Directory.CreateDirectory(Path.GetDirectoryName(newPath));
            // Search for a non-existent Filename
            int index = 1;
            string fileName = Path.GetFileNameWithoutExtension(newPath);
            string extension = Path.GetExtension(newPath);
            while (File.Exists(newPath))
            {
                string newFileName = string.Format("{0} ({1}){2}", fileName, index, extension);
                // Build the new File Path
                newPath = Path.Combine(Path.GetDirectoryName(newPath), newFileName);
            }
            // Move/Rename the File
            File.Move(oldPath, newPath);
        }
    }
}
