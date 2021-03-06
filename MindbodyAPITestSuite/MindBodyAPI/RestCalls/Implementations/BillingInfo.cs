﻿using System.Globalization;
using MindBodyAPI.RequestDataModels;
using MindBodyAPI.ResponseModels;
using MindBodyAPI.RestCalls.Interfaces;
using RestSharp;

namespace MindBodyAPI.RestCalls
{
    public class BillingInfo : AbstractBaseRestCallSetup, IBillingInfo 
    {
        public BillingInfo(TokenModel generatedToken, TokenModel userToken) : base(generatedToken, userToken)
        {
        }

        public IRestResponse GetUserBillingInfo(int userId)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{userId}/billinginfo", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserToken.AccessToken);

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));

            return client.Execute(request);
        }

        public IRestResponse AddUserBillingInfo(int userId, BillingInfoDataModel userInfo)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{userId}/billinginfo", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserToken.AccessToken);

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(new
                {
                    name = userInfo.Name,
                    streetaddress = userInfo.StreetAddress,
                    city = userInfo.City,
                    state = userInfo.State,
                    postalcode = userInfo.PostalCode,
                    cardnumber = userInfo.CardNumber,
                    expirationmonth = userInfo.ExpirationMonth,
                    expirationyear = userInfo.ExpirationYear,
                    CVV = userInfo.Cvv,
                    primarycard = userInfo.PrimaryCard
                });

            return client.Execute(request);
        }

        public IRestResponse RemoveUserBillingInfo(int userId, int cardId)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{userId}/billinginfo/{cardId}", Method.DELETE) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserToken.AccessToken);

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));
            request.AddUrlSegment("cardId", cardId.ToString(CultureInfo.InvariantCulture));

            return client.Execute(request);
        }

        public IRestResponse UpdateUserBillingInfo(int userId, int cardId, BillingInfoDataModel userInfo)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{userId}/billinginfo/{cardId}", Method.PUT) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserToken.AccessToken);

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));
            request.AddUrlSegment("cardId", cardId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(new
                {
                    name = userInfo.Name,
                    streetaddress = userInfo.StreetAddress,
                    city = userInfo.City,
                    state = userInfo.State,
                    postalcode = userInfo.PostalCode,
                    cardnumber = userInfo.CardNumber,
                    expirationmonth = userInfo.ExpirationMonth,
                    expirationyear = userInfo.ExpirationYear,
                    CVV = userInfo.Cvv,
                    primarycard = userInfo.PrimaryCard
                });

            return client.Execute(request);
        }
    }
}
