using RetroMan.Tools;

namespace RetroMan.Core
{
    public class RetroSettings : JsonSettings<RetroSettings>
    {
        public string SevenZipPath { get; set; }
    }
}
