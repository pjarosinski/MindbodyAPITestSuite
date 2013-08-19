using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;

namespace mb.Web.Tests.Automation.APITests.Models
{
    /*[Table("ApiTestResultSet")]
    public class ApiTestResultSet
    {
        [Key]
        [JsonIgnore]
        public int ID { get; set; }

        [Column("TestName")]
        [JsonProperty("testName")]
        public string TestName { get; set; }

        [Column("Service")]
        public string Service { get; set; }

        [JsonProperty("argumentList")]
        public virtual ICollection<ArgumentList> ArgumentLists { get; set; }

        [Column("ApiTestRun_ID")]
        [ForeignKey("TestRun")]
        [JsonIgnore]
        public int ApiTestRunID { get; set; }

        [JsonIgnore]
        public virtual ApiTestRun TestRun { get; set; }
    }*/
}