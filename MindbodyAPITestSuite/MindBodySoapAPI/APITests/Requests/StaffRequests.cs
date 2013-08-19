using System.Collections.Generic;
using MindbodySoapAPI.APITests.Models;
using MindbodySoapAPI.APITests.Utils;
using MindbodySoapAPI.APITests.Utils.ParsingTools;
using MindbodySoapAPI.StaffService;

namespace MindbodySoapAPI.APITests.Requests
{
    public class StaffRequests
    {
        public static StaffService.StaffService Service
        {
            get { return new StaffService.StaffService(); }
        }

        public static APIResult<GetStaffResult, Staff[]> GetStaff(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetStaffRequest>(args, domain);
            /*
            //if ((sessID = Argument.GetArgument(args, "SessionTypeID").ConvertToInt()) != 0) { request.SessionTypeID = sessID; }
            request.SessionTypeID = Argument.GetArgument(args, "SessionTypeID").ConvertToInt();
            request.CurrentPageIndex = Argument.GetArgument(args, "CurrentPageIndex").ConvertToIntNullable();
            request.PageSize = Argument.GetArgument(args, "PageSize").ConvertToIntNullable(10000);
            request.LocationID = Argument.GetArgument(args, "LocationID").ConvertToIntNullable(1);
            request.StartDateTime = Argument.GetArgument(args, "StartDatetime").ConvertToDateTime();
            request.StaffIDs = Argument.GetArgument(args, "StaffIDs").ConvertToLongArray();
            //request.StaffCredentials = Argument.GetArgument(args, "StaffCredentials").ConvertToStaffCredentials();
            //request.Filters = Argument.GetArgument(args, "Filters").ConvertToStaffFilterArray();
            */
            var results = service.GetStaff(request);
            return new APIResult<GetStaffResult, Staff[]>(results, results.StaffMembers, domain);
        }

        public static APIResult<GetStaffPermissionsResult, Permission[]> GetStaffPermissions(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetStaffPermissionsRequest>(args, domain);

            request.CurrentPageIndex = Argument.GetArgument(args, "CurrentPageIndex").ConvertToIntNullable();
            request.PageSize = Argument.GetArgument(args, "PageSize").ConvertToIntNullable(10000);
            request.StaffID = Argument.GetArgument(args, "StaffID").ConvertToLong();

            var results = service.GetStaffPermissions(request);
            return new APIResult<GetStaffPermissionsResult, Permission[]>(results, results.Permissions, domain);
        }

        public static APIResult<AddOrUpdateStaffResult, Staff[]> AddOrUpdateStaff(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<AddOrUpdateStaffRequest>(args, domain);
            request.CurrentPageIndex = Argument.GetArgument(args, "CurrentPageIndex").ConvertToIntNullable();
            request.PageSize = Argument.GetArgument(args, "PageSize").ConvertToIntNullable(10000);
            request.UpdateAction = Argument.GetArgument(args, "UpdateAction").ConvertToString("Fail");
            request.Test = Argument.GetArgument(args, "Test").ConvertToBoolNullable();
            //request.Staff = Argument.GetArgument(args, "Staff").ConvertToStaffArray();

            var results = service.AddOrUpdateStaff(request);
            return new APIResult<AddOrUpdateStaffResult, Staff[]>(results, results.Staff, domain);
        }
    }
}
