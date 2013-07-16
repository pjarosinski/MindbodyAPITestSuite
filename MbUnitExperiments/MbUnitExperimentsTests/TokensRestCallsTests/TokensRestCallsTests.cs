using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using MbUnitExperiments.TokensRestCalls;
using RestSharp;

namespace MbUnitExperimentsTests.TokensRestCallsTests
{
    public class TokensRestCallsTests : AbstractRestCallTestSuite
    {
        [Test]
        public void GenerateTokenTest()
        {
            TokensRestCalls tokenRestCalls = new TokensRestCalls();

            IRestResponse response = tokenRestCalls.GenerateToken();

            Console.WriteLine(response);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void GetUserTokenTest()
        {
            TokensRestCalls tokensRestCalls = new TokensRestCalls();

            IRestResponse response = tokensRestCalls.GetUserToken();

            Console.WriteLine(response);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
