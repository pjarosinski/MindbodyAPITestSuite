using System;
using MbUnit.Framework;
using RestCalls.RestObjects;
using RestCalls.UserRestCalls;
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

        [Test, Factory("GetRandomUser")]
        public void CreateUserTest(RestUser user)
        {
            UserRestCalls userRestCalls = new UserRestCalls();

            IRestResponse response = userRestCalls.CreateUser(user);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test, Factory("GetRandomUser")]
        public void TestGetRandomUser(RestUser user)
        {
            Console.WriteLine(user.Username);
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
