using MbUnit.Framework;
using MindbodySoapAPI.APITests.Requests;
using MindbodySoapAPI.APITests.Utils.AssertHelpers;

namespace MindbodySoapAPI.APITests.Tests
{
    [TestFixture, Category("DataTests"), Category("APITests")]
    public class DataTests : APITestSuite
    {

        [Test,  Parallelizable]
        public void TestSelectCsvRequest()
        {
            var test = GetTest("testSelectDataRequest");
            var domainOneResults = DataRequests.SelectDataCsvRequest(test.ArgList, DomainOne);
            var domainTwoResults = DataRequests.SelectDataCsvRequest(test.ArgList, DomainTwo);
            
            Assert_Api.AssertResults(domainOneResults, domainTwoResults);
        }

        [Test,  Parallelizable]
        public void TestSelectXmlRequest()
        {
            var test = GetTest("testSelectDataRequest");
            var domainOneResults = DataRequests.SelectDataXmlRequest(test.ArgList, DomainOne);
            var domainTwoResults = DataRequests.SelectDataXmlRequest(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResults, domainTwoResults, false);
        }

        [Test,  Parallelizable]
        public void TestSelectAggregateCsvRequest()
        {
            var test = GetTest("testSelectAggregateDataRequest");
            var domainOneResults = DataRequests.SelectAggregateDataCsvRequest(test.ArgList, DomainOne);
            var domainTwoResults = DataRequests.SelectAggregateDataCsvRequest(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResults, domainTwoResults);
        }

        [Test,  Parallelizable]
        public void TestSelectAggregateXmlRequest()
        {
            var test = GetTest("testSelectAggregateDataRequest");
            var domainOneResults = DataRequests.SelectAggregateDataXmlRequest(test.ArgList, DomainOne);
            var domainTwoResults = DataRequests.SelectAggregateDataXmlRequest(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResults, domainTwoResults, false);
        }

    }

}
