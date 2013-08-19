using System;
using System.Collections.Generic;
using MindbodySoapAPI.APITests.Models;
using MindbodySoapAPI.APITests.Utils;
using MindbodySoapAPI.APITests.Utils.ParsingTools;
using MindbodySoapAPI.DataService;

namespace MindbodySoapAPI.APITests.Requests
{
    public class DataRequests
    {
        public static DataService.DataService Service { get { return new DataService.DataService();} }

        public static APIResult<SelectDataXmlResult, object[]> SelectDataXmlRequest(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<SelectDataXmlRequest>(args, domain);

            request.CurrentPageIndex = Argument.GetArgument(args, "CurrentPageIndex").ConvertToIntNullable();
            request.PageSize = Argument.GetArgument(args, "PageSize").ConvertToIntNullable(10);
            request.SelectSql = Argument.GetArgument(args, "SQLString").Value;

            var results = service.SelectDataXml(request);
            return new APIResult<SelectDataXmlResult, object[]>(results,  results.Results, domain);
        }

        public static APIResult<SelectDataCSVResult, string[]> SelectDataCsvRequest(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<SelectDataCSVRequest>(args, domain);
            request.CurrentPageIndex = Argument.GetArgument(args, "CurrentPageIndex").ConvertToIntNullable();
            request.PageSize = Argument.GetArgument(args, "PageSize").ConvertToIntNullable(10);
            request.SelectSql = Argument.GetArgument(args, "SQLString").Value;

            SelectDataCSVResult results = service.SelectDataCSV(request);
            return new APIResult<SelectDataCSVResult, string[]>(results, TrySplit(results.CSV), domain);
        }

        public static APIResult<SelectAggregateDataXmlResult, Row[]> SelectAggregateDataXmlRequest(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<SelectAggregateDataXmlRequest>(args, domain);

            request.CurrentPageIndex = Argument.GetArgument(args, "CurrentPageIndex").ConvertToIntNullable();
            request.PageSize = Argument.GetArgument(args, "PageSize").ConvertToIntNullable(10);
            request.SelectSql = Argument.GetArgument(args, "SQLString").Value;

            SelectAggregateDataXmlResult results = service.SelectAggregateDataXml(request);
            return new APIResult<SelectAggregateDataXmlResult, Row[]>(results, results.Results, domain);
        }

        public static APIResult<SelectAggregateDataCSVResult, string[]> SelectAggregateDataCsvRequest(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<SelectAggregateDataCSVRequest>(args, domain);

            request.CurrentPageIndex = Argument.GetArgument(args, "CurrentPageIndex").ConvertToIntNullable();
            request.PageSize = Argument.GetArgument(args, "PageSize").ConvertToIntNullable(10);
            request.SelectSql = Argument.GetArgument(args, "SQLString").Value;

            var results = service.SelectAggregateDataCSV(request);
            return new APIResult<SelectAggregateDataCSVResult, string[]>(results, TrySplit(results.CSV), domain );
        }

        public static string[] TrySplit(string csv)
        {
            return String.IsNullOrEmpty(csv) ? null : csv.Split(',');
        }
    }
}
