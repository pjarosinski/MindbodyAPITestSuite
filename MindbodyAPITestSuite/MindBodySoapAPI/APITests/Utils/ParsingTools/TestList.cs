using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Regression.Library.Exceptions.APIExceptions;

namespace MindbodySoapAPI.APITests.Utils.ParsingTools
{
    public class TestList
    {
        internal static List<Test> Tests { get
        {
            var data =
                File.ReadAllText(@".\..\..\APITests\ArgListJSON.json");
            return JsonConvert.DeserializeObject<List<Test>>(data);
        }} 

        public static List<Argument> GetArgsForTest(string testName)
        {
            foreach(Test test in Tests)
            {
                if(test.TestName.Equals(testName))
                {
                    return test.ArgList;
                }
            }
            throw new NoSuchTestInJSONException();
        }
    }
}
