using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using MbUnitExperiments.TokensRestCalls;

namespace MbUnitExperimentsTests.TokensRestCallsTests
{
    public class TokensRestCallsTests : AbstractRestCallTestSuite
    {
        [Test]
        public void GenerateTokenTest()
        {
            TokensRestCalls tokenRestCalls = new TokensRestCalls();

            string response = tokenRestCalls.GenerateToken();

            Console.WriteLine(response);

            Assert.AreNotEqual(0, response.Length);
        }
    }
}
