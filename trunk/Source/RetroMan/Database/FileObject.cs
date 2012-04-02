using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetroMan.Database
{
    [Serializable]
    public class FileObject
    {
        public string Name { get; set; }
        public FileType FileType { get; set; }
        public long FileSize { get; set; }
        public int CRC { get; set; }
        public Guid MD5 { get; set; }
        public string SHA1 { get; set; }

        public FileObject()
        {
        }
    }
}
