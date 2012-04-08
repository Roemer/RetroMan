using System.Collections.Generic;
using RetroMan.Tools;

namespace RetroMan.Core
{
    public class RetroSettings : JsonSettings<RetroSettings>
    {
        public static RetroSettings Instance { get; set; }

        public string SevenZipPath { get; set; }
        public List<DataFileSetting> DataFiles { get; set; }

        public RetroSettings()
        {
            DataFiles = new List<DataFileSetting>();
        }
    }

    public class DataFileSetting
    {
        public string Name { get; set; }
        public string DataFilePath { get; set; }
        public string RomFolderPath { get; set; }
    }
}
