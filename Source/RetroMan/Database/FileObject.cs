using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RetroMan.Database
{
    [Serializable]
    public class FileObject
    {
        public string Name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public FileType FileType { get; set; }
        public long FileSize { get; set; }
        public uint CRC { get; set; }
        public Guid MD5 { get; set; }
        public string SHA1 { get; set; }

        public FileObject()
        {
        }
    }
}
