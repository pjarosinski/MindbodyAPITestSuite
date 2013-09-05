using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MindBodyAPI.RequestDataModels;
using RestSharp;

namespace MindBodyAPI.RestCalls.Interfaces
{
    interface IUser
    {
        IRestResponse SetupUser(int userId);
        IRestResponse GetUser();
        IRestResponse CreateUser(UserDataModel user);
        IRestResponse UpdateUser(int userId, UserProfileDataModel userProfile);
    }
}
