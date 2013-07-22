using RestSharp;

namespace RestCalls.TokensRestCalls
{
    public class TokensRestCalls : AbstractBaseRestSetup
    {
        public IRestResponse GenerateToken()
        {
            var client = new RestClient("https://auth.mbodev.me");

            var request = new RestRequest("/issue/oauth2/token", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic aW50ZWdyYXRpb25fY2xpZW50OnNlY3JldA==");

            request.AddBody(
                new
                {
                    username = "api_user",
                    password = "user1234",
                    scope = "urn:mboframeworkapi",
                    grant_type = "password"
                });

            return client.Execute(request);
        }

        public IRestResponse GetUserToken()
        {
            var client = new RestClient("https://dev-auth.mindbodyonline.com");

            var request = new RestRequest("/issue/oauth2/token", Method.POST) {RequestFormat = DataFormat.Json};

            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Basic aW50ZWdyYXRpb25fY2xpZW50OnNlY3JldA==");

            request.AddBody(
                new
                {
                    username = "jim3.joneson@mindbodyonline.com",
                    password = "owner1234",
                    scope = "urn:mboframeworkapi",
                    grant_type = "password"
                });

            return client.Execute(request);
        }
    }
}
