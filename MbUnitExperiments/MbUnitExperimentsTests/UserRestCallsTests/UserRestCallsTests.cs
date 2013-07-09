using System;
using MbUnit.Framework;
using MbUnitExperiments.RestObjects;
using MbUnitExperiments.UserRestCalls;

namespace MbUnitExperimentsTests.UserRestCallsTests
{
    public class UserRestCallsTests : AbstractRestCallTestSuite
    {
        [Test]
        public void SetupUserTest()
        {
            UserRestCalls userRestCalls = new UserRestCalls();

            string response = userRestCalls.SetupUser(UserId);

            Console.WriteLine(response);

            Assert.AreNotEqual(0, response.Length);
        }

        [Test]
        public void GetUserTest()
        {
            UserRestCalls userRestCalls = new UserRestCalls();

            string response = userRestCalls.GetUser(UserId);

            Console.WriteLine(response);

            Assert.AreNotEqual(0, response.Length);
        }

        [Test]
        public void CreateUserTest()
        {
            UserRestCalls userRestCalls = new UserRestCalls();

            string response = userRestCalls.CreateUser(User);

            Console.WriteLine(response);

            Assert.AreNotEqual(0, response.Length);
        }

        [Test]
        public void UpdateUserTest()
        {
            UserRestCalls userRestCalls = new UserRestCalls();

            string response = userRestCalls.UpdateUser(UserId, UserProfile);

            Console.WriteLine(response);

            Assert.AreNotEqual(0, response.Length);
        }
    }
}
