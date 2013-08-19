using System.Collections.Generic;
using Newtonsoft.Json;

namespace MindbodySoapAPI.APITests.Utils.ParsingTools
{
    public class Test
    {
        [JsonProperty(PropertyName = "argumentList")]
        public List<Argument> ArgList { get; set; }

        [JsonProperty(PropertyName = "testName")]
        public string TestName { get; set; }

        [JsonProperty(PropertyName = "passedTest")]
        public string PassedTest { get; set; }
    }
}
