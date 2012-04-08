using RetroMan.Database;

namespace RetroMan.Core
{
    public class RetroFileInfo
    {
        public FileDataObject FileObject { get; set; }
        public bool IsAvailable { get; set; }

        public FileType FileType
        {
            get { return FileObject.FileType; }
        }

        public string Name
        {
            get { return FileObject.Name; }
        }

        public string FileName
        {
            get { return FileObject.FileName; }
        }

        public RetroFileInfo(FileDataObject fileObject)
        {
            FileObject = fileObject;
            IsAvailable = false;
        }
    }
}
