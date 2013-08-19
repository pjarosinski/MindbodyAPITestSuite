using System;
using MbUnit.Framework;
using MindBodyAPI.LocationsAndClassesRestCalls;
using RestSharp;

namespace MindBodyAPITests.LocationAndClassesRestCallsTests
{
    public class LocationsAndClassesRestCallsTests : AbstractRestCallTestSuite
    {
        [Test]
        public void GetSpecificLocationBasedOnIdTest()
        {
            int locationId = 5;

            LocationAndClassesRestCalls locationAndClassesRestCalls = new LocationAndClassesRestCalls(null, null);

            IRestResponse response = locationAndClassesRestCalls.GetSpecificLocationBasedOnId(locationId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void SearchForLocationBasedOnSearchText()
        {
            string searchText = "in San Luis Obispo";

            LocationAndClassesRestCalls locationAndClassesRestCalls = new LocationAndClassesRestCalls(null, null);

            IRestResponse response = locationAndClassesRestCalls.SearchForLocationBasedOnSearchText(searchText);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void GetLocationsWithinRadiusBasedOnLatLongTest()
        {
            double lat = 5.43452345;
            double longitude = 3.4546345346;
            double miles = 7.0;

            LocationAndClassesRestCalls locationAndClassesRestCalls = new LocationAndClassesRestCalls(null, null);

            IRestResponse response = locationAndClassesRestCalls.GetLocationsWithinRadiusBasedOnLatLong(lat, longitude,
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

            LocationAndClassesRestCalls locationAndClassesRestCalls = new LocationAndClassesRestCalls(null, null);

            IRestResponse response =
                locationAndClassesRestCalls.GetClassesForSpecificLocationWithinSpecificDateRange(startDate, endDate,
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

            LocationAndClassesRestCalls locationAndClassesRestCalls = new LocationAndClassesRestCalls(null, null);

            IRestResponse response = locationAndClassesRestCalls.GetClassInformationBasedOnClassId(classInstanceId, UserId, siteId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void AddClientToClassTest()
        {
            int siteId = -40000;
            int classId = 34;

            LocationAndClassesRestCalls locationAndClassesRestCalls = new LocationAndClassesRestCalls(null, null);

            IRestResponse response = locationAndClassesRestCalls.AddClientToClass(UserId, siteId, classId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void RemoveClientFromClassTest()
        {
            int visitId = 5435;
            int siteId = -40000;

            LocationAndClassesRestCalls locationAndClassesRestCalls = new LocationAndClassesRestCalls(null, null);

            IRestResponse response = locationAndClassesRestCalls.RemoveClientFromClass(UserId, visitId, siteId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void AddClientToWaitlistTest()
        {
            int siteId = -40000;
            int classId = -34;

            LocationAndClassesRestCalls locationAndClassesRestCalls = new LocationAndClassesRestCalls(null, null);

            IRestResponse response = locationAndClassesRestCalls.AddClientToWaitList(UserId, siteId, classId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
