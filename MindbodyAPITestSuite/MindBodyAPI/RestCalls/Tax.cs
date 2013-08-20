using System.Globalization;
using MindBodyAPI.RequestDataModels;
using MindBodyAPI.ResponseModels;
using RestSharp;

namespace MindBodyAPI.RestCalls
{
    public class Tax : AbstractBaseRestCallSetup
    {
        public Tax(TokenModel generatedToken, TokenModel userToken) : base(generatedToken, userToken)
        {
        }

        public IRestResponse GetTaxRates(int locationId, int siteId)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/Settings/TaxTables/{LocationID}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + StaffUserToken.AccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddUrlSegment("LocationID", locationId.ToString(CultureInfo.InvariantCulture));

            return client.Execute(request);
        }

        public IRestResponse UpdateTaxRates(int locationId, int siteId, TaxDataModel taxes)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/Settings/TaxTables/{LocationID}", Method.PUT) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + StaffUserToken.AccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddUrlSegment("LocationID", locationId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(new
                {
                    Tax1 = taxes.Tax1,
                    Tax2 = taxes.Tax2,
                    Tax3 = taxes.Tax3,
                    Tax4 = taxes.Tax4,
                    Tax5 = taxes.Tax5
                });

            return client.Execute(request);
        }
    }
}
