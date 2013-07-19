using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using RestCalls.FavoritesRestCalls;
using RestSharp;

namespace RestCallsTests.FavoritesRestCallsTests
{
    public class FavoritesRestCallsTests : AbstractRestCallTestSuite
    {
        public void GetFavoriteUserLocationsTests()
        {
            int siteId = -40000;

            FavoritesRestCalls favoritesRestCalls = new FavoritesRestCalls();

            IRestResponse response = favoritesRestCalls.GetFavoriteUserLocations(UserId, siteId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        public void AddFavoriteLocationTests()
        {
            int siteId = -40000;
            int masterSiteId = 10;

            FavoritesRestCalls favoritesRestCalls = new FavoritesRestCalls();

            IRestResponse response = favoritesRestCalls.AddFavoriteLocation(UserId, siteId, masterSiteId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        public void RemoveFavoriteLocationTests()
        {
            int siteId = -40000;
            int masterSiteId = 10;

            FavoritesRestCalls favoritesRestCalls = new FavoritesRestCalls();

            IRestResponse response = favoritesRestCalls.RemoveFavoriteLocation(UserId, siteId, masterSiteId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        public void GetClassesFromUserFavoriteLocation()
        {
            string startDate = "08/10/2013";
            string endDate = "08/20/2013";

            FavoritesRestCalls favoritesRestCalls = new FavoritesRestCalls();

            IRestResponse response = favoritesRestCalls.GetClassesFromUserFavoriteLocation(UserId, startDate, endDate);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
