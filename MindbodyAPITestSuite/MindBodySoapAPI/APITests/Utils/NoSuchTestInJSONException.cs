using System;

namespace Regression.Library.Exceptions.APIExceptions
{
    public class NoSuchTestInJSONException : ApplicationException
    {
        public NoSuchTestInJSONException(
            string message = "The test name you are trying to use doesn't exist in the JSON file.") : base(message)
        {
        }
    }
}