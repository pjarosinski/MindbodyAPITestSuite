using System;
using System.Diagnostics;
using System.Net;
using MbUnit.Framework;
using MindBodyAPI.RestRequestObjects;
using RestSharp;

namespace MindBodyAPITests
{
    [TestFixture, Parallelizable]
    //[ThreadedRepeat(1)]
    //I think that using a factory with parallelizable will do what threaded reapeat does.
    public abstract class AbstractRestCallTestSuite
    {
        public RestRequestUser User = new RestRequestUser { Firstname = "joe", Lastname = "joneson2", Password = "joejoe1234", Username = "joe.joneson444@gmail.com" };

        public RestRequestUserProfile UserProfile = new RestRequestUserProfile { FirstName = "jim", LastName = "joneson", Address = "123 fake st", City = "SLO", State = "CA", Zip = "93405" };

        public RestRequestBillingInfo BillingInfo = new RestRequestBillingInfo { Name = "jimjoneson", StreetAddress = "123 fake st", City = "SLO", State = "CA", PostalCode = "93405", CardNumber = "4111111111111111", ExpirationMonth = "06", ExpirationYear = "2020", Cvv = "111", PrimaryCard = "true" };

        public RestRequestSeries Series = new RestRequestSeries { Name = "REST Series", Price = 5.00, ProgramId = 25, SeriesTypeId = 1, CategoryId = -1, Count = 4, Duration = 365, SessionTypeIds = new int[3, 5], OnlinePrice = 2.00, EnableTax1 = true, EnableTax2 = true };

        public IRestResponse BaseMockResponse = new RestResponse{
                    ErrorException = null,
                    ErrorMessage = null,
                    ResponseStatus = ResponseStatus.Completed,
                    StatusCode = HttpStatusCode.Created,
                    StatusDescription = "Created"
                };

        //This will need to be updated to the real value - chris 7/15/2013
        public readonly int CardId = 111;

        public readonly int UserId = 287; 

        private readonly Stopwatch _runTime = new Stopwatch();

        [FixtureSetUp]
        public virtual void FixtureSetUp()
        {
            //create useres here, maybe just check if they have been created already and do refresh tokens.
        }

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
            Console.WriteLine("Test");
        }

        [FixtureTearDown]
        public virtual void FixtureTearDown()
        {
            //delete users.
        }

        public bool BaseAssert(IRestResponse mockResponse, IRestResponse response)
        {
            return response.ContentLength != 0 &&
                    mockResponse.ErrorException == response.ErrorException &&
                    mockResponse.ErrorMessage == response.ErrorMessage &&
                    mockResponse.ResponseStatus.Equals(response.ResponseStatus) &&
                    mockResponse.StatusCode.Equals(response.StatusCode) &&
                    mockResponse.StatusDescription.Equals(response.StatusDescription);
        }

        private void DeleteUser()
        {
            //Code to delete user after it has been created.
        }
    }
}
