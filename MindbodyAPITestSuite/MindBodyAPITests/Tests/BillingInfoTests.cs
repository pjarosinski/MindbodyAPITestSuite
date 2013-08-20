using System;
using MbUnit.Framework;
using MindBodyAPI.RestCalls;
using RestSharp;

namespace MindBodyAPITests.Tests
{
    [Parallelizable]
    public class BillingInfoTests : AbstractTestSuite
    {
        [Test, Parallelizable]
        public void GetUserBillingInfoTest()
        {
            BillingInfo billingInfoCalls = new BillingInfo(null, null);

            IRestResponse response = billingInfoCalls.GetUserBillingInfo(UserId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test, Parallelizable]
        public void AddUsersBillingInfoTest()
        {
            BillingInfo billingInfoCalls = new BillingInfo(null, null);

            IRestResponse response = billingInfoCalls.AddUserBillingInfo(UserId, BillingInfoData);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test, Parallelizable]
        public void RemoveUsersBillingInfoTest()
        {
            BillingInfo billingInfoCalls = new BillingInfo(null, null);

            IRestResponse response = billingInfoCalls.RemoveUserBillingInfo(UserId, CardId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test, Parallelizable]
        public void UpdateUsersBillingInfoTest()
        {
            BillingInfo billingInfoCalls = new BillingInfo(null, null);

            IRestResponse response = billingInfoCalls.UpdateUserBillingInfo(UserId, CardId, BillingInfoData);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
