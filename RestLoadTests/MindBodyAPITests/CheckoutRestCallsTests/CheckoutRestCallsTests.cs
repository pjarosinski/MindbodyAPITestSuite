using System;
using MbUnit.Framework;
using MindBodyAPI.CheckoutRestCalls;
using MindBodyAPI.RestRequestObjects;
using RestSharp;

namespace MindBodyAPITests.CheckoutRestCallsTests
{
    public class CheckoutRestCallsTests : AbstractRestCallTestSuite
    {
        [Test]
        public void CheckoutShoppingCartTest()
        {
            int siteId = -40000;

            //needs real mock data as do all tests 7-19-13
            RestRequestShoppingCart cart = new RestRequestShoppingCart { SeriesId = 234, Amount = 3.50, UserId = UserId, UserBillingInfoId = 4 };

            CheckoutRestCalls checkoutRestCalls = new CheckoutRestCalls();

            IRestResponse response = checkoutRestCalls.CheckoutShoppingCart(siteId, cart);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
