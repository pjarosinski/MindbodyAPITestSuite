using System;
using MbUnit.Framework;
using MindBodyAPI.RestRequestObjects;
using MindBodyAPI.TaxRestCalls;
using RestSharp;

namespace MindBodyAPITests.TaxRestCallsTests
{
    public class TaxRestCallsTests : AbstractRestCallTestSuite
    {
        [Test]
        public void GetTaxRatesTest()
        {
            int locationId = 4;
            int siteId = -40000;

            TaxRestCalls taxRestCalls = new TaxRestCalls();

            IRestResponse response = taxRestCalls.GetTaxRates(locationId, siteId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void UpdateTaxRates()
        {
            int locationId = 4;
            int siteId = -40000;

            RestRequestTaxes taxes = new RestRequestTaxes { Tax1 = 3.3, Tax2 = 2.5, Tax3 = 6.7, Tax4 = 2.3, Tax5 = 1.1 };

            TaxRestCalls taxRestCalls = new TaxRestCalls();

            IRestResponse response = taxRestCalls.UpdateTaxRates(locationId, siteId, taxes);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
