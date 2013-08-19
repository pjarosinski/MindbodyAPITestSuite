using MindbodySoapAPI.APITests.Utils;

namespace MindbodySoapAPI.APITests.Models
{
    public class APIResult<TResult, TDesired>
    {
        public APIResult(TResult resultObj, TDesired desiredValue, string domainUsed)
        {
            Details = new ResultDetails(resultObj, domainUsed);
            FullResult = resultObj;
            Value = desiredValue;
        }
        public TResult FullResult { get; set; }

        public TDesired Value { get; set; }

        public void PrintValue()
        {
            new Introspector(Value).SearchAndDump();
        }

        public ResultDetails Details { get; set; }

    }
}
