using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MindBodyAPI.RequestDataModels;
using RestSharp;

namespace MindBodyAPI.RestCalls.Interfaces
{
    interface IStaff
    {
        IRestResponse AddStaff(int siteId, StaffDataModel staff);
        IRestResponse UpdateStaff(int siteId, int staffId, StaffDataModel staff);
        IRestResponse StaffToken(StaffInfoDataModel staff);
        IRestResponse StaffPhoto(int siteId, int staffId, string base64File);

    }
}
