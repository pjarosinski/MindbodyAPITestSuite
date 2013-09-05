using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace MindBodyAPI.RestCalls.Interfaces
{
    interface ILocationsAndClasses
    {
        IRestResponse GetSpecificLocationBasedOnId(int locationId);
        IRestResponse SearchForLocationBasedOnSearchText(string searchText);
        IRestResponse GetLocationsWithinRadiusBasedOnLatLong(double latitude, double longitude, double miles);
        IRestResponse GetClassesForSpecificLocationWithinSpecificDateRange(string startDate, string endDate,
                                                                           int locationId, int userId, int siteId);

        IRestResponse GetClassInformationBasedOnClassId(int classInstanceId, int userId, int siteId);
        IRestResponse AddClientToClass(int userId, int siteId, int classId);
        IRestResponse RemoveClientFromClass(int userId, int visitId, int siteId);
        IRestResponse AddClientToWaitList(int userId, int siteId, int classId);
    }
}
