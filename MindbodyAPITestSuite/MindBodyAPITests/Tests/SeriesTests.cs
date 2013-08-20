using System;
using MbUnit.Framework;
using MindBodyAPI.RestCalls;
using RestSharp;

namespace MindBodyAPITests.Tests
{
    [Parallelizable]
    public class SeriesTests : AbstractTestSuite
    {
        [Test, Parallelizable]
        public void GetPricingOptionsForSpecificClassTest()
        {
            int siteId = -40000;
            int classInstanceId = 3245;

            Series seriesCalls = new Series(null, null);

            IRestResponse response = seriesCalls.GetPricingOptionsForSpecificClass(siteId, classInstanceId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test, Parallelizable]
        public void AddSeriesTest()
        {
            int siteId = -40000;

            Series seriesCalls = new Series(null, null);

            IRestResponse response = seriesCalls.AddSeries(siteId, SeriesData);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test, Parallelizable]
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
