using RestSharp;

namespace MindBodyAPI.RestCalls.Interfaces
{
    interface IVisitHistoryFutureSchedule
    {
        IRestResponse GetVisitHistoryFutureSchedule(int userId, string startDate, string endDate);
    }
}
