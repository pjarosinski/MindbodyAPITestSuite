using System;
using MbUnit.Framework;
using OAuthAPI.OAuthModels;
using OAuthAPI.RestCalls;
using RestSharp;

namespace OAuthAPITests.Tests
{
    public class TokensTests : AbstractTestSuite
    {
        [Test]
        public void GenerateTokenTest()
        {
            Tokens tokenRestCalls = new Tokens();

            IRestResponse response = tokenRestCalls.GenerateToken();

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void GetUserTokenTest()
        {
            var user = new RestAuthUser {Username = "jim.joneson3@gmail.com", Password = "jimjoneson1234"};

            Tokens tokensRestCalls = new Tokens();

            IRestResponse response = tokensRestCalls.GetUserToken(user);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
