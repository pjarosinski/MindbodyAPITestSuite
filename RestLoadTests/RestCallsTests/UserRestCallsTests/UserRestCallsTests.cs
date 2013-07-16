using System;
using MbUnit.Framework;
using RestSharp;

namespace RestCallsTests.UserRestCallsTests
{
    public class UserRestCallsTests : AbstractRestCallTestSuite
    {
        [Test]
        public void SetupUserTest()
        {
            UserRestCalls userRestCalls = new UserRestCalls();

            IRestResponse response = userRestCalls.SetupUser(UserId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void GetUserTest()
        {
            UserRestCalls userRestCalls = new UserRestCalls();

            IRestResponse response = userRestCalls.GetUser(UserId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void CreateUserTest()
        {
            UserRestCalls userRestCalls = new UserRestCalls();

            IRestResponse response = userRestCalls.CreateUser(User);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void UpdateUserTest()
        {
            UserRestCalls userRestCalls = new UserRestCalls();

            IRestResponse response = userRestCalls.UpdateUser(UserId, UserProfile);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
