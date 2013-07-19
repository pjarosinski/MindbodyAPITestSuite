using System;
using System.Diagnostics;
using MbUnit.Framework;
using RestCalls.RestObjects;

namespace RestCallsTests
{
    [TestFixture, Parallelizable, ThreadedRepeat(100)]
    public abstract class AbstractRestCallTestSuite
    {
        public RestUser User = new RestUser { Username = "chris3.essley@mindbodyonline.com", Password = "owner1234", Firstname = "chris", Lastname = "essley" };

        public RestUserProfile UserProfile = new RestUserProfile { FirstName = "chris", LastName = "essley", Address = "123 fake st", City = "SLO", State = "CA", Zip = "93405" };

        public RestBillingInfo BillingInfo = new RestBillingInfo { Name = "chrisessley", StreetAddress = "123 fake st", City = "SLO", State = "CA", PostalCode = "93405", CardNumber = "4111111111111111", ExpirationMonth = "06", ExpirationYear = "2020", Cvv = "111", PrimaryCard = "true"};

        public RestSeries Series = new RestSeries { Name = "REST Series", Price = 5.00, ProgramId = 25, SeriesTypeId = 1, CategoryId = -1, Count = 4, Duration = 365, SessionTypeIds = new int[3, 5], OnlinePrice = 2.00, EnableTax1 = true, EnableTax2 = true };

        //This will need to be updated to the real value - chris 7/15/2013
        public readonly int CardId = 111;

        public readonly int UserId = 230; 

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
    }
}
