using System;
using System.Collections.Generic;

using Newtonsoft.Json;


namespace mb.Web.Tests.Automation.APITests.Models
{
    /*[Table("ApiTestRun")]
    public class ApiTestRun
    {
        [Key]
        [Column("ID")]
        [JsonIgnore]
        public int ID { get; set; }

        [Column("Name")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Column("StartTime")]
        [JsonProperty("StartTime")]
        public DateTime? StartTime { get; set; }

        [Column("EndTime")]
        [JsonProperty("EndTime")]
        public DateTime? EndTime { get; set; }

        [Column("ExecutionTimeMS")]
        [JsonProperty("ExecutionTime")]
        public int? ExecutionTimeMS { get; set; }

        [Column("Domain")]
        [JsonProperty("Domain")]
        public string Domain { get; set; }

        [Column("StudioID")]
        [JsonProperty("StudioID")]
        public string StudioID { get; set; }

        [Column("Outcome")]
        public string Outcome { get; set; }

        [Column("ApiTestBatch_ID")]
        [ForeignKey("Batch")]
        [JsonIgnore]
        public int ApiTestBatchID { get; set; }

        [JsonIgnore]
        public virtual ApiTestBatch Batch { get; set; }

        public virtual ICollection<ApiTestResultSet> ResultSets { get; set; } 
    }*/
}