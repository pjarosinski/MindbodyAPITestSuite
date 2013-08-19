﻿using System;
using System.Collections.Generic;
using System.Net;
using MbUnit.Framework;
using MindBodyAPI.RestRequestObjects;
using MindBodyAPI.UserRestCalls;
using RestSharp;

namespace MindBodyAPITests.UserRestCallsTests
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
            int content;
            IRestResponse mockResponse = BaseMockResponse;
                
            UserRestCalls userRestCalls = new UserRestCalls();

            IRestResponse response = userRestCalls.CreateUser(User);

            Console.WriteLine(response.Content);

            Assert.IsTrue(BaseAssert(mockResponse, response));
            Assert.AreEqual(Int32.TryParse(response.Content, out content), true);
            
        }

        [Test, Factory("GetRandomUser")]
        public void TestGetRandomUser(RestRequestUser user)
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

        public IEnumerable<object> GetRandomUser()
        {
            for (int i = 0; i < 2; i++)
            {
                yield return new RestRequestUser { Username = "joe" + i + ".joneson@mindbodyonline.com", Password = "owner1234", Firstname = "jim", Lastname = "joneson" };
            }
        }
    }
}
