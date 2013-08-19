using System.Collections.Generic;
using MindbodySoapAPI.APITests.Models;
using MindbodySoapAPI.APITests.Utils;
using MindbodySoapAPI.APITests.Utils.ParsingTools;
using MindbodySoapAPI.ClassService;

namespace MindbodySoapAPI.APITests.Requests
{
    public class ClassRequests
    {
        public static ClassService.ClassService Service { get { return new ClassService.ClassService(); } }

        public static APIResult<GetClassesResult, Class[]> GetClasses(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetClassesRequest>(args, domain);

            request.ClassDescriptionIDs = Argument.GetArgument(args, "ClassDescriptionIDs").ConvertToIntArray();
            request.ClassIDs = Argument.GetArgument(args, "ClassIDs").ConvertToIntArray();
            request.StaffIDs = Argument.GetArgument(args, "StaffIDs").ConvertToLongArray();
            request.StartDateTime = Argument.GetArgument(args, "StartDateTime").ConvertToDateTime();
            request.EndDateTime = Argument.GetArgument(args, "EndDateTime").ConvertToDateTime();
            request.ClientID = Argument.GetArgument(args, "ClientID").Value;
            request.ProgramIDs = Argument.GetArgument(args, "ProgramIDs").ConvertToIntArray();
            request.SessionTypeIDs = Argument.GetArgument(args, "SessionTypeIDs").ConvertToIntArray();
            request.LocationIDs = Argument.GetArgument(args, "LocationIDs").ConvertToIntArray();
            request.SemesterIDs = Argument.GetArgument(args, "SemesterIDs").ConvertToIntArray();
            request.HideCanceledClasses = Argument.GetArgument(args, "HideCanceledClasses").ConvertToBoolNullable();
            request.SchedulingWindow = Argument.GetArgument(args, "SchedulingWindow").ConvertToBoolNullable();

            var results = service.GetClasses(request);
            return new APIResult<GetClassesResult, Class[]>(results, results.Classes, domain);
        }

        public static APIResult<UpdateClientVisitsResult, Visit[]> UpdateClientVisits(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<UpdateClientVisitsRequest>(args, domain);

            request.Visits = Argument.GetArgument(args, "Visit").ConvertToVisitsArray<Visit>();
            request.Test = Argument.GetArgument(args, "Test").ConvertToBoolNullable();
            request.SendEmail = Argument.GetArgument(args, "SendEmail").ConvertToBoolNullable();

            var results = service.UpdateClientVisits(request);
            return new APIResult<UpdateClientVisitsResult, Visit[]>(results, results.Visits, domain);
        }

        public static APIResult<GetClassVisitsResult, Visit[]> GetClassVisits(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetClassVisitsRequest>(args, domain);

            request.ClassID = Argument.GetArgument(args, "ClassID").ConvertToInt();

            GetClassVisitsResult results = service.GetClassVisits(request);
            return new APIResult<GetClassVisitsResult, Visit[]>(results, results.Class.Visits, domain);
        }

        public static APIResult<GetClassDescriptionsResult, ClassDescription[]> GetClassDescriptions(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetClassDescriptionsRequest>(args, domain);

            request.ClassDescriptionIDs = Argument.GetArgument(args, "ClassDescriptionIDs").ConvertToIntArray();
            request.ProgramIDs = Argument.GetArgument(args, "ProgramIDs").ConvertToIntArray();
            request.StaffIDs = Argument.GetArgument(args, "StaffIDs").ConvertToLongArray();
            request.StartClassDateTime = Argument.GetArgument(args, "StartClassDateTime").ConvertToDateTime();
            request.EndClassDateTime = Argument.GetArgument(args, "EndClassDateTime").ConvertToDateTime();

            var results = service.GetClassDescriptions(request);
            return new APIResult<GetClassDescriptionsResult, ClassDescription[]>(results, results.ClassDescriptions, domain);
        }

