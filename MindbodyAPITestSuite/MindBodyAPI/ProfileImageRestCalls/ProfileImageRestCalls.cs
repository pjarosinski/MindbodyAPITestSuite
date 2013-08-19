using System.Globalization;
using MindBodyAPI.RestResponseObjects;
using RestSharp;

namespace MindBodyAPI.ProfileImageRestCalls
{
    public class ProfileImageRestCalls : AbstractBaseRestSetup
    {
        public ProfileImageRestCalls(RestResponseToken generatedToken, RestResponseToken userToken) : base(generatedToken, userToken)
        {
        }

        public IRestResponse GetUserProfileImage(int userId)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{userId}/profileimage", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserToken.AccessToken );

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture)); 

            return client.Execute(request);
        }

        public IRestResponse AddUserProfileImage(int userId, string base64File)
        {
            var client = new RestClient("http://dev-mobile-connect.mbodev.me");

            var request = new RestRequest("/rest/user/{userId}/profileimage", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + UserToken.AccessToken );

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));

            request.AddBody(
                new
                {
                    file = base64File
                });

            return client.Execute(request);
        }
    }
}
