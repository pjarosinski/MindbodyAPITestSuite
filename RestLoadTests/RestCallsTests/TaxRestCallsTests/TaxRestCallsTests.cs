using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using RestCalls.RestObjects;
using RestCalls.TaxRestCalls;
using RestSharp;

namespace RestCallsTests.TaxRestCallsTests
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

            RestTaxes taxes = new RestTaxes {Tax1 = 3.3, Tax2 = 2.5, Tax3 = 6.7, Tax4 = 2.3, Tax5 = 1.1};

            TaxRestCalls taxRestCalls = new TaxRestCalls();

            IRestResponse response = taxRestCalls.UpdateTaxRates(locationId, siteId, taxes);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
