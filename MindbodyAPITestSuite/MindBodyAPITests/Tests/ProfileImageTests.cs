using System;
using MbUnit.Framework;
using MindBodyAPI.RestCalls;
using RestSharp;

namespace MindBodyAPITests.Tests
{
    public class ProfileImageTests : AbstractTestSuite
    {
        [Test]
        public void GetUserProfileImageTest()
        {
            ProfileImage profileImageCalls = new ProfileImage(null, null);

            IRestResponse response = profileImageCalls.GetUserProfileImage(UserId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void AddUserProfileImageTest()
        {
            string base64File = "324234234234234";

            ProfileImage profileImageCalls = new ProfileImage(null, null);

            IRestResponse response = profileImageCalls.AddUserProfileImage(UserId, base64File);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
