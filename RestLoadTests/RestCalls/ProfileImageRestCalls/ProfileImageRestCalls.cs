﻿using System.Globalization;
using RestSharp;

namespace RestCalls.ProfileImageRestCalls
{
    public class ProfileImageRestCalls : AbstractBaseRestSetup
    {
        public IRestResponse GetUserProfileImage(int userId)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{userId}/profileimage", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserToken.AccessToken);

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture)); 

            return client.Execute(request);
        }

        public IRestResponse AddUserProfileImage(int userId, string base64File)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{userId}/profileimage", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserToken.AccessToken);

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(
                new
                {
                    file = base64File
                });

            return client.Execute(request);
        }
    }
}
