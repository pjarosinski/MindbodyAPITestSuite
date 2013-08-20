using OAuthAPI.OAuthModels;
using RestSharp;

namespace OAuthAPI.RestCalls
{
    public class Tokens
    {
        public IRestResponse GenerateToken()
        {
            var user = new RestAuthUser {Username = "api_user", Password = "user1234"};

            var client = new RestClient("https://auth.mbodev.me");

            var request = new RestRequest("/issue/oauth2/token", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic aW50ZWdyYXRpb25fY2xpZW50OnNlY3JldA==");

            request.AddBody(
                new
                {
                    username = user.Username,
                    password = user.Password,
                    scope = user.Scope,
                    grant_type = user.GrantType
                });

            return client.Execute(request);
        }

        public IRestResponse GetUserToken(RestAuthUser user)
        {
            var client = new RestClient("https://auth.mbodev.me");

            var request = new RestRequest("/issue/oauth2/token", Method.POST) {RequestFormat = DataFormat.Json};

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Basic aW50ZWdyYXRpb25fY2xpZW50OnNlY3JldA==");

            request.AddBody(
                new
                {
                    username = user.Username,
                    password = user.Password,
                    scope = user.Scope,
                    grant_type = user.GrantType
                });

            return client.Execute(request);
        }
    }
}
