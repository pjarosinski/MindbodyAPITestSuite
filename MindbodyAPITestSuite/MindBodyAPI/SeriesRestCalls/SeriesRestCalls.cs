using System.Globalization;
using MindBodyAPI.RestRequestObjects;
using MindBodyAPI.RestResponseObjects;
using RestSharp;

namespace MindBodyAPI.SeriesRestCalls
{
    public class SeriesRestCalls : AbstractBaseRestSetup
    {
        public SeriesRestCalls(RestResponseToken generatedToken, RestResponseToken userToken) : base(generatedToken, userToken)
        {
        }

        public IRestResponse GetPricingOptionsForSpecificClass(int siteId, int classInstanceId)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/series?classid={ClassInstanceId}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedToken.AccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddUrlSegment("ClassInstanceId", classInstanceId.ToString(CultureInfo.InvariantCulture));
            
            return client.Execute(request);
        }

        public IRestResponse AddSeries(int siteId, RestRequestSeries series)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/series", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + StaffUserToken.AccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));
           
            request.AddBody(new
                {
                    name  = series.Name,
                    price = series.Price,
                    programID = series.ProgramId,
                    seriesTypeID = series.SeriesTypeId,
                    categoryID = series.CategoryId,
                    count = series.Count,
                    duration = series.Duration,
                    sessiontypeids = series.SessionTypeIds,
                    onlineprice = series.OnlinePrice,
                    enabletax1 = series.EnableTax1,
                    enabletax2 = series.EnableTax2
                });

            return client.Execute(request);
        }

        public IRestResponse UpdateSeries(int siteId, RestRequestSeries series)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/series/15", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + StaffUserToken.AccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(new
                {
                    name = series.Name,
                    price = series.Price,
                    programID = series.ProgramId,
                    seriesTypeID = series.SeriesTypeId,
                    categoryID = series.CategoryId,
                    count = series.Count,
                    duration = series.Duration,
                    sessiontypeids = series.SessionTypeIds,
                    onlineprice = series.OnlinePrice,
                    enabletax1 = series.EnableTax1,
                    enabletax2 = series.EnableTax2
                });

            return client.Execute(request);
        }
    }
}
