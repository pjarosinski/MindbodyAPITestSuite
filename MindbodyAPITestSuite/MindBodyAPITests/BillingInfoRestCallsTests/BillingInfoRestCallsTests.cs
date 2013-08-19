using System;
using MbUnit.Framework;
using MindBodyAPI.BillingInfoRestCalls;
using RestSharp;

namespace MindBodyAPITests.BillingInfoRestCallsTests
{
    public class BillingInfoRestCallsTests : AbstractRestCallTestSuite
    {
        [Test]
        public void GetUserBillingInfoTest()
        {
            BillingInfoRestCalls billingInfoRestCalls = new BillingInfoRestCalls(null, null);

            IRestResponse response = billingInfoRestCalls.GetUserBillingInfo(UserId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void AddUsersBillingInfoTest()
        {
            BillingInfoRestCalls billingInfoRestCalls = new BillingInfoRestCalls(null, null);

            IRestResponse response = billingInfoRestCalls.AddUserBillingInfo(UserId, BillingInfo);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void RemoveUsersBillingInfoTest()
        {
            BillingInfoRestCalls billingInfoRestCalls = new BillingInfoRestCalls(null, null);

            IRestResponse response = billingInfoRestCalls.RemoveUserBillingInfo(UserId, CardId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void UpdateUsersBillingInfoTest()
        {
            BillingInfoRestCalls billingInfoRestCalls = new BillingInfoRestCalls(null, null);

            IRestResponse response = billingInfoRestCalls.UpdateUserBillingInfo(UserId, CardId, BillingInfo);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
