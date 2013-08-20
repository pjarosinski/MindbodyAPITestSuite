﻿using System;
using MbUnit.Framework;
using MindBodyAPI.RestCalls;
using RestSharp;

namespace MindBodyAPITests.Tests
{
    public class LocationsAndClassesTests : AbstractTestSuite
    {
        [Test]
        public void GetSpecificLocationBasedOnIdTest()
        {
            int locationId = 5;

            LocationAndClasses locationAndClassesCalls = new LocationAndClasses(null, null);

            IRestResponse response = locationAndClassesCalls.GetSpecificLocationBasedOnId(locationId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void SearchForLocationBasedOnSearchText()
        {
            string searchText = "in San Luis Obispo";

            LocationAndClasses locationAndClassesCalls = new LocationAndClasses(null, null);

            IRestResponse response = locationAndClassesCalls.SearchForLocationBasedOnSearchText(searchText);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void GetLocationsWithinRadiusBasedOnLatLongTest()
        {
            double lat = 5.43452345;
            double longitude = 3.4546345346;
            double miles = 7.0;

            LocationAndClasses locationAndClassesCalls = new LocationAndClasses(null, null);

            IRestResponse response = locationAndClassesCalls.GetLocationsWithinRadiusBasedOnLatLong(lat, longitude,
                                                                                                        miles);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void GetClassesForSpecificLocationWithinSpecificDateRangeTest()
        {
            string startDate = "08/18/2013";
            string endDate = "08/28/2013";
            int locationId = 5;
            int siteId = -40000;

            LocationAndClasses locationAndClassesCalls = new LocationAndClasses(null, null);

            IRestResponse response =
                locationAndClassesCalls.GetClassesForSpecificLocationWithinSpecificDateRange(startDate, endDate,
                                                                                                 locationId, UserId,
                                                                                                 siteId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void GetClassInformationBasedOnClassIdTest()
        {
            int classInstanceId = 3;
            int siteId = -40000;

            LocationAndClasses locationAndClassesCalls = new LocationAndClasses(null, null);

            IRestResponse response = locationAndClassesCalls.GetClassInformationBasedOnClassId(classInstanceId, UserId, siteId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void AddClientToClassTest()
        {
            int siteId = -40000;
            int classId = 34;

            LocationAndClasses locationAndClassesCalls = new LocationAndClasses(null, null);

            IRestResponse response = locationAndClassesCalls.AddClientToClass(UserId, siteId, classId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void RemoveClientFromClassTest()
        {
            int visitId = 5435;
            int siteId = -40000;

            LocationAndClasses locationAndClassesCalls = new LocationAndClasses(null, null);

            IRestResponse response = locationAndClassesCalls.RemoveClientFromClass(UserId, visitId, siteId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void AddClientToWaitlistTest()
        {
            int siteId = -40000;
            int classId = -34;

            LocationAndClasses locationAndClassesCalls = new LocationAndClasses(null, null);

            IRestResponse response = locationAndClassesCalls.AddClientToWaitList(UserId, siteId, classId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}