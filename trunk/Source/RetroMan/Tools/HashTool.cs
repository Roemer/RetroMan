using System;
using System.IO;
using System.Security.Cryptography;

namespace RetroMan.Tools
{
    public static class HashTool
    {
        public static long GetFileSize(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            if (fi.Exists)
            {
                return fi.Length;
            }
            return -1;
        }

        public static string GetCRC(string filePath)
        {
            uint decResult = Crc32.ComputeChecksum(File.ReadAllBytes(filePath));
            return decResult.ToString("X8");
        }

        public static Guid GetMD5(string filePath)
        {
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] result = md5.ComputeHash(File.ReadAllBytes(filePath));
                return new Guid(result);
            }
        }

        public static string GetSHA1(string filePath)
        {
            using (SHA1 sha = new SHA1CryptoServiceProvider())
            {
                byte[] result = sha.ComputeHash(File.ReadAllBytes(filePath));
                string hash = BitConverter.ToString(result).Replace("-", "");
                return hash;
            }
        }
    }
}
