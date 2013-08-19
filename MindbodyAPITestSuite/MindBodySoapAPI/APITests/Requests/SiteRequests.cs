using System.Collections.Generic;
using MindbodySoapAPI.APITests.Models;
using MindbodySoapAPI.APITests.Utils;
using MindbodySoapAPI.APITests.Utils.ParsingTools;
using MindbodySoapAPI.SiteService;

namespace MindbodySoapAPI.APITests.Requests
{
    public class SiteRequests
    {
        public static SiteService.SiteService Service { get { return new SiteService.SiteService();}}

        public static APIResult<GetSitesResult, Site[]> GetSites(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetSitesRequest>(args, domain);

            request.SearchText = Argument.GetArgument(args, "SearchText").Value;
            request.RelatedSiteID = Argument.GetArgument(args, "RelatedSiteID").ConvertToIntNullable();
            request.CurrentPageIndex = Argument.GetArgument(args, "CurrentPageIndex").ConvertToIntNullable();
            request.PageSize = Argument.GetArgument(args, "PageSize").ConvertToIntNullable(10);

            GetSitesResult results = service.GetSites(request);
            return new APIResult<GetSitesResult, Site[]>(results, results.Sites, domain);
        }

        public static APIResult<GetLocationsResult, Location[]> GetLocations(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetLocationsRequest>(args, domain);
   
            GetLocationsResult results = service.GetLocations(request);
            return new APIResult<GetLocationsResult, Location[]>(results, results.Locations, domain);
        }

        public static APIResult<GetActivationCodeResult, string[]> GetActiviationCode(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetActivationCodeRequest>(args, domain);

            GetActivationCodeResult results = service.GetActivationCode(request);
            return new APIResult<GetActivationCodeResult, string[]>(results, new []{results.ActivationCode}, domain);
        }

        public static APIResult<GetProgramsResult, Program[]> GetPrograms(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetProgramsRequest>(args, domain);

            //request.ScheduleType = Argument.GetArgument(args, "ScheduleType").ConvertToSiteScheduleType();
            request.OnlineOnly = Argument.GetArgument(args, "OnlineOnly").ConvertToBool();

            GetProgramsResult results = service.GetPrograms(request);
            return new APIResult<GetProgramsResult, Program[]>(results, results.Programs, domain);
        }

        public static APIResult<GetSessionTypesResult, SessionType[]> GetSessionTypes(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetSessionTypesRequest>(args, domain);

            request.ProgramIDs = Argument.GetArgument(args, "ProgramIDs").ConvertToIntArray();
            request.OnlineOnly = Argument.GetArgument(args, "OnlineOnly").ConvertToBool();

            GetSessionTypesResult results = service.GetSessionTypes(request);
            return new APIResult<GetSessionTypesResult, SessionType[]>(results, results.SessionTypes, domain);
        }

        public static APIResult<GetResourcesResult, Resource[]> GetResources(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetResourcesRequest>(args, domain);

            request.SessionTypeIDs = Argument.GetArgument(args, "SessionTypeIDs").ConvertToIntArray();
            request.LocationID = Argument.GetArgument(args, "LocationID").ConvertToInt(1);
            request.StartDateTime = Argument.GetArgument(args, "StartDateTime").ConvertToDateTime();
            request.EndDateTime = Argument.GetArgument(args, "EndDateTime").ConvertToDateTime();

            GetResourcesResult results = service.GetResources(request);
            return new APIResult<GetResourcesResult, Resource[]>(results, results.Resources, domain);
        }

        public static APIResult<GetRelationshipsResult, Relationship[]> GetRelationships(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetRelationshipsRequest>(args, domain);

            GetRelationshipsResult results = service.GetRelationships(request);
            return new APIResult<GetRelationshipsResult, Relationship[]>(results, results.Relationships, domain);
        }
    }
}
