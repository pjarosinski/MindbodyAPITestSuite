using System;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MindBodyAPI.RestResponseObjects
{
    public class RestResponseToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }

        public static RestResponseToken Parse(string json)
        {
            Console.WriteLine("JSON output: " + json);
            RestResponseToken token = JsonConvert.DeserializeObject<RestResponseToken>(json);
            return token;
        } 
    }
}
