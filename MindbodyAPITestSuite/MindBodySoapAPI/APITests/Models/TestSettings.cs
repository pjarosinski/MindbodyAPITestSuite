using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace MindbodySoapAPI.APITests.Models
{
    public class TestSettings
    {
        public String SiteID;
        public String SubDomain;
        public String Domain;
        public bool useGrid;
        public bool loggedOut;
        public bool consumerMode;
        public bool runOnCopy;
        public string username;
        public string password;
        public string MasterSiteID;
        public bool cleanCopy;
        public bool reusable;
        public String browserName;

        public TestSettings()
        {
        }

        private static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static TestSettings ParseSettings()
        {
            TestSettings result;
            //TODO normalize the relative JSON directory so the assembly can be executed from anywhere
            String data = readFile(AssemblyDirectory + "\\..\\..\\..\\..\\TestSettings.json");
            //String data = readFile("C:\\IIS\\wwwroot\\mbregressiontests\\TestSettings.json");

            if (String.IsNullOrEmpty(data))
            {
                data = readFile(AssemblyDirectory + "\\..\\..\\TestSettings.json");
                if (String.IsNullOrEmpty(data))
                {
                    throw new FileNotFoundException("TestSettings.json missing from repository root folder! Create one.");
                }
                
            }

            if (data.Contains("isParallel"))
            {
                Console.WriteLine("The isParallel attribute can be removed from your TestSettings.json.");
            }

            result = JsonConvert.DeserializeObject<TestSettings>(data);


            return result;
        }

        private static String readFile(String filename)
        {
            String result = "";
            StreamReader reader;

            try
            {
                reader = new StreamReader(filename);
            }
            catch (FileNotFoundException)
            {
                return "";
            }
            catch (DirectoryNotFoundException)
            {
                return "";
            }

            while (reader.Peek() != -1)
            {
                result += reader.ReadLine();
            }
            reader.Close();
            return result;
        }
    }
}
