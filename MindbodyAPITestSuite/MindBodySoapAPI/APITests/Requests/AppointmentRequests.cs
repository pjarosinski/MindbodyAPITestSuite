using System;
using System.Collections.Generic;
using MindbodySoapAPI.APITests.Models;
using MindbodySoapAPI.APITests.Utils;
using MindbodySoapAPI.APITests.Utils.ParsingTools;
using MindbodySoapAPI.AppointmentService;

namespace MindbodySoapAPI.APITests.Requests
{
    public class AppointmentRequests 
    {
        public static AppointmentService.AppointmentService Service { get { return new AppointmentService.AppointmentService();}}

        public static APIResult<GetStaffAppointmentsResult, Appointment[]> GetStaffAppointments(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetStaffAppointmentsRequest>(args, domain, true);

            request.PageSize = Argument.GetArgument(args, "PageSize").ConvertToIntNullable(10);
            request.CurrentPageIndex = Argument.GetArgument(args, "CurrentPageIndex").ConvertToIntNullable();
            request.AppointmentIDs = Argument.GetArgument(args, "AppointmentIDs").ConvertToIntArray();
            request.ClientIDs = Argument.GetArgument(args, "ClientIDs").ConvertToStringArray();
            request.LocationIDs = Argument.GetArgument(args, "LocationIDs").ConvertToIntArray();
            request.StaffIDs = Argument.GetArgument(args, "StaffIDs").ConvertToLongArray();
            request.StartDate = Argument.GetArgument(args, "StartDate").ConvertToDateTime();
            request.EndDate = Argument.GetArgument(args, "EndDate").ConvertToDateTime();

            var results = service.GetStaffAppointments(request);
            return new APIResult<GetStaffAppointmentsResult, Appointment[]>(results, results.Appointments, domain);
        }

        public static APIResult<AddOrUpdateAppointmentsResult, Appointment[]> AddOrUpdateAppointments(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<AddOrUpdateAppointmentsRequest>(args, domain);

            request.UpdateAction = Argument.GetArgument(args, "UpdateAction").Value;
            request.Appointments = Argument.GetArgument(args, "Appointments").ConvertToAppointmentArray();

            var result = service.AddOrUpdateAppointments(request);
            return new APIResult<AddOrUpdateAppointmentsResult, Appointment[]>(result, result.Appointments, domain);
        }

        public static APIResult<GetBookableItemsResult, ScheduleItem[]> GetBookableItems(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetBookableItemsRequest>(args, domain);

            request.SessionTypeIDs = Argument.GetArgument(args, "SessionTypeIDs").ConvertToIntArray();
            request.LocationIDs = Argument.GetArgument(args, "LocationIDs").ConvertToIntArray();
            request.StaffIDs = Argument.GetArgument(args, "StaffIDs").ConvertToLongArray();
            request.StartDate = Argument.GetArgument(args, "StartDate").ConvertToDateTime();
            request.EndDate = Argument.GetArgument(args, "EndDate").ConvertToDateTime();
            request.PageSize = Argument.GetArgument(args, "PageSize").ConvertToIntNullable();
            request.CurrentPageIndex = Argument.GetArgument(args, "CurrentPageIndex").ConvertToIntNullable();

            var result = service.GetBookableItems(request);
            return new APIResult<GetBookableItemsResult, ScheduleItem[]>(result, result.ScheduleItems, domain);
        }

        public static APIResult<GetScheduleItemsResult, Staff[]> GetScheduleItems(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetScheduleItemsRequest>(args, domain);

            request.IgnorePrepFinishTimes = Argument.GetArgument(args, "IgnorePrepFinishTimes").ConvertToBool(true);
            request.LocationIDs = Argument.GetArgument(args, "LocationIDs").ConvertToIntArray();
            request.StaffIDs = Argument.GetArgument(args, "StaffIDs").ConvertToLongArray();
            request.StartDate = Argument.GetArgument(args, "StartDate").ConvertToDateTime();
            request.EndDate = Argument.GetArgument(args, "EndDate").ConvertToDateTime();
            request.PageSize = Argument.GetArgument(args, "PageSize").ConvertToIntNullable();
            request.CurrentPageIndex = Argument.GetArgument(args, "CurrentPageIndex").ConvertToIntNullable();

            var results = service.GetScheduleItems(request);
            return new APIResult<GetScheduleItemsResult, Staff[]>(results, results.StaffMembers, domain);
        }

        public static APIResult<AddOrUpdateAvailabilitiesResult, Unavailability[]> AddOrUpdateAvailabilities(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<AddOrUpdateAvailabilitiesRequest>(args, domain);

            request.AvailabilityIDs = Argument.GetArgument(args, "AvailabilityIDs").ConvertToIntArray();
            request.LocationID = Argument.GetArgument(args, "LocationID").ConvertToIntNullable();
            request.ProgramIDs = Argument.GetArgument(args, "ProgramIDs").ConvertToIntArray();
            request.StaffIDs = Argument.GetArgument(args, "StaffIDs").ConvertToLongArray();
            request.StartDateTime = Argument.GetArgument(args, "StartDate").ConvertToDateTime();
            request.EndDateTime = Argument.GetArgument(args, "EndDate").ConvertToDateTime();
            //request.DaysOfWeek = Argument.GetArgument(args, "DaysOfWeek").ConvertToDayOfWeekArray();
            request.UnavailableDescription = Argument.GetArgument(args, "UnavailableDescription").Value;
            request.IsUnavailable = Argument.GetArgument(args, "IsUnavailable").ConvertToBool();
            request.UpdateAction = Argument.GetArgument(args, "UpdateAction").Value;
            // request.PublicDisplay = Argument.GetArgument(args, "PublicDisplay").ConvertToAvailabilityDisplay();

            var results = service.AddOrUpdateAvailabilities(request);
            var appts = new List<Unavailability>();
            foreach (var currStaff in results.StaffMembers)
            {
                appts.AddRange(currStaff.Unavailabilities);
            }
            return new APIResult<AddOrUpdateAvailabilitiesResult, Unavailability[]>(results, appts.ToArray(), domain);
        }

        public static APIResult<GetActiveSessionTimesResult, DateTime[]> GetActiveSessionTimes(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetActiveSessionTimesRequest>(args, domain);

            if ((request.SessionTypeIDs = Argument.GetArgument(args, "SessionTypeIDs").ConvertToIntArray()) == null)
            {
                //request.ScheduleType = Argument.GetArgument(args, "ScheduleType").ConvertToAppointmentScheduleType();
            }
            request.StartTime = Argument.GetArgument(args, "StartTime").ConvertToDateTime();
            request.EndTime = Argument.GetArgument(args, "EndTime").ConvertToDateTime();
            request.PageSize = Argument.GetArgument(args, "PageSize").ConvertToIntNullable();
            request.CurrentPageIndex = Argument.GetArgument(args, "CurrentPageIndex").ConvertToIntNullable();

            var results = service.GetActiveSessionTimes(request);
            return new APIResult<GetActiveSessionTimesResult, DateTime[]>(results, results.Times, domain);
        }

        public static APIResult<GetAppointmentOptionsResult, Option[]> GetAppointmentOptions(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetAppointmentOptionsRequest>(args, domain);

            request.PageSize = Argument.GetArgument(args, "PageSize").ConvertToIntNullable(10);
            request.CurrentPageIndex = Argument.GetArgument(args, "CurrentPageIndex").ConvertToIntNullable();

            var results = service.GetAppointmentOptions(request);
            return new APIResult<GetAppointmentOptionsResult, Option[]>(results, results.Options, domain);
        }

    }
}
