using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using RetroMan.Database;

namespace RetroMan.Tools
{
    public static class TosecFileParser
    {
        // Fancy Regex to Parse the Key/Value Pairs out of an Element
        private static Regex keyValueRegex = new Regex(@"(?<key>[^\s]+?)\s(?:\(\s*(?<value>(?>(?:[^()]+)|\((?<depth>)|\)(?<-depth>))*(?(depth)(?!)))\)|\""(?<value>.*?)\""|(?<value>[^\s]*))?\s*");

        public static DeviceDataObject ParseFile(string fileName)
        {
            // Prepare the Object
            DeviceDataObject ddo = new DeviceDataObject();
            // Prepare the StringBuilder which holds all lines for an element
            StringBuilder sb = new StringBuilder();
            // Open the File to Read
            using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader sr = new StreamReader(fs))
            {
                // Read the first Line
                string checkLine = sr.ReadLine();
                // Check if it is the ClrMame Pro Format
                if (!checkLine.StartsWith("clrmamepro"))
                {
                    // It's not, return
                    return null;
                }

                // Append the Line
                sb.Append(checkLine);
                // Loop as long as there are Lines to Read
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.Append(line);
                    // Check if it is a closing Line
                    if (line == ")")
                    {
                        // Match the Key/Value
                        Match match = keyValueRegex.Match(sb.ToString());
                        string key = match.Groups["key"].Value;
                        string value = match.Groups["value"].Value;

                        // Check for the different Keys
                        if (key == "clrmamepro")
                        {
                            // Header
                            ParseMetaInformation(value, ddo);
                        }
                        else if (key == "game")
                        {
                            // Game
                            FileDataObject dfo = new FileDataObject();
                            ParseGameInformation(value, dfo);
                            ddo.Files.Add(dfo);
                        }

                        // Finished current Element, clear the Buffer
                        sb.Clear();
                    }
                }
            }
            return ddo;
        }

        private static void ParseMetaInformation(string value, DeviceDataObject ddo)
        {
            MatchCollection subMatches = keyValueRegex.Matches(value);
            foreach (Match subMatch in subMatches)
            {
                string subkey = subMatch.Groups["key"].Value;
                string subvalue = subMatch.Groups["value"].Value;
                if (subkey == "name")
                {
                    ddo.Name = subvalue;
                }
            }
        }

        private static void ParseGameInformation(string value, FileDataObject dfo)
        {
            MatchCollection subMatches = keyValueRegex.Matches(value);
            foreach (Match subMatch in subMatches)
            {
                string subkey = subMatch.Groups["key"].Value;
                string subvalue = subMatch.Groups["value"].Value;
                if (subkey == "name")
                {
                    dfo.Name = subvalue;
                }
                else if (subkey == "rom")
                {
                    // Rom
                    ParseRomInformation(subvalue, dfo);
                }
            }
        }

        private static void ParseRomInformation(string value, FileDataObject dfo)
        {
            MatchCollection subMatches = keyValueRegex.Matches(value);
            foreach (Match subMatch in subMatches)
            {
                string subkey = subMatch.Groups["key"].Value;
                string subvalue = subMatch.Groups["value"].Value;
                if (subkey == "name")
                {
                    dfo.FileName = subvalue;
                }
                else if (subkey == "size")
                {
                    dfo.FileSize = Convert.ToInt64(subvalue);
                }
                else if (subkey == "crc")
                {
                    dfo.CRC = subvalue;
                }
                else if (subkey == "md5")
                {
                    dfo.MD5 = new Guid(subvalue);
                }
            }
        }
    }
}
