using System;
using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using MindbodySoapAPI.APITests.Models;
using MindbodySoapAPI.APITests.Utils.DiffTools;

namespace MindbodySoapAPI.APITests.Utils.AssertHelpers
{
    public class Assert_Api
    {
        private static DiffModule DifferenceFinder
        {
            get
            {
                var differ = new DiffModule();
                differ.AddSpecialCaseProperties(new KeyValuePair<string, string>("LogoURL", "="));
                differ.AddSpecialCaseProperties(new KeyValuePair<string, string>("ImageURL", "="));
                //differ.MakeLoud();
                return differ;
            }
        }

        public static void AssertResults<T, T2>(APIResult<T,T2[]> resultOne, APIResult<T, T2[]> resultTwo, bool failZeroCount = true)
        {
            DumpDetails(resultOne, resultTwo);
            Assert.IsTrue(WereApiCallsSuccesful(resultOne.Details.Status, resultOne.Details.Status));
            if (!failZeroCount) return;
            Assert.IsTrue(AreCountsGreaterThanZero(resultOne.Value.Count(), resultOne.Value.Count()));
            Assert.IsTrue(DifferenceFinder.DiffListResults(resultOne.Value, resultTwo.Value));
        }
        
        private static void DumpDetails<T, T2>(APIResult<T, T2> resultOne, APIResult<T, T2> resultTwo)
        {
            Console.WriteLine(resultOne.Details);
            resultOne.PrintValue();
            Console.WriteLine(resultTwo.Details);
            resultTwo.PrintValue();
        }

        private static bool AreCountsGreaterThanZero(int one, int two)
        {
            if (GreaterThanZero(one) && GreaterThanZero(two))
                return true;
            Console.WriteLine(Environment.NewLine + EmptyResults);
            return false;
        }

        private static bool GreaterThanZero(int num)
        {
            return num > 0;
        }

        private static bool WereApiCallsSuccesful(string statusCode, string statusCodeTwo)
        {
            if (statusCode.Contains(Success) && statusCodeTwo.Contains(Success))
                return true;

            Console.WriteLine(Environment.NewLine + UnsuccessfulCall);
            return false;
        }
        private const string UnsuccessfulCall = "ONE OR MORE API CALLS WAS UNSUCCESSFUL";
        private const string EmptyResults = "API CALLS WERE SUCCESSFUL BUT ONE OR MORE CALLS RETURNED NOTHING";
        private const string EqualToZero = " RESULTS SHOULD NOT BE EQUAL TO ZERO";
        private const string Success = "Success";
        private const int DomainOne = 0;
        private const int DomainTwo = 1;

    }
}