        public static APIResult<GetEnrollmentsResult, ClassSchedule[]> GetEnrollments(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetEnrollmentsRequest>(args, domain);

            request.LocationIDs = Argument.GetArgument(args, "LocationIDs").ConvertToIntArray();
            request.ClassScheduleIDs = Argument.GetArgument(args, "ClassScheduleIDs").ConvertToIntArray();
            request.StaffIDs = Argument.GetArgument(args, "StaffIDs").ConvertToLongArray();
            request.ProgramIDs = Argument.GetArgument(args, "ProgramIDs").ConvertToIntArray();
            request.SessionTypeIDs = Argument.GetArgument(args, "SessionTypeIDs").ConvertToIntArray();
            request.SemesterIDs = Argument.GetArgument(args, "SemesterIDs").ConvertToIntArray();
            request.CourseIDs = Argument.GetArgument(args, "CourseIDs").ConvertToLongArray();
            request.StartDate = Argument.GetArgument(args, "StartDate").ConvertToDateTime();
            request.EndDate = Argument.GetArgument(args, "EndDate").ConvertToDateTime();

            GetEnrollmentsResult results = service.GetEnrollments(request);
            return new APIResult<GetEnrollmentsResult, ClassSchedule[]>(results, results.Enrollments, domain);

        }

        public static APIResult<GetClassSchedulesResult, ClassSchedule[]> GetClassSchedules(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetClassSchedulesRequest>(args, domain);

            request.LocationIDs = Argument.GetArgument(args, "LocationIDs").ConvertToIntArray();
            request.ClassScheduleIDs = Argument.GetArgument(args, "ClassScheduleIDs").ConvertToIntArray();
            request.StaffIDs = Argument.GetArgument(args, "StaffIDs").ConvertToLongArray();
            request.ProgramIDs = Argument.GetArgument(args, "ProgramIDs").ConvertToIntArray();
            request.SessionTypeIDs = Argument.GetArgument(args, "SessionTypeIDs").ConvertToIntArray();
            request.StartDate = Argument.GetArgument(args, "StartDate").ConvertToDateTime();
            request.EndDate = Argument.GetArgument(args, "EndDate").ConvertToDateTime();

            GetClassSchedulesResult results = service.GetClassSchedules(request);
            return new APIResult<GetClassSchedulesResult, ClassSchedule[]>(results, results.ClassSchedules, domain);
        }


        public static APIResult<RemoveClientsFromClassesResult, Class[]> RemoveClientsFromClasses(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<RemoveClientsFromClassesRequest>(args, domain);

            request.ClassIDs = Argument.GetArgument(args, "ClassIDs").ConvertToIntArray();
            request.ClientIDs = Argument.GetArgument(args, "ClientIDs").ConvertToStringArray();
            request.Test = Argument.GetArgument(args, "Test").ConvertToBoolNullable();
            request.SendEmail = Argument.GetArgument(args, "SendEmail").ConvertToBoolNullable();
            request.LateCancel = Argument.GetArgument(args, "LateCancel").ConvertToBoolNullable();

            RemoveClientsFromClassesResult results = service.RemoveClientsFromClasses(request);
            return new APIResult<RemoveClientsFromClassesResult, Class[]>(results, results.Classes, domain);
        }

        public static APIResult<AddClientsToEnrollmentsResult, ClassSchedule[]> AddClientsToEnrollments(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<AddClientsToEnrollmentsRequest>(args, domain);

            request.ClientIDs = Argument.GetArgument(args, "ClientIDs").ConvertToStringArray();
            request.ClassScheduleIDs = Argument.GetArgument(args, "ClassScheduleIDs").ConvertToIntArray();
            request.CourseIDs = Argument.GetArgument(args, "CourseIDs").ConvertToIntArray();
            request.EnrollDateForward = Argument.GetArgument(args, "EnrollDateForward").ConvertToDateTime();
            request.EnrollOpen = Argument.GetArgument(args, "EnrollOpen").ConvertToDateTimeArray();
            request.Test = Argument.GetArgument(args, "Test").ConvertToBoolNullable();
            request.Waitlist = Argument.GetArgument(args, "Waitlist").ConvertToBoolNullable();

            AddClientsToEnrollmentsResult results = service.AddClientsToEnrollments(request);
            return new APIResult<AddClientsToEnrollmentsResult, ClassSchedule[]>(results, results.Enrollments, domain);
        }

