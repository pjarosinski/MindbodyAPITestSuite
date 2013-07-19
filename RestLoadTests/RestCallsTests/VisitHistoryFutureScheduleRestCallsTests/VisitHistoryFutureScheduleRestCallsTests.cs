using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using RestCalls.VisitHistoryFutureScheduleRestCalls;
using RestSharp;

namespace RestCallsTests.VisitHistoryFutureScheduleRestCallsTests
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
