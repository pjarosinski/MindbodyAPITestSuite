using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using RestCalls.CheckoutRestCalls;
using RestCalls.RestObjects;
using RestSharp;

namespace RestCallsTests.CheckoutRestCallsTests
{
    public class CheckoutRestCallsTests : AbstractRestCallTestSuite
    {
        [Test]
        public void CheckoutShoppingCartTest()
        {
            int siteId = -40000;

            //needs real mock data as do all tests 7-19-13
            RestShoppingCart cart = new RestShoppingCart { SeriesId = 234, Amount = 3.50, UserId = UserId, UserBillingInfoId = 4 };

            CheckoutRestCalls checkoutRestCalls = new CheckoutRestCalls();

            IRestResponse response = checkoutRestCalls.CheckoutShoppingCart(siteId, cart);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
