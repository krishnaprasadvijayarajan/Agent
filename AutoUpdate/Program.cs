using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent
{
    class Program
    {
        static string version = "0.2";
        static string versionFilePath = @"C:\Users\krish\source\repos\AutoUpdate\version\";
        static string zipPath = @"C:\Users\krish\source\repos\AutoUpdate\version.zip";
        static void Main(string[] args)
        {
            WriteVersion();
            Console.WriteLine("I am agent {0}", version);
            Console.ReadLine();
        }

        public static void WriteVersion()
        {
            string createText = version;
            File.WriteAllText(versionFilePath + "version.txt", createText);
            ZipVersionInfo();
        }

        public static void ZipVersionInfo()
        {
            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }
            ZipFile.CreateFromDirectory(versionFilePath, zipPath);
        }
    }
}
