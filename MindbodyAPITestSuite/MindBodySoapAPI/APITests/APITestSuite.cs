using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using MbUnit.Framework;
using MindbodySoapAPI.APITests.Models;
using MindbodySoapAPI.APITests.Utils;
using MindbodySoapAPI.APITests.Utils.DiffTools;
using MindbodySoapAPI.APITests.Utils.ParsingTools;
using Test = MindbodySoapAPI.APITests.Utils.ParsingTools.Test;

namespace MindbodySoapAPI.APITests
{
    public abstract class APITestSuite
    {
        protected int NormalSiteID = -99;
        protected int DestructiveSiteID = -99;
        protected int AutoBotsMaster = -40001;
        protected static string OhCanada = "ohcanada";
        protected static string Dev16 = "dev16";
        protected static string Clients = "clients";
        protected static string DefaultProductionDomain = "api";
        protected static string DefaultDevDomain = OhCanada;
        protected static string DomainOne = DefaultProductionDomain;
        protected static string DomainTwo = Clients;
        //protected string DomainOneOutput = Environment.NewLine + DomainOne + " results:";
        //protected string DomainTwoOutput = Environment.NewLine + DomainTwo + " results:";

        public string SourcePassword
        {
            get
            {
                return DomainOne.Equals(DefaultProductionDomain)
                           ? DefaultCredentials.ProductionSourcePassword
                           : DefaultCredentials.DevSourcePassword;
            }
        }

        protected string SourceUser { get { return DefaultCredentials.SourceUser; } }
       

        public DiffModule ApiDiffModule
        {
            get { return new DiffModule(); }
        }

        public TestSettings Settings
        {
            get
            {
                return new TestSettings
                    {
                        SubDomain = "api"
                    };
            }
        }

        public Tuple<string, string> Domains { get { return new Tuple<string, string>(DomainOne, DomainTwo);}} 

        
        private readonly ThreadLocal<Stopwatch> _StopWatch = new ThreadLocal<Stopwatch>();

        private Stopwatch Stopwatch
        {
            get { return _StopWatch.Value; }
            set { _StopWatch.Value = value; }
        }

        [SetUp, Parallelizable]
        public virtual void TestSetup()
        {

            Stopwatch = Stopwatch.StartNew();
            VerfiyAndSetDomain(Settings.SubDomain);
        }

        [TearDown, Parallelizable]
        public virtual void TearDown()
        {
            Stopwatch.Stop();
            Console.WriteLine("\nTest ran in " + Stopwatch.ElapsedMilliseconds / 1000.0 + " seconds.");

        }

        public string BuildURLWithDomain(string domain, bool useHttps = false)
        {
            return new ApiUrlBuilder(domain, GetService(), useHttps).Build();
        }

        protected virtual Test GetTest(string testName)
        {
            var test = TestList.Tests.FirstOrDefault(t => t.TestName.Equals(testName));
            //LogTest(testName, test);
            return test;
        }

        private static void VerfiyAndSetDomain(string subdomain)
        {
            try
            {
                if (subdomain.Contains("clients") || subdomain.Equals("api"))
                {
                    DomainOne = DefaultProductionDomain;
                }
                else
                {
                    DomainOne = DefaultDevDomain;
                }
            }
            catch (Exception)
            {
                Console.Error.WriteLine("Please specify a subdomain in TestSettings.json");
                throw;
            }

            DomainTwo = subdomain;
        }

        private string GetService()
        {
            return GetType().Name.Replace("Tests", "Service");
        }
    }
}