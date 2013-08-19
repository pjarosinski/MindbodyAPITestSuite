using System;
using MbUnit.Framework;
using MindBodyAPI.VisitHistoryFutureScheduleRestCalls;
using RestSharp;

namespace MindBodyAPITests.VisitHistoryFutureScheduleRestCallsTests
{
    public class VisitHistoryFutureScheduleRestCallsTests : AbstractRestCallTestSuite
    {
        [Test]
        public void GetVisitHistoryFutureScheduleTest()
        {
            string startDate = "08/10/2013";
            string endDate = "08/20/2013";

            VisitHistoryFutureScheduleRestCalls visitHistoryFutureScheduleRestCalls = new VisitHistoryFutureScheduleRestCalls();

            IRestResponse response = visitHistoryFutureScheduleRestCalls.GetVisitHistoryFutureSchedule(UserId, startDate, endDate);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
