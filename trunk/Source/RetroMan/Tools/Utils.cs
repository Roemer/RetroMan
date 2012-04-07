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
    }
}
