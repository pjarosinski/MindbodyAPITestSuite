using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MindBodyAPI.RequestDataModels;
using MindBodyAPI.ResponseModels;
using RestSharp;

namespace MindBodyAPITests
{
    [TestClass]
    public class BaseTestSuite
    {
        //public UserDataModel UserData { get; set; }
        public UserDataModel UserData = new UserDataModel { Username = "jim.joneson5436543@gmail.com", Password = "jimjoneson1234", Firstname = "Jim", Lastname = "Joneson"};

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

       
        [ClassInitialize]
        public virtual void FixtureSetup()
        {
            TokenModel generatedToken = new TokenModel
            {
                AccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOi8vYXV0aC5tYm9kZXYubWUvdHJ1c3QvdjIiLCJhdWQiOiJ1cm46bWJvZnJhbWV3b3JrYXBpIiwibmJmIjoxMzc4OTI5NTQ2LCJleHAiOjEzNzg5MzY3NDYsIm5hbWVpZCI6ImFwaV91c2VyIiwidW5pcXVlX25hbWUiOiJhcGlfdXNlciIsImF1dGhtZXRob2QiOiJPQXV0aDIiLCJhdXRoX3RpbWUiOiIyMDEzLTA5LTExVDE5OjU5OjA2LjY4MFoiLCJodHRwOi8vaWRlbnRpdHlzZXJ2ZXIudGhpbmt0ZWN0dXJlLmNvbS9jbGFpbXMvY2xpZW50IjoiVGVzdENsaWVudCIsImh0dHA6Ly9pZGVudGl0eXNlcnZlci50aGlua3RlY3R1cmUuY29tL2NsYWltcy9zY29wZSI6InVybjptYm9mcmFtZXdvcmthcGkiLCJyb2xlIjoiTWluZGJvZHlBcGlDbGllbnQifQ.ieNftfKCu5CGDF62R4ZkPB0g5JCmUuDzI54SxW9Gi2s",
                ExpiresIn = "7199",
                RefreshToken = "deda596367594946a861dba28ed70e37",
                TokenType = "urn:ietf:params:oauth:token-type:jwt"
            };

            TokenModel userToken = new TokenModel
            {
                AccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOi8vYXV0aC5tYm9kZXYubWUvdHJ1c3QvdjIiLCJhdWQiOiJ1cm46bWJvZnJhbWV3b3JrYXBpIiwibmJmIjoxMzc4OTI5NjQ5LCJleHAiOjEzNzg5MzY4NDksIm5hbWVpZCI6ImppbS5qb25lc29uNTQzNjU0M0BnbWFpbC5jb20iLCJ1bmlxdWVfbmFtZSI6ImppbS5qb25lc29uNTQzNjU0M0BnbWFpbC5jb20iLCJhdXRobWV0aG9kIjoiT0F1dGgyIiwiYXV0aF90aW1lIjoiMjAxMy0wOS0xMVQyMDowMDo0OS45MjdaIiwiaHR0cDovL2lkZW50aXR5c2VydmVyLnRoaW5rdGVjdHVyZS5jb20vY2xhaW1zL2NsaWVudCI6IlRlc3RDbGllbnQiLCJodHRwOi8vaWRlbnRpdHlzZXJ2ZXIudGhpbmt0ZWN0dXJlLmNvbS9jbGFpbXMvc2NvcGUiOiJ1cm46bWJvZnJhbWV3b3JrYXBpIiwiZW1haWwiOiJqaW0uam9uZXNvbjU0MzY1NDNAZ21haWwuY29tIn0.SkN3wcb5Qit-_RjG-MaKT5qtKIggqQZzlCde6tQbDfI",
                ExpiresIn = "7199",
                RefreshToken = "a46b973799bc4afb9606ec1ba903d2b7",
                TokenType = "urn:ietf:params:oauth:token-type:jwt"
            };

            GeneratedToken = generatedToken;

            UserToken = userToken;

            Console.WriteLine("Fixture Setup Executed");

            //I will finish this one day when the API works. Until then error log gen yay!
            /*Tokens tokenCalls = new Tokens();

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
            UserToken = TokenModel.Parse(SetupUsers[0].Content);*/
        }

        [TestInitialize]
        public virtual void Setup()
        {
            Console.WriteLine("Test Setup Executed");
        }

        [TestCleanup]
        public virtual void Teardown()
        {
            Console.WriteLine("Test Teardown Executed");
        }

        [ClassCleanup]
        public virtual void FixtureTeardown()
        {
            Console.WriteLine("Fixture Teardown Executed");
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
            IList<UserDataModel> users = new List<UserDataModel>();
            Random randomGenerator = new Random();

            for (int user = 0; user < howManyUsers; user++)
            {
                users.Add(new UserDataModel { Username = "jim" + randomGenerator.Next(1000) + user + ".joneson@mindbodyonline.com", Password = "jimmybob1234", Firstname = "jim", Lastname = "joneson" });
            }

            return users;
        }
    }
}
