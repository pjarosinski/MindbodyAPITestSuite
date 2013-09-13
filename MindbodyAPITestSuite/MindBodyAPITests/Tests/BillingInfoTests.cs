using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MindBodyAPI.RestCalls;
using RestSharp;

namespace MindBodyAPITests.Tests
{
    public class BillingInfoTests : BaseTestSuite
    {
        [TestMethod]
        public void GetUserBillingInfoTest()
        {
            BillingInfo billingInfoCalls = new BillingInfo(null, null);

            IRestResponse response = billingInfoCalls.GetUserBillingInfo(UserId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [TestMethod]
        public void AddUsersBillingInfoTest()
        {
            BillingInfo billingInfoCalls = new BillingInfo(null, null);

            IRestResponse response = billingInfoCalls.AddUserBillingInfo(UserId, BillingInfoData);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [TestMethod]
        public void RemoveUsersBillingInfoTest()
        {
            BillingInfo billingInfoCalls = new BillingInfo(null, null);

            IRestResponse response = billingInfoCalls.RemoveUserBillingInfo(UserId, CardId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [TestMethod]
        public void UpdateUsersBillingInfoTest()
        {
            BillingInfo billingInfoCalls = new BillingInfo(null, null);

            IRestResponse response = billingInfoCalls.UpdateUserBillingInfo(UserId, CardId, BillingInfoData);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
