﻿using System.Globalization;
using MindBodyAPI.RequestDataModels;
using MindBodyAPI.ResponseModels;
using MindBodyAPI.RestCalls.Interfaces;
using RestSharp;

namespace MindBodyAPI.RestCalls
{
    public class Staff : AbstractBaseRestCallSetup, IStaff 
    {
        public Staff(TokenModel generatedToken, TokenModel userToken) : base(generatedToken, userToken)
        {
        }

        public IRestResponse AddStaff(int siteId, StaffDataModel staff)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/staff", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + StaffUserToken.AccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(
                new
                {
                    firstname = staff.Firstname,
                    lastname = staff.Lastname,
                    bio = staff.Bio,
                    email = staff.Email,
                    phone = staff.Phone,
                    isFemale = staff.IsFemale
                });

            return client.Execute(request);
        }

        public IRestResponse UpdateStaff(int siteId, int staffId, StaffDataModel staff)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/staff/{staffId}", Method.PUT) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + StaffUserToken.AccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddUrlSegment("staffId", staffId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(
                new
                {
                    firstname = staff.Firstname,
                    lastname = staff.Lastname,
                    bio = staff.Bio,
                    email = staff.Email,
                    phone = staff.Phone,
                    isFemale = staff.IsFemale
                });

            return client.Execute(request);
        }

        public IRestResponse StaffToken(StaffInfoDataModel staff)
        {
            var client = new RestClient("https://auth.mbodev.me");

            var request = new RestRequest("/issue/oauth2/token", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic aW50ZWdyYXRpb25fY2xpZW50OnNlY3JldA==");

            request.AddBody(
                new
                {
                    username = staff.Username,
                    password = staff.Password,
                    scope = staff.Scope,
                    grant_type = staff.GrantType,
                    subscriberid = staff.SubscriberId
                });

            return client.Execute(request);
        }

        public IRestResponse StaffPhoto(int siteId, int staffId, string base64File)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/staff/ProfileImage/?staffID={StaffID}", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + StaffUserToken.AccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddUrlSegment("StaffID", staffId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(
                new
                {
                    file = base64File
                });

            return client.Execute(request);
        }
    }
}
