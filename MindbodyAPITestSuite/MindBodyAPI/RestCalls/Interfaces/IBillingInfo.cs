using MindBodyAPI.RequestDataModels;
using RestSharp;

namespace MindBodyAPI.RestCalls.Interfaces
{
    interface IBillingInfo
    {
        IRestResponse GetUserBillingInfo(int userId);
        IRestResponse AddUserBillingInfo(int userId, BillingInfoDataModel userInfo);
        IRestResponse RemoveUserBillingInfo(int userId, int cardId);
        IRestResponse UpdateUserBillingInfo(int userId, int cardId, BillingInfoDataModel userInfo);
    }
}
