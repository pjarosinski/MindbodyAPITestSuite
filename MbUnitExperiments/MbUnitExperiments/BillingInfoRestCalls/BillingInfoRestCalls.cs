using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace MbUnitExperiments.BillingInfoRestCalls
{
    public class BillingInfoRestCalls : AbstractBaseRestSetup
    {
        public string GetUserBillingInfo(int userId)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{userId}/profileimage", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserAccessToken);

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));

            var response = client.Execute(request);

            return response.Content;
        }

        public string AddUserBillingInfo()
        {
            return "";
        }

        public string RemoveUserBillingInfo()
        {
            return "";
        }

        public string UpdateUserBillingInfo()
        {
            return "";
        }
    }
}
