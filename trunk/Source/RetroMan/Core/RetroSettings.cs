using RetroMan.Tools;
using System.Collections.Generic;

namespace RetroMan.Core
{
    public class RetroSettings : JsonSettings<RetroSettings>
    {
        public static RetroSettings Instance { get; set; }

        public string SevenZipPath { get; set; }
        public List<string> RomPathList { get; set; }
        public List<string> DataFileList { get; set; }

        public RetroSettings()
        {
            RomPathList = new List<string>();
            DataFileList = new List<string>();
        }
    }
}
