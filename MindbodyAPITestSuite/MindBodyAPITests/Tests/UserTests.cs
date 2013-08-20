﻿using System;
using MbUnit.Framework;
using MindBodyAPI.RequestDataModels;
using MindBodyAPI.RestCalls;
using RestSharp;

namespace MindBodyAPITests.Tests
{
    public class UserTests : AbstractTestSuite
    {
        [Test]
        public void SetupUserTest()
        {
            User userCalls = new User(null, null);

            IRestResponse response = userCalls.SetupUser(UserId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void GetUserTest()
        {
            User userCalls = new User(GeneratedToken, UserToken);

            IRestResponse response = userCalls.GetUser();

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
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

        [Test]
        public void UpdateUserTest()
        {
            User userCalls = new User(null, null);

            IRestResponse response = userCalls.UpdateUser(UserId, UserProfileData);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        
    }
}