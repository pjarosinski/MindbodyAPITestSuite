using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using RestSharp;

namespace OAuthAPITests
{
    public class AbstractTestSuite
    {
        private readonly Stopwatch _runTime = new Stopwatch();

        public IRestResponse BaseMockResponse = new RestResponse
            {
                ErrorException = null,
                ErrorMessage = null,
                ResponseStatus = ResponseStatus.Completed,
            };

        [SetUp]
        public virtual void SetUp()
        {
            _runTime.Start();
        }

        [TearDown]
        public virtual void TearDown()
        {
            _runTime.Stop();
            Console.WriteLine("Runtime: " + _runTime.Elapsed);
            Console.WriteLine("Test");
        }

        public bool BaseCompare(IRestResponse mockResponse, IRestResponse response)
        {
            return response.ContentLength != 0 &&
                   mockResponse.ErrorException == response.ErrorException &&
                   mockResponse.ErrorMessage == response.ErrorMessage &&
                   mockResponse.ResponseStatus.Equals(response.ResponseStatus);
        }
    }
}
