using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MindBodyAPI.RestCalls;
using RestSharp;

namespace MindBodyAPITests.Tests
{
    public class VisitHistoryFutureScheduleTests : BaseTestSuite
    {
        [TestMethod]
        public void GetVisitHistoryFutureScheduleTest()
        {
            string startDate = "08/10/2013";
            string endDate = "08/20/2013";

            VisitHistoryFutureSchedule visitHistoryFutureScheduleCalls = new VisitHistoryFutureSchedule(null, null);

            IRestResponse response = visitHistoryFutureScheduleCalls.GetVisitHistoryFutureSchedule(UserId, startDate, endDate);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
