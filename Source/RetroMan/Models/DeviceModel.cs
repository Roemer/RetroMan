using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetroMan.Models
{
    public class DeviceModel
    {
        public int ChildCount { get { return Children.Count; } }
        public List<FileModel> Children { get; set; }
        public string Label { get; set; }

        public DeviceModel()
        {
            Children = new List<FileModel>();
        }
    }
}
