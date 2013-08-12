using System;
using MbUnit.Framework;
using MindBodyAPI.TokensRestCalls;
using RestSharp;

namespace MindBodyAPITests.TokensRestCallsTests
{
    public class TokensRestCallsTests : AbstractRestCallTestSuite
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
            TokensRestCalls tokensRestCalls = new TokensRestCalls();

            IRestResponse response = tokensRestCalls.GetUserToken();

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
