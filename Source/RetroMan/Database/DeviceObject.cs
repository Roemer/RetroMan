using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetroMan.Database
{
    [Serializable]
    public class DeviceObject
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public List<FileObject> Files { get; set; }

        public DeviceObject()
        {
            Files = new List<FileObject>();
        }
    }
}
