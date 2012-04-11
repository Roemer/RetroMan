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
                else if (key == "game")
                {
                    // Rom
                    FileDataObject fdo = new FileDataObject();
                    MatchCollection subMatches = keyValueRegex.Matches(value);
                    foreach (Match subMatch in subMatches)
                    {
                        string subkey = subMatch.Groups[1].Captures[0].Value;
                        string subvalue = subMatch.Groups[2].Captures[0].Value;
                        if (subkey == "name")
                        {
                            fdo.Name = subvalue;
                            // TODO:
                            fdo.MD5 = Guid.NewGuid();
                        }
                    }
                    ddo.Files.Add(fdo);
                }
            }
            return ddo;
        }
    }
}
