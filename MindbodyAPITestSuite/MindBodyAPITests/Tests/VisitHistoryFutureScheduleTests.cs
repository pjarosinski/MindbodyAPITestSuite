using System;
using MbUnit.Framework;
using MindBodyAPI.RestCalls;
using RestSharp;

namespace MindBodyAPITests.Tests
{
    [Parallelizable]
    public class VisitHistoryFutureScheduleTests : AbstractTestSuite
    {
        [Test, Parallelizable]
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
