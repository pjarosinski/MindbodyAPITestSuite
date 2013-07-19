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

        public string GetClassesForSpecificLocationWithinSpecificDateRange()
        {
            return "";
        }

        public string GetClassInformationBasedOnClassId()
        {
            return "";
        }

        public string AddClientToClass()
        {
            return "";
        }

        public string RemoveClientFromClass()
        {
            return "";
        }

        public string AddClientToWaitList()
        {
            return "";
        }
    }
}
