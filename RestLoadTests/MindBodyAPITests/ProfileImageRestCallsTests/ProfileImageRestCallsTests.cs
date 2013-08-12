using System;
using MbUnit.Framework;
using MindBodyAPI.ProfileImageRestCalls;
using RestSharp;

namespace MindBodyAPITests.ProfileImageRestCallsTests
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
