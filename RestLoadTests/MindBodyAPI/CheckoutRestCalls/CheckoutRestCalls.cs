﻿using System.Globalization;
using MindBodyAPI.RestRequestObjects;
using RestSharp;

namespace MindBodyAPI.CheckoutRestCalls
{
    public class CheckoutRestCalls : AbstractBaseRestSetup
    {
        public IRestResponse CheckoutShoppingCart(int siteId, RestRequestShoppingCart cart)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/sale/Checkout", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserToken.AccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(new
                {
                    seriesID = cart.SeriesId,
                    amount = cart.Amount,
                    userID = cart.UserId,
                    userBillingInfoID = cart.UserBillingInfoId
                });

            return client.Execute(request);
        }
    }
}
