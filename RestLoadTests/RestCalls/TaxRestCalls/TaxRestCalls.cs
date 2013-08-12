using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestCalls.RestRequestObjects;
using RestSharp;

namespace RestCalls.TaxRestCalls
{
    public class TaxRestCalls : AbstractBaseRestSetup
    {
        public IRestResponse GetTaxRates(int locationId, int siteId)
        {
            var client = new RestClient("http://dev-mobile-rest.mbodev.me");

            var request = new RestRequest("/Settings/TaxTables/{LocationID}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + StaffUserToken.AccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddUrlSegment("LocationID", locationId.ToString(CultureInfo.InvariantCulture));

            return client.Execute(request);
        }

        public IRestResponse UpdateTaxRates(int locationId, int siteId, RestRequestTaxes taxes)
        {
            var client = new RestClient("http://dev-mobile-rest.mbodev.me");

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
