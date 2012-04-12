using System;
using System.IO;
using System.Text.RegularExpressions;
using RetroMan.Database;

namespace RetroMan.Tools
{
    public static class TosecFileParser
    {
        private static Regex keyValueRegex = new Regex(@"([^\s]+?)\s(\((?>([^()]+)|\((?<number>)|\)(?<-number>))*(?(number)(?!))\)|(?:\"".*?\"")|[^\s]*)?");

        public static DeviceDataObject ParseFile(string fileName)
        {
            string fileContent = File.ReadAllText(fileName);
            // Check the Header
            if (!fileContent.StartsWith("clrmamepro"))
            {
                return null;
            }
            // Create the new Object
            DeviceDataObject ddo = new DeviceDataObject();
            // Valid Header, Parse the Root-Elements
            MatchCollection matches = keyValueRegex.Matches(fileContent);
            foreach (Match match in matches)
            {
                string key = match.Groups[1].Captures[0].Value;
                string value = match.Groups[2].Captures[0].Value;

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
            }
            return ddo;
        }

        private static void ParseMetaInformation(string value, DeviceDataObject ddo)
        {
            MatchCollection subMatches = keyValueRegex.Matches(value);
            foreach (Match subMatch in subMatches)
            {
                string subkey = subMatch.Groups[1].Captures[0].Value;
                string subvalue = subMatch.Groups[2].Captures[0].Value;
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
                string subkey = subMatch.Groups[1].Captures[0].Value;
                string subvalue = subMatch.Groups[2].Captures[0].Value;
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
                string subkey = subMatch.Groups[1].Captures[0].Value;
                string subvalue = subMatch.Groups[2].Captures[0].Value;
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
