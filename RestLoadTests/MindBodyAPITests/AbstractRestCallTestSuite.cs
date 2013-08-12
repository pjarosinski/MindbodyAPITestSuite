using System;
using System.Diagnostics;
using MbUnit.Framework;
using MindBodyAPI.RestRequestObjects;

namespace MindBodyAPITests
{
    [TestFixture, Parallelizable]
    //[ThreadedRepeat(1)]
    //I think that using a factory with parallelizable will do what threaded reapeat does.
    public abstract class AbstractRestCallTestSuite
    {
        public const int MaxThreads = 2;

        public RestRequestUser User = new RestRequestUser();

        public RestRequestUserProfile UserProfile = new RestRequestUserProfile { FirstName = "jim", LastName = "joneson", Address = "123 fake st", City = "SLO", State = "CA", Zip = "93405" };

        public RestRequestBillingInfo BillingInfo = new RestRequestBillingInfo { Name = "jimjoneson", StreetAddress = "123 fake st", City = "SLO", State = "CA", PostalCode = "93405", CardNumber = "4111111111111111", ExpirationMonth = "06", ExpirationYear = "2020", Cvv = "111", PrimaryCard = "true" };

        public RestRequestSeries Series = new RestRequestSeries { Name = "REST Series", Price = 5.00, ProgramId = 25, SeriesTypeId = 1, CategoryId = -1, Count = 4, Duration = 365, SessionTypeIds = new int[3, 5], OnlinePrice = 2.00, EnableTax1 = true, EnableTax2 = true };

        //This will need to be updated to the real value - chris 7/15/2013
        public readonly int CardId = 111;

        public readonly int UserId = 287; 

        private readonly Stopwatch _runTime = new Stopwatch();

        [SetUp]
        public virtual void SetUp()
        {
            _runTime.Start();
        }

        [TearDown]
        public virtual void TearDown()
        {
            _runTime.Stop();
            Console.WriteLine("Runtime: " +  _runTime.Elapsed);
        }

        private void DeleteUser()
        {
            //Code to delete user after it has been created.
        }
    }
}
