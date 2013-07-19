using System.Globalization;
using RestCalls.RestObjects;
using RestSharp;

namespace RestCalls.BillingInfoRestCalls
{
    public class BillingInfoRestCalls : AbstractBaseRestSetup
    {
        public IRestResponse GetUserBillingInfo(int userId)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{userId}/billinginfo", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserAccessToken);

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));

            return client.Execute(request);
        }

        public IRestResponse AddUserBillingInfo(int userId, RestBillingInfo userInfo)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{userId}/billinginfo", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserAccessToken);

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
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{userId}/billinginfo/{cardId}", Method.DELETE) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserAccessToken);

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));
            request.AddUrlSegment("cardId", cardId.ToString(CultureInfo.InvariantCulture));

            return client.Execute(request);
        }

        public IRestResponse UpdateUserBillingInfo(int userId, int cardId, RestBillingInfo userInfo)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{userId}/billinginfo/{cardId}", Method.PUT) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserAccessToken);

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
