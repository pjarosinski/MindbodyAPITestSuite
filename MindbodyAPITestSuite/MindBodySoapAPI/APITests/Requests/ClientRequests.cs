using System.Collections.Generic;
using MindbodySoapAPI.APITests.Models;
using MindbodySoapAPI.APITests.Utils;
using MindbodySoapAPI.APITests.Utils.ParsingTools;
using MindbodySoapAPI.ClientService;

namespace MindbodySoapAPI.APITests.Requests
{
    public class ClientRequests
    {
        public static ClientService.ClientService Service { get { return new ClientService.ClientService();}}

        public static APIResult<AddArrivalResult, bool[]> AddArrival(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<AddArrivalRequest>(args, domain);

            request.ClientID = Argument.GetArgument(args, "ClientID").Value;
            request.LocationID = Argument.GetArgument(args, "LocationID").ConvertToInt();

            AddArrivalResult result = service.AddArrival(request);
            return new APIResult<AddArrivalResult, bool[]>(result, new[]{result.ArrivalAdded}, domain);
        }

        public static APIResult<GetClientsResult, Client[]> GetClients(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetClientsRequest>(args, domain);

            //required
            request.ClientIDs = Argument.GetArgument(args, "ClientIDs").ConvertToStringArray();
            //optional
            request.SearchText = Argument.GetArgument(args, "SearchText").Value;

            GetClientsResult result = service.GetClients(request);
            return new APIResult<GetClientsResult, Client[]>(result, result.Clients, domain);
        }

        public static APIResult<GetCustomClientFieldsResult, CustomClientField[]> GetCustomClientFields(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetCustomClientFieldsRequest>(args, domain);

            GetCustomClientFieldsResult result = service.GetCustomClientFields(request);
            return new APIResult<GetCustomClientFieldsResult, CustomClientField[]>(result, result.CustomClientFields, domain);
        }

        public static APIResult<GetClientIndexesResult, ClientIndex[]> GetClientIndexes(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetClientIndexesRequest>(args, domain);

            GetClientIndexesResult result = service.GetClientIndexes(request);
            return new APIResult<GetClientIndexesResult, ClientIndex[]>(result, result.ClientIndexes, domain);
        }

        public static APIResult<GetClientContactLogsResult, ContactLog[]> GetClientContactLogs(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetClientContactLogsRequest>(args, domain);

            //Required
            request.ClientID = Argument.GetArgument(args, "ClientID").Value;
            request.StartDate = Argument.GetArgument(args, "StartDate").ConvertToDateTime();
            request.EndDate = Argument.GetArgument(args, "EndDate").ConvertToDateTime();
            //Optional
            request.StaffIDs = Argument.GetArgument(args, "StaffIDs").ConvertToLongArray();
            request.ShowSystemGenerated = Argument.GetArgument(args, "ShowSystemGenerated").ConvertToBoolNullable();
            request.TypeIDs = Argument.GetArgument(args, "TypeIDs").ConvertToIntArray();
            request.SubtypeIDs = Argument.GetArgument(args, "SubtypeIDs").ConvertToIntArray();

            GetClientContactLogsResult result = service.GetClientContactLogs(request);
            return new APIResult<GetClientContactLogsResult, ContactLog[]>(result, result.ContactLogs, domain);
        }

        public static APIResult<AddOrUpdateContactLogsResult, ContactLog[]> AddOrUpdateContactLogs(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<AddOrUpdateContactLogsRequest>(args, domain);

            //request.ContactLogs = Argument.GetArgument(args, "ContactLogs").ConvertToContactLogArray();
            request.UpdateAction = Argument.GetArgument(args, "UpdateAction").Value;

            AddOrUpdateContactLogsResult result = service.AddOrUpdateContactLogs(request);
            return new APIResult<AddOrUpdateContactLogsResult, ContactLog[]>(result, result.ContactLogs, domain);
        }

        public static APIResult<GetContactLogTypesResult, ContactLogType[]> GetContactLogTypes(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetContactLogTypesRequest>(args, domain);

            GetContactLogTypesResult result1 = service.GetContactLogTypes(request);
            return new APIResult<GetContactLogTypesResult, ContactLogType[]>(result1, result1.ContatctLogTypes, domain);
        }

        public static APIResult<UploadClientDocumentResult, string[]> UploadClientDocument(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<UploadClientDocumentRequest>(args, domain);

            /* You would think that FileName would represent the full path, but....no.
             * string basedir = AppDomain.CurrentDomain.BaseDirectory;
            int startIndex = basedir.IndexOf("Web.Tests");
            string fullPath = basedir.Substring(0, startIndex);
            fullPath += "Web.Tests\\Automation\\APITests\\AvailableMethods\\";*/

            request.ClientID = Argument.GetArgument(args, "ClientID").Value;
            //request.FileName = fullPath + Argument.GetArgument(args, "FileName").Value;
            request.FileName = Argument.GetArgument(args, "FileName").Value;
            request.Bytes = Argument.GetArgument(args, "Bytes").ConvertToByteArray();

            UploadClientDocumentResult result = service.UploadClientDocument(request);
            return new APIResult<UploadClientDocumentResult, string[]>(result, new []{result.FileName}, domain);
        }

        public static APIResult<GetClientReferralTypesResult, string[]> GetClientReferralTypes(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetClientReferralTypesRequest>(args, domain);

            GetClientReferralTypesResult result = service.GetClientReferralTypes(request);
            return new APIResult<GetClientReferralTypesResult, string[]>(result, result.ReferralTypes, domain);
        }