        public static APIResult<AddClientsToClassesResult, Class[]> AddClientsToClasses(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<AddClientsToClassesRequest>(args, domain);

            request.ClientIDs = Argument.GetArgument(args, "ClientIDs").ConvertToStringArray();
            request.ClassIDs = Argument.GetArgument(args, "ClassIDs").ConvertToIntArray();
            request.Test = Argument.GetArgument(args, "Test").ConvertToBoolNullable();
            request.RequirePayment = Argument.GetArgument(args, "RequirePayment").ConvertToBoolNullable();
            request.Waitlist = Argument.GetArgument(args, "Waitlist").ConvertToBoolNullable();

            AddClientsToClassesResult results = service.AddClientsToClasses(request);
            return new APIResult<AddClientsToClassesResult, Class[]>(results, results.Classes, domain);
        }

        public static APIResult<RemoveFromWaitlistResult, StatusCode[]> RemoveFromWaitlist(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<RemoveFromWaitlistRequest>(args, domain);

            request.WaitlistEntryIDs = Argument.GetArgument(args, "WaitlistEntryIDs").ConvertToIntArray();

            RemoveFromWaitlistResult results = service.RemoveFromWaitlist(request);
            return new APIResult<RemoveFromWaitlistResult, StatusCode[]>(results, new []{results.Status}, domain);
        }

        public static APIResult<GetSemestersResult, Semester[]> GetSemesters(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetSemestersRequest>(args, domain);

            request.SemesterIDs = Argument.GetArgument(args, "SemesterIDs").ConvertToIntArray();
            request.StartDate = Argument.GetArgument(args, "StartDate").ConvertToDateTime();
            request.EndDate = Argument.GetArgument(args, "EndDate").ConvertToDateTime();

            GetSemestersResult results = service.GetSemesters(request);
            return new APIResult<GetSemestersResult, Semester[]>(results, results.Semesters, domain);
        }

        public static APIResult<GetCoursesResult, Course[]> GetCourses(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetCoursesRequest>(args, domain);

            request.LocationIDs = Argument.GetArgument(args, "LocationIDs").ConvertToIntArray();
            request.CourseIDs = Argument.GetArgument(args, "CourseIDs").ConvertToLongArray();
            request.StaffIDs = Argument.GetArgument(args, "StaffIDs").ConvertToLongArray();
            request.ProgramIDs = Argument.GetArgument(args, "ProgramIDs").ConvertToIntArray();
            request.StartDate = Argument.GetArgument(args, "StartDate").ConvertToDateTime();
            request.EndDate = Argument.GetArgument(args, "EndDate").ConvertToDateTime();
            request.SemesterIDs = Argument.GetArgument(args, "SemesterIDs").ConvertToIntArray();

            GetCoursesResult results = service.GetCourses(request);
            return new APIResult<GetCoursesResult, Course[]>(results, results.Courses, domain);
        }

        public static APIResult<GetWaitlistEntriesResult, WaitlistEntry[]> GetWaitlistEntries(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetWaitlistEntriesRequest>(args, domain);

            request.ClassScheduleIDs = Argument.GetArgument(args, "ClassScheduleIDs").ConvertToIntArray();
            request.ClientIDs = Argument.GetArgument(args, "ClientIDs").ConvertToStringArray();
            request.WaitlistEntryIDs = Argument.GetArgument(args, "WaitlistEntryIDs").ConvertToIntArray();

            GetWaitlistEntriesResult results = service.GetWaitlistEntries(request);
            return new APIResult<GetWaitlistEntriesResult, WaitlistEntry[]>(results, results.WaitlistEntries, domain);
        }


    }
}
