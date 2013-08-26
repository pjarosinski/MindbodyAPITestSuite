using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
    [TestFixture]
    //[ThreadedRepeat(1)]
    //I think that using a factory with parallelizable will do what threaded reapeat does.
    public abstract class AbstractTestSuite
    {
        public UserDataModel UserData { get; set; }

        public UserProfileDataModel UserProfileData { get; set; }

        public BillingInfoDataModel BillingInfoData { get; set; }
        //= new BillingInfoDataModel { Name = "jimjoneson", StreetAddress = "123 fake st", City = "SLO", State = "CA", PostalCode = "93405", CardNumber = "4111111111111111", ExpirationMonth = "06", ExpirationYear = "2020", Cvv = "111", PrimaryCard = "true" };

        public SeriesDataModel SeriesData = new SeriesDataModel { Name = "REST Series", Price = 5.00, ProgramId = 25, SeriesTypeId = 1, CategoryId = -1, Count = 4, Duration = 365, SessionTypeIds = new int[3, 5], OnlinePrice = 2.00, EnableTax1 = true, EnableTax2 = true };

        public TokenModel GeneratedToken;

        public TokenModel UserToken;

        public TokenModel StaffToken;

        public List<IRestResponse> CreatedUsers = new List<IRestResponse>();

        public List<IRestResponse> SetupUsers = new List<IRestResponse>(); 

        public IRestResponse BaseMockResponse = new RestResponse {
                    ErrorException = null,
                    ErrorMessage = null,
                    ResponseStatus = ResponseStatus.Completed
                };

        //This will need to be updated to the real value - chris 7/15/2013
        public readonly int CardId = 111;

        public int UserId; 

        private readonly Stopwatch _runTime = new Stopwatch();

        [FixtureSetUp]
        public virtual void FixtureSetUp()
        {
            Tokens tokenCalls = new Tokens();

            IRestResponse response = tokenCalls.GenerateToken();

            GeneratedToken = TokenModel.Parse(response.Content);

            User userCalls = new User(GeneratedToken, null);

            //create useres here, maybe just check if they have been created already and do refresh tokens.
            var userList = GetRandomUsers(1).ToList();

            UserProfileData = new UserProfileDataModel { FirstName = userList[0].Firstname, LastName = userList[0].Lastname };
            BillingInfoData = new BillingInfoDataModel { Name = userList[0].Firstname + userList[0].Lastname };

            foreach (var user in userList)
            {
                CreatedUsers.Add(userCalls.CreateUser(user));
                RestAuthUser authUser = new RestAuthUser { Username = user.Username, Password = user.Password};
                SetupUsers.Add(tokenCalls.GetUserToken(authUser));
            }

            UserId = Int32.Parse(CreatedUsers[0].Content);
            UserToken = TokenModel.Parse(SetupUsers[0].Content);
        }

        [SetUp, Parallelizable]
        public virtual void SetUp()
        {
            _runTime.Start();
        }

        [TearDown, Parallelizable]
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
