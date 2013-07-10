using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace MbUnitExperiments.ProfileImageRestCalls
{
    public class ProfileImageRestCalls : AbstractBaseRestSetup
    {
        public string GetUserProfileImage(int userId)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{userId}/profileimage", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserAccessToken);

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));

            var response = client.Execute(request);

            return response.Content;
        }

        public string AddUserProfileImage(int userId)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{userId}/profileimage", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserAccessToken);

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(
                new
                {
                    file = "no file"
                });

            var response = client.Execute(request);

            return response.Content;
        }
    }
}
