using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace MindBodyAPI.RestCalls.Interfaces
{
    interface IFavorites
    {
        IRestResponse GetFavoriteUserLocations(int userId, int siteId);
        IRestResponse AddFavoriteLocation(int userId, int siteId, int masterLocationId);
        IRestResponse RemoveFavoriteLocation(int userId, int siteId, int masterLocationId);
        IRestResponse GetClassesFromUserFavoriteLocation(int userId, string startDate, string endDate);
    }
}
