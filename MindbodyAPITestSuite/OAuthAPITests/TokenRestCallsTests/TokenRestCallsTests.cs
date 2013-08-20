using System;
using MbUnit.Framework;
using OAuthAPI.OAuthModels;
using OAuthAPI.TokenRestCalls;
using RestSharp;

namespace OAuthAPITests.TokenRestCallsTests
{
    public class TokenRestCallsTests : AbstractOAuthRestCallsSuite
    {
        [Test]
        public void GenerateTokenTest()
        {
            TokenRestCalls tokenRestCalls = new TokenRestCalls();

            IRestResponse response = tokenRestCalls.GenerateToken();

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void GetUserTokenTest()
        {
            var user = new RestAuthUser {Username = "jim.joneson3@gmail.com", Password = "jimjoneson1234"};

            TokenRestCalls tokensRestCalls = new TokenRestCalls();

            IRestResponse response = tokensRestCalls.GetUserToken(user);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
