using System.Globalization;
using RestCalls.RestObjects;
using RestSharp;

namespace RestCalls.SeriesRestCalls
{
    public class SeriesRestCalls : AbstractBaseRestSetup
    {
        public IRestResponse GetPricingOptionsForSpecificClass(int siteId, int classInstanceId)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/series?classid={ClassInstanceId}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedAccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddUrlSegment("ClassInstanceId", classInstanceId.ToString(CultureInfo.InvariantCulture));
            
            return client.Execute(request);
        }

        public IRestResponse AddSeries(int siteId, RestSeries series)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/series", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + StaffAccessToken);
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

        public IRestResponse UpdateSeries(int siteId, RestSeries series)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/series/15", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + StaffAccessToken);
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
