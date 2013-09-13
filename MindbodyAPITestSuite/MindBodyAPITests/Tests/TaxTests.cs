using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MindBodyAPI.RequestDataModels;
using MindBodyAPI.RestCalls;
using RestSharp;

namespace MindBodyAPITests.Tests
{

    public class TaxTests : BaseTestSuite
    {
        [TestMethod]
        public void GetTaxRatesTest()
        {
            int locationId = 4;
            int siteId = -40000;

            Tax taxCalls = new Tax(null, null);

            IRestResponse response = taxCalls.GetTaxRates(locationId, siteId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [TestMethod]
        public void UpdateTaxRates()
        {
            int locationId = 4;
            int siteId = -40000;

            TaxDataModel taxes = new TaxDataModel { Tax1 = 3.3, Tax2 = 2.5, Tax3 = 6.7, Tax4 = 2.3, Tax5 = 1.1 };

            Tax taxCalls = new Tax(null, null);

            IRestResponse response = taxCalls.UpdateTaxRates(locationId, siteId, taxes);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
