using System;
using MindbodySoapAPI.APITests.Utils.DiffTools;

namespace MindbodySoapAPI.APITests.Models
{
    public class ResultDetails
    {
        public ResultDetails(object resultInstance, string domain)
        {
            Status = ReflectiveGetStatus(resultInstance);
            Message = ReflectiveGetMessage(resultInstance);
            Count = ReflectiveGetResultCount(resultInstance);
            Domain = domain;
        }

        public string Status { get; set; }

        public string Message { get; set; }

        public string Domain { get; set; }

        public int Count { get; set; }

        private string ReflectiveGetStatus(object resultInstance)
        {
            return PropertyInspector.GetPropertyValue(resultInstance, "Status").ToString();
        }

        private string ReflectiveGetMessage(object resultInstance)
        {
            var message = PropertyInspector.GetPropertyValue(resultInstance, "Message");
            return message != null ? message.ToString() : "";
        }

        private int ReflectiveGetResultCount(object resultInstance)
        {
            return (int)PropertyInspector.GetPropertyValue(resultInstance, "ResultCount");
        }

        public override string ToString()
        {
            return Domain + " results: " + Environment.NewLine +
                "Status: " + Status + Environment.NewLine +
                "Message: " + Message + Environment.NewLine +
                "Result Count: " + Count + Environment.NewLine;
        }
    }
}
