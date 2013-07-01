using System;
using MbUnit.Framework;
using MbUnitExperiments.RestObjects;
using MbUnitExperiments.UserRestCalls;

namespace MbUnitExperimentsTests.UserRestCallsTests
{
    public class UserRestCallsTests : AbstractRestCallTestSuite
    {
        [Test]
        public void GetUserTest()
        {
            UserRestCalls userRestCalls = new UserRestCalls();

            string response = userRestCalls.GetUser(1000004);

            Console.WriteLine(response);

            Assert.AreNotEqual(0, response.Length);
        }

        [Test]
        public void CreateUserTest()
        {
            UserRestCalls userRestCalls = new UserRestCalls();

            RestUser user = new RestUser { Username = "chris.essley@mindbodyonline.com", Password = "owner1234", Firstname = "chris", Lastname = "essley" };

            string response = userRestCalls.CreateUser(user);

            Console.WriteLine(response);

            Assert.AreNotEqual(0, response.Length);
        }
    }
}
