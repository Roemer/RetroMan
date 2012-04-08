using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RetroMan.Core;

namespace RetroMan.Database
{
    [Serializable]
    public class FileDataObject
    {
        public string Name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public FileType FileType { get; set; }
        public long FileSize { get; set; }
        public uint CRC { get; set; }
        public Guid MD5 { get; set; }
        public string SHA1 { get; set; }

        public FileDataObject()
        {
        }
    }
}
