using System;
using MbUnit.Framework;
using MindBodyAPI.RequestDataModels;
using MindBodyAPI.ResponseModels;
using MindBodyAPI.RestCalls;
using MindBodyAPITests.ParallelAttribute;
using RestSharp;

namespace MindBodyAPITests.Tests
{
    [Parallelizable]
    public class UserTests : AbstractTestSuite
    {
        [Test, Parallelizable]
        public void SetupUserTest()
        {
            User userCalls = new User(null, null);

            IRestResponse response = userCalls.SetupUser(UserId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test, ForParallel]
        public void GetUserTest()
        {
            IRestResponse mockResponse = BaseMockResponse;

            User userCalls = new User(GeneratedToken, UserToken);

            IRestResponse response = userCalls.GetUser();

            Console.WriteLine(response);

            Console.WriteLine(response.Content);

            var responseId = GetUserModel.Parse(response.Content).Id;
            var expectedId = 577;//Int32.Parse(CreatedUsers[0].Content);

            Console.WriteLine("responseId: " + responseId + " expectedId: " + expectedId);

            Assert.IsTrue(BaseCompare(mockResponse, response));
            Assert.IsTrue(responseId.Equals(expectedId));
        }

        [Test]
        public void CreateUserTest()
        {
            int content;
            IRestResponse mockResponse = BaseMockResponse;

            User userCalls = new User(GeneratedToken, null);

            IRestResponse response = userCalls.CreateUser(UserData);

            Console.WriteLine(response.Content);

            Assert.IsTrue(BaseCompare(mockResponse, response));
            Assert.AreEqual(Int32.TryParse(response.Content, out content), true);
        }

        [Test, Factory("GetRandomUser")]
        public void TestGetRandomUser(UserDataModel user)
        {
            Console.WriteLine(user.Username);
        }

        [Test, Parallelizable]
        public void UpdateUserTest()
        {
            UserProfileDataModel userProfileData = UserProfileData;

            userProfileData.State = "CA";
            userProfileData.Address = "4051 Broad Street";
            userProfileData.Zip = "93405";
            userProfileData.City = "San Luis Obispo";

            IRestResponse mockResposne = BaseMockResponse;

            User userCalls = new User(null, null);

            IRestResponse response = userCalls.UpdateUser(UserId, userProfileData);

            Console.WriteLine(response.Content);

            Assert.IsTrue(BaseCompare(mockResposne, response));
            Assert.AreNotEqual(0, response.ContentLength);
        }

        
    }
}
