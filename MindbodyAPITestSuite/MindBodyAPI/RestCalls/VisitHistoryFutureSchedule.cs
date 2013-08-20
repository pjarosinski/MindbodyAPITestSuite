using System.Globalization;
using MindBodyAPI.ResponseModels;
using RestSharp;

namespace MindBodyAPI.RestCalls
{
    public class VisitHistoryFutureSchedule : AbstractBaseRestCallSetup
    {
        public VisitHistoryFutureSchedule(TokenModel generatedToken, TokenModel userToken) : base(generatedToken, userToken)
        {
        }

        public IRestResponse GetVisitHistoryFutureSchedule(int userId, string startDate, string endDate)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{id}/visits?startrange={startDate}&endrange={endDate}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedToken.AccessToken);

            request.AddUrlSegment("id", userId.ToString(CultureInfo.InvariantCulture));
            request.AddUrlSegment("startDate", startDate);
            request.AddUrlSegment("endDate", endDate);

            return client.Execute(request);
        }
    }
}
