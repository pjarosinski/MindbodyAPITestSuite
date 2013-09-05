using System;
using MbUnit.Framework;
using MindBodyAPI.RestCalls;
using RestSharp;

namespace MindBodyAPITests.Tests
{
    [Parallelizable]
    public class LocationsAndClassesTests : AbstractTestSuite
    {
        [Test, Parallelizable]
        public void GetSpecificLocationBasedOnIdTest()
        {
            int locationId = 5;

            LocationsAndClasses locationAndClassesCalls = new LocationsAndClasses(null, null);

            IRestResponse response = locationAndClassesCalls.GetSpecificLocationBasedOnId(locationId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test, Parallelizable]
        public void SearchForLocationBasedOnSearchText()
        {
            string searchText = "in San Luis Obispo";

            LocationsAndClasses locationAndClassesCalls = new LocationsAndClasses(null, null);

            IRestResponse response = locationAndClassesCalls.SearchForLocationBasedOnSearchText(searchText);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test, Parallelizable]
        public void GetLocationsWithinRadiusBasedOnLatLongTest()
        {
            double lat = 5.43452345;
            double longitude = 3.4546345346;
            double miles = 7.0;

            LocationsAndClasses locationAndClassesCalls = new LocationsAndClasses(null, null);

            IRestResponse response = locationAndClassesCalls.GetLocationsWithinRadiusBasedOnLatLong(lat, longitude,
                                                                                                        miles);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test, Parallelizable]
        public void GetClassesForSpecificLocationWithinSpecificDateRangeTest()
        {
            string startDate = "08/18/2013";
            string endDate = "08/28/2013";
            int locationId = 5;
            int siteId = -40000;

            LocationsAndClasses locationAndClassesCalls = new LocationsAndClasses(null, null);

            IRestResponse response =
                locationAndClassesCalls.GetClassesForSpecificLocationWithinSpecificDateRange(startDate, endDate,
                                                                                                 locationId, UserId,
                                                                                                 siteId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test, Parallelizable]
        public void GetClassInformationBasedOnClassIdTest()
        {
            int classInstanceId = 3;
            int siteId = -40000;

            LocationsAndClasses locationAndClassesCalls = new LocationsAndClasses(null, null);

            IRestResponse response = locationAndClassesCalls.GetClassInformationBasedOnClassId(classInstanceId, UserId, siteId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test, Parallelizable]
        public void AddClientToClassTest()
        {
            int siteId = -40000;
            int classId = 34;

            LocationsAndClasses locationAndClassesCalls = new LocationsAndClasses(null, null);

            IRestResponse response = locationAndClassesCalls.AddClientToClass(UserId, siteId, classId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test, Parallelizable]
        public void RemoveClientFromClassTest()
        {
            int visitId = 5435;
            int siteId = -40000;

            LocationsAndClasses locationAndClassesCalls = new LocationsAndClasses(null, null);

            IRestResponse response = locationAndClassesCalls.RemoveClientFromClass(UserId, visitId, siteId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test, Parallelizable]
        public void AddClientToWaitlistTest()
        {
            int siteId = -40000;
            int classId = -34;

            LocationsAndClasses locationAndClassesCalls = new LocationsAndClasses(null, null);

            IRestResponse response = locationAndClassesCalls.AddClientToWaitList(UserId, siteId, classId);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