        public static APIResult<GetActiveClientMembershipsResult, ClientMembership[]> GetActiveClientMemberships(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetActiveClientMembershipsRequest>(args, domain);


            request.ClientID = Argument.GetArgument(args, "ClientID").Value;
            request.LocationID = Argument.GetArgument(args, "LocationID").ConvertToIntNullable();

            GetActiveClientMembershipsResult result = service.GetActiveClientMemberships(request);
            return new APIResult<GetActiveClientMembershipsResult, ClientMembership[]>(result, result.ClientMemberships, domain);
        }

        public static APIResult<GetClientContractsResult, ClientContract[]> GetClientContracts(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetClientContractsRequest>(args, domain);

            //optional
            request.ClientID = Argument.GetArgument(args, "ClientID").Value;
            //required
            request.LocationID = Argument.GetArgument(args, "LocationID").ConvertToIntNullable();

            GetClientContractsResult result = service.GetClientContracts(request);
            return new APIResult<GetClientContractsResult, ClientContract[]>(result, result.Contracts, domain);
        }

        public static APIResult<GetClientAccountBalancesResult, Client[]> GetClientAccountBalances(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetClientAccountBalancesRequest>(args, domain);
            //required
            request.ClientIDs = Argument.GetArgument(args, "ClientIDs").ConvertToStringArray();
            //optional
            request.BalanceDate = Argument.GetArgument(args, "BalanceDate").ConvertToDateTime();
            request.ClassID = Argument.GetArgument(args, "ClassID").ConvertToLongNullable();

            GetClientAccountBalancesResult result = service.GetClientAccountBalances(request);
            return new APIResult<GetClientAccountBalancesResult, Client[]>(result, result.Clients, domain);
        }

        public static APIResult<GetClientServicesResult, ClientService1[]> GetClientServices(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetClientServicesRequest>(args, domain);

            //required (ProgramID or SessionTypeID or both needed)
            request.ClientID = Argument.GetArgument(args, "ClientID").Value;
            request.ProgramIDs = Argument.GetArgument(args, "ProgramIDs").ConvertToIntArray();
            request.SessionTypeIDs = Argument.GetArgument(args, "SessionTypeIDs").ConvertToIntArray();
            //optional
            request.LocationIDs = Argument.GetArgument(args, "LocationIDs").ConvertToIntArray();
            request.VisitCount = Argument.GetArgument(args, "VisitCount").ConvertToIntNullable();
            request.StartDate = Argument.GetArgument(args, "StartDate").ConvertToDateTime();
            request.EndDate = Argument.GetArgument(args, "EndDate").ConvertToDateTime();
            request.ShowActiveOnly = Argument.GetArgument(args, "ShowActiveOnly").ConvertToBoolNullable();

            GetClientServicesResult result = service.GetClientServices(request);
            return new APIResult<GetClientServicesResult, ClientService1[]>(result, result.ClientServices, domain);
        }

        public static APIResult<GetClientVisitsResult, Visit[]> GetClientVisits(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetClientVisitsRequest>(args, domain);

            request.ClientID = Argument.GetArgument(args, "ClientID").Value;
            request.StartDate = Argument.GetArgument(args, "StartDate").ConvertToDateTime();
            request.EndDate = Argument.GetArgument(args, "EndDate").ConvertToDateTime();

            GetClientVisitsResult result = service.GetClientVisits(request);
            return new APIResult<GetClientVisitsResult, Visit[]>(result, result.Visits, domain);
        }

        public static APIResult<GetClientPurchasesResult, SaleItem[]> GetClientPurchases(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetClientPurchasesRequest>(args, domain);

            request.ClientID = Argument.GetArgument(args, "ClientID").Value;
            request.StartDate = Argument.GetArgument(args, "StartDate").ConvertToDateTime();
            request.EndDate = Argument.GetArgument(args, "EndDate").ConvertToDateTime();

            GetClientPurchasesResult result = service.GetClientPurchases(request);
            return new APIResult<GetClientPurchasesResult, SaleItem[]>(result, result.Purchases, domain);
        }

        public static APIResult<GetClientScheduleResult, Visit[]> GetClientSchedule(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetClientScheduleRequest>(args, domain);

            request.ClientID = Argument.GetArgument(args, "ClientID").Value;
            request.StartDate = Argument.GetArgument(args, "StartDate").ConvertToDateTime();
            request.EndDate = Argument.GetArgument(args, "EndDate").ConvertToDateTime();

            GetClientScheduleResult result = service.GetClientSchedule(request);
            return new APIResult<GetClientScheduleResult, Visit[]>(result, result.Visits, domain);
        }

        public static APIResult<GetRequiredClientFieldsResult, string[]> GetRequiredClientFields(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetRequiredClientFieldsRequest>(args, domain);

            GetRequiredClientFieldsResult result = service.GetRequiredClientFields(request);
            return new APIResult<GetRequiredClientFieldsResult, string[]>(result, result.RequiredClientFields, domain);
        }

        public static APIResult<ValidateLoginResult, StatusCode[]> ValidateLogin(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<ValidateLoginRequest>(args, domain);

            request.Username = Argument.GetArgument(args, "Username").Value;
            request.Password = Argument.GetArgument(args, "Password").Value;

            ValidateLoginResult result = service.ValidateLogin(request);
            return new APIResult<ValidateLoginResult, StatusCode[]>(result, new[] { result.Status }, domain);
        }
    }
}
