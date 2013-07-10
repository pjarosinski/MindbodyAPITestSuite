using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnitExperiments.RestObjects;
using RestSharp;

namespace MbUnitExperiments.UserRestCalls
{
    public class UserRestCalls : AbstractBaseRestSetup
    {
        public string SetupUser(int userId)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{id}/setup") {RequestFormat = DataFormat.Json};

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedAccessToken);

            request.AddUrlSegment("id", userId.ToString(CultureInfo.InvariantCulture));

            var response = client.Execute(request);

            return response.Content;
        }

        public string GetUser(int userId)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{id}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedAccessToken);

            request.AddUrlSegment("id", userId.ToString(CultureInfo.InvariantCulture));

            var response = client.Execute(request);

            return response.Content;
        }

        public string CreateUser(RestUser user)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/user", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedAccessToken);

            request.AddBody(
                new
                    {
                        username = user.Username,
                        password = user.Password,
                        firstname = user.Firstname,
                        lastname = user.Lastname
                    });

            var response = client.Execute(request);

            return response.Content;
        }

        public string UpdateUser(int userId, RestUserProfile userProfile)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{id}", Method.PUT) {RequestFormat = DataFormat.Json};

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserAccessToken);

            request.AddBody(
                new
                    {
                        firstname = userProfile.FirstName,
                        lastname = userProfile.LastName,
                        address = userProfile.Address,
                        city = userProfile.City,
                        state = userProfile.State,
                        zip = userProfile.Zip
                    });

            var response = client.Execute(request);

            return response.Content;
        }
    }
}
