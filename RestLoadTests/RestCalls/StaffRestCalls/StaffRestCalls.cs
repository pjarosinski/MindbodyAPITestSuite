using System.Globalization;
using RestCalls.RestRequestObjects;
using RestSharp;

namespace RestCalls.StaffRestCalls
{
    public class StaffRestCalls : AbstractBaseRestSetup
    {
        public IRestResponse AddStaff(int siteId, RestRequestStaff staff)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me/");

            var request = new RestRequest("/rest/staff", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + StaffUserToken.AccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(
                new
                {
                    firstname = staff.Firstname,
                    lastname = staff.Lastname,
                    bio = staff.Bio,
                    email = staff.Email,
                    phone = staff.Phone,
                    isFemale = staff.IsFemale
                });

            return client.Execute(request);
        }

        public IRestResponse UpdateStaff(int siteId, int staffId, RestRequestStaff staff)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me/");

            var request = new RestRequest("/rest/staff/{staffId}", Method.PUT) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + StaffUserToken.AccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddUrlSegment("staffId", staffId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(
                new
                {
                    firstname = staff.Firstname,
                    lastname = staff.Lastname,
                    bio = staff.Bio,
                    email = staff.Email,
                    phone = staff.Phone,
                    isFemale = staff.IsFemale
                });

            return client.Execute(request);
        }

        public IRestResponse StaffToken(RestRequestStaffInfo staff)
        {
            var client = new RestClient("https://dev-auth.mindbodyonline.com");

            var request = new RestRequest("/issue/oauth2/token", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic aW50ZWdyYXRpb25fY2xpZW50OnNlY3JldA==");

            request.AddBody(
                new
                {
                    username = staff.Username,
                    password = staff.Password,
                    scope = staff.Scope,
                    grant_type = staff.GrantType,
                    subscriberid = staff.SubscriberId
                });

            return client.Execute(request);
        }

        public IRestResponse StaffPhoto(int siteId, int staffId, string base64File)
        {
            var client = new RestClient("http://dev2-connect.mbodev.me/");

            var request = new RestRequest("/rest/staff/ProfileImage/?staffID={StaffID}", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + StaffUserToken.AccessToken);
            request.AddHeader("SiteId", siteId.ToString(CultureInfo.InvariantCulture));

            request.AddUrlSegment("StaffID", staffId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(
                new
                {
                    file = base64File
                });

            return client.Execute(request);
        }
    }
}
