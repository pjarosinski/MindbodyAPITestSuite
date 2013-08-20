using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using MbUnit.Framework;
using MindBodyAPI.RequestDataModels;
using MindBodyAPI.ResponseModels;
using MindBodyAPI.RestCalls;
using OAuthAPI.OAuthModels;
using OAuthAPI.RestCalls;
using RestSharp;

namespace MindBodyAPITests
{
    [TestFixture, Parallelizable]
    //[ThreadedRepeat(1)]
    //I think that using a factory with parallelizable will do what threaded reapeat does.
    public abstract class AbstractTestSuite
    {
        public UserDataModel UserData = new UserDataModel { Firstname = "joe", Lastname = "joneson2", Password = "joejoe1234", Username = "joe.joneson44454@gmail.com" };

        public UserProfileDataModel UserProfileData = new UserProfileDataModel { FirstName = "jim", LastName = "joneson", Address = "123 fake st", City = "SLO", State = "CA", Zip = "93405" };

        public BillingInfoDataModel BillingInfoData = new BillingInfoDataModel { Name = "jimjoneson", StreetAddress = "123 fake st", City = "SLO", State = "CA", PostalCode = "93405", CardNumber = "4111111111111111", ExpirationMonth = "06", ExpirationYear = "2020", Cvv = "111", PrimaryCard = "true" };

        public SeriesDataModel SeriesData = new SeriesDataModel { Name = "REST Series", Price = 5.00, ProgramId = 25, SeriesTypeId = 1, CategoryId = -1, Count = 4, Duration = 365, SessionTypeIds = new int[3, 5], OnlinePrice = 2.00, EnableTax1 = true, EnableTax2 = true };

        public TokenModel GeneratedToken;

        public TokenModel UserToken;

        public TokenModel StaffToken;

        public List<IRestResponse> CreatedUsers = new List<IRestResponse>();

        public List<IRestResponse> SetupUsers = new List<IRestResponse>(); 

        public IRestResponse BaseMockResponse = new RestResponse{
                    ErrorException = null,
                    ErrorMessage = null,
                    ResponseStatus = ResponseStatus.Completed,
                };

        //This will need to be updated to the real value - chris 7/15/2013
        public readonly int CardId = 111;

        public readonly int UserId = 287; 

        private readonly Stopwatch _runTime = new Stopwatch();

        [FixtureSetUp]
        public virtual void FixtureSetUp()
        {
            Tokens tokenCalls = new Tokens();

            IRestResponse response = tokenCalls.GenerateToken();

            GeneratedToken = TokenModel.Parse(response.Content);

            User userCalls = new User(GeneratedToken, null);

            //create useres here, maybe just check if they have been created already and do refresh tokens.
            var userList = GetRandomUsers(1);

            foreach (var user in userList)
            {
                CreatedUsers.Add(userCalls.CreateUser(user));
                RestAuthUser authUser = new RestAuthUser { Username = user.Username, Password = user.Password};
                SetupUsers.Add(tokenCalls.GetUserToken(authUser));
            }

            UserToken = TokenModel.Parse(SetupUsers[0].Content);
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

            foreach (var user in CreatedUsers)
            {
                Console.WriteLine("User: " + user.Content);
            }
        }

        [FixtureTearDown]
        public virtual void FixtureTearDown()
        {
            //delete users.
        }

        public bool BaseCompare(IRestResponse mockResponse, IRestResponse response)
        {
            return response.ContentLength != 0 &&
                   mockResponse.ErrorException == response.ErrorException &&
                   mockResponse.ErrorMessage == response.ErrorMessage &&
                   mockResponse.ResponseStatus.Equals(response.ResponseStatus);
        }

        private void DeleteUser()
        {
            //Code to delete user after it has been created.
        }

        public IEnumerable<UserDataModel> GetRandomUsers(int howManyUsers)
        {
            Random randomGenerator = new Random();

            for (int user = 0; user < howManyUsers; user++)
            {
                yield return new UserDataModel { Username = "jim" + randomGenerator.Next(1000) + user + ".joneson@mindbodyonline.com", Password = "jimmybob1234", Firstname = "jim", Lastname = "joneson" };
            }
        }
    }
}
