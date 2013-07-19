using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using RestCalls.SeriesRestCalls;
using RestSharp;

namespace RestCallsTests.SeriesRestCallsTests
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

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
