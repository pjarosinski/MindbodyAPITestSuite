using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MindBodyAPI.ResponseModels
{
    public class GetUserModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Firstname")]
        public string Firstname { get; set; }

        [JsonProperty("Lastname")]
        public string Lastname { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("Zip")]
        public string Zip { get; set; }

        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [JsonProperty("Birthday")]
        public string Birthday { get; set; }

        [JsonProperty("LastSignedIn")]
        public string LastSignedIn { get; set; }

        public static GetUserModel Parse(string json)
        {
            GetUserModel userModel = JsonConvert.DeserializeObject<GetUserModel>(json);
            return userModel;
        } 
    }
}
