using System;
using MbUnit.Framework;
using MindBodyAPI.RestCalls;
using RestSharp;

namespace MindBodyAPITests.Tests
{
    [Parallelizable]
    public class ProfileImageTests : AbstractTestSuite
    {
        [Test, Parallelizable]
        public void GetUserProfileImageTest()
        {
            ProfileImage profileImageCalls = new ProfileImage(null, null);

            IRestResponse response = profileImageCalls.GetUserProfileImage(UserId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test, Parallelizable]
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
