using System.Globalization;
using MindBodyAPI.RequestDataModels;
using MindBodyAPI.ResponseModels;
using RestSharp;

namespace MindBodyAPI.RestCalls
{
    public class Checkout : AbstractBaseRestCallSetup
    {
        public Checkout(TokenModel generatedToken, TokenModel userToken) : base(generatedToken, userToken)
        {
        }

        public IRestResponse CheckoutShoppingCart(int siteId, ShoppingCartDataModel cart)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

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
