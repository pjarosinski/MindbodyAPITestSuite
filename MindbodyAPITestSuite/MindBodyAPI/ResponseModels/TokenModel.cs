using System;
using Newtonsoft.Json;

namespace MindBodyAPI.ResponseModels
{
    public class TokenModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }

        public static TokenModel Parse(string json)
        {
            TokenModel token = JsonConvert.DeserializeObject<TokenModel>(json);
            return token;
        } 
    }
}
