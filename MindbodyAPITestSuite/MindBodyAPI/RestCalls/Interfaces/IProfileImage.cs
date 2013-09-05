using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace MindBodyAPI.RestCalls.Interfaces
{
    interface IProfileImage
    {
        IRestResponse GetUserProfileImage(int userId);
        IRestResponse AddUserProfileImage(int userId, string base64File);
    }
}
