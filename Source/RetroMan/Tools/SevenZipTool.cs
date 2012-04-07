using System.Diagnostics;
using System.IO;
using RetroMan.Core;

namespace RetroMan.Tools
{
    public static class SevenZipTool
    {
        public static string ExtractToTemp(string filePath)
        {
            string sevenZipExecutable = Path.Combine(RetroSettings.Instance.SevenZipPath, "7z.exe");

            string tempFolder = Utils.GetTempFolderName();

            ProcessStartInfo pInfo = new ProcessStartInfo();
            pInfo.FileName = sevenZipExecutable;
            pInfo.Arguments = string.Format(@"e ""{0}"" -o""{1}""", filePath, tempFolder);
            Process p = Process.Start(pInfo);
            p.WaitForExit();
            return tempFolder;
        }
    }
}
