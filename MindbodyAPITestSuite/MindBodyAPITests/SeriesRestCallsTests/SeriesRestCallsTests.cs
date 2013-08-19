using System;
using MbUnit.Framework;
using MindBodyAPI.SeriesRestCalls;
using RestSharp;

namespace MindBodyAPITests.SeriesRestCallsTests
{
    public class SeriesRestCallsTests : AbstractRestCallTestSuite
    {
        [Test]
        public void GetPricingOptionsForSpecificClassTest()
        {
            int siteId = -40000;
            int classInstanceId = 3245;

            SeriesRestCalls seriesRestCalls = new SeriesRestCalls();

            IRestResponse response = seriesRestCalls.GetPricingOptionsForSpecificClass(siteId, classInstanceId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void AddSeriesTest()
        {
            int siteId = -40000;

            SeriesRestCalls seriesRestCalls = new SeriesRestCalls();

            IRestResponse response = seriesRestCalls.AddSeries(siteId, Series);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void UpdateSeriesTest()
        {
            int siteId = -40000;

            SeriesRestCalls seriesRestCalls = new SeriesRestCalls();

            IRestResponse response = seriesRestCalls.UpdateSeries(siteId, Series);

            Console.WriteLine(response.Content);

            Console.WriteLine(response);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
