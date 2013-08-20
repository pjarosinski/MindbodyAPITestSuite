using System;
using MbUnit.Framework;
using MindBodyAPI.RequestDataModels;
using MindBodyAPI.RestCalls;
using RestSharp;

namespace MindBodyAPITests.Tests
{
    public class CheckoutTests : AbstractTestSuite
    {
        [Test]
        public void CheckoutShoppingCartTest()
        {
            int siteId = -40000;

            //needs real mock data as do all tests 7-19-13
            ShoppingCartDataModel cart = new ShoppingCartDataModel { SeriesId = 234, Amount = 3.50, UserId = UserId, UserBillingInfoId = 4 };

            Checkout checkoutCalls = new Checkout(null, null);

            IRestResponse response = checkoutCalls.CheckoutShoppingCart(siteId, cart);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
