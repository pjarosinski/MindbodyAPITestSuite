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
        public string GetUser(int userId)
        {
            var client = new RestClient("http://dev2-webapi.mbodev.me");

            var request = new RestRequest("/rest/user/{id}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer" + AccessToken);

            request.AddUrlSegment("id", userId.ToString(CultureInfo.InvariantCulture));

            var response = client.Execute(request);

            return response.Content;
        }

        public string CreateUser(RestUser user)
        {
            var client = new RestClient("http://dev2-webapi.mbodev.me");

            var request = new RestRequest("/rest/user", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer" + AccessToken);

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
    }
}
