using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static string version = ConfigurationManager.AppSettings["version"];
        static string versionFilePath = ConfigurationManager.AppSettings["versionFilePath"];
        static string zipPath = ConfigurationManager.AppSettings["zipPath"];
        static void Main(string[] args)
        {
            
            WriteVersion();
            Console.WriteLine("I am agent {0}", version);
            Console.ReadLine();
        }

        public static void WriteVersion()
        {            
            try
            {
                string createText = version;
                File.WriteAllText(versionFilePath + "version.txt", createText);
                log.Info("Version updated in file");
                ZipVersionInfo();
                log.Info("Version file zipped");
            }
            catch(Exception ex)
            {
                log.Error("Error Message: " + ex.Message.ToString(), ex);
            }
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
