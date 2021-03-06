﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MindBodyAPI.RestCalls;
using RestSharp;

namespace MindBodyAPITests.Tests
{
    public class FavoritesTests : BaseTestSuite
    {
        [TestMethod]
        public void GetFavoriteUserLocationsTests()
        {
            int siteId = -40000;

            Favorites favoritesCalls = new Favorites(null, null);

            IRestResponse response = favoritesCalls.GetFavoriteUserLocations(UserId, siteId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [TestMethod]
        public void AddFavoriteLocationTests()
        {
            int siteId = -40000;
            int masterSiteId = 10;

            Favorites favoritesCalls = new Favorites(null, null);

            IRestResponse response = favoritesCalls.AddFavoriteLocation(UserId, siteId, masterSiteId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [TestMethod]
        public void RemoveFavoriteLocationTests()
        {
            int siteId = -40000;
            int masterSiteId = 10;

            Favorites favoritesCalls = new Favorites(null, null);

            IRestResponse response = favoritesCalls.RemoveFavoriteLocation(UserId, siteId, masterSiteId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [TestMethod]
        public void GetClassesFromUserFavoriteLocation()
        {
            string startDate = "08/10/2013";
            string endDate = "08/20/2013";

            Favorites favoritesCalls = new Favorites(null, null);

            IRestResponse response = favoritesCalls.GetClassesFromUserFavoriteLocation(UserId, startDate, endDate);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
