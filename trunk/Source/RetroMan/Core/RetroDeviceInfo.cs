using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RetroMan.Database;
using RetroMan.Tools;
using System.Linq;
using System.Windows.Forms;

namespace RetroMan.Core
{
    public class RetroDeviceInfo
    {
        /// <summary>
        /// The associated DataFile Setting for this Device
        /// </summary>
        public DataFileSetting DataFileSetting { get; set; }
        /// <summary>
        /// The Device Info from the Database
        /// </summary>
        private DeviceDataObject DeviceObject { get; set; }
        /// <summary>
        /// Lookup Dictionary for the Files
        /// </summary>
        private Dictionary<Guid, RetroFileInfo> FileDict { get; set; }

        public int FileCount
        {
            get { return FileDict.Count; }
        }

        public List<RetroFileInfo> Files
        {
            get { return new List<RetroFileInfo>(FileDict.Values); }
        }

        public string Name
        {
            get { return DeviceObject.Name; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public RetroDeviceInfo(DataFileSetting dataFileSetting)
        {
            // Assign the DataFileSetting
            DataFileSetting = dataFileSetting;

            // Try the TOSEC File
            DeviceObject = TosecFileParser.ParseFile(DataFileSetting.DataFilePath);

            // Try the custom Database Format
            if (DeviceObject == null)
            {
                DeviceObject = JsonConvert.DeserializeObject<DeviceDataObject>(File.ReadAllText(DataFileSetting.DataFilePath));
            }

            // Create the Dictionary
            FileDict = new Dictionary<Guid, RetroFileInfo>();
            // Fill the Dictionary with the Data from the Data File
            foreach (FileDataObject fileData in DeviceObject.Files)
            {
                // Create the FileInfo
                RetroFileInfo fileInfo = new RetroFileInfo(fileData);
                // Add the FileInfo to the DIctionary
                FileDict.Add(fileData.MD5, fileInfo);
            }
        }

        public int CheckFiles(bool fixNames = true)
        {
            // Reset all Status first
            foreach (RetroFileInfo fileInfo in FileDict.Values)
            {
                fileInfo.IsAvailable = false;
            }

            // Process all Files
            int unknownFiles = 0;
            foreach (string filePath in Directory.GetFiles(DataFileSetting.RomFolderPath))
            {
                // Check if it is compressed
                if (Path.GetExtension(filePath).Equals(".7z") || Path.GetExtension(filePath).Equals(".zip") || Path.GetExtension(filePath).Equals(".rar"))
                {
                    // TODO: Either extract OR use CRC from inside archive
                    string tempFolder = SevenZipTool.ExtractToTemp(filePath);
                    // Process Files in the Directory
                    foreach (string innerPath in Directory.GetFiles(tempFolder))
                    {
                        //TODODODODO
                        //ProcessPath(innerPath);
                    }
                    // Delete the Temp Folder
                    Directory.Delete(tempFolder, true);
                }
                else
                {
                    // Normal File
                }


                // Get the MD5 of the File
                Guid md5 = HashTool.GetMD5(filePath);
                // Try to find the appropriate File in the Dictionary
                RetroFileInfo fileInfo;
                if (FileDict.TryGetValue(md5, out fileInfo))
                {
                    if (fixNames)
                    {
                        FileInfo fi = new FileInfo(filePath);
                        // Check if the Name is different
                        if (fi.Name != fileInfo.FileName)
                        {
                            // It is, so rename it
                            string newFilePath = Path.Combine(fi.DirectoryName, fileInfo.FileName);
                            // Check if there is already a File with the new Name
                            if (File.Exists(newFilePath))
                            {
                                // There is, so this should be a Duplicate
                                string pathInDupDir = Path.Combine(fi.DirectoryName, "Duplicate", fileInfo.FileName);
                                // Safely move the File
                                Utils.SafeMoveFile(fi.FullName, pathInDupDir);
                            }
                            else
                            {
                                // Just rename the File
                                fi.MoveTo(newFilePath);
                            }
                        }
                    }
                    // Found one, set it to avaliable
                    fileInfo.IsAvailable = true;
                }
                else
                {
                    // It's an unknown File
                    FileInfo fi = new FileInfo(filePath);
                    string pathInUnkDir = Path.Combine(fi.DirectoryName, "Unknown", fi.Name);
                    // Safely move the File
                    Utils.SafeMoveFile(fi.FullName, pathInUnkDir);

                    unknownFiles++;
                }
            }
            return unknownFiles;
        }
    }
}
