using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using RestCalls.ProfileImageRestCalls;
using RestSharp;

namespace RestCallsTests.ProfileImageRestCallsTests
{
    public class ProfileImageRestCallsTests : AbstractRestCallTestSuite
    {
        [Test]
        public void GetUserProfileImageTest()
        {
            ProfileImageRestCalls profileImageRestCalls = new ProfileImageRestCalls();

            IRestResponse response = profileImageRestCalls.GetUserProfileImage(UserId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void AddUserProfileImageTest()
        {
            string base64File = "324234234234234";

            ProfileImageRestCalls profileImageRestCalls = new ProfileImageRestCalls();

            IRestResponse response = profileImageRestCalls.AddUserProfileImage(UserId, base64File);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
