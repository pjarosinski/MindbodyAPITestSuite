using System;
using MbUnit.Framework;
using MindBodyAPITests;
using OAuthAPI.OAuthModels;
using OAuthAPI.TokensRestCalls;
using RestSharp;

namespace OAuthAPITests.TokensRestCallsTests
{
    public class TokensRestCallsTests : AbstractOAuthRestCallsSuite
    {
        [Test]
        public void GenerateTokenTest()
        {
            TokensRestCalls tokenRestCalls = new TokensRestCalls();

            IRestResponse response = tokenRestCalls.GenerateToken();

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void GetUserTokenTest()
        {
            var user = new RestAuthUser {Username = "jim.joneson3@gmail.com", Password = "jimjoneson1234"};

            TokensRestCalls tokensRestCalls = new TokensRestCalls();

            IRestResponse response = tokensRestCalls.GetUserToken(user);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
