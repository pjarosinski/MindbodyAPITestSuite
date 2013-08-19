using System.Collections.Generic;
using System.Collections.Specialized;


namespace mb.Web.Tests.Automation.APITests.Models
{
    /*[Table("ApiTestArgumentList")]
    public class ArgumentList
    {
        [Key]
        [JsonIgnore]
        public int ID { get; set; }

        [Column("SOAPNodeName")]
        [JsonProperty("SOAPNodeName")]
        public string SoapNodeName { get; set; }

        [Column("Value")]
        [JsonProperty("value")]
        public string Value { get; set; }

        [Column("IsRequired")]
        [JsonProperty("isRequired")]
        public string IsRequired { get; set; }

        [Column("RequiredMembers")]
        [JsonProperty("requiredMembers")]
        public string[] RequiredMembers { get; set; }

        [Column("ApiTestResultSet_ID")]
        [ForeignKey("ResultSet")]
        [JsonIgnore]
        public int ResultSetID { get; set; }

        [JsonIgnore]
        public virtual ApiTestResultSet ResultSet { get; set; }

        public static ArgumentList ConvertToArgumentList(Argument argument)
        {
            var arglist = new ArgumentList()
            {
                IsRequired = argument.IsRequired.ToString(CultureInfo.InvariantCulture),
                SoapNodeName = argument.SoapNodeName,
                Value = argument.Value
            };
            return arglist;
        }
    }*/
}