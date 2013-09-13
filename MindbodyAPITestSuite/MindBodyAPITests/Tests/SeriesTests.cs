using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MindBodyAPI.RestCalls;
using RestSharp;

namespace MindBodyAPITests.Tests
{

    public class SeriesTests : BaseTestSuite
    {
        [TestMethod]
        public void GetPricingOptionsForSpecificClassTest()
        {
            int siteId = -40000;
            int classInstanceId = 3245;

            Series seriesCalls = new Series(null, null);

            IRestResponse response = seriesCalls.GetPricingOptionsForSpecificClass(siteId, classInstanceId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [TestMethod]
        public void AddSeriesTest()
        {
            int siteId = -40000;

            Series seriesCalls = new Series(null, null);

            IRestResponse response = seriesCalls.AddSeries(siteId, SeriesData);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [TestMethod]
        public void UpdateSeriesTest()
        {
            int siteId = -40000;

            Series seriesCalls = new Series(null, null);

            IRestResponse response = seriesCalls.UpdateSeries(siteId, SeriesData);

            Console.WriteLine(response.Content);

            Console.WriteLine(response);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
