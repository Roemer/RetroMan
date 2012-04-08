using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetroMan.Database
{
    [Serializable]
    public class DeviceDataObject
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public List<FileDataObject> Files { get; set; }

        public DeviceDataObject()
        {
            Files = new List<FileDataObject>();
        }
    }
}
