using System.Globalization;
using RestSharp;

namespace RestCalls.LocationsAndClassesRestCalls
{
    public class LocationAndClassesRestCalls : AbstractBaseRestSetup
    {
        public IRestResponse GetSpecificLocationBasedOnId(int locationId)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/Location/{id}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedAccessToken);

            request.AddUrlSegment("id", locationId.ToString(CultureInfo.InvariantCulture));

            return client.Execute(request);
        }

        public IRestResponse SearchForLocationBasedOnSearchText(string searchText)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/Location?searchText={searchText}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedAccessToken);

            request.AddUrlSegment("searchText", searchText);

            return client.Execute(request);
        }

        public IRestResponse GetLocationsWithinRadiusBasedOnLatLong(double latitude, double longitude, double miles)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/location/GetLocationsWithinRadius?latitude={lat}&longitude={long}&radius={miles}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedAccessToken);

            request.AddUrlSegment("lat", latitude.ToString(CultureInfo.InvariantCulture));
            request.AddUrlSegment("long", longitude.ToString(CultureInfo.InvariantCulture));
            request.AddUrlSegment("miles", miles.ToString(CultureInfo.InvariantCulture));

            return client.Execute(request);
        }

        public IRestResponse GetClassesForSpecificLocationWithinSpecificDateRange(string startDate, string endDate, int locationId, int userId, int siteId)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/class?startRange={startDate}&endRange={endDate}&locationId={locationId}&userid={UserId}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedAccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddUrlSegment("startDate", startDate);
            request.AddUrlSegment("endDate", endDate);
            request.AddUrlSegment("locationId", locationId.ToString(CultureInfo.InvariantCulture));
            request.AddUrlSegment("UserId", userId.ToString(CultureInfo.InvariantCulture));

            return client.Execute(request);
        }

        public IRestResponse GetClassInformationBasedOnClassId(int classInstanceId, int userId, int siteId)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/class/{classInstanceId}?userid={userId}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedAccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddUrlSegment("classInstanceId", classInstanceId.ToString(CultureInfo.InvariantCulture));
            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));

            return client.Execute(request);
        }

        public IRestResponse AddClientToClass(int userId, int siteId, int classId)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{userid}/visits", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedAccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(new
                {
                    classid = classId
                });

            return client.Execute(request);
        }

        public IRestResponse RemoveClientFromClass(int userId, int visitId, int siteId)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{UserId}/visits/{visitId}", Method.DELETE) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedAccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddUrlSegment("UserId", userId.ToString(CultureInfo.InvariantCulture));
            request.AddUrlSegment("visitId", visitId.ToString(CultureInfo.InvariantCulture));

            return client.Execute(request);
        }

        public IRestResponse AddClientToWaitList(int userId, int siteId, int classId)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{userid}/waitlist", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + GeneratedAccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(new
                {
                    classid = classId
                });

            return client.Execute(request);
        }
    }
}
