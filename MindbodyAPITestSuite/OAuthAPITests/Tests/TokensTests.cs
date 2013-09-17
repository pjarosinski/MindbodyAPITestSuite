using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OAuthAPI.OAuthModels;
using OAuthAPI.RestCalls;
using RestSharp;

namespace OAuthAPITests.Tests
{
    public class TokensTests : AbstractTestSuite
    {
        [TestMethod]
        public void GenerateTokenTest()
        {
            IRestResponse mockResposne = BaseMockResponse;

            Tokens tokenRestCalls = new Tokens();

            IRestResponse response = tokenRestCalls.GenerateToken();

            Console.WriteLine(response.Content);

            Console.WriteLine("fuck is it in here");

            Assert.IsTrue(BaseCompare(mockResposne, response));

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [TestMethod]
        public void GetUserTokenTest()
        {
            var user = new RestAuthUser { Username = "jim.joneson5436543@gmail.com", Password = "jimjoneson1234", GrantType = "password", Scope = "urn:mboframeworkapi" };

            Tokens tokensRestCalls = new Tokens();

            IRestResponse response = tokensRestCalls.GetUserToken(user);

            Console.WriteLine(response.Content);

            Console.WriteLine("fuck is it in here");

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
